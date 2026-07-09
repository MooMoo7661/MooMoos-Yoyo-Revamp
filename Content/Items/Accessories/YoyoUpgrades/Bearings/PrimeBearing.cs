using System.Reflection;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Bearings
{

    public class PrimeBearing : ModItem, IYoyoUpgrade
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
                .AddIngredient(ItemID.HallowedBar, 5)
                .AddIngredient(ItemID.SoulofFright, 2)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public void ApplyEffects(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            data.RangeMult -= 0.725f;
            data.DamageMult += 0.5f;
        }
    }
}