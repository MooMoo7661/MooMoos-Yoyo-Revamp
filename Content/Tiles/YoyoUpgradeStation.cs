using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinationsMod.Content.UI.UpgradeStationUI;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ObjectData;

namespace CombinationsMod.Content.Tiles
{
    public class YoyoUpgradeStation : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileID.Sets.IgnoredByNpcStepUp[Type] = true;
            TileID.Sets.PreventsSandfall[Type] = true;
            TileID.Sets.AvoidedByMeteorLanding[Type] = true;
            TileID.Sets.PreventsTileReplaceIfOnTopOfIt[Type] = true;
            TileID.Sets.PreventsTileRemovalIfOnTopOfIt[Type] = true;
            DustType = DustID.WoodFurniture;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);

            // Etc
            AddMapEntry(new Color(255, 88, 255), Language.GetText("Mods.CombinationsMod.Tiles.PlanteraAltar.MapEntry"));
        }

        public override bool RightClick(int i, int j)
        {
            if (ModContent.GetInstance<UpgradeStationUISystem>().IsUIOpen())
            {
                SoundEngine.PlaySound(SoundID.MenuClose);
                ModContent.GetInstance<UpgradeStationUISystem>().HideMyUI();
            }
            else
            {
                SoundEngine.PlaySound(SoundID.MenuOpen);
                ModContent.GetInstance<UpgradeStationUISystem>().ShowMyUI();

                Main.playerInventory = true;
            }

            return true;
        }

        public override void MouseOverFar(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemID.IronHammer;

        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ItemID.IronHammer;
        }

    }
}
