using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TheQueensGambitProjectile : ModProjectile
    {
        public int timer = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 240f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.3f;
        }

        public override void SetDefaults()
        {
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
            
            if (timer == 60 && Main.myPlayer == Projectile.owner)
            {
                Vector2 velocity = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 1f;

                Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, velocity, player.beeType(), player.beeDamage(Projectile.damage), player.beeKB(Projectile.knockBack), Projectile.owner);
                proj.friendly = true;
            }

            if (Main.rand.NextBool(4))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Bee);
                dust.noGravity = true;
                dust.noLight = true;
                float random = Main.rand.NextFloat(1f, 2f);
                dust.scale = random;
            }

            if (timer == 60)
                timer = 0;
        }
    }
}
