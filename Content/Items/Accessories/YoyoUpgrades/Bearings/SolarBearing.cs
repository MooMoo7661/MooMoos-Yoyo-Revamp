using System.Reflection;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Bearings
{

    public class SolarBearing : ModItem, IYoyoUpgrade
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 20);
            ItemSets.YoyoUpgrade[Type] = true;
            ItemSets.YoyoBearing[Type] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 5)
                .AddIngredient(ItemID.FragmentSolar, 2)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public void ApplyEffects(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            data.RangeMult -= 0.65f;
            data.SpeedMult -= 0.6f;
            data.DamageMult += 1.3f;
        }
    }
}