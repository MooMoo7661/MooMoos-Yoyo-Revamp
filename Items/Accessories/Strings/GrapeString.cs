﻿using Terraria;
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
    public class GrapeString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Grape String");
            // Tooltip.SetDefault("Increases yoyo range\nSmells like grapes\n[c/6EAE6E:+150 yoyo range]");
        }
        
        public override void SetDefaults()
        {

            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            Item.hasVanityEffects = true;
            
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.grapeString = true;
                player.stringColor = 34;
                player.yoyoString = true;
            }

        }

        public override void UpdateVanity(Player player)
        {
                player.stringColor = 34; // Custom string color ID. Vanilla stops at 28, and to keep our String Info accessory working right, we create our own.
        }
    }
}
