using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Rarities;
using CombinationsMod.Content.ModSystems;

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
            Utility.ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().eclipseString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoSpeedModifier += 2f;
            player.yoyoString = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<EclipseBar>(), 3)
                .AddRecipeGroup(CombinationsModSystem.yoyoStringGroup)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
