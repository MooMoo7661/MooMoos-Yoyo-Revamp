using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Drills
{
    public class TitaniumDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 13, silver: 60);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.titaniumDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TitaniumBar, 20);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}