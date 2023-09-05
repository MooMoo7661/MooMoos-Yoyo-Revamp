using CombinationsMod.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CombinationsMod.Items.Accessories.YoyoBags
{
    public class ShimmeringBeetleBag : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 56;
            Item.height = 44;
            Item.rare = ItemRarityID.Purple;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 18);
            Item.defense = 6;

            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Tier2Bag>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.beetleBag = true;
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
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Items/Accessories/YoyoBags/ShimmeringBeetleBag").Value;

            Main.spriteBatch.Draw(tex, position, null, drawColor, 0, origin, scale * 1.18f, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.BeetleBag1")));
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo2", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.BeetleBag2")));
            }

            tooltips.Add(new TooltipLine(Mod, "ShimmerBagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoShimmer")));
        }
    }
}   