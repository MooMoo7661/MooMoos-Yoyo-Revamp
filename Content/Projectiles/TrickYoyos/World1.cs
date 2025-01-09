using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.TrickYoyos
{
    public class World1 : ModProjectile
    {

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
            //MooMooLib.DrawSets.CanHaveYoyoStringDrawnFromProjectile[Type] = true;
        }

        private bool _initialized;

        int randPi;
        double distance = 1;
        int randSpeed;

        public override void OnSpawn(IEntitySource source)
        {
            randPi = Main.rand.Next(360) + 1;
            randSpeed = Main.rand.Next(3);
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile proj = Main.projectile[(int)Projectile.ai[1]];

            if (!proj.active || proj.owner != Projectile.owner || proj.aiStyle != 99)
            {
                Projectile.Kill();
                return;
            }

            double rad = randPi + Projectile.ai[0] * (randSpeed + 3) * (Math.PI / 180.0);



            if (distance <= 70 + ProjectileID.Sets.YoyosMaximumRange[proj.type] / 4)
            {
                distance += 10;
            }

            Projectile.ai[0] += 1f;

            float posX = player.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = player.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;

            Projectile.position = new Vector2(posX, posY);

            if (!_initialized)
            {
                Projectile.frame = player.ownedProjectileCounts[Type];
                _initialized = true;
            }
        }

        /*public override bool PreDraw(ref Color lightColor)
        {
            Color defaultColor = Projectile.GetAlpha(lightColor);
            Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/TrickYoyos/World1");

            int frameHeight = texture.Height / Main.projFrames[Projectile.type];
            int startY = frameHeight * Projectile.frame;
            Rectangle sourceRectangle = new(0, startY, texture.Width, frameHeight);
            Main.spriteBatch.Draw(texture, Projectile.Center - Main.screenPosition, sourceRectangle, defaultColor, Projectile.rotation, sourceRectangle.Size() / 2f, Projectile.scale, SpriteEffects.None, 0);
            return false;
        }*/
    }
}
