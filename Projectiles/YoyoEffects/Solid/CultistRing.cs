using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Humanizer.In;

namespace CombinationsMod.Projectiles.YoyoEffects.Solid
{

    public class CultistRing1 : ModProjectile
    {
        protected float scaleSync = 0.15f;

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
        }

        public override string Texture => "CombinationsMod/Projectiles/YoyoEffects/Solid/CultistRing";
        public override void AI()
        {
            
            Projectile.rotation += 0.09f;

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
            Texture2D texture = ModContent.Request<Texture2D>("CombinationsMod/Projectiles/YoyoEffects/Solid/CultistRing").Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);
            var rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

            Main.EntitySpriteDraw(texture,
                pos,
                rectangle,
                Color.White,
                Projectile.rotation,
                drawOrigin,
                0.3f,
                SpriteEffects.None, 0);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            DrawDisc();

            return false;
        }
    }
}