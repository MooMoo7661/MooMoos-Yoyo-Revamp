using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;
using Terraria;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles
{

    public class HallowedAxle : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.HallowedBar, 8)
                .AddIngredient(ItemID.SoulofFright, 2)
                .AddIngredient(ItemID.SoulofMight, 2)
                .AddIngredient(ItemID.SoulofSight, 2)
                .AddTile(TileID.MythrilAnvil)
                .DisableDecraft()
                .Register();
        }

        public void AI(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            var modplayer = player.GetModPlayer<YoyoModPlayer>();

            if (data.StoredCounters[0] < 20 && projectile.localAI[0] % (30 * projectile.MaxUpdates) == 0)
            {
                data.StoredCounters[0]++;
                data.SpeedMult += 0.025f;
                data.RangeBonus += 12.5f;
            }
        }
    }
}