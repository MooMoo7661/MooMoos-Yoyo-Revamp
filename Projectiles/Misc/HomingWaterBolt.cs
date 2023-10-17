using CombinationsMod.Projectiles.Explosions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.Misc
{
    // yes this is example mod's targetting code cause i didnt feel like writing it myself lol. it's 12:00 at night ok
    public class HomingWaterBolt : ModProjectile
    {
        private int dustTimer = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.damage = 30;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 300;
            Projectile.velocity *= 0.2f;
        }


        public override void AI()
        {
            float maxDetectRadius = 400f;
            float projSpeed = 5f;

            NPC closestNPC = FindClosestNPC(maxDetectRadius);

            if (closestNPC is null)
            {
                Projectile.Kill();
                return;
            }
        
            Projectile.velocity = (closestNPC.Center - Projectile.Center).SafeNormalize(Vector2.Zero) * projSpeed;
            Projectile.rotation = Projectile.velocity.ToRotation();

            Projectile.rotation = Projectile.Center.AngleTo(closestNPC.Center);
        }

        public NPC FindClosestNPC(float maxDetectDistance)
        {
            NPC closestNPC = null;
            float sqrMaxDetectDistance = maxDetectDistance * maxDetectDistance;

            for (int k = 0; k < Main.maxNPCs; k++)
            {
                NPC target = Main.npc[k];

                if (target.CanBeChasedBy())
                {

                    float sqrDistanceToTarget = Vector2.DistanceSquared(target.Center, Projectile.Center);


                    if (sqrDistanceToTarget < sqrMaxDetectDistance)
                    {
                        sqrMaxDetectDistance = sqrDistanceToTarget;
                        closestNPC = target;
                    }
                }
            }

            return closestNPC;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Main.myPlayer == Projectile.owner)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                    Main.rand.NextBool() ? 1 : -1, ModContent.ProjectileType<WaterExplosion>(), 34, 0, Projectile.owner);
            }
        }

        public override void PostAI()
        {
            dustTimer++;

            if (dustTimer >= 10)
            {
                if (Main.rand.NextBool())
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.WaterCandle);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.2f;
                }
            }
        }
    }
}