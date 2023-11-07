using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using CombinationsMod.Items.Accessories.Strings;
using CombinationsMod.Items.Accessories.YoyoBags;
using CombinationsMod.Items.Accessories.YoyoGloves;
using CombinationsMod.Items.Accessories.Drills;
using CombinationsMod.Drills;
using CombinationsMod.Items.Accessories.Rings;
using CombinationsMod.Items.Accessories.Tricks;

namespace CombinationsMod
{
    public class ItemSets : ModSystem
    {
        public override void Load()
        {
            CreateModdedSets();
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
            ItemID.RedString,
            ItemType<DarkBlueString>(),
            ItemType<DarkGreenString>(),
            ItemType<DarkTealString>(),
            ItemType<EclipseString>(),
            ItemType<FrostbiteString>(),
            ItemType<GolemsteelString>(),
            ItemType<GrapeString>(),
            ItemType<LightPinkString>(),
            ItemType<NaniteString>(),
            ItemType<NebulaString>(),
            ItemType<SlimyString>(),
            ItemType<SolarString>(),
            ItemType<StardustString>(),
            ItemType<VortexString>()
            );

        public static bool[] YoyoBag = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.YoyoBag,
            ItemType<AdvancedYoyoBag>(),
            ItemType<BeetleBag>(),
            ItemType<MoonlordBag>(),
            ItemType<ShimmerBag>(),
            ItemType<ShimmeringBeetleBag>(),
            ItemType<Tier2Bag>()
            );

        public static bool[] YoyoGlove = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.YoYoGlove
            );

        public static bool[] SupportGlove = ItemID.Sets.Factory.CreateBoolSet(
            ItemType<SupportGlove>()
            );

        public static bool[] DrillCasing = ItemID.Sets.Factory.CreateBoolSet(
            ItemType<AdamantiteDrillCasing>(),
            ItemType<CelestialDrillCasing>(),
            ItemType<CobaltDrillCasing>(),
            ItemType<ExcavatorCasing>(),
            ItemType<HakapikDrillCasing>(),
            ItemType<HorsemansDrillCasing>(),
            ItemType<YoyoDrillCasing>(),
            ItemType<MattockDrillCasing>(),
            ItemType<MooMooDrillCasing>(),
            ItemType<MythrilDrillCasing>(),
            ItemType<NebulaDrillCasing>(),
            ItemType<OrichalcumDrillCasing>(),
            ItemType<PalladiumCasing>(),
            ItemType<ShroomiteShredderCasing>(),
            ItemType<SolarDrillCasing>(),
            ItemType<SpectralShredderCasing>(),
            ItemType<StardustDrillCasing>(),
            ItemType<TitaniumDrillCasing>(),
            ItemType<TreeClippersDrillCasing>(),
            ItemType<TsurugiDrillCasing>(),
            ItemType<VortexDrillCasing>()
            );

        public static bool[] Counterweight = ItemID.Sets.Factory.CreateBoolSet(
            ItemID.BlackCounterweight,
            ItemID.BlueCounterweight,
            ItemID.GreenCounterweight,
            ItemID.PurpleCounterweight,
            ItemID.RedCounterweight,
            ItemID.YellowCounterweight
            );

        public static bool[] YoyoRing = ItemID.Sets.Factory.CreateBoolSet(
            ItemType<AbilityRing>(),
            ItemType<AmberRing>(),
            ItemType<AmethystRing>(),
            ItemType<DiamondRing>(),
            ItemType<EmeraldRing>(),
            ItemType<FortitudeRing>(),
            ItemType<GemstoneRing>(),
            ItemType<OmnipotenceRing>(),
            ItemType<RingOfCoalescence>(),
            ItemType<RubyRing>(),
            ItemType<SapphireRing>(),
            ItemType<TerreneRing>(),
            ItemType<TopazRing>(),
            ItemType<TrepidationRing>()
            );

        public static bool[] Trick = ItemID.Sets.Factory.CreateBoolSet(
            ItemType<AroundTheWorld>(),
            ItemType<AroundTheWorldTier2>(),
            ItemType<ShootToTheMoon>(),
            ItemType<DualYoyo>()
            );


    }
}
