using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.Misc
{
    public class BlackHoleSparkle : ModProjectile
    {
        public const int Lifetime = 90;

        public const int FadeinTime = 18;

        public const int FadeoutTime = 18;

        public float Time
        {
            get
            {
                return Projectile.ai[0];
            }
            set
            {
                Projectile.ai[0] = value;
            }
        }

        public float ColorSpectrumHue
        {
            get
            {
                return Projectile.ai[1];
            }
            set
            {
                Projectile.ai[1] = value;
            }
        }

        public override void SetDefaults()
        {
            Projectile.width = 72;
            Projectile.height = 72;
            Projectile.friendly = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.timeLeft = 90;
            Projectile.damage = 0;
            Projectile.scale = 0.001f;
        }

        public override void AI()
        {
            if (Time == 1f)
            {
                Projectile.scale = Main.rand.NextFloat(0.4f, 1.1f);
                ColorSpectrumHue = Main.rand.NextFloat(0f, 0.9999f);
                Projectile.netUpdate = true;
                Projectile.rotation = Projectile.velocity.ToRotation() + (float)Math.PI / 2f;
            }
            Time++;
            Projectile.velocity *= 0.96f;
            Projectile.rotation = Projectile.rotation.AngleLerp((float)Math.PI / 2f, 0.085f);
            ColorSpectrumHue = (ColorSpectrumHue + 0.0037f) % 0.999f;
            Projectile.Opacity = Utils.GetLerpValue(0f, 18f, Time, clamped: true) * Utils.GetLerpValue(90f, 72f, Time, clamped: true);
            Projectile.velocity = Projectile.velocity.RotatedBy(Math.Sin(Time / 30f) * 0.012500000186264515);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Color color = CombinationsModUtils.MulticolorLerp(ColorSpectrumHue, new Color(150, 0, 255)) * Projectile.Opacity * 0.5f;
            color.A = 0;
            color *= MathHelper.Lerp(1f, 1.5f, Utils.GetLerpValue(30f, 60f, Time, clamped: true));
            Color color2 = Color.Lerp(color, Color.White, 0.5f) * 0.5f;
            Vector2 origin = texture.Size() / 2f;
            Vector2 vector = new Vector2(0.3f, 1f) * Projectile.Opacity * Projectile.scale;
            Vector2 vector2 = new Vector2(0.3f, 1f) * Projectile.Opacity * Projectile.scale;
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY, null, color, (float)Math.PI / 2f + Projectile.rotation, origin, vector2, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY, null, color, Projectile.rotation, origin, vector, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY, null, color2, (float)Math.PI / 2f + Projectile.rotation, origin, vector2 * 0.6f, SpriteEffects.None, 0f);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition + Vector2.UnitY * Projectile.gfxOffY, null, color2, Projectile.rotation, origin, vector * 0.6f, SpriteEffects.None, 0f);
            return false;
        }
    }
}