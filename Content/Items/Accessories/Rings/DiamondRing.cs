using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class DiamondRing : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 3, 2, 0);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.diamondRing = true;
        }

        public override void UpdateVanity(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.diamondRing = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(CombinationsModSystem.silverBarRecipeGroup, 5);
            recipe.AddIngredient(ItemID.Diamond, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}