using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using CombinationsMod.Content.ModSystems;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class TopazRing : ModRing
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
            Utility.ItemSets.YoyoRing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.topazRing = true;
        }

        public override void UpdateVanity(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.topazRing = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(CombinationsModSystem.silverBarRecipeGroup, 5);
            recipe.AddIngredient(ItemID.Topaz, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}