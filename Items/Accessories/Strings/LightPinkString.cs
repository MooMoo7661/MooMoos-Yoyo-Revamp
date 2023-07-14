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
    public class LightPinkString : ModString
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Light Pink String");
            // Tooltip.SetDefault("Increases yoyo range\n[c/6EAE6E:+150 yoyo range]");
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.rare = ItemRarityID.Blue;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 1);
            Item.hasVanityEffects = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.lightPinkString = true;
            player.stringColor = 31;
            player.yoyoString = true;
        }
        public override void UpdateVanity(Player player)
        {
                player.stringColor = 31; // Custom string color ID. Vanilla stops at 28, and to keep our String Info accessory working right, we create our own.
        }
    }
}
