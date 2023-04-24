using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TocantinProjectile : ModProjectile
    {
        public int counter = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 270f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 10.6f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            counter++;
            if (counter >= 20)
            {
                SpecialEffect(target);
            }

            int rand = Main.rand.Next(4);
            if (rand == 0)
            {
                target.AddBuff(BuffID.Poisoned, 420);
            }
        }

        public void SpecialEffect(NPC target)
        {
            for (int i = 0; i < 8; i++)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                        ProjectileID.QueenBeeStinger, 12, 1, Projectile.owner);
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                }

                target.AddBuff(BuffID.Poisoned, 300);
            }
        }
        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.JungleGrass);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 1.35f;

            }
            int rand = Main.rand.Next(10);

            if (rand == 0)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.JungleSpore);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.5f;
            }
        }
    }
}
