using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Misc;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Yoyos
{
    public class TheTempest : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 38;
            Item.height = 34;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 20f;
            Item.knockBack = 7f;
            Item.damage = 97;
            Item.rare = ItemRarityID.Yellow;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.shoot = ModContent.ProjectileType<TempestProjectile>();


        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TrueAbbhor>())
                .AddIngredient(ModContent.ItemType<TrueCode3>())
                .AddIngredient(ModContent.ItemType<BrokenHeroYoyo>())
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.LimeGreen.ToVector3() * 0.8f);

            Texture2D tex = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            int numberOfCloneImages = 3;
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly * MathF.Tau / 1.5f) + 0.9f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.1f);
                Color color = Color.LimeGreen * 0.8f;
                color *= 1f - cloneImageDistance * 0.2f;
                color.A = 0;
                cloneImageDistance *= 4;
                Vector2 drawPos = Item.Center + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f) - Main.screenPosition;
                Main.EntitySpriteDraw(tex, drawPos, null, color, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            }
            return false;
        }
    }
}