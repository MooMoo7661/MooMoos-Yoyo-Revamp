﻿using System;
using System.Reflection;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.Explosions;
using CombinationsMod.Content.Projectiles.TrickYoyos;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses.Projectiles
{

    public class GlobalProjectileModifications : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        private readonly bool isOriginalYoyo;
        private int cursedFlamesCounter = 0;
        private int slimeThornCounter = 0;
        private int lifestealCooldown = 0;

        // This class mostly does things with yoyos. The reason it's not part of VanillaYoyoEffects class is because this applies to all
        // yoyos, and not just vanilla ones. I felt that the things in here fit better where they are.

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            lifestealCooldown += Main.rand.Next(10);
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.aiStyle == 99 && !projectile.counterweight) // Checking if yoyo but not counterweight
            {
                if (modPlayer.trick1 && projectile.owner == Main.myPlayer)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                    new(0, 0), ModContent.ProjectileType<World1>(), (int)(projectile.damage * 0.3f), 0, Main.myPlayer, 0, projectile.whoAmI);
                }
                else if (modPlayer.trick2 && projectile.owner == Main.myPlayer)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                        new(0, 0), ModContent.ProjectileType<World2>(), (int)(projectile.damage * 0.5f), 0, Main.myPlayer, 0, projectile.whoAmI);
                    }
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.golemString && projectile.aiStyle == 99 && projectile.counterweight)
            {
                modifiers.FinalDamage *= 2f;
                modifiers.Knockback *= 2f;
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.aiStyle == 99 && modPlayer.hitTracker && !projectile.counterweight && ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(projectile))
                modPlayer.HitCounter++;

            if (projectile.aiStyle == 99 && !projectile.counterweight)
            {
                cursedFlamesCounter++;

                if (modPlayer.eclipseString && Main.myPlayer == projectile.owner)
                {
                    if (Main.rand.NextBool(4))
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;

                        if (Main.rand.NextBool())
                        {
                            Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                    ModContent.ProjectileType<EclipseSwirl>(), 0, 0, projectile.owner, 0, 1f);
                        }
                        else
                        {
                            Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                    ModContent.ProjectileType<EclipseSwirlOrange>(), 0, 0, projectile.owner, 0, 1f);
                        }

                        Projectile projHitbox = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                ModContent.ProjectileType<SolidHitbox>(), 75, 4f, projectile.owner, 0, 1f);
                        projHitbox.Resize(100, 100);
                    }
                }

                if (modPlayer.omnipotenceRing && isOriginalYoyo && cursedFlamesCounter % 3 == 0 && Main.myPlayer == projectile.owner)
                {
                    Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 3f;

                    Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, velocity,
                        ProjectileID.CursedFlameFriendly, 54, 4f, projectile.owner, 0, 1f);
                    proj.scale = 1f;
                    proj.tileCollide = true;
                    proj.timeLeft = 120;
                    proj.friendly = true;
                    proj.hostile = false;
                    proj.netUpdate = true;
                }
            }
            else if (projectile.counterweight && projectile.aiStyle == 99)
            {
                if (modPlayer.golemString)
                {
                    if (Main.myPlayer == projectile.owner)
                    {
                        Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), new(projectile.Center.X, projectile.Center.Y - 1f), new(Main.rand.NextBool() ? 1 : -1,
                        Main.rand.NextBool() ? 1 : -1), ModContent.ProjectileType<EclipseExplosion>(), 11, 0, projectile.owner);

                        proj.damage = 84;
                    }
                }

                if (modPlayer.frostbiteString)
                    target.AddBuff(BuffID.Frostburn2, 300);
            }
            if (projectile.type == ProjectileID.Stinger)
            {
                int rand = Main.rand.Next(2);
                if (rand == 0)
                    target.AddBuff(BuffID.Poisoned, 240);
            }
                
            if (lifestealCooldown < 15 + (projectile.MaxUpdates * 10) + (projectile.usesLocalNPCImmunity ? projectile.localNPCHitCooldown * 0.7f : 0    ) && modPlayer.lifestealTrick)
            {
                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero,
                ProjectileID.VampireHeal, 0, 0, projectile.owner, projectile.owner, Math.Clamp(projectile.damage / 20f, 1f, 3f) + Main.rand.Next(3));
                lifestealCooldown = 0;
            }
        }
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>(); //  Getting an instance of the player and the ModPlayer

            if (projectile.aiStyle == 99 && !projectile.counterweight)
            {
                slimeThornCounter++;

                if (modPlayer.slimeString)
                {
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

                if (lifestealCooldown < 15 + (projectile.MaxUpdates * 10) + (projectile.usesLocalNPCImmunity ? projectile.localNPCHitCooldown * 0.7f : 0))
                    lifestealCooldown++;
            }
        }

        public override void PostAI(Projectile projectile) // Using this mostly to make vanilla yoyos have certain dust effects.
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (projectile.aiStyle == 99 && !projectile.counterweight)
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

        public override void OnKill(Projectile projectile, int timeLeft) // Resetting counters when the yoyo is killed.
        {
            if (projectile.aiStyle == 99 && !projectile.counterweight && ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(projectile))
            {
                Player player = Main.player[projectile.owner];
                YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
                modPlayer.HitCounter = 0;
            }
        }

        public override bool TileCollideStyle(Projectile projectile, ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if ((modPlayer.shimmerBag || modPlayer.moonlordBag) && projectile.aiStyle == 99 && !projectile.counterweight && Main.myPlayer == projectile.owner) { return false; }

            return true;
        }

    }
}
