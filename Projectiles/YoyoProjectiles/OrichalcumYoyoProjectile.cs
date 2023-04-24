using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class OrichalcumYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 276f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13f;
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
        public override void OnSpawn(IEntitySource source)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<PinkSwirl>(),
                    (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                    Projectile.Center.Y, 0, 0, ModContent.ProjectileType<PinkPartSwirl>(),
                    (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[proj].scale = 1.8f;
            }
        }
    }
}
