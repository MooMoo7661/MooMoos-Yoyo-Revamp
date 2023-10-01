﻿using CombinationsMod.Items.Bars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Tricks
{
    public class ShootToTheMoon : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().moonTrick = true;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Book)
                .AddIngredient(ItemID.Cloud, 15)
                .AddIngredient(ItemID.FallenStar, 1)
                .AddIngredient(ModContent.ItemType<EclipseBar>(), 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
