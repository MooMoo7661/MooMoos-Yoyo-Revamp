using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Projectiles.Misc
{
    public class CascadeFireTrail : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.damage = 20;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 20;
            Projectile.aiStyle = -1;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return false;
        }

        public override void PostAI()
        {
            Dust fire = Dust.NewDustDirect(Projectile.position, 3, 3, DustID.Torch, 0, 3f);
            fire.noGravity = true;
            fire.scale = 1.6f;
        }
    }
}
