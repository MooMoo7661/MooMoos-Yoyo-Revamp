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

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nanite String");
            Tooltip.SetDefault("Increases yoyo range\n[c/6EAE6E:+150 yoyo range]");
        }
        
        public override void SetDefaults()
        {

            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            Item.canBePlacedInVanityRegardlessOfConditions = true;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.naniteString = true;
                player.stringColor = 32;
                player.yoyoString = true;
            }
        }

        public override void UpdateVanity(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            
                player.stringColor = 32; // Custom string color ID. Vanilla stops at 28, and to keep our String Info accessory working right, we create our own.
        }
    }
}
