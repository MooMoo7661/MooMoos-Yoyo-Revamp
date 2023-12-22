using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Misc
{
    public class BrokenHeroRing : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = false;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(0, 1, 55, 0);
        }
    }
}