using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.WeightMods
{

    public class HellstoneEffect : ModItem, IYoyoUpgrade
    {
        public LocalizedText Description => Language.GetText("Mods.CombinationsMod.LocalizedText.UpgradeUI.HellstoneEffect");
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(silver: 20);
            ItemSets.YoyoUpgrade[Type] = true;
            ItemSets.YoyoWeightMod[Type] = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
            .AddIngredient(ItemID.PlatinumBar, 5)
            .AddTile(TileID.WorkBenches)
            .Register();
        }
    }
}