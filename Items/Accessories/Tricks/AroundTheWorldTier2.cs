using CombinationsMod.Items.Bars;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Items.Accessories.Tricks
{
    public class AroundTheWorldTier2 : ItemLoader
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Around The World Tier 2");
            Tooltip.SetDefault("Medium-value trick\nCreates 2 seperate yoyos that swirl around the player in a circle that do 2.5x damage.\nRange stacks with a percentage of your current yoyo's range\nCreates two per yoyo that you have active\nMust be equipped in regular slots");
        }

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
                .AddIngredient(ItemType<MightBar>(), 5)
                .AddIngredient(ItemType<SightBar>(), 5)
                .AddIngredient(ItemType<FrightBar>(), 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}
