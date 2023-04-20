using CombinationsMod.Items.Bars;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class RingOfCoalescence : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ring of Coalescence");
            Tooltip.SetDefault("Yoyos can phase through walls\nYoyos shoot cursed flames\n[c/6EAE6E:+10% base yoyo damage]");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 25, 69, 0);
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
            recipe.AddIngredient(ModContent.ItemType<NeutralineScrap>(), 10);
            recipe.AddIngredient(ModContent.ItemType<OmnipotenceRing>());
            recipe.AddIngredient(ModContent.ItemType<TrepidationRing>());
            recipe.AddIngredient(ModContent.ItemType<FortitudeRing>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}