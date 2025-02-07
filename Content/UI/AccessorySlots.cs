﻿using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Accessories.YoyoGloves;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static CombinationsMod.Content.Utility.CombinationsModUtils;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.UI
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().stringSlot;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;
        public override Vector2? CustomLocation => StringPos();
        public override string FunctionalTexture => "CombinationsMod/Content/UI/accessorySlot";
        public override bool DrawDyeSlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.YoyoStrings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
                    break;
                case AccessorySlotType.VanitySlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.VanityStrings");
                    break;
            }
        }
    }

    public class YoyoGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => ItemSets.YoyoGlove[checkItem.type] || checkItem.type == ModContent.ItemType<SupportGlove>();

        public override bool IsVisibleWhenNotEnabled() => false;

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().gloveSlot;
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
        public override string FunctionalTexture => "CombinationsMod/Content/UI/YoyoGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.RightHand") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                        Main.hoverItemName += " (" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.YoyoGloves") + ")";
                    break;
            }
        }
    }
    public class YoyoSupportGloveSlot : ModAccessorySlot
    {
        public override bool CanAcceptItem(Item checkItem, AccessorySlotType context) => checkItem.type == ItemType<SupportGlove>();

        public override bool IsVisibleWhenNotEnabled() => false;

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsEnabled()
        {
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().supportGloveSlot;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.SupportGlove[item.type];

        public override Vector2? CustomLocation => LeftGlovePos();

        public override string FunctionalTexture => "CombinationsMod/Content/UI/SupportGloveSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.LeftHand") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
                    if (GetInstance<YoyoModConfig>().AccessorySlotIndicators)
                        Main.hoverItemName += " (" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SupportGloves") + ")";
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().drillSlot;
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override Vector2? CustomLocation => DrillPos();

        public override string FunctionalBackgroundTexture => "CombinationsMod/Content/UI/PanelColors/tealPanel";
        public override string FunctionalTexture => "CombinationsMod/Content/UI/drillSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.DrillCasings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().counterweightSlot;
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

        public override string FunctionalBackgroundTexture => "CombinationsMod/Content/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => CounterweightPos();
        public override string FunctionalTexture => "CombinationsMod/Content/UI/counterweightSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.YoyoCounterweights") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().ringSlot1;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoRing[item.type];

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override string FunctionalBackgroundTexture => "CombinationsMod/Content/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => RingPos1();
        public override string FunctionalTexture => "CombinationsMod/Content/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;
        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.Rings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().ringSlot1;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.YoyoRing[item.type];

        public override void ApplyEquipEffects()
        {
            Player.GrantArmorBenefits(FunctionalItem);
            Player.ApplyEquipFunctional(FunctionalItem, HideVisuals);
            Player.ApplyEquipVanity(VanityItem);
        }

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override string FunctionalBackgroundTexture => "CombinationsMod/Content/UI/PanelColors/tealPanel";
        public override Vector2? CustomLocation => RingPos2();
        public override string FunctionalTexture => "CombinationsMod/Content/UI/ringSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;

        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.Rings") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
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
            if (!GetInstance<YoyoModConfig>().EnableModifiedYoyoBag || !Player.TryGetModPlayer<YoyoModPlayer>(out YoyoModPlayer _))
            {
                return false;
            }

            return Player.GetModPlayer<YoyoModPlayer>().trickSlot;
        }

        public override bool ModifyDefaultSwapSlot(Item item, int accSlotToSwapTo) => ItemSets.Trick[item.type];

        public override bool IsLoadingEnabled(Mod mod) => GetInstance<YoyoModConfig>().EnableModifiedYoyoBag;

        public override string FunctionalBackgroundTexture => "CombinationsMod/Content/UI/PanelColors/pinkPanel";
        public override Vector2? CustomLocation => TrickPos();
        public override string FunctionalTexture => "CombinationsMod/Content/UI/TrickSlot";
        public override bool DrawDyeSlot => false;
        public override bool DrawVanitySlot => false;

        public override void OnMouseHover(AccessorySlotType context)
        {
            switch (context)
            {
                case AccessorySlotType.FunctionalSlot:
                    Main.hoverItemName = Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.Tricks") +
                        "\n" + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SlotPrefix");
                    break;
            }
        }
    }
}