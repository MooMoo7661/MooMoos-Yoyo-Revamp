using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.Items.Misc;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class TrepidationRing : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 12, 55, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            modPlayer.trepidationRing = true;

        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroRing>());
            recipe.AddIngredient(ModContent.ItemType<EclipseBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<FrightBar>(), 10);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}