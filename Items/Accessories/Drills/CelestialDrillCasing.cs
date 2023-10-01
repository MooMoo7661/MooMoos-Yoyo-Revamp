using CombinationsMod.Items.Bars;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Drills
{
    public class CelestialDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Celestial Drill Casing");
            // Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:250% pickaxe power]\n+1 range");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.celestialDrill = true;
        }
    }
}