using System;
using CombinationsMod.Projectiles;
using CombinationsMod.Projectiles.Misc;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class ThinMintProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 220f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.5f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 30;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1.15f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Blood);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 2.2f;
                    
                Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.RedMoss);
                dust2.noGravity = true;
                dust2.noLight = true;
                dust2.scale = 2f;

                Dust dust3 = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.DynastyShingle_Red);
                dust3.noGravity = true;
                dust3.noLight = true;
                dust3.scale = 2.5f;
            }
        }
        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Blood);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 1.6f;
            }
        }
    }
}
