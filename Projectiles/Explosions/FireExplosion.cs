using Terraria.Audio;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.Explosions
{
    
    public class FireExplosion : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fire Explosion");

            
        }
        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 100;

            Projectile.aiStyle = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.friendly = true;
            Projectile.hostile = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 5;
            Projectile.knockBack = 6f;
            Projectile.damage = 8;
        }

        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
           for(int i = 0; i < 20; i++)
           {
                Vector2 circular = Main.rand.NextVector2Circular(3f, 3f);

                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.FlameBurst, 0f, 0f, 100, default(Color), 3f);
                Main.dust[dustIndex].noGravity = true;

           }
        }
        public override void Kill(int timeLeft)
        {
            if (Projectile.soundDelay == 0)
            {
               SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            }
            Projectile.soundDelay = 10;
        }

        

        
    }
}