using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects
{

    public abstract class BaseSwirl : ModProjectile
    {
        protected virtual bool DoesFrostburnDamage { get; }

        protected abstract float Scale { get; }
        protected abstract float Rotation { get; }
        protected abstract int Width { get; }
        protected abstract int Height { get; }

        protected abstract bool Friendly { get; }
        protected abstract bool Hostile { get; }

        protected abstract int Penetrate { get; }
        protected virtual bool InheritsColor { get; }
        protected virtual Color Color { get; }
        protected abstract string ProjectileName { get; }
        protected abstract string TexturePath { get; }
        protected abstract string TexturePathTransparent { get; }

        public string transparent = "/Transparent";

        public override void SetDefaults()
        {
            Projectile.width = Width;
            Projectile.height = Height;
            Projectile.friendly = Friendly;
            Projectile.hostile = Hostile;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = Penetrate;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            if (InheritsColor)
            {
                return new(255, 255, 255, 255);
            }

            return Color;
        }

        public override string Texture => TexturePath;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (DoesFrostburnDamage) // For use with swirls like ones used in the Amarok. Deals Frostburn damage.
                target.AddBuff(BuffID.Frostburn, 180);
        }

        public override void AI()
        {
            Projectile.rotation -= Rotation;
            Projectile.scale = Scale;
            Projectile.netUpdate = true;

            if (Projectile.ai[1] != -1)
            {
                Projectile proj = Main.projectile[(int)Projectile.ai[1]];

                if (proj.active && proj.owner == Projectile.owner && proj.aiStyle == 99 && !proj.counterweight)
                {
                    Projectile.Center = proj.Center;
                    Projectile.timeLeft = 6;
                    Projectile.netUpdate = true;
                }

                if (proj.ai[0] == -1)
                {
                    Projectile.Kill();
                }
            }
        }

        private void DrawDisc()
        {
            var pos = Projectile.Center - Main.screenPosition;
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>(TexturePath);
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            var rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            float hueScrollRate = 0.005f;
            float gradientSize = 2f;
            float time = (float)Main.timeForVisualEffects;

            Color color = Main.hslToRgb((4 * gradientSize + hueScrollRate * time) % 1, 1, 0.5f);

            /* What is happening here is this:
             1. Getting the crap to draw the textures in the right spot. I'm manually drawing because Projectile.scale is not synced between players.
             2.

            */
            if (TexturePathTransparent != null)
            {
                Texture2D texture2 = (Texture2D)ModContent.Request<Texture2D>(TexturePathTransparent);

                Main.spriteBatch.End();
                Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
                Main.EntitySpriteDraw(texture2,
                    pos,
                    rectangle,
                    new Color(0, 0, 0, 192), // 192 alpha
                    Projectile.rotation,
                    drawOrigin,
                    Scale,
                    SpriteEffects.None, 0);
            }

            Main.spriteBatch.End();
            Main.spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, Main.DefaultSamplerState, DepthStencilState.None, Main.Rasterizer, null, Main.Transform);
            Main.EntitySpriteDraw(texture,
                pos,
                rectangle,
                Color,
                Projectile.rotation,
                drawOrigin,
                Scale,
                SpriteEffects.None, 0);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            DrawDisc();

            return false;
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float radius = Width / 2f;
            return Projectile.Center.DistanceSQ(targetHitbox.ClosestPointInRect(Projectile.Center)) < radius * Scale * radius * Scale;
        }
    }
}