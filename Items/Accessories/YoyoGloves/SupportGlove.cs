using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.YoyoGloves
{
    public class SupportGlove : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Support Glove");
            Tooltip.SetDefault("Allows the use of a third yoyo\nRequires a yoyo glove to work");
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

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
            {
                modPlayer.supportGlove = true;
                modPlayer.yoyoNumber = 3;
            }
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<YoyoSupportGloveSlot>().Type);
        }
    }
}   