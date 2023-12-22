using CombinationsMod.Content.Items.Bars;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CombinationsMod.Content.Tiles;

public class MightBarTile : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileShine[Type] = 699;
        Main.tileSolid[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;

        DustType = 154;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<MightBar>());
    }
}