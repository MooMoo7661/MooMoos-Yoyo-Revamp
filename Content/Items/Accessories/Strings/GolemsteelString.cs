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
            Item.stringColor = 28;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.golemString = true;
            player.yoyoString = true;
        }
    }
}
