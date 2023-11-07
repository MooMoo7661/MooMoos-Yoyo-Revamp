using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.ID;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Souls;
using CombinationsMod.UI;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Items.Accessories.Strings
{
    public class NaniteString : ModString
    {
        public override bool CanBeUnloaded => true; 
        
        public override void SetDefaults()
        {

            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4);
            Item.hasVanityEffects = true;
            Item.stringColor = -1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.naniteString = true;
            player.stringColor = -1;
            player.yoyoString = true;
        }
    }
}
