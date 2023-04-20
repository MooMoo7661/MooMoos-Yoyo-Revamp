using CombinationsMod.Items.Bars;
using CombinationsMod.UI;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Drills
{
    public class MooMooDrillCasing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("MooMoo's Drill");
            Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:250% pickaxe power]\n+2 range");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.Quest;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 28);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.moomooDrill = true;
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<DrillSlot>().Type;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Insert(1, new TooltipLine(Mod, "YoyoType", "[c/FF32DE:Dev Item]"));
        }
    }
}