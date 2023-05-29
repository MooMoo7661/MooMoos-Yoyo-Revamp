using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Reflection;
using System;
using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Achievements;
using CombinationsMod.Items.Yoyos;
using Terraria.ID;
using CombinationsMod.Projectiles.TrickYoyos;
using static Terraria.ModLoader.ModContent;
using CombinationsMod.Projectiles.YoyoProjectiles;

namespace CombinationsMod
{
    public class CombinationsModClass : Mod
    {
        public override void Load()
        {
            On.Terraria.Main.DrawProj_DrawYoyoString += Test;
            On.Terraria.Player.ApplyEquipFunctional += On_Player_ApplyEquipFunctional;
        }

        public override void Unload()
        {
            On.Terraria.Main.DrawProj_DrawYoyoString -= Test;
            On.Terraria.Player.ApplyEquipFunctional -= On_Player_ApplyEquipFunctional;
        }

        private void On_Player_ApplyEquipFunctional(On.Terraria.Player.orig_ApplyEquipFunctional orig, Player self, Item item, bool hideVisual)
        {
            if (item.type != ItemID.YoyoBag)
                orig.Invoke(self, item, hideVisual);

            if (!ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag && item.type == ItemID.YoyoBag)
            {
                orig.Invoke(self, item, hideVisual);
            }

            if (item.type == ItemID.YoyoBag)
            {
                self.GetModPlayer<YoyoModPlayer>().yoyoBag = true;
            }
        }

        private void DrawCustomYoyoString(Projectile projectile, Vector2 mountedCenter, Color textureColor, Asset<Texture2D> texture)
        {
            // Adapted Vanilla Code for drawing custom yoyo strings.
            // Yes, I know it's a horrible sight.

            if (projectile.aiStyle == 99 || projectile.type == ProjectileType<World1>() || projectile.type == ProjectileType<World2>())
            {

                if (projectile.counterweight)
                {
                    texture = TextureAssets.FishingLine;
                }

                Player player = Main.player[projectile.owner];

                if (player.stringColor == 32)
                {
                    return;
                }

                Vector2 vector = mountedCenter;
                vector.Y += player.gfxOffY;

                float num2 = projectile.Center.X - vector.X;
                float num3 = projectile.Center.Y - vector.Y;

                Math.Sqrt((double)(num2 * num2 + num3 * num3));
                float num4 = (float)Math.Atan2((double)num3, (double)num2) - 1.57f;

                if (!projectile.counterweight)
                {
                    int num5 = -1;
                    if (projectile.position.X + projectile.width / 2 < Main.player[projectile.owner].position.X + Main.player[projectile.owner].width / 2)
                    {
                        num5 = 1;
                    }
                    num5 *= -1;
                    player.itemRotation = MathF.Atan2(num3 * num5, num2 * num5);
                }

                bool drawString = true;

                if (num2 == 0f && num3 == 0f)
                {
                    drawString = false;
                }
                else
                {
                    float num6 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
                    num6 = 12f / num6;
                    num2 *= num6;
                    num3 *= num6;
                    vector.X -= num2 * 0.1f;
                    vector.Y -= num3 * 0.1f;
                    num2 = projectile.position.X + projectile.width * 0.5f - vector.X;
                    num3 = projectile.position.Y + projectile.height * 0.5f - vector.Y;
                }
                while (drawString)
                {
                    float num7 = 12f;
                    float num8 = (float)Math.Sqrt((double)(num2 * num2 + num3 * num3));
                    float num9 = num8;

                    if (float.IsNaN(num8) || float.IsNaN(num9))
                    {
                        drawString = false;
                    }

                    else
                    {
                        if (num8 < 20f)
                        {
                            num7 = num8 - 8f;
                            drawString = false;
                        }
                        num8 = 12f / num8;
                        num2 *= num8;
                        num3 *= num8;
                        vector.X += num2;
                        vector.Y += num3;
                        num2 = projectile.position.X + projectile.width * 0.5f - vector.X;
                        num3 = projectile.position.Y + projectile.height * 0.1f - vector.Y;
                        if (num9 > 12f)
                        {
                            float num10 = 0.3f;
                            float num11 = Math.Abs(projectile.velocity.X) + Math.Abs(projectile.velocity.Y);
                            if (num11 > 16f)
                            {
                                num11 = 16f;
                            }
                            num11 = 1f - num11 / 16f;
                            num10 *= num11;
                            num11 = num9 / 80f;
                            if (num11 > 1f)
                            {
                                num11 = 1f;
                            }
                            num10 *= num11;
                            if (num10 < 0f)
                            {
                                num10 = 0f;
                            }
                            num10 *= num11;
                            num10 *= 0.5f; // Intensity of string bending 
                            if (num3 > 0f)
                            {
                                num3 *= 1f + num10;
                                num2 *= 1f - num10;
                            }
                            else
                            {
                                num11 = Math.Abs(projectile.velocity.X) / 3f;
                                if (num11 > 1f)
                                {
                                    num11 = 1f;
                                }
                                num11 -= 0.5f;
                                num10 *= num11;
                                if (num10 > 0f)
                                {
                                    num10 *= 2f;
                                }
                                num3 *= 1f + num10; // Controls vertical climb of the string on the Y+ axis
                                num2 *= 1f - num10;
                            }
                        }

                        num4 = (float)Math.Atan2((double)num3, (double)num2) - 1.57f;

                        textureColor = Color.White; // Starts textureColor at white. If you don't want to change the color at all, delete the 2 lines below.

                        // Calling Main.TryApplyingPlayerStringColor with reflection. This allows us to actually make yoyo strings influence color.
                        var method = typeof(Main).GetMethod("TryApplyingPlayerStringColor", BindingFlags.Static | BindingFlags.NonPublic);

                        textureColor = (Color)method.Invoke(null, new object[] { player.stringColor, textureColor });

                        
                        // Keep in mind that this will only work with vanilla yoyo strings. If you want to make custom ones work, you'll have to manually set the color in here.

                        switch (player.stringColor) // For custom string colors. There's several ways to go about it, 
                        {
                            case 28:
                                textureColor = new(255, 42, 212);
                                break;

                            case 29:
                                textureColor = new(41, 96, 0);
                                break;

                            case 30:
                                textureColor = new(0, 37, 106);
                                break;

                            case 31:
                                textureColor = new(255, 164, 228);
                                break;

                            // 32 is nanite string, which just makes it invisible.

                            case 33:
                                textureColor = new(60, 151, 146);
                                break;

                            case 34:
                                textureColor = new(168, 59, 153);
                                break;

                            case 35: // Stardust String
                                textureColor = new(90, 195, 248);
                                break;

                            case 36: // Solar String
                                textureColor = new(255, 180, 56);
                                break;

                            case 37: // Vortex String
                                textureColor = new(131, 238, 220);
                                break;

                            case 38: // Nebula String
                                textureColor = new(254, 14, 177);
                                break;
                        }

                        float alphaDilation = 0.6f; // Dilates the texture's alpha. Otherwise, it wouldn't look right

                        texture = WhichTextureShouldBeUsed(texture, projectile);
                        textureColor = WhichColorShouldBeUsed(textureColor, projectile);

                        textureColor.A = (byte)(textureColor.A * 0.4f);
                        textureColor = Lighting.GetColor((int)vector.X / 16, (int)(vector.Y / 16f), textureColor); // Makes the string use Terraria's lighting system to turn darker / lighter in the appropriate enviornment.

                        // Drawing the string itself
                        Color textureDrawColor = new Color((byte)(textureColor.R * alphaDilation), (byte)(textureColor.G * alphaDilation), (byte)(textureColor.B * alphaDilation), (byte)(textureColor.A * alphaDilation));

                        //if (projectile.type != ProjectileType<BlackHoleProjectile>())
                        Main.EntitySpriteDraw(texture.Value, new Vector2(vector.X - Main.screenPosition.X + texture.Width() * 0.5f,
                            vector.Y - Main.screenPosition.Y + texture.Height() * 0.5f) - new Vector2(6f, 0f),
                            new Rectangle?(new Rectangle(0, 0, texture.Width(), (int)num7)),
                            textureDrawColor * 1.3f, num4, new Vector2(texture.Width() * 0.5f, 0f), 1f, 0, 0);
                    }
                }
            }
        }

