using CombinationsMod.Items.Accessories.YoyoGloves;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static CombinationsMod.CombinationsModUtils;
using Terraria.Localization;
using CombinationsMod.Items.Accessories.Drills;
using CombinationsMod.Global_Classes;

namespace CombinationsMod.UI
{
    public class StringSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => ItemSets.YoyoString[checkItem.type] || checkItem.ModItem is ModString;

        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoString[item.type];

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().yoyoBag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;
        public override Vector2? CustomLocation => StringPos();
        public override string FunctionalTexture => "CombinationsMod/UI/accessorySlot";
        public override bool DrawDyeSlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoStrings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.VanityStrings");
                    break;
            }
        }
    }

    public class YoyoGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => ItemSets.YoyoGlove[checkItem.type];

        public override bool IsVisibleWhenNotEnabled() => false;

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().yoyoBag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoGlove[item.type];

        public override Vector2? CustomLocation => RightGlovePos();
        public override string FunctionalTexture => GetInstance<YoyoModConfig>().UpscaleYoyoGlove ? "CombinationsMod/UI/YoyoGloveSlotLarge" : "CombinationsMod/UI/YoyoGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.RightHand") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                    Main.hoverItemName += " (" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoGloves") + ")";
                    break;
            }
        }
    }
    public class YoyoSupportGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => checkItem.type == ModContent.ItemType<SupportGlove>();

        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.SupportGlove[item.type];

        public override Vector2? CustomLocation => LeftGlovePos();

        public override string FunctionalTexture => GetInstance<YoyoModConfig>().UpscaleYoyoGlove ? "CombinationsMod/UI/SupportGloveSlotLarge" : "CombinationsMod/UI/SupportGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.LeftHand") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                        Main.hoverItemName += " (" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SupportGloves") + ")";
                    break;
            }
        }
    }
    public class DrillSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => checkItem.ModItem is ModDrill || ItemSets.DrillCasing[checkItem.type];

        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.DrillCasing[item.type];

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().tier2Bag || Player.GetModPlayer<YoyoModPlayer>().shimmerBag || Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

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
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.DrillCasings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
            }
        }
    }

    public class CounterweightSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => ItemSets.Counterweight[checkItem.type];
        public override bool IsVisibleWhenNotEnabled() => false;

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

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.Counterweight[item.type];

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
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
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoCounterweights") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
            }
        }
    }

    public class RingSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => checkItem.ModItem is ModRing || ItemSets.YoyoRing[checkItem.type];
        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoRing[item.type];

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

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
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Rings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
            }
        }


    }

    public class RingSlot2 : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => checkItem.ModItem is ModRing || ItemSets.YoyoRing[checkItem.type];
        public override bool IsVisibleWhenNotEnabled() => false;

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().beetleBag || Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoRing[item.type];

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

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
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Rings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
            }
        }
    }

    public class TrickSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => ItemSets.Trick[checkItem.type];
        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().moonlordBag;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.Trick[item.type];

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

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
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Tricks") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SlotPrefix");
                    break;
            }
        }
    }
}