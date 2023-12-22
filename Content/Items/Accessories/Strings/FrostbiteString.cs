using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Rarities;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.Strings
{
    public class FrostbiteString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<DevBagRarity>();
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4, silver: 18);
            Item.stringColor = 7;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.frostbiteString = true;
            player.yoyoString = true;
        }
    }
}
