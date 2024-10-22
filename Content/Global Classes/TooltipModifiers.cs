using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Keybindings;
using CombinationsMod.Content.ModPlayers;
using System;
using System.Collections.Generic;
using System.Linq;
using CombinationsMod.Content.ModSystems;

namespace CombinationsMod.Content.Global_Classes
{
   public class TooltipModifiers : GlobalItem
   {
        public override bool InstancePerEntity => true;

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (ItemSets.DrillCasing[item.type])
            {
                Color color = Color.Lerp(Color.HotPink, Color.MediumPurple, (MathF.Sin(Main.GlobalTimeWrappedHourly * 2.9f) + 1) / 2f);
                string obj = KeybindInputs.GetKeybindDisplayName(KeybindSystem.DrillKeybind.GetAssignedKeys().FirstOrDefault()) ?? "[c/565558:<unbound>]"; // Attempts to find a custom set display name for keybinds. If none is found, the input is returned again. Example : Inputting "Mouse2" will return "Right Click"
                LocalizedText rightClick = Language.GetText($"Mods.CombinationsMod.LocalizedText.RightClickInfo").WithFormatArgs(obj); // formatting the string to display the current keybind name
                tooltips.Add(new TooltipLine(Mod, "RightClickInfo", rightClick.Value.ToHexString(color)));
            }

            if (ItemSets.Counterweight[item.type]) // Is a counterweight -> display "creates one counterweight per yoyo"
            {
                tooltips.Add(new TooltipLine(Mod, "CounterweightStackInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.CounterweightPerYoyo")));
            }

            if (ItemID.Sets.Yoyo[item.type] || ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                AddStatTooltips(item, ref tooltips);

                if (Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().CurrentDrillType != 0)
                {
                    if (ContentSamples.ProjectilesByType[Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().CurrentDrillType].ModProjectile is BaseDrill drill)
                    {
                        tooltips.Add(new TooltipLine(Mod, "CurrentDrill", (Language.GetTextValue("Mods.CombinationsMod.LocalizedText.CurrentDrill") + ContentSamples.ItemsByType[drill.DrillItem].Name).ToHexString("5F65FF")));
                    }
                }

                if (!Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().yoyoRing) // if player does not have a yoyo ring, only show "no ability ring detected" prompt.
                    tooltips.Add(new TooltipLine(Mod, "NoRing", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.NoRing")));
                else
                {
                    if (!KeybindSystem.AbilityKeybind.Current) // if not currently holding ability keybind, display that it needs to be held to show ability
                    {
                        LocalizedText holdDown = Language.GetText($"Mods.CombinationsMod.LocalizedText.HoldDown").WithFormatArgs(KeybindInputs.GetKeybindDisplayName(KeybindSystem.AbilityKeybind.GetAssignedKeys().FirstOrDefault()) ?? "][c/565558:<unbound>][c/6FD4FF:");
                        tooltips.Add(new TooltipLine(Mod, "HoldDown", holdDown.Value));
                    }
                    else // currently holding down keybind
                    {
                        string localizedText = CombinationsModSystem.GetLocalizedStringFromDictionary(Main.HoverItem.type);
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

            if (item.type == ItemID.YoyoBag && ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
                tooltips.RemoveAll(tip => tip.Name.StartsWith("Tooltip"));
                tooltips.Add(new TooltipLine(Mod, "YoyoBagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MoreAccessorySlots")));
            }
        }

        private void AddStatTooltips(Item item, ref List<TooltipLine> tooltips)
        {
            if (ModLoader.TryGetMod("YoyoStats", out _))
                return;

            Projectile proj = ContentSamples.ProjectilesByType[item.shoot];
            var instance = ModContent.GetInstance<YoyoModConfig>();
            string localPath = "Mods.CombinationsMod.LocalizedText.StatTooltips.";

            int updates = proj.MaxUpdates;
            if (proj.extraUpdates == 0) { updates = 1; }

            float yoyoSpeed = ProjectileID.Sets.YoyosTopSpeed[item.shoot] * updates;
            float yoyoRange = (float)Math.Round(ProjectileID.Sets.YoyosMaximumRange[item.shoot] / 16f, 1);
            float yoyoLifetime = ProjectileID.Sets.YoyosLifeTimeMultiplier[item.shoot];
            int maxHits = ContentSamples.ProjectilesByType[item.shoot].penetrate;

            int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Speed"));
            if (index < 0)
                index = tooltips.Count - 1;


            if (instance.MaxHits)
                tooltips.Insert(index, new TooltipLine(Mod, "Hits", maxHits > 0 ? Language.GetText(localPath + "Hits").WithFormatArgs(maxHits).Value : Language.GetText(localPath + "NoMaxHits").Value));

            if (instance.YoyoLifetime)
                tooltips.Insert(index, new TooltipLine(Mod, "Lifetime", yoyoLifetime > 0 ? Language.GetText(localPath + "Lifetime").WithFormatArgs(yoyoLifetime, yoyoLifetime > 1 ? "" : "s").Value : Language.GetText(localPath + "InfiniteLifetime").Value));

            if (instance.YoyoRange)
                tooltips.Insert(index, new TooltipLine(Mod, "Range", Language.GetText(localPath + "Range").WithFormatArgs(yoyoRange).Value));

            if (instance.YoyoSpeed)
                tooltips.Insert(index, new TooltipLine(Mod, "Speed", Language.GetText(localPath + "Speed").WithFormatArgs(yoyoSpeed).Value));
        }
   }
}
