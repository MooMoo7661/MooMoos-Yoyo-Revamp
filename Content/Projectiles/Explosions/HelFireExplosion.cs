using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.Explosions
{

    public class HelFireExplosion : ModProjectile
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
            SoundEngine.PlaySound(in SoundID.Item14, Projectile.Center);

            for (int i = 0; i < 20; i++)
            {
                int dust1 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, 0f, 0f, 100, default, 1.5f);
                Main.dust[dust1].velocity *= 1.4f;

                int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 3f);
                Main.dust[dust2].noGravity = true;
            }

            for (int j = 0; j < 3; j++)
            {
                int gore1 = Gore.NewGore(Projectile.GetSource_FromThis(), Projectile.Center, default, Main.rand.Next(61, 64));
                Main.gore[gore1].velocity *= 0.4f;

                Vector2 direction = Utils.RotatedByRandom(new(1f, 1f), MathHelper.ToRadians(360f));
                Main.gore[gore1].velocity.X += direction.X;
                Main.gore[gore1].velocity.Y += direction.Y;
            }

            for (int k = 0; k < 10; k++)
            {
                int dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 2.5f);
                Main.dust[dust3].noGravity = true;
                Main.dust[dust3].velocity *= 5f;

                dust3 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 100, default, 1.5f);
                Main.dust[dust3].velocity *= 3f;
            }
        }
    }
}