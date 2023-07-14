using CombinationsMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static CombinationsMod.YoyoModConfig;

namespace CombinationsMod.Items.Accessories.YoyoGloves
{
    public class SupportGlove : ItemLoader
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Support Glove");
            // Tooltip.SetDefault("Allows the use of a third yoyo\nRequires a yoyo glove or yoyo bag to work");
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override string Texture => ModContent.GetInstance<YoyoModConfig>().UpscaleYoyoGlove ? "CombinationsMod/Items/Accessories/YoyoGloves/SupportGlove" : "CombinationsMod/Items/Accessories/YoyoGloves/SupportGloveSmall";

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

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return true;
            }

            return modded && LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<YoyoSupportGloveSlot>().Type;
        }
    }
}   