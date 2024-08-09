using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects.Solid
{

    public class CultistRing2 : ModProjectile
    {
        public int counter = 0;
        public float scaleSync = 0.3f;

        public override void SetDefaults()
        {
            Projectile.width = 408;
            Projectile.height = 408;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
            Projectile.hide = true;

            Projectile.usesIDStaticNPCImmunity = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25 * Projectile.MaxUpdates;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCs.Add(index);
        }

        public override string Texture => "CombinationsMod/Content/Projectiles/YoyoEffects/Solid/CultistRing";

        public override void AI()
        {
            Projectile.rotation -= 0.05f;

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

            counter++;

            if (counter >= 45 && counter <= 60)
            {
                scaleSync += 0.016f;
                //Projectile.netUpdate = true;
            }
        }

        private void DrawDisc()
        {

            var pos = Projectile.Center - Main.screenPosition;
            Texture2D texture = ModContent.Request<Texture2D>("CombinationsMod/Content/Projectiles/YoyoEffects/Solid/CultistRing").Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            var rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            if (counter >= 45)
            {
                Main.EntitySpriteDraw(texture,
                pos,
                rectangle,
                Color.White,
                Projectile.rotation,
                drawOrigin,
                scaleSync,
                SpriteEffects.None, 0);
            }
            else
            {
                Main.EntitySpriteDraw(texture,
                    pos,
                    rectangle,
                    Color.White,
                    Projectile.rotation,
                    drawOrigin,
                    0.3f,
                    SpriteEffects.None, 0);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            DrawDisc();
            return false;
        }
    }
}