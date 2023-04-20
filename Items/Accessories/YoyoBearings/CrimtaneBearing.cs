using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Tiles;
using CombinationsMod.UI;

namespace CombinationsMod.Items.Accessories.YoyoBearings
{
	public class CrimtaneBearing : ModItem
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimtane Yoyo Bearing");
			Tooltip.SetDefault("Yoyo hits will drain life");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Green;
			Item.accessory = true;
			Item.maxStack = 1;
			Item.value = Item.sellPrice(gold: 3);
		}
        public override bool? PrefixChance(int pre, Terraria.Utilities.UnifiedRandom rand)
        {
            return false;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
		{
			YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

			if (!hideVisual)
			modPlayer.crimtaneBearing = true;
		}
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<BearingSlot2>().Type ||
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<BearingSlot1>().Type);
        }
	}
}