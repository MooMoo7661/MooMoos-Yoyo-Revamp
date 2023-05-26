using CombinationsMod.Buffs;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Misc;
using CombinationsMod.Items.Souls;
using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class OmnipotenceRing : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ring of Perception");
            // Tooltip.SetDefault("Yoyos shoot cursed flames");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 12, 55, 0);
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
                modPlayer.omnipotenceRing = true;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(); 
            recipe.AddIngredient(ModContent.ItemType<BrokenHeroRing>());
            recipe.AddIngredient(ModContent.ItemType<EclipseBar>(), 5);
            recipe.AddIngredient(ModContent.ItemType<SightBar>(), 10);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}