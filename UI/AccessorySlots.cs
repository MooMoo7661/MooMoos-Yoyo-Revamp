using CombinationsMod.Drills;
using CombinationsMod.Items.Accessories.Drills;
using CombinationsMod.Items.Accessories.Rings;

using CombinationsMod.Items.Accessories.YoyoGloves;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Default;
using Terraria.UI;
using Terraria.ModLoader.Utilities;
using Terraria.GameContent.UI.Elements;
using System.Drawing;
using static Terraria.ModLoader.ModContent;
using CombinationsMod.Items.Accessories.Strings;

namespace CombinationsMod.UI
{
    public class StringSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            //3293 - 3308 : vanilla yoyo strings
            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
            {
               if (checkItem.type == veridianMod.Find<ModItem>("CrimsonString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("CrossString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("CursedString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("FrogString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("FrostString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("HoneyString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("HorseshoeString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("IchorString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("JungleString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("LavaString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("MythString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("PumpkinString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("RegenString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("ShadowString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("SharktoothString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("VeilString").Type ||
                   checkItem.type == veridianMod.Find<ModItem>("HellString").Type)
               {
                    return true;
               }
            }
           
            if ((checkItem.type >= 3293 && checkItem.type <= 3308) || checkItem.type == ModContent.ItemType<EclipseString>() || checkItem.type == ModContent.ItemType<GolemsteelString>() ||
                checkItem.type == ModContent.ItemType<SolarString>() || checkItem.type == ModContent.ItemType<FrostbiteString>()||
                checkItem.type == ModContent.ItemType<SlimyString>() || checkItem.type == ModContent.ItemType<DarkGreenString>() || checkItem.type == ModContent.ItemType<DarkBlueString>() ||
                checkItem.type == ModContent.ItemType<LightPinkString>() || checkItem.type == ItemType<DarkTealString>() ||
                checkItem.type == ItemType<GrapeString>())
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 350, Main.screenHeight / 11);
        public override string FunctionalTexture => "CombinationsMod/UI/accessorySlot";
        public override bool DrawDyeSlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Yoyo Strings";
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = "Vanity Yoyo Strings";
                    break;
            }
        }
    }

    public class RingSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ModContent.ItemType<AbilityRing>() || checkItem.type == ModContent.ItemType<AmberRing>() ||
                checkItem.type == ModContent.ItemType<AmethystRing>() || checkItem.type == ModContent.ItemType<TopazRing>() ||
                checkItem.type == ModContent.ItemType<RubyRing>() || checkItem.type == ModContent.ItemType<SapphireRing>() ||
                checkItem.type == ModContent.ItemType<EmeraldRing>() || checkItem.type == ModContent.ItemType<DiamondRing>() ||
                checkItem.type == ModContent.ItemType<GemstoneRing>() || checkItem.type == ModContent.ItemType<FortitudeRing>() ||
                checkItem.type == ModContent.ItemType<TrepidationRing>() || checkItem.type == ModContent.ItemType<OmnipotenceRing>() ||
                checkItem.type == ModContent.ItemType<RingOfCoalescence>() || checkItem.type == ModContent.ItemType<TerreneRing>())
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 50);
        public override string FunctionalTexture => "CombinationsMod/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Yoyo Rings";
                    break;
            }
        }
    }
    public class RingSlot2 : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ModContent.ItemType<AbilityRing>() || checkItem.type == ModContent.ItemType<AmberRing>() ||
                checkItem.type == ModContent.ItemType<AmethystRing>() || checkItem.type == ModContent.ItemType<TopazRing>() ||
                checkItem.type == ModContent.ItemType<RubyRing>() || checkItem.type == ModContent.ItemType<SapphireRing>() ||
                checkItem.type == ModContent.ItemType<EmeraldRing>() || checkItem.type == ModContent.ItemType<DiamondRing>() ||
                checkItem.type == ModContent.ItemType<GemstoneRing>() || checkItem.type == ModContent.ItemType<FortitudeRing>() ||
                checkItem.type == ModContent.ItemType<TrepidationRing>() || checkItem.type == ModContent.ItemType<OmnipotenceRing>() ||
                checkItem.type == ModContent.ItemType<RingOfCoalescence>() || checkItem.type == ModContent.ItemType<TerreneRing>() || checkItem.type == ModContent.ItemType<HoneyRing>())
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 50);
        public override string FunctionalTexture => "CombinationsMod/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Yoyo Rings";
                    break;
            }
        }


    }
    public class YoyoGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ItemID.YoYoGlove)
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 100);
        public override string FunctionalTexture => "CombinationsMod/UI/yoyoGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Right Hand";
                    break;
            }
        }


    }
    public class YoyoSupportGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ModContent.ItemType<SupportGlove>())
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 100);
        public override string FunctionalTexture => "CombinationsMod/UI/supportGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Left Hand";
                    break;
            }
        }
    }
    public class DrillSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ModContent.ItemType<YoyoDrillCasing>() || checkItem.type == ModContent.ItemType<AdamantiteDrillCasing>() ||
                checkItem.type == ModContent.ItemType<CobaltDrillCasing>() || checkItem.type == ModContent.ItemType<HakapikDrillCasing>() ||
                checkItem.type == ModContent.ItemType<HorsemansDrillCasing>() || checkItem.type == ModContent.ItemType<MattockDrillCasing>() ||
                checkItem.type == ModContent.ItemType<MythrilDrillCasing>() || checkItem.type == ModContent.ItemType<OrichalcumDrillCasing>() ||
                checkItem.type == ModContent.ItemType<PalladiumCasing>() || checkItem.type == ModContent.ItemType<ShroomiteShredderCasing>() ||
                checkItem.type == ModContent.ItemType<SpectralShredderCasing>() || checkItem.type == ModContent.ItemType<TitaniumDrillCasing>() ||
                checkItem.type == ModContent.ItemType<TreeClippersDrillCasing>() || checkItem.type == ModContent.ItemType<TsurugiDrillCasing>() ||
                checkItem.type == ModContent.ItemType<SolarDrillCasing>() || checkItem.type == ModContent.ItemType<VortexDrillCasing>() ||
                checkItem.type == ModContent.ItemType<NebulaDrillCasing>() || checkItem.type == ModContent.ItemType<StardustDrillCasing>() ||
                checkItem.type == ModContent.ItemType<CelestialDrillCasing>() || checkItem.type == ModContent.ItemType<CelestialDrillCasingExtended>() ||
                checkItem.type == ModContent.ItemType<MooMooDrillCasing>() || checkItem.type == ModContent.ItemType<ShadowflameDrillCasing>() ||
                checkItem.type == ModContent.ItemType<TheScooperDrillCasing>() || checkItem.type == ModContent.ItemType<NinjaStarCasing>())
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 150);

        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/tealPanel";
        public override string FunctionalTexture => "CombinationsMod/UI/drillSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Drill Casings";
                    break;
            }
        }


    }
    public class CounterweightSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ItemID.BlackCounterweight || checkItem.type == ItemID.BlueCounterweight || checkItem.type == ItemID.GreenCounterweight ||
                checkItem.type == ItemID.PurpleCounterweight || checkItem.type == ItemID.RedCounterweight || checkItem.type == ItemID.YellowCounterweight)
                return true;

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }
        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 150);
        public override string FunctionalTexture => "CombinationsMod/UI/counterweightSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Yoyo Counterweights";
                    break;
            }
        }


    }
}