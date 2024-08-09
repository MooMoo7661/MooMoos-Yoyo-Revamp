using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects.Solid
{

    public class Sparkle1 : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 200;
            Projectile.height = 200;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 1f;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
            Projectile.alpha = 0;
            Projectile.hide = true;

            Projectile.usesIDStaticNPCImmunity = false;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 25 * Projectile.MaxUpdates;
        }

        public override void DrawBehind(int index, List<int> behindNPCsAndTiles, List<int> behindNPCs, List<int> behindProjectiles, List<int> overPlayers, List<int> overWiresUI)
        {
            behindNPCs.Add(index);
        }

        private int dustID;
        private bool secondDustVelocity = false;

        public override void PostAI()
        {
            switch (Projectile.localAI[0])
            {
                case 1:
                    dustID = DustID.TerraBlade;
                    break;

                case 2:
                    dustID = DustID.Shadowflame;
                    break;
            }

            if (Projectile.localAI[1] == 1)
            {
                secondDustVelocity = true;
            }

            if (secondDustVelocity)
            {
                if (Main.rand.NextBool())
                {
                    int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
                    dustID, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 0.7f);

                    Main.dust[dust].velocity = Projectile.velocity * 1f;
                    Main.dust[dust].velocity *= 0.2f;
                }
            }
            else
            {
                if (Main.rand.NextBool())
                {
                    for (int i = 0; i < 1; i++)
                    {
                        Vector2 circular = Main.rand.NextVector2Circular(3f, 3f);

                        int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, dustID, 0f, 0f, 100, default, 1f);
                        Main.dust[dustIndex].noGravity = true;

                    }
                }
            }
        }
        public override void AI()
        {

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
    }
}