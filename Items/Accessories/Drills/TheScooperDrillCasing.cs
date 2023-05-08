using CombinationsMod.Rarities;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CombinationsMod.Items.Accessories.Drills
{
       
    public class TheScooperDrillCasing : ModItem
    {
       
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Scooper");
            // Tooltip.SetDefault("Allows Yoyos to drill through blocks\nHold right click to drill\n[c/BCFFF0:200% pickaxe power]");
        }

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ModContent.RarityType<DevBagRarity>();
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);

        }

        public override bool? PrefixChance(int pre, UnifiedRandom rand)
        {
            return false;
        }
        
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
          
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.scooperDrill = true;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
         
            if (!modded)
                return false;

            ModAccessorySlot curSlot = LoaderManager.Get<AccessorySlotLoader>().Get(slot, player);

            return !ModLoader.TryGetMod("CombinationsMod", out Mod mod) ||
                   !mod.TryFind("DrillSlot", out ModAccessorySlot otherSlot) ||
                   otherSlot.Type == curSlot.Type;

            //return true;
        }
    }
}