namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.ResponsePads
{
    public class WhiteResponsePad : ModItem, IYoyoUpgrade
    {
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

        public void ApplyEffects(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            data.SpeedMult += 0.15f;
        }
    }
}