using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Misc;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class TerreneRing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrene Ring");
            Tooltip.SetDefault("[c/FF00AB:Enables Yoyos to use their special abilities.]\nYoyos will show the requirements for triggering the ability.\nYoyos can phase through walls\nYoyos shoot cursed flames\n[c/6EAE6E:+10% base yoyo damage]");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 30, 5, 0);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.trepidationRing = true;
                modPlayer.omnipotenceRing = true;
                modPlayer.fortitudeRing = true;
                modPlayer.yoyoRing = true;
            }
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot>().Type || 
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot2>().Type) ;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RingOfCoalescence>());
            recipe.AddIngredient(ModContent.ItemType<AbilityRing>());
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroRing>());
            recipe.AddIngredient(ItemID.LunarBar, 5);
            recipe.AddIngredient(ModContent.ItemType<NeutralineScrap>(), 5);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}