using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Drills
{
    public class HakapikDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;
        public override int DrillProjectile => ModContent.ProjectileType<Hakapik>();

        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 52;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4, silver: 59);
            Utility.ItemSets.DrillCasing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.hallowedDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.HallowedBar, 20);
            recipe.AddIngredient(ItemID.SoulofFright, 5);
            recipe.AddIngredient(ItemID.SoulofSight, 5);
            recipe.AddIngredient(ItemID.SoulofMight, 5);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}