using System.Collections.Generic;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.GlobalClasses
{
    public class GlobalString : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            bool damageChanges = ModContent.GetInstance<YoyoModConfig>().VanillaYoyoDamageChanges;


            if (item.type == ItemID.TheEyeOfCthulhu && ModContent.GetInstance<YoyoModConfig>().EOCYoyoProgressionMovement)
            {
                item.damage = 49;
                item.knockBack = 3.9f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(0, 4, 2, 0);
            }
            else if (item.type == ItemID.Gradient && damageChanges)
            {
                item.damage = 57;
            }
            else if (item.type == ItemID.Code1 && damageChanges)
            {
                item.damage = 24;
            }
            else if ((item.type == ItemID.ValkyrieYoyo || item.type == ItemID.RedsYoyo) && damageChanges)
            {
                item.damage = 64;
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {

            if (item.type == ItemID.YoyoBag)
                player.GetModPlayer<YoyoModPlayer>().yoyoBag = true;
        }



        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.trepidationRing && ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                damage *= 1.05f;
            }

            if (modPlayer.solarString || modPlayer.stardustString || modPlayer.vortexString || modPlayer.nebulaString
                && (ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99 || ItemID.Sets.Yoyo[item.type]))
            {
                damage *= 1.05f;
            }
        }

        public override void ModifyWeaponKnockback(Item item, Player player, ref StatModifier knockback)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (modPlayer.fortitudeRing)
            {
                knockback.Flat += 2f;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type >= ItemID.BlackCounterweight && item.type <= ItemID.YellowCounterweight) // Is a counterweight
            {
                tooltips.Add(new TooltipLine(Mod, "CounterweightStackInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.CounterweightPerYoyo")));
            }

            if ((ItemID.Sets.Yoyo[item.type] || ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99))
            {
                if (!Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().yoyoRing)
                {
                    tooltips.Add(new TooltipLine(Mod, "NoRing", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.NoRing")));
                }
                else
                {
                    if (!Main.LocalPlayer.controlDown)
                    {
                        tooltips.Add(new TooltipLine(Mod, "HoldDown", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.HoldDown")));
                    }
                    else
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

            if (item.type >= ItemID.RedString && item.type <= ItemID.BlackString)
            {

                tooltips.Add(new TooltipLine(Mod, "YoyoStringInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.150YoyoRange")));
            }
            switch (item.type)
            {
                case ItemID.YoyoBag:
                    if (GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
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
