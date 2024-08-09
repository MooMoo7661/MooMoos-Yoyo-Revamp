using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class TheQueensGambitProjectile : ModProjectile
    {
        public int timer = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 480;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.7f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.5f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 40;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];
            Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;

            if (Main.myPlayer == Projectile.owner)
            {
                Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, velocity, player.beeType(), player.beeDamage(damageDone), player.beeKB(Projectile.knockBack), Projectile.owner);
                proj.friendly = true;
            }
        }

        public override void PostAI()
        {
            timer++;

            Player player = Main.player[Projectile.owner];

            if (timer >= 60 && Main.myPlayer == Projectile.owner)
            {
                for (int i = 0; i < Main.rand.Next(1, 3); i++)
                {
                    Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;
                    Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, velocity, ProjectileID.Wasp, (int)(player.beeDamage(Projectile.damage) * 0.7f), player.beeKB(Projectile.knockBack), Projectile.owner);
                    proj.friendly = true;
                }
                timer = 0;
            }

            if (Main.rand.NextBool(4))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Bee);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = Main.rand.NextFloat(1f, 2f);
            }
        }
    }
}
