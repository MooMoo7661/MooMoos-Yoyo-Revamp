namespace CombinationsMod.Content.Items.Accessories.YoyoUpgrades.ResponsePads
{
    public class GreenResponsePad : ModItem, IYoyoUpgrade
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

        public void ApplyOnHitEffect(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            target.AddBuff(BuffID.Poisoned, 60);
        }

        public void ApplyEffects(Projectile projectile)
        {
            var data = projectile.YoyoData();
            var player = projectile.GetOwner();

            if (player == null || data == null)
                return;

            data.SpeedMult += 0.25f;
        }
    }
}