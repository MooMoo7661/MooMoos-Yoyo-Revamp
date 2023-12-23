using CombinationsMod.Content.TrailSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace CombinationsMod.Content.Global_Classes
{
    public class GlowingTooltips : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => entity.type == ItemID.Terrarian;
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item entity)
        {
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
        public override bool PreDrawTooltipLine(Item item, DrawableTooltipLine line, ref int yOffset)
        {
            if (line.Name == "ItemName" && line.Mod == "Terraria")
            {
                float mult = 1.3f;
                float updateTime = 3f;
                Color primary = new Color(79, 166, 118);
                bool blur = false;
                if (item.prefix == PrefixID.Legendary2)
                {
                    mult = 2f;
                    updateTime = 1f;
                    primary = new Color(236, 37, 92);
                    blur = true;
                }

                Color color = Color.Lerp(primary, new Color(79, 166, 118), (MathF.Sin(Main.GlobalTimeWrappedHourly * mult) + 1) / mult);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);

                Vector2 bounds = FontAssets.MouseText.Value.MeasureString(line.Text);
                if (blur)
                {
                    Texture2D glow = ModContent.Request<Texture2D>("CombinationsMod/Content/Assets/Glow").Value;
                    Vector2 texSize = glow.Size();
                    Main.spriteBatch.Draw(glow, (line.X + bounds.X / 2) * Vector2.UnitX + (line.Y + bounds.Y / 2) * Vector2.UnitY - Vector2.UnitY * 3, null, color
                        , 0f, texSize / 2, new Vector2(4f, 0.7f), SpriteEffects.None, 0f);
                }

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);

                if (Main.GameUpdateCount % updateTime == 0)
                {
                    bounds.Y -= 10;
                    Vector2 pos = new Vector2(0, 5) + new Vector2(Main.rand.NextFloat(bounds.X), Main.rand.NextFloat(bounds.Y));
                    manager.AddParticle(pos, (pos - bounds / 2).SafeNormalize(Vector2.UnitY) * 1, 0f, 5f, 1f, color);
                }
                manager.Update();

                ChatManager.DrawColorCodedStringShadow(Main.spriteBatch, FontAssets.MouseText.Value, line.Text,
                    new Vector2(line.X, line.Y), Color.White, 0f, Vector2.Zero, line.BaseScale);

                ChatManager.DrawColorCodedString(Main.spriteBatch, FontAssets.MouseText.Value, line.Text,
                    new Vector2(line.X, line.Y), color, 0f, Vector2.Zero, Vector2.One);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);
                manager.Draw(Main.spriteBatch, new Vector2(line.X, line.Y));
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);



                return false;
            }
            return base.PreDrawTooltipLine(item, line, ref yOffset);
        }
    }
}
