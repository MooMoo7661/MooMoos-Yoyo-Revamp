using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class NaniteString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {

            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4);
            Item.hasVanityEffects = true;
            Item.stringColor = -1;
            Utility.ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().naniteString = true;
            player.stringColor = -1;
            player.yoyoString = true;
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<YoyoModPlayer>().naniteString = true;
            player.stringColor = -1;
        }
    }
}
