using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Projectiles.Misc
{
    public class CobaltFist : ModProjectile
    {
        int timer = 0;
        public override void SetDefaults()
        {
            Projectile.width = 30;
            Projectile.height = 38;
            Projectile.damage = 40;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.usesIDStaticNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 20;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
        }

        public override void PostAI()
        {
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            timer++;

            if (timer >= 20)
            {
                if (Projectile.alpha < 255)
                    Projectile.alpha += 4;
                else
                    Projectile.Kill();
            }

            Projectile.velocity.X *= 0.95f;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            return false;
        }
    }
}
