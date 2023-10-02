using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Rarities;
using CombinationsMod.Items.Souls;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;

namespace CombinationsMod.Items.Bars
{
    public class EclipseBar : ItemLoader
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Eclipse Bar");
            // Tooltip.SetDefault("Radiates otherworldly energy");
        }

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 99;
            Item.value = Item.sellPrice(gold: 1, silver: 22);
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.autoReuse = true;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.EclipseBarTile>(); // The ID of the wall that this item should place when used. ModContent.TileType<T>() method returns an integer ID of the wall provided to it through its generic type argument (the type in angle brackets)..
            Item.placeStyle = 0;
            Item.rare = ModContent.RarityType<EclipseRarity>();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            return base.Shoot(player, source, position, velocity, type, damage, knockback);
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SoulOfEclipse>(), 2);
            recipe.AddIngredient(ModContent.ItemType<NeutralineScrap>());
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }

        //public override bool PreDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale)
        //{
        //    float sizeLimit = 34;
        //    int numberOfCloneImages = 6;
        //    Main.DrawItemIcon(spriteBatch, Item, position, Color.White * 0.7f, sizeLimit);
        //    for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
        //    {
        //        float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly * MathF.Tau / 1.5f) + 0.9f;
        //        cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.3f);
        //        Color color = Color.OrangeRed * 0.3f;
        //        color *= 1f - cloneImageDistance * 0.2f;
        //        color.A = 0;
        //        cloneImageDistance *= 2.5f;
        //        Vector2 drawPos = position + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f);
        //        Main.DrawItemIcon(spriteBatch, Item, drawPos, color, sizeLimit);
        //    }
        //    return false;
        //}

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.OrangeRed.ToVector3() * 1.7f);

            Texture2D tex = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            int numberOfCloneImages = 3;
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly * MathF.Tau / 1.5f) + 0.9f;
                cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.2f);
                Color color = Color.OrangeRed * 0.3f;
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