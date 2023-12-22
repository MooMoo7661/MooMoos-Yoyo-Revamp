using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.RotationalYoyos
{
    public class GradientEffect : ModProjectile
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
            Projectile.damage = 45;
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

            float maxDetectRadius = 800f;
            float projSpeed = 12f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);

            if (closestNPC is null)
            {
                Projectile.velocity *= 0;
                Projectile.velocity = away * 9f;
                Projectile.tileCollide = true;
                Projectile.timeLeft = 180;
                return;
            }

            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;

            Projectile.penetrate = 1;
            Projectile.rotation += 0.2f;

            if (!_initialized)
            {
                Projectile.frame = player.ownedProjectileCounts[Type];
                _initialized = true;
            }
        }

        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];

                if (target.CanBeChasedBy())
                {

                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);


                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }

            }

            return closestNPC;
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
