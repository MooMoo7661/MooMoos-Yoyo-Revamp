using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class OrichalcumYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 11f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 220f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.5f;

            if (ModLoader.HasMod("CalamityMod") || ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror)
            {
                CalamityBalancing.RebalanceYoyoOnDemand(29f, 300f, 18f, 1, this.Projectile, 12);
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
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<PinkSwirl>(),
                    (int)(Projectile.damage * 0.5f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<PinkPartSwirl>(),
                    (int)(Projectile.damage * 0.5f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }
        }
    }
}
