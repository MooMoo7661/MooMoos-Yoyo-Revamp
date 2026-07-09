using CombinationsMod.Content.Configs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class StoneAgeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 3f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 110f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 8.3f;

            if (ModLoader.HasMod("CalamityMod") || ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror)
            {
                CalamityBalancing.RebalanceYoyoOnDemand(6f, 130f, 11.2f, 0, this.Projectile, 20);
            }
        }

        public override void SetDefaults()
        {
            Projectile.scale = 1f;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(12))
            {
                target.AddBuff(BuffID.Confused, 180);
            }
        }
    }
}
