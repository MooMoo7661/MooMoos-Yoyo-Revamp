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
    public class Convergance : ModYoyo
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
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 50, 90, 83);
            Item.shoot = ModContent.ProjectileType<ConverganceProjectile>();


        }
        public override void AddRecipes()
        {

            CreateRecipe()
                .AddIngredient(ItemID.WoodYoyo)
                .AddRecipeGroup(CombinationsModSystem.ironYoyoGroup )
                .AddIngredient(ItemID.Rally)
                .AddIngredient(ModContent.ItemType<ThinMint>())
                .AddIngredient(ModContent.ItemType<Catacomb>())
                .AddIngredient(ModContent.ItemType<TheQueensGambit>())
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
                .AddIngredient(ModContent.ItemType<ChristmasBulb>())
                .AddIngredient(ModContent.ItemType<Mambele>())
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

        public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        {
            float sizeLimit = 34;
            int numberOfCloneImages = 6;
            Main.DrawItemIcon(spriteBatch, Item, position, Color.White * 0.7f, sizeLimit);
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly / 2.4f * MathF.Tau / 2f) + 0.5f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.3f);
                Color color = Color.MediumPurple * 0.4f;
                color *= 1f - cloneImageDistance * 0.2f;
                color.A = 0;
                cloneImageDistance *= 3;
                Vector2 drawPos = position + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f);
                Main.DrawItemIcon(spriteBatch, Item, drawPos, color, sizeLimit);
            }
            return false;
        }
    }
}