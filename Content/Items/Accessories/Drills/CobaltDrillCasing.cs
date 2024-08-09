using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Drills
{
    public class CobaltDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;
        public override int DrillProjectile => ModContent.ProjectileType<CobaltDrill>();

        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 36;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3);
            Utility.ItemSets.DrillCasing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.cobaltDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltBar, 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}