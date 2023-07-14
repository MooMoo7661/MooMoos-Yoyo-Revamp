using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Souls;

namespace CombinationsMod.Items.Bars
{
    public class MightBar : ItemLoader
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Might Bar");
            // Tooltip.SetDefault("'Forged from the essence of powerful creatures'");
        }

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
            Item.createTile = ModContent.TileType<Tiles.MightBarTile>();
            Item.placeStyle = 0;
            Item.rare = ItemRarityID.LightPurple;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.SoulofMight, 1);
            recipe.AddRecipeGroup(CombinationsModSystem.adamantiteBarRecipeGroup, 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }


    }
}