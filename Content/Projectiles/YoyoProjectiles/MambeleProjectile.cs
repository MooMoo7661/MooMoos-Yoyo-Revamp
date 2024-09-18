using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class MambeleProjectile : ModProjectile
    {
        public int counter = 0;
        public int altCounter = 0;
        public int storeData = -1;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 450;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.4f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.1f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 2;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            counter++;
            altCounter++;


            if (counter >= 30 && altCounter == 2)
            {
                SpecialEffect();
            }

            if (altCounter == 2)
            {
                altCounter = 0;
            }
        }

        public void SpecialEffect()
        {
            for (int i = 0; i < 8; i++)
            {
                if (Main.myPlayer == Projectile.owner)
                {
                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 2f;

                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                        ProjectileID.GreekFire3, Projectile.damage / 2, 1, Projectile.owner, 0, 1f);
                    Main.projectile[proj].scale = 0.45f;
                    Main.projectile[proj].tileCollide = true;
                    Main.projectile[proj].timeLeft = 120;
                    Main.projectile[proj].friendly = true;
                    Main.projectile[proj].hostile = false;
                }
            }
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.SpookyWood);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 2f;


                if (Main.rand.NextBool())
                {
                    Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.BatScepter);
                    dust2.noGravity = true;
                    dust2.noLight = false;
                    dust2.scale = 1.5f;
                }
            }

            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1.4f);
            }
        }
    }
}
