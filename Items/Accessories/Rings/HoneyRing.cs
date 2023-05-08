using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class HoneyRing : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Honey Ring");
            // Tooltip.SetDefault("Increases the strength of friendly bees\nCan be equipped in regular slots");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 18, 49);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!hideVisual)
                player.strongBees = true;
        }
    }
}