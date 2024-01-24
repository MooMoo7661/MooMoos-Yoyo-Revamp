using CombinationsMod.Content.Items.Accessories.Drills;
using CombinationsMod.Content.Items.Accessories.Rings;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Accessories.Tricks;
using CombinationsMod.Content.Items.Accessories.YoyoBags;
using CombinationsMod.Content.Items.Accessories.YoyoGloves;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Utility
{
    public class ItemSets : ModSystem
    {
        public override void PostSetupContent()
        {
            CreateModdedSets();
            Mod.Logger.Info("Created modded sets");
        }

        private static void CreateModdedSets()
        {
            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
            {
                YoyoString[veridianMod.Find<ModItem>("CrimsonString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("CrossString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("CursedString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("FrogString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("FrostString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("HoneyString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("HorseshoeString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("IchorString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("JungleString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("LavaString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("MythString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("PumpkinString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("RegenString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("ShadowString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("SharktoothString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("VeilString").Type] = true;
                YoyoString[veridianMod.Find<ModItem>("HellString").Type] = true;
            }

            #region YoyoString
            YoyoString[ItemType<DarkBlueString>()] = true;
            YoyoString[ItemType<DarkGreenString>()] = true;
            YoyoString[ItemType<DarkTealString>()] = true;
            YoyoString[ItemType<EclipseString>()] = true;
            YoyoString[ItemType<FrostbiteString>()] = true;
            YoyoString[ItemType<GolemsteelString>()] = true;
            YoyoString[ItemType<GrapeString>()] = true;
            YoyoString[ItemType<LightPinkString>()] = true;
            YoyoString[ItemType<NaniteString>()] = true;
            YoyoString[ItemType<NebulaString>()] = true;
            YoyoString[ItemType<SlimyString>()] = true;
            YoyoString[ItemType<SolarString>()] = true;
            YoyoString[ItemType<StardustString>()] = true;
            YoyoString[ItemType<VortexString>()] = true;
            #endregion

            #region YoyoBag
            YoyoBag[ItemType<AdvancedYoyoBag>()] = true;
            YoyoBag[ItemType<BeetleBag>()] = true;
            YoyoBag[ItemType<MoonlordBag>()] = true;
            YoyoBag[ItemType<ShimmerBag>()] = true;
            YoyoBag[ItemType<ShimmeringBeetleBag>()] = true;
            YoyoBag[ItemType<Tier2Bag>()] = true;
            #endregion

            SupportGlove[ItemType<SupportGlove>()] = true;

            #region Drills
            DrillCasing[ItemType<AdamantiteDrillCasing>()] = true;
            DrillCasing[ItemType<CelestialDrillCasing>()] = true;
            DrillCasing[ItemType<CobaltDrillCasing>()] = true;
            DrillCasing[ItemType<ExcavatorCasing>()] = true;
            DrillCasing[ItemType<HakapikDrillCasing>()] = true;
            DrillCasing[ItemType<HorsemansDrillCasing>()] = true;
            DrillCasing[ItemType<YoyoDrillCasing>()] = true;
            DrillCasing[ItemType<MattockDrillCasing>()] = true;
            DrillCasing[ItemType<MooMooDrillCasing>()] = true;
            DrillCasing[ItemType<MythrilDrillCasing>()] = true;
            DrillCasing[ItemType<NebulaDrillCasing>()] = true;
            DrillCasing[ItemType<OrichalcumDrillCasing>()] = true;
            DrillCasing[ItemType<PalladiumCasing>()] = true;
            DrillCasing[ItemType<ShroomiteShredderCasing>()] = true;
            DrillCasing[ItemType<SolarDrillCasing>()] = true;
            DrillCasing[ItemType<SpectralShredderCasing>()] = true;
            DrillCasing[ItemType<StardustDrillCasing>()] = true;
            DrillCasing[ItemType<TitaniumDrillCasing>()] = true;
            DrillCasing[ItemType<TreeClippersDrillCasing>()] = true;
            DrillCasing[ItemType<TsurugiDrillCasing>()] = true;
            DrillCasing[ItemType<VortexDrillCasing>()] = true;
            #endregion

            #region Rings
            YoyoRing[ItemType<AbilityRing>()] = true;
            YoyoRing[ItemType<AmberRing>()] = true;
            YoyoRing[ItemType<AmethystRing>()] = true;
            YoyoRing[ItemType<DiamondRing>()] = true;
            YoyoRing[ItemType<EmeraldRing>()] = true;
            YoyoRing[ItemType<FortitudeRing>()] = true;
            YoyoRing[ItemType<GemstoneRing>()] = true;
            YoyoRing[ItemType<OmnipotenceRing>()] = true;
            YoyoRing[ItemType<RingOfCoalescence>()] = true;
            YoyoRing[ItemType<RubyRing>()] = true;
            YoyoRing[ItemType<SapphireRing>()] = true;
            YoyoRing[ItemType<TerreneRing>()] = true;
            YoyoRing[ItemType<TopazRing>()] = true;
            YoyoRing[ItemType<TrepidationRing>()] = true;
            #endregion

            #region Tricks
            Trick[ItemType<AroundTheWorld>()] = true;
            Trick[ItemType<AroundTheWorldTier2>()] = true;
            Trick[ItemType<ShootToTheMoon>()] = true;
            Trick[ItemType<DualYoyo>()] = true;
            #endregion
        }

        public static bool[] YoyoString = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.BlackString,
            ItemID.BlueString,
            ItemID.BrownString,
            ItemID.CyanString,
            ItemID.GreenString,
            ItemID.LimeString,
            ItemID.OrangeString,
            ItemID.PinkString,
            ItemID.PurpleString,
            ItemID.SkyBlueString,
            ItemID.TealString,
            ItemID.VioletString,
            ItemID.WhiteString,
            ItemID.YellowString,
            ItemID.RedString
            );

        public static bool[] YoyoBag = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.YoyoBag
            );

        public static bool[] YoyoGlove = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.YoYoGlove
            );

        public static bool[] SupportGlove = ItemID.Sets.Factory.CreateBoolSet();

        public static bool[] DrillCasing = ItemID.Sets.Factory.CreateBoolSet();

        public static bool[] Counterweight = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.BlackCounterweight,
            ItemID.BlueCounterweight,
            ItemID.GreenCounterweight,
            ItemID.PurpleCounterweight,
            ItemID.RedCounterweight,
            ItemID.YellowCounterweight
            );

        public static bool[] YoyoRing = ItemID.Sets.Factory.CreateBoolSet();

        public static bool[] Trick = ItemID.Sets.Factory.CreateBoolSet();
    }
}
