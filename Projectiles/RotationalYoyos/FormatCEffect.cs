﻿using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
using Humanizer;

namespace CombinationsMod.Projectiles.RotationalYoyos
{
    public class FormatCEffect : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
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
        double distance = 70;
        bool growing = true;
        bool shrinking = false;
        Vector2 endPos = new(0, 0);
        private bool secondAI = false;

        public override void AI()
        {
            Player player = Main.player[Projectile.owner];

            Projectile.rotation += 0.2f;

            Projectile proj = Main.projectile[(int)Projectile.ai[1]];

            if (proj.ai[0] == -1 && proj.localAI[0] >= 100)
            {
                secondAI = true;
            }

            if (secondAI)
            {
                if (endPos == Vector2.Zero)
                {
                    endPos = proj.position;
                }

                AI2();
                return;
            }

            if (!proj.active || proj.owner != Projectile.owner || proj.aiStyle != 99)
            {
                Projectile.Kill();
                return;
            }

            double rad = Projectile.localAI[1] + Projectile.ai[0] * 12f * (Math.PI / 180.0);

            Projectile.ai[0] += 1f;

            float posX = proj.Center.X - (int)(Math.Cos(rad) * distance) - Projectile.width / 2;
            float posY = proj.Center.Y - (int)(Math.Sin(rad) * distance) - Projectile.height / 2;

            Projectile.position = new Vector2(posX, posY);


            int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height,
            DustID.RedTorch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1f);
            Main.dust[dust].noGravity = true;

            if (!_initialized)
            {
                Projectile.frame = player.ownedProjectileCounts[Type];
                _initialized = true;
            }
        }

        public void AI2() // Controls the state of the projectile when the yoyo has been recalled.
        {
            Player player = Main.player[Projectile.owner];

            Vector2 away = Projectile.DirectionFrom(endPos);

            Projectile.velocity *= 0;
            Projectile.velocity = away * 9f;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 180;

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

            for (int i = 0; i < base.Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = base.Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, base.Projectile.gfxOffY);

                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.4f;
                Main.EntitySpriteDraw(texture, drawPos, null, color, base.Projectile.rotation, drawOrigin, base.Projectile.scale, 0, 0);
                
            }
            return true;
        }
    }
}
