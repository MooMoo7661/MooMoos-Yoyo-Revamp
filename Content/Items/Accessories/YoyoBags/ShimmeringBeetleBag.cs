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
            Utility.ItemSets.YoyoBag[Type] = true;
            ItemID.Sets.ShimmerTransformToItem[Type] = ModContent.ItemType<Tier2Bag>();

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

        CompactParticleManager manager;
        public override bool PreDrawTooltipLine(DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Name == "ItemName" && line.Mod == "Terraria")
            {
                Color color = Color.Lerp(Color.Purple, Color.DeepPink, (MathF.Sin(Main.GlobalTimeWrappedHourly * 1.5f) + 1) / 2f);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);
                Vector2 bounds = FontAssets.MouseText.Value.MeasureString(line.Text);
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);


                if (Main.GameUpdateCount % 14 == 0)
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
            Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Content/Items/Accessories/YoyoBags/ShimmeringBeetleBag").Value;

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

            tooltips.Add(new TooltipLine(Mod, "BagInfo", Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoShimmer")));
        }
    }
}