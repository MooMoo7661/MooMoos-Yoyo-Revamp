using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using System.Diagnostics.Metrics;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.Explosions;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class SpheruliteProjectile : ModProjectile
    {
        public int counter = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 212f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 11.7f;
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
            Projectile.scale = 1.1f;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            counter++;
            Player player = Main.player[Projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                if (counter >= 15 && counter % 2 == 0 && Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<FireExplosion>(), 8, 1, Projectile.owner);
                }
            }
        }


        public override void PostAI()
        {
            

            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Obsidian);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 0.9f;

                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.InfernoFork);
                dust2.noGravity = true;
                dust2.noLight = false;
                dust2.scale = 0.9f;
            }
        }
    }
}
