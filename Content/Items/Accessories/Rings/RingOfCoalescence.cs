using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class RingOfCoalescence : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 25, 69, 0);
            Utility.ItemSets.YoyoRing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            modPlayer.trepidationRing = true;
            modPlayer.omnipotenceRing = true;
            modPlayer.fortitudeRing = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 5);
            recipe.AddIngredient(ModContent.ItemType<OmnipotenceRing>());
            recipe.AddIngredient(ModContent.ItemType<TrepidationRing>());
            recipe.AddIngredient(ModContent.ItemType<FortitudeRing>());
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}