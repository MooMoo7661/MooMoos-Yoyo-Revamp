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
            CombinationsMod.Content.Utility.ItemSets.Trick[Type] = true;
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
                .AddIngredient(ItemID.SoulofFright, 4)
                .AddIngredient(ItemID.SoulofSight, 4)
                .AddIngredient(ItemID.SoulofMight, 4)
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
