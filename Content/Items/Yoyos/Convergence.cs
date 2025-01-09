using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using CombinationsMod.Content.TrailSystem;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Terraria.UI.Chat;
using CombinationsMod.Content.ModSystems;

namespace CombinationsMod.Content.Items.Yoyos
{
    // Yeah I know I misspelled "Convergence".
    [LegacyName("Convergance")]
    public class Convergence : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 40;
            Item.height = 34;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 32f;
            Item.knockBack = 8f;
            Item.damage = 210;
            Item.crit = 19;
            Item.rare = ItemRarityID.Red;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 50, 90, 83);
            Item.shoot = ModContent.ProjectileType<ConvergenceProjectile>();

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
                Color color = Color.Lerp(new Color(236, 37, 92), Color.HotPink, (MathF.Sin(Main.GlobalTimeWrappedHourly * 1.3f) + 1) / 2f);

                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.Additive);

                Vector2 bounds = FontAssets.MouseText.Value.MeasureString(line.Text);
                TrailSystem.Utils.Reload(Main.spriteBatch, BlendState.AlphaBlend);


                if (Main.GameUpdateCount % 2 == 0)
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
            return base.PreDrawTooltipLine(line, ref yOffset);
        }

        public override void AddRecipes()
        {

            CreateRecipe()
                .AddIngredient(ItemID.WoodYoyo)
                .AddRecipeGroup(CombinationsModSystem.ironYoyoGroup)
                .AddIngredient(ItemID.Rally)
                .AddIngredient(ModContent.ItemType<ThinMint>())
                .AddIngredient(ModContent.ItemType<Catacomb>())
                .AddIngredient(ModContent.ItemType<SwarmSpinner>())
                .AddIngredient(ItemID.Code1)
                .AddRecipeGroup(CombinationsModSystem.cobaltYoyoGroup)
                .AddRecipeGroup(CombinationsModSystem.mythrilYoyoGroup)
                .AddIngredient(ItemID.Chik)
                .AddIngredient(ItemID.FormatC)
                .AddIngredient(ItemID.HelFire)
                .AddIngredient(ItemID.Amarok)
                .AddIngredient(ItemID.Gradient)
                .AddIngredient(ItemID.Yelets)
                .AddIngredient(ItemID.RedsYoyo)
                .AddIngredient(ItemID.ValkyrieYoyo)
                .AddIngredient(ModContent.ItemType<HolidayDelight>())
                .AddIngredient(ModContent.ItemType<PumpkinPatcher>())
                .AddIngredient(ItemID.Kraken)
                .AddIngredient(ItemID.TheEyeOfCthulhu)
                .AddIngredient(ModContent.ItemType<BlackHole>())
                .AddIngredient(ModContent.ItemType<CultistYoyo>())
                .AddIngredient(ItemID.Terrarian)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.MediumPurple.ToVector3() * 2.3f);

            Texture2D tex = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            int numberOfCloneImages = 6;
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly / 2.4f * MathF.Tau / 2f) + 0.5f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.3f);
                Color color = Color.White * 0.2f;
                color *= 1f - cloneImageDistance * 0.2f;
                color.A = 0;
                cloneImageDistance *= 4;
                Vector2 drawPos = Item.Center + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f) - Main.screenPosition;
                Main.EntitySpriteDraw(tex, drawPos, null, color, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            }
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
        //        Color color = Color.MediumPurple * 0.4f;
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