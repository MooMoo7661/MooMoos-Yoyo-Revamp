using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Items.Accessories.Tricks
{
    public class AroundTheWorld : ItemLoader
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Around The World");
            Tooltip.SetDefault("Low-value trick\nCreates a seperate yoyo that swirls around the player in a circle that does 2x damage.\nRange stacks with your current yoyo's range\nCreates one per yoyo that you have active\nMust be equipped in regular slots");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 30;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().trick1 = true;
        }

        public override void AddRecipes()
        {
            
        }
    }
}
