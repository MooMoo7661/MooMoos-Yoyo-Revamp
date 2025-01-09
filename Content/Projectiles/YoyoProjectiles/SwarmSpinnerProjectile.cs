using System;
using CombinationsMod.Content.Global_Classes.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class SwarmSpinnerProjectile : ModProjectile
    {
        public int timer = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 480;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.7f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
            Projectile.penetrate = -1;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.immortal || !target.chaseable)
                return;

            Player player = Main.player[Projectile.owner];

            if (Main.rand.NextBool(4))
                target.AddBuff(Main.rand.NextBool(5) ? BuffID.Confused : BuffID.Poisoned, 120 + Main.rand.Next(15, 75));

            int num3 = Main.rand.Next(2, 5);
            if (player.strongBees && Main.rand.NextBool(2))
            {
                num3++;
            }
            for (int j = 0; j < num3; j++)
            {
                float num4 = (float)(Projectile.direction * 2) + (float)Main.rand.Next(-35, 36) * 0.02f;
                float num5 = (float)Main.rand.Next(-35, 36) * 0.02f;
                num4 *= 0.2f;
                num5 *= 0.2f;
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, new(num4, num5), ProjectileID.Wasp, player.beeDamage(Projectile.damage), player.beeKB(0f), Projectile.owner);
            }
        }
    }
}
