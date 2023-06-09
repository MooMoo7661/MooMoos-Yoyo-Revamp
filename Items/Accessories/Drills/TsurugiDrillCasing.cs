using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Drills
{
    public class TsurugiDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tsurugi");
            // Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:210% pickaxe power]\n+1 range\nCapable of mining Lihzahrd Bricks");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4, silver: 32);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.golemDrill = true;
        }
    }
}