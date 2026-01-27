using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Rings
{
    public class AbilityRing : ModItem
    {
         

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 5, 55, 0);
            ItemSets.YoyoRing[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ShimmeringRing>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.yoyoRing = true;
        }
    }
}