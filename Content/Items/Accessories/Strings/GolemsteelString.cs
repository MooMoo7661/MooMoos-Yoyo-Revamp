using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class GolemsteelString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Lime;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 3, silver: 29);
            Utility.ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().golemString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoSpeedModifier += 2f;
            player.yoyoString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoStringColor = new(162, 108, 60);
        }

        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<YoyoModPlayer>().YoyoStringColor = new(162, 108, 60);
        }
    }
}
