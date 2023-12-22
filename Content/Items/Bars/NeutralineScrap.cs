using CombinationsMod.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Bars
{
    public class NeutralineScrap : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1, silver: 82);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.NeutralineScrapTile>();
            Item.placeStyle = 0;
            Item.rare = ModContent.RarityType<EclipseRarity>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddRecipeGroup(CombinationsModSystem.eclipseWeaponGroup);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.DisableDecraft();
            recipe.Register();
        }
    }
}