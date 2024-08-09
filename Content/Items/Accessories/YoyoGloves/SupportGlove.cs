using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.YoyoGloves
{
    public class SupportGlove : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override string Texture => "CombinationsMod/Content/Items/Accessories/YoyoGloves/SupportGlove";

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.supportGlove = true;
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }
}