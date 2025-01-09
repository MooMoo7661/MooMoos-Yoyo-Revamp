using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class ShimmeringRing : ModRing
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 20;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 2, 13, 0);
            Utility.ItemSets.YoyoRing[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<AbilityRing>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.phasingYoyos = true;
        }
    }
}