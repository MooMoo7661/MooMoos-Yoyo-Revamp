using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using System.Diagnostics;
using Terraria.ModLoader;
using Terraria.GameContent;

namespace CombinationsMod.Projectiles.Explosions
{

    public class DeprecatedExplosion : ModProjectile
    {


        /* public override void SetDefaults()
         {
             base.Projectile.timeLeft = 420;
             base.Projectile.width = (base.Projectile.height = 98);
             Projectile.aiStyle = 595;
             base.Projectile.friendly = true;
             Main.projFrames[base.Projectile.type] = 7;
             base.Projectile.light = 0.6f;
             base.Projectile.alpha = 150;
             base.Projectile.tileCollide = true;
             base.Projectile.penetrate = 5;
             base.Projectile.DamageType = DamageClass.Melee;
             ProjectileID.Sets.TrailCacheLength[Projectile.type] = 6;
             ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
         }
         public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
         {
             target.immune[base.Projectile.owner] = 6;
             target.AddBuff(39, 600);
         }




         public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
         {
             width = (height = 8);
             return true;
         }

         public override bool OnTileCollide(Vector2 oldVelocity)
         {
             if (base.Projectile.velocity.X != oldVelocity.X)
             {
                 base.Projectile.velocity.X = (0f - oldVelocity.X) * 0.5f;
             }
             if (base.Projectile.velocity.Y != oldVelocity.Y)
             {
                 base.Projectile.velocity.Y = (0f - oldVelocity.Y) * 0.5f;
             }
             return false;
         }

         public override void AI()
         {
             float num2 = base.Projectile.Center.X;
             float num3 = base.Projectile.Center.Y;
             float num4 = 1000f;
             bool flag = false;
             for (int j = 0; j < 200; j++)
             {
                 NPC nPC = Main.npc[j];
                 if (nPC.wet || !nPC.active || nPC.dontTakeDamage || nPC.friendly || nPC.lifeMax <= 5 || nPC.type == 488 || !((double)base.Projectile.Distance(nPC.Center) < (double)num4) || !Collision.CanHit(base.Projectile.Center, 1, 1, nPC.Center, 1, 1))
                 {
                     continue;
                 }
                 float num5 = nPC.position.X + (float)(nPC.width / 2);
                 float num6 = nPC.position.Y + (float)(nPC.height / 2);
                 float num7 = Math.Abs(base.Projectile.position.X + (float)(base.Projectile.width / 2) - num5) + Math.Abs(base.Projectile.position.Y + (float)(base.Projectile.height / 2) - num6);
                 if (num7 < num4)
                 {
                     if ((double)nPC.position.X > (double)base.Projectile.position.X)
                     {
                         base.Projectile.direction = 1;
                     }
                     else if ((double)nPC.position.X < (double)base.Projectile.position.X)
                     {
                         base.Projectile.direction = -1;
                     }
                     num4 = num7;
                     num2 = num5;
                     num3 = num6;
                     flag = true;
                 }
             }
             if (flag)
             {
                 Vector2 vector = new Vector2(base.Projectile.position.X + (float)base.Projectile.width * 0.5f, base.Projectile.position.Y + (float)base.Projectile.height * 0.5f);
                 float num8 = num2 - vector.X;
                 float num9 = num3 - vector.Y;
                 float num10 = (float)Math.Sqrt((double)num8 * (double)num8 + (double)num9 * (double)num9);
                 float num11 = 20f;
                 base.Projectile.velocity.X = (float)(((double)base.Projectile.velocity.X * 20.0 + (double)num8 * (double)(num11 / num10)) / 21.0);
                 base.Projectile.velocity.Y = (float)(((double)base.Projectile.velocity.Y * 20.0 + (double)num9 * (double)(num11 / num10)) / 21.0);
             }
             base.Projectile.rotation += (float)Math.PI / 30f;

             if (base.Projectile.ai[0] == 0f)
             {
                 base.Projectile.rotation = Main.rand.Next(130);
                 base.Projectile.ai[0] = 1f;
             }
             if (base.Projectile.alpha >= 0)
             {
                 base.Projectile.alpha -= 25;
             }
             base.Projectile.velocity.X /= 1.07f;
             base.Projectile.velocity.Y /= 1.07f;
             base.Projectile.frameCounter++;
             if (base.Projectile.frameCounter > 3)
             {
                 base.Projectile.frame++;
                 base.Projectile.frameCounter = 0;
             }
             if (base.Projectile.frame >= 7)
             {
                 base.Projectile.Kill();
             }
         }




         public override bool PreDraw(ref Color lightColor)
         {
             SpriteEffects spriteEffects = SpriteEffects.None;
             Color color = Lighting.GetColor((int)((double)base.Projectile.position.X + (double)base.Projectile.width * 1) / 16, (int)(((double)base.Projectile.position.Y + (double)base.Projectile.height * 1) / 16.0));
             Texture2D texture2D = TextureAssets.Projectile[Projectile.type].Value;
             int num = TextureAssets.Projectile[base.Projectile.type].Height() / Main.projFrames[base.Projectile.type];
             int y = num * base.Projectile.frame;
             Rectangle rectangle = new Rectangle(0, y, texture2D.Width, num);
             Vector2 origin = rectangle.Size() / 2f;
             _ = base.Projectile.type;
             _ = base.Projectile.type;
             _ = base.Projectile.type;
             int num2 = 6;
             int num3 = 2;
             int num4 = 1;
             float num5 = 0f;
             for (int i = num4; (num3 > 0 && i < num2) || (num3 < 0 && i > num2); i += num3)
             {
                 Color newColor = color;
                 newColor = base.Projectile.GetAlpha(newColor);
                 float num6 = num2 - i;
                 if (num3 < 0)
                 {
                     num6 = num4 - i;
                 }
                 newColor *= num6 / ((float)ProjectileID.Sets.TrailCacheLength[base.Projectile.type] * 1.5f);
                 Vector2 vector = base.Projectile.oldPos[i];
                 float num7 = base.Projectile.rotation;
                 SpriteEffects effects = spriteEffects;
                 if (ProjectileID.Sets.TrailingMode[base.Projectile.type] == 60)
                 {
                     num7 = base.Projectile.oldRot[i];
                     effects = ((base.Projectile.oldSpriteDirection[i] == -1) ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
                 }
                 Main.spriteBatch.Draw(texture2D, vector + base.Projectile.Size / 2f - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), rectangle, newColor, num7 + base.Projectile.rotation * num5 * (float)(i - 1) * (0f - (float)spriteEffects.HasFlag(SpriteEffects.FlipHorizontally).ToDirectionInt()), origin, base.Projectile.scale, effects, 0f);
             }
             Color alpha = base.Projectile.GetAlpha(color);
             Main.spriteBatch.Draw(texture2D, base.Projectile.Center - Main.screenPosition + new Vector2(0f, base.Projectile.gfxOffY), rectangle, alpha, base.Projectile.rotation, origin, base.Projectile.scale, spriteEffects, 0f);
             return false;
         }

         public override Color? GetAlpha(Color lightColor)
         {
             return new Color(255, 255, 255, 0) * 0.9f;
         }
      */
    }
}