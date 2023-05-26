using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.ID;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Souls;
using CombinationsMod.UI;

namespace CombinationsMod.Items.Accessories.Strings
{
    public class NebulaString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Nebula String");
            // Tooltip.SetDefault("Increases yoyo range\n[c/6EAE6E:+250 yoyo range]\n[c/6EAE6E:+5% base yoyo damage]");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<DevBagRarity>();
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 5);
            Item.stringColor = 38;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.nebulaString = true;
                player.yoyoString = true;
            }

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.FragmentStardust, 20)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}
