using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.ModSystems;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class DiamondRing : ModItem
    {
         

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 3, 2, 0);
            ItemSets.YoyoRing[Type] = true;
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
            recipe.AddRecipeGroup(CombinationsModSystem.goldBarRecipeGroup, 5);
            recipe.AddIngredient(ItemID.Diamond, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}