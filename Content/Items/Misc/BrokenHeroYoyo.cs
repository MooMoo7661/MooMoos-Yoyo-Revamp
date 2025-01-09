using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Misc;

public class BrokenHeroYoyo : YoyoModItemLoader
{
    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 26;
        Item.maxStack = 99;
        Item.value = Item.sellPrice(gold: 6, silver: 20);
        Item.rare = ItemRarityID.Yellow;
    }
}
