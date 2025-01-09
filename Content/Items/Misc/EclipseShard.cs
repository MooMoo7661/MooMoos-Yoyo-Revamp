using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Misc
{
    [LegacyName("SoulOfEclipse")]
    public class EclipseShard : YoyoModItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = false;
            Item.maxStack = 9999;
            Item.value = Item.sellPrice(0, 1, 55, 0);
        }
    }
}