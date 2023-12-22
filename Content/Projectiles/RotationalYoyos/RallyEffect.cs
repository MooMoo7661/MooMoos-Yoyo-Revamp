using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.RotationalYoyos
{
    public class RallyEffect : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;

            Projectile.ArmorPenetration = 500;
            Projectile.damage = 12;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.DamageType = DamageClass.Melee;
        }

        private bool _initialized;
        double distance = 30;
        bool growing = true;
        bool shrinking = false;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.rotation += 0.2f;

            Projectile proj = Main.projectile[(int)Projectile.ai[1]];

            if (!proj.active || proj.owner != Projectile.owner || proj.aiStyle != 99)
            {
                Projectile.Kill();
                return;
            }

            double rad = Projectile.localAI[1] + Projectile.ai[0] * 6f * (Math.PI / 180.0);

            if (growing)
            {
                distance++;
            }
            else if (shrinking)
            {
                distance--;
            }

            if (distance == 90)
            {
                growing = false;
                shrinking = true;
            }
            else if (distance == 30)
            {
                growing = true;
                shrinking = false;
            }



            Projectile.ai[0] += 1f;

            float posX = proj.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = proj.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;

            Projectile.position = new Vector2(posX, posY);


            int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height,
            DustID.WhiteTorch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1f);
            Main.dust[dust].noGravity = true;

            if (!_initialized)
            {
                Projectile.frame = player.ownedProjectileCounts[Type];
                _initialized = true;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {

            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);

                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.4f;
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, 0, 0);

            }
            return true;
        }
    }
}
