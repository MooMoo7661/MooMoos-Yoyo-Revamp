using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;
using Terraria.DataStructures;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles
{

    public class SolarAxle : ModItem, IYoyoUpgrade
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 20);
            ItemSets.YoyoUpgrade[Type] = true;
            ItemSets.YoyoAxle[Type] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.LunarBar, 8)
                .AddIngredient(ItemID.FragmentSolar, 3)
                .AddTile(TileID.LunarCraftingStation)
                .DisableDecraft()
                .Register();
        }

        public void AI(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            if (projectile.localAI[0] % (30 * projectile.MaxUpdates) == 0 && data.StoredCounters[0] < 60)
            {
                data.StoredCounters[0]++;
                data.DamageMult += 0.0083f;
            }
        }

        public void ApplyOnHitEffect(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            if (data.StoredCounters[1] < 30)
            {
                data.StoredCounters[1]++;
                data.DamageMult += 0.01f;
            }
        }
    }
}