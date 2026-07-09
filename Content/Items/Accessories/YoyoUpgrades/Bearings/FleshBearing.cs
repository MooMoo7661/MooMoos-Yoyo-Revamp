using System.Reflection;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Bearings
{

    public class FleshBearing : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.CrimtaneBar, 5)
                .AddIngredient(ItemID.Vertebrae, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public void AI(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            foreach (var npc in Main.ActiveNPCs)
            {
                if (!npc.active || npc.friendly || npc.dontTakeDamage || npc.immortal || npc.Distance(projectile.Center) > 200)
                    continue;

                if (data.StoredCounters[2] == 0)
                {
                    data.SpeedMult += 0.25f;
                    data.StoredCounters[2] = 1;
                }

                return;
            }

            if (data.StoredCounters[2] == 1)
            {
                data.SpeedMult -= 0.25f;
                data.StoredCounters[2] = 0;
            }
        }
    }
}