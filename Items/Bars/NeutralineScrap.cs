using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Souls;

namespace CombinationsMod.Items.Bars
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
            Item.createTile = ModContent.TileType<Tiles.NeutralineScrapTile>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
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