using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Buffs;
using Microsoft.Xna.Framework;
using System.Diagnostics.Metrics;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TheMuscleYoyoProjectile : ModProjectile
    {
        public int counter = 0;
        public int storeData = -1;
        public int storeData2 = -1;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 240f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.7f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 90;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 20, DustID.BloodWater);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 0.8f;
            }
            Player player = Main.player[Projectile.owner];
            if (player.ZoneCrimson == true)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 20, DustID.CrimsonTorch);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.35f;


                Lighting.AddLight(Projectile.Center, (float)1.2, 0, 0);


                if (storeData2 == -1 && Projectile.owner == Main.myPlayer)
                {
                    storeData2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<SwirlRed>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
                }
            }
        }
    }
}
