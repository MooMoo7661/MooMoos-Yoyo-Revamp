﻿using CombinationsMod.Dusts;
using Microsoft.Xna.Framework;
using On.Terraria.DataStructures;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.YoyoEffects.Solid
{

    public class SmudgeHitbox : ModProjectile
    {

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Smudge Hitbox");
        }

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
        }
        public override string Texture => "CombinationsMod/Projectiles/YoyoEffects/ScalableHitbox1";

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            Player player = Main.player[Projectile.owner];

            if (player.ZoneGraveyard)
            {
                damage = (int)(damage * 1.5f);
            }
        }
        public override void AI()
        {
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
    }
}