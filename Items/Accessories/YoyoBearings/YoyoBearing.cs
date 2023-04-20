using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Tiles;
using CombinationsMod.UI;


namespace CombinationsMod.Items.Accessories.YoyoBearings
{
    public class YoyoBearing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yoyo Bearing");
            Tooltip.SetDefault("Allows for the creation of Yoyo Bearings that add special effects");
            
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.accessory = false;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup("IronBar", 10);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}