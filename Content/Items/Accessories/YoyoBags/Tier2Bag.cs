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
    public class Tier2Bag : ItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 36;
            Item.height = 44;
            Item.rare = ItemRarityID.LightPurple;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<ShimmerBag>();
            Utility.ItemSets.YoyoBag[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            modPlayer.tier2Bag = true;
            modPlayer.stringSlot = true;
            modPlayer.gloveSlot = true;
            modPlayer.supportGloveSlot = true;
            modPlayer.counterweightSlot = true;
            modPlayer.drillSlot = true;
            modPlayer.ringSlot1 = true;
            modPlayer.ringSlot2 = true;

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
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Content/Items/Accessories/YoyoBags/Tier2Bag").Value;

            Main.spriteBatch.Draw(tex, position, null, drawColor, 0, origin, scale * 1.13f, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AdditionalYoyo")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MoreAccessorySlots")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.SupportGlove")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.DrillsAndCounterweights")));
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MasterYoyoSkills")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AdditionalYoyo")));
            }

        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.YoyoBag)
                .AddIngredient(ItemID.ChlorophyteBar, 15)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}