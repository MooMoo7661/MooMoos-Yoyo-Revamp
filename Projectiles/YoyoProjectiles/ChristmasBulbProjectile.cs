using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CombinationsMod.Items;
using CombinationsMod.Dusts;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class ChristmasBulbProjectile : ModProjectile
    {
        public int counter = 0;
        public int storeData = -1;
        public int altCounter = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 347f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.8f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.1f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            counter++;
            altCounter++;


            if (counter >= 30 && altCounter == 2)
            {
                SpecialEffect();
            }

            if (altCounter == 2)
            {
                altCounter = 0;
            }
        }

        public void SpecialEffect()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;

                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                        ProjectileID.OrnamentFriendly, Projectile.damage / 2, 1, Projectile.owner, 1, 1);
                    Main.projectile[proj].scale = 0.9f;
                    Main.projectile[proj].tileCollide = true;
                    Main.projectile[proj].timeLeft = 60;
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                    Main.projectile[proj].usesLocalNPCImmunity = true;
                }
            }
        }

        public override void PostAI()
        {
           if (Main.rand.NextBool())
           {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.Everscream);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 2f;

                if (Main.rand.NextBool())
                {
                    Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.t_LivingWood);
                    dust2.noGravity = true;
                    dust2.noLight = false;
                    dust2.scale = 1.5f;
                }
           }
        }
    }
}

