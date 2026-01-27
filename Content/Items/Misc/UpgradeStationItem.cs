using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Misc
{
    public class UpgradeStationItem : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 24;

            Item.placeStyle = 0;
            Item.consumable = true;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.maxStack = Item.CommonMaxStack;
            Item.createTile = ModContent.TileType<YoyoUpgradeStation>();
            Item.rare = ItemRarityID.Pink;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.useAnimation = 15;
        }
    }
}
