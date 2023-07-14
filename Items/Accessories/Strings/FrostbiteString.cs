using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.ID;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Souls;
using CombinationsMod.UI;

namespace CombinationsMod.Items.Accessories.Strings
{
    public class FrostbiteString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Frostbite String");
            // Tooltip.SetDefault("Increases yoyo range\nCounterweights inflict Frostbite\n[c/6EAE6E:+150 yoyo range]");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ModContent.RarityType<DevBagRarity>();
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 4, silver:18);
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
