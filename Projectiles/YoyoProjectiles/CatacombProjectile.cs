using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class CatacombProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {

            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 238.2f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.3f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15f;
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

            if (Main.rand.NextBool(20) && Main.myPlayer == Projectile.owner && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 1f, Main.rand.Next(-5, 5),
                Main.rand.Next(-5, 5), ProjectileID.Bone, (int)(Projectile.damage * 0.7f), 0, Projectile.owner);
                Main.projectile[proj].scale = 0.8f;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }
        }
    }
}
