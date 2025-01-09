using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Tricks
{
    public class ShootToTheMoon : YoyoModItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 34;
            Item.height = 36;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
            CombinationsMod.Content.Utility.ItemSets.Trick[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().moonTrick = true;
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
                .AddIngredient(ItemID.Cloud, 15)
                .AddIngredient(ItemID.FallenStar, 1)
                .AddIngredient(ModContent.ItemType<EclipseBar>(), 3)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}
