using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Souls;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Items.Bars
{
    public class EclipseBar : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Eclipse Bar");
            Tooltip.SetDefault("Radiates otherworldly energy");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1, silver: 22);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.EclipseBarTile>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
            Item.placeStyle = 0;
            Item.rare = ModContent.RarityType<EclipseRarity>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SoulOfEclipse>(), 2);
            recipe.AddIngredient(ModContent.ItemType<NeutralineScrap>());
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }


    }
}