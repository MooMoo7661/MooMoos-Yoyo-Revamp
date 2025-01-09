using CombinationsMod.Content.Configs;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.TrailSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace CombinationsMod.Content.Items.Accessories.YoyoBags
{
    public class MoonlordBag : YoyoModItemLoader
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 52;
            Item.rare = ItemRarityID.Red;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 13);
            Utility.ItemSets.YoyoBag[Type] = true;

            manager = new CompactParticleManager(
            particle =>
            {
                particle.Rotation = 0;
                if (particle.TimeAlive == 0)
                {
                    particle.Scale = 0f;
                    particle.Opacity = 1f;
                }
                else if (particle.TimeAlive < 30)
                {
                    particle.Scale = MathHelper.Lerp(particle.Scale, 1f, 0.1f);
                    particle.Opacity = MathHelper.Lerp(particle.Opacity, 0f, 0.1f);
                }
                else if (particle.TimeAlive < 60)
                {
                    particle.Scale = MathHelper.Lerp(particle.Scale, 0f, 0.1f);
                    particle.Opacity = MathHelper.Lerp(particle.Opacity, 1f, 0.1f);
                }
                else
                {
                    particle.Dead = true;
                }
            },
            (particle, spriteBatch, anchor) =>
            {
                Texture2D texture = ModContent
                    .Request<Texture2D>("Terraria/Images/Projectile_" + ProjectileID.RainbowCrystalExplosion).Value;
                spriteBatch.Draw(texture, anchor + particle.Position, null, particle.Color * particle.Opacity, 0f, texture.Size() / 2, particle.Scale * 0.5f, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, anchor + particle.Position, null, particle.Color * particle.Opacity, MathHelper.PiOver2, texture.Size() / 2, particle.Scale * 0.5f, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, anchor + particle.Position, null, particle.Color * particle.Opacity * 0.5f, 0f, texture.Size() / 2, particle.Scale * 0.75f, SpriteEffects.None, 0f);
                spriteBatch.Draw(texture, anchor + particle.Position, null, particle.Color * particle.Opacity * 0.5f, MathHelper.PiOver2, texture.Size() / 2, particle.Scale * 0.75f, SpriteEffects.None, 0f);
            }
        );
        }

        [CloneByReference]
        CompactParticleManager manager;
        public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Name == "ItemName" && line.Mod == "Terraria")
            {
                Color color = Color.Lerp(new(20, 240, 211), new(47, 107, 74), (MathF.Sin(Main.GlobalTimeWrappedHourly * 2.4f) + 1) / 2f);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);
                Vector2 bounds = FontAssets.MouseText.Value.MeasureString(line.Text);
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);


                if (Main.GameUpdateCount % 9 == 0)
                {
                    bounds.Y -= 10;
                    Vector2 pos = new Vector2(0, 5) + new Vector2(Main.rand.NextFloat(bounds.X), Main.rand.NextFloat(bounds.Y));
                    manager.AddParticle(pos, (pos - bounds / 2).SafeNormalize(Vector2.UnitY) * 1, 0f, 5f, 1f, color);
                }
                manager.Update();

                ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, FontAssets.MouseText.Value, line.Text,
                    new Vector2(line.X, line.Y), Color.WhiteSmoke, 0f, Vector2.Zero, line.BaseScale);

                ChatManager.DrawColorCodedString(Main.spriteBatch, FontAssets.MouseText.Value, line.Text,
                    new Vector2(line.X, line.Y), color, 0f, Vector2.Zero, Vector2.One);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);
                manager.Draw(Main.spriteBatch, new Vector2(line.X, line.Y));
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);
                return false;
            }
            return base.PreDrawTooltipLine(line, ref yOffset);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.moonlordBag = true;
            modPlayer.stringSlot = true;
            modPlayer.gloveSlot = true;
            modPlayer.supportGloveSlot = true;
            modPlayer.counterweightSlot = true;
            modPlayer.drillSlot = true;
            modPlayer.ringSlot1 = true;
            modPlayer.ringSlot2 = true;
            modPlayer.trickSlot = true;
            modPlayer.yoyoBag = true;
            modPlayer.YoyoAmountModifier += 1;

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
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Content/Items/Accessories/YoyoBags/MoonlordBag").Value;

            Main.spriteBatch.Draw(tex, position, null, drawColor, 0, origin, scale * 1.28f, SpriteEffects.None, 0f);
            return false;
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo/MoreSlots", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.MoreAccessorySlots")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo/DrillsAndCounterweights", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.DrillsAndCounterweights")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo/YoyoRings", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.YoyoRings")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo/SupportGlove", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AccessorySlots.SupportGlove")));
            }
            else
            {
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Misc.MasterYoyoSkills")));
                tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Misc.IncreasedYoyoKnockback")));
            }

            tooltips.Add(new TooltipLine(Mod, "BagInfo/AdditionalYoyo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Misc.AdditionalYoyo")));
            tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Misc.YoyoShimmer")));
            tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.Misc.TrickSlot")));

            //tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.MoonlordBag")));
        }
    }
}