using CombinationsMod.Content.Global_Classes.Projectiles;
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

            if (ModLoader.HasMod("CalamityMod"))
            {
                CalamityBalancing.RebalanceYoyoOnDemand(17f, 260f, 14.8f, 0, this.Projectile, 20);
            }
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }
    }
}
