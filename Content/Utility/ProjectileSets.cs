using CombinationsMod.Content.Drills;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Utility
{
    public class ProjectileSets : ModSystem
    {
        public static bool[] IsYoyoDrillProjectile = ProjectileID.Sets.Factory.CreateBoolSet();

        public override void PostSetupContent()
        {
            AddModdedSets();
        }

        private static void AddModdedSets()
        {
            IsYoyoDrillProjectile[ProjectileType<IronDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<PalladiumDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<CobaltDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<OrichalcumDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<MythrilDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<AdamantiteDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<TitaniumDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<Hakapik>()] = true;
            IsYoyoDrillProjectile[ProjectileType<Mattock>()] = true;
            IsYoyoDrillProjectile[ProjectileType<SpectralShredder>()] = true;
            IsYoyoDrillProjectile[ProjectileType<ShroomiteShredder>()] = true;
            IsYoyoDrillProjectile[ProjectileType<Tsurugi>()] = true;
            IsYoyoDrillProjectile[ProjectileType<HorsemansDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<TreeClippers>()] = true;
            IsYoyoDrillProjectile[ProjectileType<SolarDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<VortexDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<NebulaDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<StardustDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<CelestialDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<MooMooDrill>()] = true;
            IsYoyoDrillProjectile[ProjectileType<Excavator>()] = true;
        }
    }
}
