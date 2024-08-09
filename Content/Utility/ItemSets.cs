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

            SupportGlove[ItemType<SupportGlove>()] = true;
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
            ItemID.RainbowString
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
