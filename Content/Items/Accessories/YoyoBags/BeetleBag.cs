using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.YoyoBags
{
    public class BeetleBag : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 46;
            Item.rare = ItemRarityID.Cyan;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);
            Item.defense = 6;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ShimmeringBeetleBag>();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.beetleBag = true;
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
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Content/Items/Accessories/YoyoBags/BeetleBag").Value;

            Main.spriteBatch.Draw(tex, position, null, drawColor, 0, origin, scale * 1.18f, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MoreAccessorySlots")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.DrillsAndCounterweights")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoRings")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AdditionalYoyo")));
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AdditionalYoyo")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MasterYoyoSkills")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.IncreasedYoyoKnockback")));
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Tier2Bag>())
                .AddIngredient(ItemID.BeetleHusk, 10)
                .AddIngredient(ItemID.ChlorophyteBar, 5)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}