using CombinationsMod.Drills;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses
{
    public class SpawnDrill : GlobalProjectile
    {
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>(); // Getting modplayer and player

            if (projectile.type == ContentSamples.ProjectilesByType[player.HeldItem.shoot].type && projectile.aiStyle == 99 &&
                projectile.ai[0] != 1f) // If projectile is a Yoyo & it is the same one as the .shoot of the held yoyo.
            {
                if (modPlayer.ironDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                        0, ModContent.ProjectileType<IronDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.palladiumDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<PalladiumDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.cobaltDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<CobaltDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.orichalcumDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<OrichalcumDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.mythrilDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<MythrilDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.adamantiteDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<AdamantiteDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.titaniumDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<TitaniumDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.hallowedDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<Hakapik>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.chlorophyteDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<Mattock>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.spectreDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<SpectralShredder>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.shroomiteDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<ShroomiteShredder>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.golemDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<Tsurugi>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.horseDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<HorsemansDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.christmasDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<TreeClippers>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.solarDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<SolarDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.vortexDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<VortexDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.nebulaDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<NebulaDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.stardustDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<StardustDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.celestialDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<CelestialDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.celestialDrillExtended)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<CelestialDrill2>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.moomooDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<MooMooDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.shadowflameDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<ShadowflameDrill>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.scooperDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<TheScooper>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }
                else if (modPlayer.ninjaDrill)
                {
                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0,
                         0, ModContent.ProjectileType<NinjaStar>(), (int)(projectile.damage * 1f), 0, projectile.owner, 0, projectile.whoAmI);
                }

            }
        }
    }
}

