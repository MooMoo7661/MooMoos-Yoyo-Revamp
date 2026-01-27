using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class LightPinkString : ModItem
    {
         

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            Item.hasVanityEffects = true;
            ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().lightPinkString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoSpeedModifier += 1f;
            player.yoyoString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoStringColor = new(255, 165, 228);
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<YoyoModPlayer>().YoyoStringColor = new(255, 165, 228);
        }
    }
}
