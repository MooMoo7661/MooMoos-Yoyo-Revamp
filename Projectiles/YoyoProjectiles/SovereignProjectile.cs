using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using System.Diagnostics.Metrics;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class SovereignProjectile : ModProjectile
    {
        public int storeData = -1;
        public int storeData2 = -1;
        public int counter = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 290f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            counter++;

            Player player = Main.player[Projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                if (counter >= 15 && counter % 2 == 0)
                {
                    SpecialEffect();
                }
            }
        }

        public void SpecialEffect()
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.SapphireBolt, 7, 1, Projectile.owner);
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }
        } 
        public override void PostAI()
        {


            Lighting.AddLight(Projectile.Center, (float)1.2, 0, 0);
            if (storeData == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<CurveDuo>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData2 == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<SwirlBlue>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.DungeonWater);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1f;
            }
        }
    }
}
