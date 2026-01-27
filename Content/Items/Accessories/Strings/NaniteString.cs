using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class NaniteString : ModItem
    {
         

        public override void SetDefaults()
        {

            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4);
            Item.hasVanityEffects = true;
            ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().naniteString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoSpeedModifier += 2f;
            player.yoyoString = true;
        }
    }
}
