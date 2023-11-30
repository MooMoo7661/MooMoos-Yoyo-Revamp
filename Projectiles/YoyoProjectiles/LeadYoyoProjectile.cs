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
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class LeadYoyoProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 153f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.7f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.2f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 20;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }
    }
}
