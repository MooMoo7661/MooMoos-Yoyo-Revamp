using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.ModSystems;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles
{

    public class MeteorAxle : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.MeteoriteBar, 8)
                .AddRecipeGroup(CombinationsModSystem.goldBarRecipeGroup, 8)
                .AddIngredient(ItemID.FallenStar, 2)
                .AddTile(TileID.Anvils)
                .DisableDecraft()
                .Register();
        }

        public void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            var modplayer = player.GetModPlayer<YoyoModPlayer>();

            if (data.StoredCounters[0] < 16 && data.Hits % 3 == 0)
            {
                data.SpeedBonus += 0.5f;
                data.StoredCounters[0]++;
            }
        }
    }
}