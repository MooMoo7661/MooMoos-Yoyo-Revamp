using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.Items.Souls;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Rarities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class EclipseString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<EclipseRarity>();
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 5);
            Item.stringColor = 2;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.eclipseString = true;
            player.yoyoString = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EclipseBar>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SoulOfEclipse>(), 10);
            recipe.AddRecipeGroup(CombinationsModSystem.yoyoStringGroup);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
