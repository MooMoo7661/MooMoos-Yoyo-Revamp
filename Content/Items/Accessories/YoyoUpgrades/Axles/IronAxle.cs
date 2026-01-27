using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Tiles;

namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles
{

    public class IronAxle : ModItem, IYoyoUpgrade
    {
        public LocalizedText Description => Language.GetText("Mods.CombinationsMod.LocalizedText.UpgradeUI.IronAxle");

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

        public void ApplyEffects(Projectile proj)
        {

        }
    }
}