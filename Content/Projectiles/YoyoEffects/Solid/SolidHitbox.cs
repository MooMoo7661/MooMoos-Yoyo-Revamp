using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects.Solid
{

    public class SolidHitbox : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 150;
            Projectile.height = 150;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 3f;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
        }

        public override string Texture => "CombinationsMod/Content/Projectiles/YoyoEffects/ScalableHitbox1";
    }
}