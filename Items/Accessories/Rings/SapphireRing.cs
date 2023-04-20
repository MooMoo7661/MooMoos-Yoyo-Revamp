using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Tiles;
using CombinationsMod.UI;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class SapphireRing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sapphire Ring");
            Tooltip.SetDefault("Yoyos will emit bright blue light");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Green;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 1, 12, 0);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
                modPlayer.sapphireRing = true;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot>().Type ||
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot2>().Type);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddRecipeGroup(CombinationsModSystem.silverBarRecipeGroup, 5);
            recipe.AddIngredient(ItemID.Sapphire, 15);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}