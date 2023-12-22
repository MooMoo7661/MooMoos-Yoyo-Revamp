using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.Explosions
{

    public class RedExplosion : ModProjectile
    {
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

        public override string Texture => "CombinationsMod/Content/Projectiles/Explosions/FireExplosion";
        public override void OnSpawn(Terraria.DataStructures.IEntitySource source)
        {
            for (int i = 0; i < 20; i++)
            {
                int dustIndex = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Clentaminator_Red, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex].noGravity = true;

                int dustIndex2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.RedTorch, 0f, 0f, 100, default, 3f);
                Main.dust[dustIndex2].noGravity = true;
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