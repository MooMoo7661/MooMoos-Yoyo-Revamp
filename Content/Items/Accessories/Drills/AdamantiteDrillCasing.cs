using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Drills
{

    public class AdamantiteDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.adamantiteDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}