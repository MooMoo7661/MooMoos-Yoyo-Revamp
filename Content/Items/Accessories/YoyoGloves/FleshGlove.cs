using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.YoyoGloves
{
    public class FleshGlove : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 30;
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold:2);
            ItemSets.YoyoGlove[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.fleshGlove = true;
            modPlayer.YoyoSpeedModifier += 4.5f;
            modPlayer.YoyoLifetimeModifier += 5f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.CrimtaneBar, 6)
                .AddIngredient(ItemID.Silk, 3)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }
}