using CombinationsMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.YoyoBags
{
    public class ShimmerBag : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 52;
            Item.height = 46;
            Item.rare = ItemRarityID.Pink;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);

            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Tier2Bag>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.shimmerBag = true;
            if (!ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                player.yoyoGlove = true;
                player.yoyoString = true;
            }
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Items/Accessories/YoyoBags/ShimmerBag").Value;

            Main.spriteBatch.Draw(tex, position, null, drawColor, 0, origin, scale * 1.18f, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", "Yoyos are recalled faster\nGives the user more accessory slots for yoyos\nAllows the use of Support Gloves and Yoyo Drills\nYoyos can phase through blocks"));
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo2", "Gives the user master yoyo skills\nAdds one additional yoyo\nYoyos can phase through blocks"));
            }
        }
    }
}   