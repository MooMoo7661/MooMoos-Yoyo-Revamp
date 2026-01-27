namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.ResponsePads
{
    public class WhiteResponsePad : ModItem, IYoyoUpgrade
    {
        public LocalizedText Description => Language.GetText("Mods.CombinationsMod.LocalizedText.UpgradeUI.WhiteResponsePad");

        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 18;
            Item.rare = ItemRarityID.Blue;
            Item.maxStack = Item.maxStack;
            Item.value = Item.sellPrice(silver: 20);
            ItemSets.YoyoUpgrade[Type] = true;
            ItemSets.YoyoResponsePad[Type] = true;
        }

        public void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
           
        }
    }
}