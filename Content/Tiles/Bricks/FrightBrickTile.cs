using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using CombinationsMod.Content.Dusts;
using CombinationsMod.Content.Items.Bars;
using Microsoft.Xna.Framework;
using CombinationsMod.Content.Items.Tiles;

namespace CombinationsMod.Content.Tiles.Bricks
{
    public class FrightBrickTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileMerge[Type][Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileLighted[Type] = false;
            Main.tileNoSunLight[Type] = false;
            Main.tileBlockLight[Type] = true;
            DustType = ModContent.DustType<FrightBarTileDust>();
            HitSound = SoundID.Tink;
            RegisterItemDrop(ModContent.ItemType<FrightBrick>());
            AddMapEntry(Color.IndianRed);
        }

        public override void KillTile(int i, int j, ref bool fail, ref bool effectOnly, ref bool noItem)
        {
            Lighting.AddLight(new Vector2(i, j) * 16, TorchID.Red);
            for (int x = 0; x < 4; x++)
                Dust.NewDust(new Vector2(i, j) * 16, 16, 16, DustID.RedTorch);
        }
    }
}
