using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using CombinationsMod.Items.Bars;
using Microsoft.Xna.Framework.Graphics;

namespace CombinationsMod.Items.Yoyos
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
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 17, 0, 0);
            Item.shoot = ModContent.ProjectileType<BlackHoleProjectile>();
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