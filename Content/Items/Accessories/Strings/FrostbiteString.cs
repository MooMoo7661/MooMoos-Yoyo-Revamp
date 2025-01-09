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
            Utility.ItemSets.YoyoString[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<YoyoModPlayer>().frostbiteString = true;
            player.GetModPlayer<YoyoModPlayer>().YoyoSpeedModifier += 2f;
            player.yoyoString = true;
        }
    }
}
