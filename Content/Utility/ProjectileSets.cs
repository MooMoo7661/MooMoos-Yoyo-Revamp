using CombinationsMod.Content.Drills;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Utility
{
    public class ProjectileSets : ModSystem
    {
        public static bool[] IsYoyoDrillProjectile = ProjectileID.Sets.Factory.CreateBoolSet(
            ProjectileType<IronDrill>(),
            ProjectileType<PalladiumDrill>(),
            ProjectileType<CobaltDrill>(),
            ProjectileType<OrichalcumDrill>(),
            ProjectileType<MythrilDrill>(),
            ProjectileType<AdamantiteDrill>(),
            ProjectileType<TitaniumDrill>(),
            ProjectileType<Hakapik>(),
            ProjectileType<Mattock>(),
            ProjectileType<SpectralShredder>(),
            ProjectileType<ShroomiteShredder>(),
            ProjectileType<Tsurugi>(),
            ProjectileType<HorsemansDrill>(),
            ProjectileType<TreeClippers>(),
            ProjectileType<SolarDrill>(),
            ProjectileType<VortexDrill>(),
            ProjectileType<NebulaDrill>(),
            ProjectileType<StardustDrill>(),
            ProjectileType<CelestialDrill>(),
            ProjectileType<MooMooDrill>(),
            ProjectileType<Excavator>()
            );
    }
}
