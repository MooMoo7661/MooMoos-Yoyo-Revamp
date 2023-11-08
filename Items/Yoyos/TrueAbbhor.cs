using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using CombinationsMod.Rarities;
using CombinationsMod.Tiles;
using CombinationsMod.Items.Bars;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace CombinationsMod.Items.Yoyos
{
    public class TrueAbbhor : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 34;
            Item.height = 30;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 4.5f;
            Item.damage = 81;
            Item.crit = 16; 
            Item.rare = ItemRarityID.Red;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 15, 90, 83);
            Item.shoot = ModContent.ProjectileType<TrueAbbhorProjectile>();


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TheAbbhor>());
            recipe.AddIngredient(ModContent.ItemType<MightBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SightBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<FrightBar>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.LawnGreen.ToVector3() * 0.8f);

            Texture2D tex = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            int numberOfCloneImages = 3;
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly * MathF.Tau / 1.5f) + 0.9f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.1f);
                Color color = Color.LawnGreen * 0.8f;
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