using System;
using System.Collections.Generic;
using System.Reflection;
using CombinationsMod.Content.Global_Classes.Projectiles;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.Explosions;
using CombinationsMod.Content.Projectiles.Misc;
using CombinationsMod.Content.Projectiles.TrickYoyos;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
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
        private int lifestealGloveCooldown = 300;
        private int pumpkinGloveCooldown = 180;
        private int rad = 0;

        bool cascadeGreekFire = false;
        bool yoyoOrnament = false;
        bool recall = false;
        private int heat = 0;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            lifestealCooldown += Main.rand.Next(10);

            if (!projectile.TryGetOwner(out _))
                return;

            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.IsYoyo() && projectile.owner == Main.myPlayer)
            {
                if (!projectile.YoyoData().MainYoyo && projectile.scale == 1f)
                    projectile.scale = 0.9f;

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

            if (projectile.IsYoyo())
            {
                modifiers.FinalDamage *= Math.Clamp(1 + MathHelper.Lerp(0f, 0.5f, (float)heat / 300), 1, 2);
                modifiers.SourceDamage *= projectile.YoyoData().DamageMult;
            }
        }

        //----------------------------------------------------------------------------------------------------------------------
        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            if (projectile.IsYoyo())
            {
                Player player = projectile.GetOwner();
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

                if (heat > 100 && Main.rand.NextBool(3))
                    target.AddBuff(BuffID.OnFire, heat);

                if (modPlayer.hallowGlove && projectile.YoyoData().Hits % 15 == 0)
                {
                    foreach (NPC npc in Main.ActiveNPCs)
                    {
                        if (npc.Distance(projectile.Center) > 250f || (npc.friendly || npc.dontTakeDamage || npc.immortal))
                            continue;

                        if (npc.knockBackResist != 0f)
                        {
                            npc.velocity -= npc.DirectionTo(projectile.Center) * 4;
                            npc.velocity.Y -= 3f;
                        }

                        const int max = 18;
                        for (int index1 = 0; index1 < max; ++index1)
                        {
                            Vector2 vector2 = (Vector2.UnitX * (float)-projectile.width / 2f + -Vector2.UnitY.RotatedBy((double)index1 * 2 * Math.PI / max, new Vector2()) * new Vector2(8f, 16f)).RotatedBy((double)projectile.rotation - 1.57079637050629, new Vector2());
                            int index2 = Dust.NewDust(projectile.Center, 0, 0, Main.rand.NextBool() ? DustID.YellowTorch : DustID.HallowedWeapons, 0.0f, 0.0f, 160, new Color(), 1f);
                            Main.dust[index2].scale = 1.7f;
                            Main.dust[index2].noGravity = true;
                            Main.dust[index2].position = npc.Center + vector2 * 2f;
                            Main.dust[index2].velocity = Vector2.Normalize(npc.Center - npc.velocity * 3f - Main.dust[index2].position) * 1.25f;
                        }

                        SoundStyle HitSound = new()
                        {
                            SoundPath = SoundID.Item8.SoundPath,
                            Volume = 0.55f,
                            PitchVariance = 0.15f,
                            SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                        };
                        SoundEngine.PlaySound(HitSound);

                        NPC.HitInfo info = target.CalculateHitInfo((int)(projectile.damage * 1.15f), -target.direction, true, 0f);
                        target.StrikeNPC(info, true);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendStrikeNPC(target, info);
                        }

                        npc.AddBuff(BuffID.OnFire, 240);
                    }
                }

                if (modPlayer.crystalGlove)
                {
                    if (Main.rand.NextBool(7))
                    {
                        for (int i = 0; i < 20; i++)
                        {
                            Vector2 speed = -Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Main.rand.NextFloat() * 4f;
                            Dust.NewDustDirect(projectile.Center, 5, 5, Main.rand.NextBool() ? DustID.PurpleCrystalShard : DustID.PinkCrystalShard, speed.X, speed.Y).scale = 0.8f;
                        }

                        SoundEngine.PlaySound(SoundID.Item27, projectile.Center);
                        NPC.HitInfo info = target.CalculateHitInfo((int)(projectile.damage * 1.15f), -target.direction, true, 0f);
                        target.StrikeNPC(info, true);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendStrikeNPC(target, info);
                        }
                    }
                }

                // lifesteal
                if (modPlayer.fleshGlove && !target.immortal && !target.dontTakeDamage && target.lifeMax > 10 && lifestealGloveCooldown <= 0)
                {
                    if (projectile.YoyoData().Hits % 20 == 0)
                    {
                        List<NPC> nearby = new List<NPC>();

                        foreach (NPC npc in Main.ActiveNPCs)
                        {
                            if (npc.Distance(projectile.Center) > 750f)
                                continue;

                            if (!npc.friendly && !npc.dontTakeDamage && !npc.immortal)
                            {
                                nearby.Add(npc);
                            }
                        }

                        if (nearby.Count < 4)
                        {
                            player.AddBuff(BuffID.Rage, 240);
                        }

                        for (int i = 0; i < 5 + (projectile.YoyoData().MainYoyo ? 0 : -2); i++)
                        {
                            if (nearby.Count > 0)
                            {
                                int idx = Main.rand.Next(nearby.Count);
                                NPC pick = nearby[idx];
                                Projectile.NewProjectile(pick.GetSource_FromThis(), pick.Center, Vector2.Zero,
                                ProjectileID.VampireHeal, (int)(projectile.damage * 0.3f), 0, projectile.owner, projectile.owner, 1 + (pick.boss ? 2 : 0));
                                NPC.HitInfo info = pick.CalculateHitInfo((int)(projectile.damage * 0.3f), -pick.direction, false, 0f);
                                pick.StrikeNPC(info, true);
                                if (Main.netMode == NetmodeID.MultiplayerClient)
                                {
                                    NetMessage.SendStrikeNPC(pick, info);
                                }

                                nearby.RemoveAt(idx);
                            }
                        }

                        nearby.Clear();
                        lifestealGloveCooldown = 180 + (projectile.YoyoData().MainYoyo ? 0 : 120);
                    }
                }

                if (modPlayer.corruptGlove)
                {
                    if (Main.rand.NextBool(4))
                        target.AddBuff(BuffID.Poisoned, 120);
                    if (projectile.YoyoData().Hits % 20 == 0)
                    {
                        PoisionExplosion(projectile);
                    }
                }
   
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
                    Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ModContent.ProjectileType<EclipseExplosion>(), 84, 0, projectile.owner);

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

        void PoisionExplosion(Projectile projectile)
        {
            for (int i = 0; i < 20; i++)
            {
                Vector2 speed = -Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Main.rand.NextFloat() * 4f;
                Dust.NewDustDirect(projectile.Center, 5, 5, Main.rand.NextBool() ? DustID.Poisoned : DustID.Venom, speed.X, speed.Y).scale = 1.6f;
            }

            foreach (NPC npc in Main.ActiveNPCs)
            {
                if (npc.Distance(projectile.Center) > (projectile.YoyoData().MainYoyo ? 230f : 200f))
                    continue;

                if (!npc.friendly && !npc.dontTakeDamage && !npc.immortal)
                {
                    if (npc.knockBackResist != 0f)
                        npc.velocity -= npc.DirectionTo(projectile.Center) * (projectile.YoyoData().MainYoyo ? 4f : 2.3f);

                    NPC.HitInfo info = npc.CalculateHitInfo((int)(projectile.damage * 1.1), -npc.direction, false, 0f);
                    npc.StrikeNPC(info, true);
                    if (Main.netMode == NetmodeID.MultiplayerClient)
                    {
                        NetMessage.SendStrikeNPC(npc, info);
                    }

                    npc.AddBuff(BuffID.Poisoned, 240);
                    npc.AddBuff(BuffID.Weak, 180);
                }
            }
        }

        //----------------------------------------------------------------------------------------------------
        public override void AI(Projectile projectile)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            if (projectile.IsYoyo())
            {
                Player player = projectile.GetOwner();
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

                if (modPlayer.skeletonGlove)
                {
                    if (pumpkinGloveCooldown <= 0)
                    {
                        pumpkinGloveCooldown = 180;

                        if (rad >= 360)
                            rad = 0;

                        rad += 60;

                        Vector2 vel = new Vector2(0, -1).RotatedBy(MathHelper.ToRadians(rad)) * 6.5f;
                        Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis("SkeletonGlove"), projectile.Center, vel, Main.rand.NextBool() ? ProjectileID.GreekFire2 : ProjectileID.GreekFire1, projectile.damage / 2, 1f, projectile.owner);
                        proj.scale = 0.65f;
                        proj.timeLeft = 90;
                        proj.hostile = false;
                        proj.friendly = true;
                    }
                    else
                    {
                        pumpkinGloveCooldown--;
                    }
                }

                if (modPlayer.corruptGlove)
                {
                    if (modPlayer.YoyoLifetimeModifier == -1 || ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type] == -1)
                    {
                        if (projectile.localAI[0] % 1200 == 0)
                            PoisionExplosion(projectile);
                    }
                    else if (!recall && projectile.ai[0] == -1)
                    {
                        if (modPlayer.corruptGlove)
                            PoisionExplosion(projectile);

                        recall = true;
                    }
                }

                if (lifestealCooldown < 15 + (projectile.MaxUpdates * 10) + (projectile.usesLocalNPCImmunity ? projectile.localNPCHitCooldown * 0.7f : 0))
                    lifestealCooldown++;

                if (lifestealGloveCooldown > 0)
                    lifestealGloveCooldown--;

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
                if (modPlayer.spelunkerGlove)
                {
                    Lighting.AddLight(projectile.Center, new Color(255, 255, 255).ToVector3() * 1.2f);
                }

                if (heat > 0)
                heat = Math.Clamp(heat - 2, 0, 500);

                if (heat > 100 && Main.rand.NextBool(150 - Math.Clamp(heat / 2, 0, 145))) 
                    Dust.NewDust(projectile.position, 5, 5, DustID.Torch, 0, 0);

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

        public override Color? GetAlpha(Projectile projectile, Color lightColor)
        {
            if (projectile.aiStyle == ProjAIStyleID.Yoyo && projectile.TryGetOwner(out var player) && player.GetModPlayer<YoyoModPlayer>().sparkTrick)
            {
                Color posColor = Lighting.GetColor(projectile.Center.ToTileCoordinates());
                return new Microsoft.Xna.Framework.Color(posColor.R, posColor.G - Math.Clamp(heat, 0, 255), posColor.B - Math.Clamp(heat, 0, 255), 255 - projectile.alpha);
            }

            return null;
        }

        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (!projectile.IsYoyo() || !Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().sparkTrick)
                return true;

            Vector2 dir = Vector2.Zero;
            Vector2 offset = Vector2.Zero;
            int x = (int)(projectile.Center.X / 16);
            int y = (int)(projectile.Center.Y / 16);

            if (WorldGen.InWorld(x, y + 1) && Framing.GetTileSafely(x, y + 1).HasTile)
            {
                dir.X = -13 * (projectile.GetOwner().direction == -1 ? -1 : 1);
                offset.Y = 3;
                if (heat < 300)
                    heat += Math.Abs((int)projectile.velocity.X / 2);
            }
            else if (WorldGen.InWorld(x, y - 1) && Framing.GetTileSafely(x, y - 1).HasTile)
            {
                dir.X = 13 * (projectile.GetOwner().direction == -1 ? -1 : 1);
                offset.Y = -10;
            }
            else if (WorldGen.InWorld(x + 1, y) && Framing.GetTileSafely(x + 1, y).HasTile)
            {
                dir.Y = -13 * (projectile.GetOwner().direction == -1 ? -1 : 1);
                offset.X = 5;
            }
            else if (WorldGen.InWorld(x - 1, y) && Framing.GetTileSafely(x - 1, y).HasTile)
            {
                dir.Y = 13 * (projectile.GetOwner().direction == -1 ? -1 : 1);
                offset.X = -10;
            }

            if (projectile.GetOwner().GetModPlayer<YoyoModPlayer>().sparkTrick && !Main.rand.NextBool(4) && dir != Vector2.Zero)
            {
                Dust spark2 = Dust.NewDustDirect(projectile.Center + offset, 5, 5, DustID.Torch, dir.X, dir.Y);
                spark2.alpha = 0;
                spark2.scale = 0.55f;

                if (heat < 300)
                    heat += 3;
            }

            return true;
        }

        // Resetting counters when the yoyo is killed.
        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (!projectile.TryGetOwner(out _))
                return;

            if (projectile.IsYoyo())
            {
                if (projectile.YoyoData().MainYoyo)
                    projectile.GetOwner().GetModPlayer<YoyoModPlayer>().HitCounter = 0;
            }

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
