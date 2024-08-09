using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombinationsMod.Content.Items.Accessories.Drills
{

    public class AdamantiteDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;
        public override int DrillProjectile => ModContent.ProjectileType<AdamantiteDrill>();

        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 48;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);
            Utility.ItemSets.DrillCasing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.adamantiteDrill = true;
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}