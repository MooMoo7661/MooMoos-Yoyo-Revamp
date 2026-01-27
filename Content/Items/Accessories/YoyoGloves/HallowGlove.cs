using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.YoyoGloves
{
    [LegacyName("SupportGlove")]
    public class HallowGlove : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 32;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold:4);
            ItemSets.YoyoGlove[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.hallowGlove = true;
            modPlayer.YoyoSpeedModifier += 8f;
            modPlayer.YoyoLifetimeModifier += -1000;
            player.yoyoGlove = true;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }
}