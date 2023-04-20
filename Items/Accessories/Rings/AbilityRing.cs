using CombinationsMod.UI;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.Rings
{
    public class AbilityRing : ModItem
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ability Ring");
            Tooltip.SetDefault("[c/FF00AB:Enables Yoyos to use their special abilities.]\nYoyos will show the requirements for triggering the ability.");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(0, 20, 55, 0);
        }
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (!hideVisual)
                modPlayer.yoyoRing = true;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot>().Type || 
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<RingSlot2>().Type) ;
        }
    }
}