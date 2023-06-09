﻿using CombinationsMod.Items.Bars;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace CombinationsMod.Tiles;

public class FrightBarTile  : ModTile
{
    public override void SetStaticDefaults()
    {
        Main.tileShine[Type] = 699;
        Main.tileSolid[Type] = true;
        Main.tileSolidTop[Type] = true;
        Main.tileFrameImportant[Type] = true;

        TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
        TileObjectData.newTile.StyleHorizontal = true;
        TileObjectData.newTile.LavaDeath = false;
        TileObjectData.addTile(Type);

        RegisterItemDrop(ModContent.ItemType<FrightBar>());
    }
}