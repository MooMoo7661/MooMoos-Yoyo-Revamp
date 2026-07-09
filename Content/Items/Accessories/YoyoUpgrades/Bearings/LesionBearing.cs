using System.Reflection;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Bearings
{

    public class LesionBearing : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.DemoniteBar, 5)
                .AddIngredient(ItemID.RottenChunk, 8)
                .AddTile(TileID.Anvils)
                .Register();
        }

        public void ApplyEffects(Projectile projectile)
        {
            var data = projectile.YoyoData();

            if (data == null)
                return;

            data.LifetimeMult += 0.2f;
        }

        public void AI(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            int count = 0;
            foreach (var npc in Main.ActiveNPCs)
            {
                if (!npc.active || npc.friendly || npc.dontTakeDamage || npc.immortal || npc.Distance(projectile.Center) > 220)
                    continue;

                if (count < 3)
                {
                    count++;
                    continue;
                }

                if (data.StoredCounters[2] == 0)
                {
                    data.SpeedMult += 0.25f;
                    data.StoredCounters[2] = 1;
                }

                count = 0;
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