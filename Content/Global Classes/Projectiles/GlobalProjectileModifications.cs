using System;
using System.Reflection;
using CombinationsMod.Content.Global_Classes.Projectiles;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.Explosions;
using CombinationsMod.Content.Projectiles.Misc;
using CombinationsMod.Content.Projectiles.TrickYoyos;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YoyoStringLib;

namespace CombinationsMod.GlobalClasses.Projectiles
{
    public class GlobalProjectileModifications : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        private int slimeThornCounter = 0;
        private int lifestealCooldown = 0;

        bool cascadeGreekFire = false;
        bool yoyoOrnament = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            lifestealCooldown += Main.rand.Next(10);

            if (!projectile.TryGetOwner(out _))
                return;

            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.IsYoyo() && projectile.owner == Main.myPlayer)
            {
                if (modPlayer.trick2)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                        Vector2.Zero, ModContent.ProjectileType<World2>(), (int)(projectile.damage * 0.5f), 0, Main.myPlayer, 0, projectile.whoAmI);
                    }
                }
                else if (modPlayer.trick1)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                    Vector2.Zero, ModContent.ProjectileType<World1>(), (int)(projectile.damage * 0.3f), 0, Main.myPlayer, 0, projectile.whoAmI);
                }
            }

            if (projectile.type == ProjectileID.SantaBombs && source.Context == "ChristmasBulb")
            {
                yoyoOrnament = true;
            }

            if (projectile.type == ProjectileID.GreekFire1 || projectile.type == ProjectileID.GreekFire2 || projectile.type == ProjectileID.GreekFire3)
            {
                if(source is not null && source.Context == "Cascade")
                {
                    cascadeGreekFire = true;
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.golemString && projectile.IsCounterweight())
            {
                modifiers.FinalDamage *= 2f;
                modifiers.Knockback *= 2f;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            if (projectile.IsYoyo())
            {
                Player player = projectile.GetOwner();
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

                projectile.GetGlobalProjectile<YoyoDataHouse>().Hits++;
   
                if (projectile.YoyoData().MainYoyo)
                {
                    modPlayer.HitCounter++;

                    if (modPlayer.eclipseString && Main.rand.NextBool(4))
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi);

                        Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                               Main.rand.NextBool() ? ModContent.ProjectileType<EclipseSwirl>() : ModContent.ProjectileType<EclipseSwirlOrange>(), 0, 0, projectile.owner, 0, 1f);

                        Projectile projHitbox = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                ModContent.ProjectileType<SolidHitbox>(), 75, 4f, projectile.owner, 0, 1f);

                        projHitbox.Resize(100, 100);
                    }
                }

                if (!target.immortal && !target.dontTakeDamage && target.lifeMax > 10 && lifestealCooldown >= 15 + (projectile.MaxUpdates * 10) + (projectile.usesLocalNPCImmunity ? projectile.localNPCHitCooldown * 0.7f : 0) && modPlayer.lifestealTrick)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero,
                        ProjectileID.VampireHeal, 0, 0, projectile.owner, projectile.owner, Math.Clamp(projectile.damage / 20f, 1f, 3f) + Main.rand.Next(3));

                    lifestealCooldown = 0;
                }
            }
            else if (projectile.IsCounterweight())
            {
                Player player = projectile.GetOwner();
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();


                if (modPlayer.golemString && Main.myPlayer == projectile.owner)
                {
                    Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ModContent.ProjectileType<EclipseExplosion>(), 84, 0, projectile.owner);
                }

                if (modPlayer.frostbiteString)
                    target.AddBuff(BuffID.Frostburn2, 300);
            }

            if (projectile.type == ProjectileID.Stinger)
            {
                if (Main.rand.NextBool(2))
                    target.AddBuff(BuffID.Poisoned, 240);
            }
            else if ((projectile.type == ProjectileID.GreekFire1 || projectile.type == ProjectileID.GreekFire2 || projectile.type == ProjectileID.GreekFire3) && cascadeGreekFire)
            {
                target.AddBuff(BuffID.OnFire, 180);
            }
        }
        public override void AI(Projectile projectile)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            if (projectile.IsYoyo())
            {
                Player player = projectile.GetOwner();
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

                if (lifestealCooldown < 15 + (projectile.MaxUpdates * 10) + (projectile.usesLocalNPCImmunity ? projectile.localNPCHitCooldown * 0.7f : 0))
                    lifestealCooldown++;

                if (modPlayer.slimeString)
                {
                    slimeThornCounter++;
                    if (slimeThornCounter == 60)
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 3f;
                        if (Main.myPlayer == projectile.owner)
                        {
                            Projectile projSlimeSpike = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, velocity,
                            ProjectileID.SpikedSlimeSpike, projectile.damage / 2, 3f, projectile.owner, 0, 1f);
                            projSlimeSpike.friendly = true;
                            projSlimeSpike.hostile = false;
                        }

                        slimeThornCounter = 0;
                    }
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.IsYoyo())
            {
                if (modPlayer.amberRing)
                {
                    Lighting.AddLight(projectile.Center, 1, (float)0.62, 1);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.OrangeTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
                if (modPlayer.amethystRing)
                {
                    Lighting.AddLight(projectile.Center, 1, 0, 1);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.PurpleTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
                if (modPlayer.topazRing)
                {
                    Lighting.AddLight(projectile.Center, 1, 1, 0);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.YellowTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
                if (modPlayer.rubyRing)
                {
                    Lighting.AddLight(projectile.Center, 1, 0, 0);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.RedTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
                if (modPlayer.sapphireRing)
                {
                    Lighting.AddLight(projectile.Center, 0, 0, 1);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.BlueTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
                if (modPlayer.emeraldRing)
                {
                    Lighting.AddLight(projectile.Center, 0, 1, 0);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.GreenTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.5f;
                }
                if (modPlayer.diamondRing)
                {
                    Lighting.AddLight(projectile.Center, 1, 1, 1);
                    Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.WhiteTorch);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.5f;
                }
                if (modPlayer.gemRing)
                {
                    switch (Main.rand.Next(8))
                    {
                        case 0:
                            Lighting.AddLight(projectile.Center, 1, 1, 1);
                            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.WhiteTorch);
                            dust.noGravity = true;
                            dust.noLight = false;
                            dust.scale = 1.5f;
                            break;
                        case 1:
                            Lighting.AddLight(projectile.Center, 0, 1, 0);
                            Dust dust2 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.GreenTorch);
                            dust2.noGravity = true;
                            dust2.noLight = false;
                            dust2.scale = 1.5f;
                            break;
                        case 2:
                            Lighting.AddLight(projectile.Center, 0, 0, 1);
                            Dust dust3 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.BlueTorch);
                            dust3.noGravity = true;
                            dust3.noLight = false;
                            dust3.scale = 1.2f;
                            break;
                        case 4:
                            Lighting.AddLight(projectile.Center, 1, 0, 0);
                            Dust dust4 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.RedTorch);
                            dust4.noGravity = true;
                            dust4.noLight = false;
                            dust4.scale = 1.2f;
                            break;
                        case 5:
                            Lighting.AddLight(projectile.Center, 1, 1, 0);
                            Dust dust5 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.YellowTorch);
                            dust5.noGravity = true;
                            dust5.noLight = false;
                            dust5.scale = 1.2f;
                            break;
                        case 6:
                            Lighting.AddLight(projectile.Center, 1, 0, 1);
                            Dust dust6 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.PurpleTorch);
                            dust6.noGravity = true;
                            dust6.noLight = false;
                            dust6.scale = 1.2f;
                            break;
                        case 7:
                            Lighting.AddLight(projectile.Center, 1, (float)0.62, 1);
                            Dust dust7 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.OrangeTorch);
                            dust7.noGravity = true;
                            dust7.noLight = false;
                            dust7.scale = 1.2f;
                            break;
                    }
                }
            }
        }

        // Resetting counters when the yoyo is killed.
        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.TryGetOwner(out _))
                return;
            
            if (projectile.IsYoyo() && projectile.YoyoData().MainYoyo)
                projectile.GetOwner().GetModPlayer<YoyoModPlayer>().HitCounter = 0;

            if (yoyoOrnament)
            {
                for (int i = Main.rand.Next(0, 3); i < 4; i++)
                {
                    var proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(),
                    projectile.Center, Main.rand.NextVector2CircularEdge(1f, 1f) * Main.rand.NextFloat(3f, 4.5f), ProjectileID.OrnamentHostileShrapnel, (int)(projectile.damage * 0.5f), 1f, projectile.owner);
                    proj.friendly = true;
                    proj.hostile = false;
                    proj.usesIDStaticNPCImmunity = true;
                    proj.idStaticNPCHitCooldown = 20;
                }
            }
        }

        // Preventing recalling yoyos from dealing damage
        public override bool? CanDamage(Projectile projectile)
        {
            if (projectile.aiStyle == 99)
            {
                return projectile.ai[0] != -1 ? null : false;
            }

            return null;
        }

        public override bool TileCollideStyle(Projectile projectile, ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            if (projectile.GetOwner().GetModPlayer<YoyoModPlayer>().phasingYoyos && projectile.IsYoyo())
                return false;

            return true;
        }
    }
}
