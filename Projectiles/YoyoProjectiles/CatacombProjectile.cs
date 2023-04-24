using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class CatacombProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 238.2f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 10.3f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 65;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;

            Projectile.velocity *= 0.8f;
        }
        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Bone);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 0.73f;
            }

            int rand = Main.rand.Next(20);
            if (rand == 0 && Main.myPlayer == Projectile.owner)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 1f, Main.rand.Next(-3, 3) * 1f,
                Main.rand.Next(-3, 3) * 1f, ProjectileID.Bone, (int)(Projectile.damage * 1f), 0, Projectile.owner);
                Main.projectile[proj].scale = 0.8f;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }
        }
    }
}
