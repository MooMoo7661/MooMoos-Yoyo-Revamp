using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.ModSystems;

namespace CombinationsMod.Content.Items.Accessories.Tricks
{
    public class DualYoyo : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 5);
            ItemSets.Trick[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().dualYoyo = true;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.Book)
                .AddRecipeGroup(CombinationsModSystem.cobaltBarRecipeGroup, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
