using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Keybindings;
using CombinationsMod.Content.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using CombinationsMod.Content.Utility;

namespace CombinationsMod.Content.Global_Classes
{
   public class TooltipModifiers : GlobalItem
   {
        public override bool InstancePerEntity => true;
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ItemSets.DrillCasing[item.type])
            {
                var obj = KeybindInputs.GetKeybindDisplayName(KeybindSystem.DrillKeybind.GetAssignedKeys().FirstOrDefault()) ?? "[c/565558:<unbound>]"; // Attempts to find a custom set display name for keybinds. If none is found, the input is returned again. Example : Inputting "Mouse2" will return "Right Click"
                LocalizedText rightClick = Language.GetText($"Mods.CombinationsMod.LocalizedText.RightClickInfo").WithFormatArgs(obj); // formatting the string to display the current keybind name
                tooltips.Add(new TooltipLine(Mod, "RightClickInfo", rightClick.Value));
            }

            if (ItemSets.Counterweight[item.type]) // Is a counterweight -> display "creates one counterweight per yoyo"
            {
                tooltips.Add(new TooltipLine(Mod, "CounterweightStackInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.CounterweightPerYoyo")));
            }

            if ((ItemID.Sets.Yoyo[item.type] || ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99))
            {

                if (Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().CurrentDrillType != 0)
                {
                    if (ContentSamples.ProjectilesByType[Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().CurrentDrillType].ModProjectile is BaseDrill drill)
                    {
                        tooltips.Add(new TooltipLine(Mod, "CounterweightStackInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.CurrentDrill") + ContentSamples.ItemsByType[drill.DrillItem].Name));
                    }
                }

                if (!Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().yoyoRing) // if player does not have a yoyo ring, only show "no ability ring detected" prompt.
                {
                    tooltips.Add(new TooltipLine(Mod, "NoRing", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.NoRing")));
                }
                else
                {
                    if (!KeybindSystem.AbilityKeybind.Current) // if not currently holding ability keybind, display that it needs to be held to show ability
                    {
                        LocalizedText holdDown = Language.GetText($"Mods.CombinationsMod.LocalizedText.HoldDown").WithFormatArgs(KeybindInputs.GetKeybindDisplayName(KeybindSystem.AbilityKeybind.GetAssignedKeys().FirstOrDefault()) ?? "][c/565558:<unbound>][c/6FD4FF:");

                        tooltips.Add(new TooltipLine(Mod, "HoldDown", holdDown.Value));
                    }
                    else // currently holding down keybind
                    {
                        CombinationsModSystem combinationsModSystem = new CombinationsModSystem();
                        string localizedText = combinationsModSystem.GetLocalizedStringFromDictionary(Main.HoverItem.type);
                        if (localizedText == null)
                        {
                            tooltips.Add(new TooltipLine(Mod, "NoAbility", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.NoAbility")));
                        }
                        else
                        {
                            tooltips.Add(new TooltipLine(Mod, "YoyoAbilitySnippet", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoAbilitySnippet")));
                            tooltips.Add(new TooltipLine(Mod, "AbilityInfo", localizedText));
                        }
                    }
                }
            }

            if (item.type >= ItemID.RedString && item.type <= ItemID.BlackString) // basic vanilla strings all give 150 yoyo range
            {
                tooltips.Add(new TooltipLine(Mod, "YoyoStringInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.150YoyoRange")));
            }

            switch (item.type)
            {
                case ItemID.YoyoBag: // rewriting vanilla yoyo bag tooltip
                    if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                    {
                        int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
                        tooltips.RemoveAll(tip => tip.Name.StartsWith("Tooltip"));
                        tooltips.Add(new TooltipLine(Mod, "YoyoBagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MoreAccessorySlots")));
                    }
                    break;
            }
        }
    }
}
