﻿using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects.Solid
{

    public class CultistRingDamage : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 150;
            Projectile.height = 150;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 3f;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
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

        public override string Texture => "CombinationsMod/Content/Projectiles/YoyoEffects/ScalableHitbox1";

        public override void AI()
        {
            Projectile.rotation += 0.20f;

            if (Projectile.ai[1] != -1)
            {
                Projectile proj = Main.projectile[(int)Projectile.ai[1]];

                if (proj.active && proj.owner == Projectile.owner && proj.aiStyle == 99)
                {
                    Projectile.Center = proj.Center;
                    Projectile.position.X = proj.Center.X - Projectile.width / 2;
                    Projectile.position.Y = proj.Center.Y - Projectile.height / 2;
                    Projectile.timeLeft = 6;
                    Projectile.netUpdate = true;
                }

                if (proj.ai[0] == -1)
                {
                    Projectile.Kill();
                }
            }
        }

        public override bool? Colliding(Rectangle projHitbox, Rectangle targetHitbox)
        {
            float radius = Projectile.width / 2f;
            return Projectile.Center.DistanceSQ(targetHitbox.ClosestPointInRect(Projectile.Center)) < radius * Projectile.scale * radius * Projectile.scale;
        }
    }
}