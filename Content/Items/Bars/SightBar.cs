using CombinationsMod.Content.Tiles.Bars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Bars
{
    public class SightBar : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 26;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1, silver: 2);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<SightBarTile>();
            Item.placeStyle = 0;
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ItemID.SoulofSight, 1);
            recipe.AddRecipeGroup(CombinationsModSystem.adamantiteBarRecipeGroup, 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }


    }
}