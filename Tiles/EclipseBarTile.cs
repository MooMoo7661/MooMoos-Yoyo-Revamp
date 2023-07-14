using CombinationsMod.Items.Bars;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CombinationsMod.Tiles;

public class EclipseBarTile  : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileShine[Type] = 699;
        Main.tileSolid[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;
        DustType = 54;
        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<EclipseBar>());
    }
}