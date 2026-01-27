using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.ModSystems;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.YoyoGloves
{
    public class CrystalGlove : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 28;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold:3);
            ItemSets.YoyoGlove[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.crystalGlove = true;
            modPlayer.YoyoSpeedModifier += 6f;
            modPlayer.YoyoLifetimeModifier += 10f;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddRecipeGroup(CombinationsModSystem.mythrilBarRecipeGroup, 6)
                .AddIngredient(ItemID.CrystalShard, 15)
                .AddIngredient(ItemID.SoulofLight, 10)
                .AddTile(TileID.MythrilAnvil)
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