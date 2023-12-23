using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using CombinationsMod.Content.TrailSystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace CombinationsMod.Content.Items.Yoyos
{
    public class BlackHole : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 36;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 3f;
            Item.knockBack = 15f;
            Item.damage = 105;
            Item.rare = ItemRarityID.Lime;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 17, 0, 0);
            Item.shoot = ModContent.ProjectileType<BlackHoleProjectile>();

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
                Color color = Color.Lerp(Color.Purple, Color.DarkBlue, (MathF.Sin(Main.GlobalTimeWrappedHourly * 0.7f) + 1) / 2f);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);
                Vector2 bounds = FontAssets.MouseText.Value.MeasureString(line.Text);
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);


                if (Main.GameUpdateCount % 9 == 0)
                {
                    bounds.Y -= 10;
                    Vector2 pos = new Vector2(0, 5) + new Vector2(Main.rand.NextFloat(bounds.X), Main.rand.NextFloat(bounds.Y));
                    Color color2 = Color.MediumPurple;
                    manager.AddParticle(pos, (pos - bounds / 2).SafeNormalize(Vector2.UnitY) * 1, 0f, 5f, 1f, color2);
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

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TheTempest>())
                .AddIngredient(ItemID.BeetleHusk, 5)
                .AddIngredient(ModContent.ItemType<EclipseBar>(), 5)
                .AddIngredient(ItemID.SoulofNight, 20)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.Purple.ToVector3() * 2.3f);

            Texture2D tex = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            int numberOfCloneImages = 6;
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly / 2.4f * MathF.Tau / 2f) + 0.5f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.3f);
                Color color = Color.Purple;
                color *= 1f - cloneImageDistance * 0.2f;
                color.A = 0;
                cloneImageDistance *= 4;
                Vector2 drawPos = Item.Center + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f) - Main.screenPosition;
                Main.EntitySpriteDraw(tex, drawPos, null, color, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            }
            Item.Size = new(60, 46);
            return false;// base.PreDrawInWorld(spriteBatch, lightColor, alphaColor, ref rotation, ref scale, whoAmI);
        }

        //public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //{
        //    float sizeLimit = 34;
        //    int numberOfCloneImages = 6;
        //    Main.DrawItemIcon(spriteBatch, Item, position, Color.White * 0.7f, sizeLimit);
        //    for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
        //    {
        //        float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly / 2.4f * MathF.Tau / 2f) + 0.5f;
        //        cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.3f);
        //        Color color = Color.Purple * 0.4f;
        //        color *= 1f - cloneImageDistance * 0.2f;
        //        color.A = 0;
        //        cloneImageDistance *= 3;
        //        Vector2 drawPos = position + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f);
        //        Main.DrawItemIcon(spriteBatch, Item, drawPos, color, sizeLimit);
        //    }
        //    return false;
        //}
    }
}