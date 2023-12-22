using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class IronYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 8f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 153f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.7f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.2f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 15;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }
    }
}
