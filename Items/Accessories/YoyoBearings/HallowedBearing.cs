using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Tiles;
using CombinationsMod.UI;

namespace CombinationsMod.Items.Accessories.YoyoBearings
{
	public class HallowedBearing : ModItem
	{
		public bool hasBeenEquipped;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Yoyo Bearing");
			Tooltip.SetDefault("Yoyo hits will inflict targets with Hallowed");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.rare = ItemRarityID.Orange;
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
			modPlayer.hallowedBearing = true;
		}

		public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<BearingSlot2>().Type ||
                LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<BearingSlot1>().Type);
        }
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddIngredient(Mod, "YoyoBearing");
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}