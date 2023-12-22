using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.InfoAccessories
{
    public class HitDisplay : ItemLoader
    {
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