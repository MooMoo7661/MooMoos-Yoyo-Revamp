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
using ReLogic;
using CombinationsMod.Items.Accessories.YoyoBags;
using static CombinationsMod.CombinationsModUtils;
using Terraria.GameContent;
using CombinationsMod.Items.Accessories.Tricks;

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

            return checkItem.ModItem is ModString;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().yoyoBag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override Vector2? CustomLocation => StringPos();
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

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().yoyoBag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override Vector2? CustomLocation => RightGlovePos();
        public override string FunctionalTexture => GetInstance<YoyoModConfig>().UpscaleYoyoGlove ? "CombinationsMod/UI/YoyoGloveSlotLarge" : "CombinationsMod/UI/YoyoGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Right Hand";
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                    Main.hoverItemName += " (Yoyo Gloves)";
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

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override Vector2? CustomLocation => LeftGlovePos();

        public override string FunctionalTexture => GetInstance<YoyoModConfig>().UpscaleYoyoGlove ? "CombinationsMod/UI/SupportGloveSlotLarge" : "CombinationsMod/UI/SupportGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Left Hand";
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                        Main.hoverItemName += "(Support Gloves)";
                    break;
            }
        }
    }
    public class DrillSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.ModItem is ModDrill;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override Vector2? CustomLocation => DrillPos();

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
            return checkItem.type == ItemID.BlackCounterweight || checkItem.type == ItemID.BlueCounterweight || checkItem.type == ItemID.GreenCounterweight ||
                checkItem.type == ItemID.PurpleCounterweight || checkItem.type == ItemID.RedCounterweight || checkItem.type == ItemID.YellowCounterweight;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().yoyoBag ||
                Player.GetModPlayer<YoyoModPlayer>().shimmerBag ||
                Player.GetModPlayer<YoyoModPlayer>().tier2Bag ||
                Player.GetModPlayer<YoyoModPlayer>().beetleBag ||
                Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;
        }

        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => CounterweightPos();
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

    public class RingSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.ModItem is ModRing;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => RingPos1();
        public override string FunctionalTexture => "CombinationsMod/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Rings";
                    break;
            }
        }


    }

    public class RingSlot2 : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            if (checkItem.type == ItemType<RingOfCoalescence>() || checkItem.type == ItemType<AbilityRing>() || checkItem.type == ItemType<AmberRing>() ||
                checkItem.type == ItemType<AmethystRing>() || checkItem.type == ItemType<DiamondRing>() || checkItem.type == ItemType<EmeraldRing>() ||
                checkItem.type == ItemType<FortitudeRing>() || checkItem.type == ItemType<GemstoneRing>() || checkItem.type == ItemType<OmnipotenceRing>() ||
                checkItem.type == ItemType<RubyRing>() || checkItem.type == ItemType<SapphireRing>() || checkItem.type == ItemType<TerreneRing>() ||
                checkItem.type == ItemType<TopazRing>() || checkItem.type == ItemType<TrepidationRing>())
            {
                return true;
            }

            return false;
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => RingPos2();
        public override string FunctionalTexture => "CombinationsMod/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Rings";
                    break;
            }
        }


    }

    public class TrickSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context)
        {
            return checkItem.type == ItemType<AroundTheWorld>() || checkItem.type == ItemType<AroundTheWorldTier2>() || checkItem.type == ItemType<DualYoyo>();
        }
        public override bool IsVisibleWhenNotEnabled()
        {
            return false;
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return true;
        }

        public override string FunctionalBackgroundTexture => "CombinationsMod/UI/PanelColors/pinkPanel";
        public override Vector2? CustomLocation =>  TrickPos();
        public override string FunctionalTexture => "CombinationsMod/UI/TrickSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = "Tricks";
                    break;
            }
        }


    }
}