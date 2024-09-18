using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class ChristmasBulbProjectile : ModProjectile
    {
        public int timer = 30;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 450;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.4f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.1f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 2;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }

        public override void AI()
        { 
            timer--;
            if (timer <= 0)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center + Projectile.velocity * 0.6f, Projectile.velocity + Vector2.One.RotatedByRandom(MathHelper.TwoPi),
                ProjectileID.NorthPoleSnowflake, (int)(Projectile.damage * 2.8f), 4f, Projectile.owner, 0, 1f);
                timer = 30;
            }
        }
    }
}

