using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Items.Accessories.Tricks
{
    public class AroundTheWorldTier2 : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 7);
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (equippedItem.type == ItemType<AroundTheWorld>())
            {
                return false;
            }

            return true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().trick2 = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<AroundTheWorld>())
                .AddIngredient(ItemType<MightBar>(), 2)
                .AddIngredient(ItemType<SightBar>(), 2)
                .AddIngredient(ItemType<FrightBar>(), 2)
                .AddIngredient(ItemID.SoulofNight, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }
}
