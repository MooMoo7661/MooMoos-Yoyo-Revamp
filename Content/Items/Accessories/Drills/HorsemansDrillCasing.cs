using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Items.Accessories.Drills
{
    public class HorsemansDrillCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.Yellow;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.horseDrill = true;
        }
    }
}