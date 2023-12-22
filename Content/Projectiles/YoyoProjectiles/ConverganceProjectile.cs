using CombinationsMod.Content.ModPlayers;
using CombinationsMod.GlobalClasses.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class ConverganceProjectile : ModProjectile
    {
        public int timer = 10;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 420f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 2;
            Projectile.extraUpdates = 2;
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int damage = (int)(Projectile.damage * 1.75f);

                if (Main.myPlayer == Projectile.owner)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.WoodYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<IronYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<LeadYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Rally, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.CorruptYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.CrimsonYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.JungleYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Valor, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Cascade, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Code2, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<SmudgeProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<Code3Projectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<TheAbbhorProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<ThinMintProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CatacombProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<TheQueensGambitProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Code1, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CobaltYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<PalladiumYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<MythrilYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<OrichalcumYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Chik, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.FormatC, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.HelFire, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Amarok, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Gradient, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Yelets, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.RedsYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.ValkyrieYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<ChristmasBulbProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<MambeleProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Kraken, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.TheEyeOfCthulhu, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CultistYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Terrarian, damage, Projectile.knockBack, Projectile.owner);
                    }
                }
            }
        }
    }
}
