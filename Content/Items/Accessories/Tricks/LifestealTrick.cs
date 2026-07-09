using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.ModSystems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Tricks
{
    public class LifestealTrick : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
            ItemSets.Trick[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().lifestealTrick = true;
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
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddIngredient(ItemID.DarkShard, 1)
                .AddIngredient(ItemID.Deathweed, 2)
                .AddRecipeGroup(CombinationsModSystem.mythrilBarRecipeGroup, 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();

            CreateRecipe()
                .AddIngredient(ItemID.Book)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddIngredient(ItemID.LightShard, 1)
                .AddIngredient(ItemID.Deathweed, 2)
                .AddRecipeGroup(CombinationsModSystem.mythrilBarRecipeGroup, 6)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
