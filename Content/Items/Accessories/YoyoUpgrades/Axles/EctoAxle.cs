using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles
{

    public class EctoAxle : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.SpectreBar, 8)
                .AddIngredient(ItemID.Ectoplasm, 5)
                .AddIngredient(ItemID.Bone, 15)
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

            Tile tile = Main.tile[new Point16(projectile.Center.ToTileCoordinates().X, projectile.Center.ToTileCoordinates().Y)];
            if (tile.HasTile && Main.tileSolid[tile.TileType])
            {
                if (data.StoredCounters[0] == 0)
                {
                    data.DamageMult += 0.55f;
                    data.StoredCounters[0] = 1;
                }
            }
            else
            {
                if (data.StoredCounters[0] == 1)
                {
                    data.DamageMult -= 0.55f;
                    data.StoredCounters[0] = 0;
                }
            }
        }

        public void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            var modplayer = player.GetModPlayer<YoyoModPlayer>();

            if (data.StoredCounters[0] < 80 && data.Hits % 2 == 0)
            {
                data.SpeedBonus += 0.225f;
                data.StoredCounters[0]++;
            }
        }

        public void ApplyEffects(Projectile projectile)
        {
            projectile.tileCollide = false;
        }
    }
}