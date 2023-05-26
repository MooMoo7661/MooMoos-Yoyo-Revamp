using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    public class HitDisplay : ItemLoader
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mechanical Clicker");
            // Tooltip.SetDefault("Displays the current consecutive hits by a Yoyo");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 4, 5, 0);
        }

        public override void UpdateInventory(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.hitTracker = true;
        }

       
    }
}