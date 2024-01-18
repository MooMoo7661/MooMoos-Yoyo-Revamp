using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Items.Accessories.Drills
{

    public class ExcavatorCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;
        public override int DrillProjectile => ModContent.ProjectileType<Excavator>();

        public override void SetDefaults()
        {
            Item.width = 38;
            Item.height = 38;
            Item.rare = ItemRarityID.Master;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.excavatorDrill = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<AdamantiteDrillCasing>())
                .AddIngredient(ItemType<CelestialDrillCasing>())
                .AddIngredient(ItemType<CobaltDrillCasing>())
                .AddIngredient(ItemType<HakapikDrillCasing>())
                .AddIngredient(ItemType<HorsemansDrillCasing>())
                .AddIngredient(ItemType<MattockDrillCasing>())
                .AddIngredient(ItemType<MythrilDrillCasing>())
                .AddIngredient(ItemType<OrichalcumDrillCasing>())
                .AddIngredient(ItemType<PalladiumCasing>())
                .AddIngredient(ItemType<ShroomiteShredderCasing>())
                .AddIngredient(ItemType<TitaniumDrillCasing>())
                .AddIngredient(ItemType<TreeClippersDrillCasing>())
                .AddIngredient(ItemType<TsurugiDrillCasing>())
                .AddIngredient(ItemType<YoyoDrillCasing>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public override bool PreDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(Item.Center, Color.MediumPurple.ToVector3() * 1.3f);
            Texture2D tex = Request<Texture2D>("CombinationsMod/Content/Items/Accessories/Drills/ExcavatorGlowmask").Value;
            Texture2D tex2 = TextureAssets.Item[Type].Value;

            Main.EntitySpriteDraw(tex, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
            Main.EntitySpriteDraw(tex2, Item.Center - Main.screenPosition, null, Color.White, rotation, tex.Size() / 2, scale, SpriteEffects.None);
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
    }
}