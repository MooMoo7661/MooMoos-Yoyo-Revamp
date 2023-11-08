using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CombinationsMod.Items;
using CombinationsMod.Dusts;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class StoneAgeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 11f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 143f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.8f;
        }

        public override void SetDefaults()
        {
            Projectile.scale = 1f;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 20;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.rand.NextBool(7))
            {
                target.AddBuff(BuffID.Confused, 180);
            }
        }
    }
}
