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
    public class SlimyString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Slimy String");
            // Tooltip.SetDefault("Increases yoyo range\nYoyos create slime covered spikes\n[c/6EAE6E:+150 yoyo range]");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Expert;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 2);
            Item.stringColor = 8;
            Item.expert = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.slimeString = true;
                player.yoyoString = true;
            }

        }
    }
}
