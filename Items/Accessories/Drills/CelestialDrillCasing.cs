using CombinationsMod.Items.Bars;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Drills
{
    public class CelestialDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Drill Casing");
            Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:250% pickaxe power]\n+1 range");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 6);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.celestialDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<NebulaDrillCasing>());
            recipe.AddIngredient(ModContent.ItemType<SolarDrillCasing>());
            recipe.AddIngredient(ModContent.ItemType<VortexDrillCasing>());
            recipe.AddIngredient(ModContent.ItemType<StardustDrillCasing>());
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ModContent.ItemType<CelestialDrillCasingExtended>());
            recipe2.AddIngredient(ItemID.LunarBar, 3);
            recipe2.AddTile(TileID.LunarCraftingStation);
            recipe2.Register();
        }
    }
}