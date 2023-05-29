using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    public class SpeedDisplay : ItemLoader
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yoyo Radar");
            Tooltip.SetDefault("Displays how fast a Yoyo can move");
        }

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 2, 5, 0);


        }

        public override void UpdateInventory(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.speedTracker = true;
        }
    }
}