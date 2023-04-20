using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TestingYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 650f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 20f;

        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        // public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        // {    
        // }

        public override void PostAI()
        {

        }
    }
}
