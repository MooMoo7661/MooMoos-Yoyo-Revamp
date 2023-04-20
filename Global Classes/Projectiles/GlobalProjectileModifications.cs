﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CombinationsMod.Buffs;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.Projectiles.Explosions;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Projectiles.TrickYoyos;
using Terraria.ModLoader.UI.ModBrowser;
using System;

namespace CombinationsMod.GlobalClasses.Projectiles
{

    public class GlobalProjectileModifications : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        private int beeCounter = 0;
        private bool isOriginalYoyo;
        private int solarExplosionCounter = 0;
        private int cursedFlamesCounter = 0;
        private int slimeThornCounter = 0;

        // This class mostly does things with yoyos. The reason it's not part of VanillaYoyoEffects class is because this applies to all
        // yoyos, and not just vanilla ones. I felt that the things in here fit better where they are.

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.aiStyle == 99 && !projectile.counterweight) // Checking if yoyo but not counterweight
            {
                if (modPlayer.trick1 && projectile.owner == Main.myPlayer)
                {
                    int projYoyoCircle = Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                    new(0, 0), ModContent.ProjectileType<World1>(), projectile.damage * 2, 0, Main.myPlayer, 0, projectile.whoAmI);
                }
                else if (modPlayer.trick2 && projectile.owner == Main.myPlayer)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        int projYoyoCircle = Projectile.NewProjectile(projectile.GetSource_FromThis(), player.Center,
                        new(0, 0), ModContent.ProjectileType<World2>(), projectile.damage * 2, 0, Main.myPlayer, 0, projectile.whoAmI);
                    }
                }
            }
        }

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.golemString && projectile.aiStyle == 99 && projectile.counterweight)
            {
                damage *= 2;
                knockback *= 2;
            }
        }
        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            YoyoClipClassNormal yoyoClipClassNormal = new(projectile);

            if (projectile.aiStyle == 99 && modPlayer.hitTracker && !projectile.counterweight)
                modPlayer.HitCounter++;

            if (projectile.aiStyle == 99 && !projectile.counterweight)
            {
                solarExplosionCounter++;
                cursedFlamesCounter++;

                if (modPlayer.crimtaneBearing || modPlayer.demoniteBearing)
                {
                    if (!target.CountsAsACritter && !(target.type == NPCID.TargetDummy))
                    {
                        int rand = Main.rand.Next(2) + 1;

                        Vector2 vector = new(0, 0);
                        Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vector,
                        ProjectileID.VampireHeal, 0, 0, projectile.owner, projectile.owner, rand);
                    }
                }

                if (modPlayer.eclipseString)
                {
                    if (Main.rand.NextBool(4))
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;

                        if (Main.rand.NextBool())
                        {
                            int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                    ModContent.ProjectileType<EclipseSwirl>(), 0, 0, projectile.owner, 0, 1f);
                        }
                        else
                        {
                            int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                    ModContent.ProjectileType<EclipseSwirlOrange>(), 0, 0, projectile.owner, 0, 1f);
                        }

                        int projHitbox = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                ModContent.ProjectileType<SolidHitbox>(), 75, 4f, projectile.owner, 0, 1f);
                        Main.projectile[projHitbox].Resize(100, 100);
                    }
                }

                if (modPlayer.omnipotenceRing && isOriginalYoyo && cursedFlamesCounter % 3 == 0)
                {
                    Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 3f;

                    int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                        ProjectileID.CursedFlameFriendly, 54, 4f, projectile.owner, 0, 1f);
                    Main.projectile[proj].scale = 1f;
                    Main.projectile[proj].tileCollide = true;
                    Main.projectile[proj].timeLeft = 120;
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].netUpdate = true;
                }

                if (modPlayer.jungleBearing)
                {
                    if (Main.rand.NextBool(2))
                    {
                        target.AddBuff(ModContent.BuffType<Pestilence>(), 300);
                    }
                }
                if (modPlayer.ironBearing)
                {
                    target.AddBuff(BuffID.Weak, 300);
                }
            }
            else if (projectile.counterweight && projectile.aiStyle == 99)
            {
                if (modPlayer.golemString)
                {
                    int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                    Main.rand.NextBool() ? 1 : -1, ModContent.ProjectileType<EclipseExplosion>(), 11, 0, projectile.owner);

                    Main.projectile[proj].damage = 84;
                }

                if (modPlayer.frostbiteString)
                {
                    target.AddBuff(BuffID.Frostburn2, 300);
                }
            }

            if (projectile.type == ProjectileID.Stinger)
            {
                int rand = Main.rand.Next(2);
                if (rand == 0)
                    target.AddBuff(BuffID.Poisoned, 240);
            }



            if (projectile.aiStyle == 99 && modPlayer.obsidianBearing && !projectile.counterweight) { target.AddBuff(BuffID.OnFire, 120); }
            if (projectile.aiStyle == 99 && modPlayer.hallowedBearing && !projectile.counterweight) { target.AddBuff(ModContent.BuffType<Hallowed>(), 300); }
        }
        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>(); //  Getting an instance of the player and the ModPlayer |

            if (projectile.aiStyle == 99 && !projectile.counterweight)
            {
                beeCounter++;
                slimeThornCounter++;

                if (modPlayer.slimeString)
                {
                    if (slimeThornCounter == 60)
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 3f;
                        int projSlimeSpike = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, velocity,
                                    ProjectileID.SpikedSlimeSpike, projectile.damage / 2, 3f, projectile.owner, 0, 1f);
                        Main.projectile[projSlimeSpike].friendly = true;
                        Main.projectile[projSlimeSpike].hostile = false;
                        slimeThornCounter = 0;
                    }

                }

                if (beeCounter == 60)
                {
                    if (modPlayer.waspBearing)
                    {
                        Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;

                        Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, velocity, player.beeType(), player.beeDamage(projectile.damage / 3), player.beeKB(projectile.knockBack), projectile.owner);
                        proj.friendly = true;
                    }

                    beeCounter = 0;
                }
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

        public override void SetDefaults(Projectile projectile) // Making vanilla yoyos have different max hit counts.
        {
            if (projectile.type == ProjectileID.SporeGas || projectile.type == ProjectileID.SporeGas2 || projectile.type == ProjectileID.SporeGas3)
            {
                // Attempting to deal with I-Frames that were not being applied correctly.
                projectile.localNPCHitCooldown = 60;
                projectile.usesLocalNPCImmunity = true;
            }
        }
        public override void Kill(Projectile projectile, int timeLeft) // Resetting counters when the yoyo is killed.
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (projectile.aiStyle == 99 && !projectile.counterweight)
            {
                modPlayer.HitCounter = 0;
            }
        }

        public override bool TileCollideStyle(Projectile projectile, ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.fortitudeRing && projectile.aiStyle == 99 && !projectile.counterweight && Main.myPlayer == projectile.owner) { return false; }

            return true;
        }

        
    }
}