        private void Test(On.Terraria.Main.orig_DrawProj_DrawYoyoString orig, Main self, Projectile projectile, Vector2 mountedCenter)
        {
            Player player = Main.player[projectile.owner];

            CombinationsModSystem combinationsModSystem = new CombinationsModSystem();

            Asset<Texture2D> texture = combinationsModSystem.GetStringFromDictionary(player.HeldItem.type);

            DrawCustomYoyoString(
                projectile,
                mountedCenter,
                Color.White,
                texture
            );
        }

        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("TMLAchievements", out Mod mod))
            {
                mod.Call("AddAchievement", this, "Code1Achievement", AchievementCategory.Collector, "CombinationsMod/Crossmod/Achievements/AchievementCode1", null, false, true, 1f, new string[] { "Collect_" + ItemID.Code1 });
                mod.Call("AddAchievement", this, "AbbhorAchievement", AchievementCategory.Collector, "CombinationsMod/Crossmod/Achievements/AchievementAbbhor", null, false, false, 2f, new string[] { "Collect_" + ItemType<TheAbbhor>() });
                mod.Call("AddAchievement", this, "Code2Achievement", AchievementCategory.Collector, "CombinationsMod/Crossmod/Achievements/AchievementCode2", "CombinationsMod/Crossmod/Achievements/RareBorder", false, true, 3f, new string[] { "Collect_" + ItemID.Code2 });
                mod.Call("AddAchievement", this, "ConverganceAchievement", AchievementCategory.Collector, "CombinationsMod/Crossmod/Achievements/AchievementConvergance", "CombinationsMod/Crossmod/Achievements/SpecialBorder", false, true, 4f, new string[] { "Collect_" + ItemType<Convergance>() });
            }
        }

        /// <summary>
        /// Lets specific projectiles have strings, without requiring them to be added to a dictionary and all that shit.
        /// </summary>
        private static Asset<Texture2D> WhichTextureShouldBeUsed(Asset<Texture2D> texture, Projectile projectile)
        {
            int type = projectile.type;

            if (type == ProjectileType<World2>())
            {
                texture = TextureAssets.Chain33;
            }
            else if (type == ProjectileID.TheEyeOfCthulhu && projectile.localAI[1] == 2)
            {
                texture = Request<Texture2D>("CombinationsMod/YoyoStringTextures/BloodString");
            }

            return texture;
        }
        /// <summary>
        /// Lets specific projectiles modify the color of the yoyo string, without doing it in the actual detour.
        /// </summary>
        private static Color WhichColorShouldBeUsed(Color textureColor, Projectile projectile)
        {
            if (projectile.type == ProjectileID.TheEyeOfCthulhu && projectile.localAI[1] == 2)
            {
                textureColor = Color.White;
            }

            return textureColor;
        }
    }
}

