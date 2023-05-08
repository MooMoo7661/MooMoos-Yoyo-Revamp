using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.Explosions
{
    // yes this is example mod's targetting code cause i didnt feel like writing it myself lol. it's 12:00 at night ok
    public class CragHomingExplosive : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");

            ProjectileID.Sets.CultistIsResistantTo[Projectile.type] = true;
        }
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.light = 1f;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 300;
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


        public override void Kill(int timeLeft)
        {
            






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
                    Main.rand.NextBool() ? 1 : -1, ModContent.ProjectileType<FireExplosion>(), 11, 0, Projectile.owner);
            }
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.Lava);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.2f;
            }
        }
    }
}