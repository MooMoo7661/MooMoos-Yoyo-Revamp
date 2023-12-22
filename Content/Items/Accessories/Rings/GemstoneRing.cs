using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class GemstoneRing : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 12, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.gemRing = true;
        }

        public override void UpdateVanity(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.gemRing = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AmberRing>());
            recipe.AddIngredient(ModContent.ItemType<AmethystRing>());
            recipe.AddIngredient(ModContent.ItemType<TopazRing>());
            recipe.AddIngredient(ModContent.ItemType<RubyRing>());
            recipe.AddIngredient(ModContent.ItemType<SapphireRing>());
            recipe.AddIngredient(ModContent.ItemType<EmeraldRing>());
            recipe.AddIngredient(ModContent.ItemType<DiamondRing>());
            recipe.AddRecipeGroup(CombinationsModSystem.goldBarRecipeGroup, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}