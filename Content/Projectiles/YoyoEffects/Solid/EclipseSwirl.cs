using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoEffects.Solid
{

    public class EclipseSwirl : ModProjectile
    {
        protected float Scale = 0.5f;

        public override void SetDefaults()
        {
            Projectile.width = 100;
            Projectile.height = 100;

            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.knockBack = 3f;
            Projectile.light = 0.8f;
            Projectile.aiStyle = -1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 150;
        }
        public override string Texture => "CombinationsMod/Content/Projectiles/YoyoEffects/Solid/EclipseSwirl";
        public override Color? GetAlpha(Color lightColor) => new(255, 92, 0, 0); // More Orange

        public override void AI()
        {
            Projectile.rotation += 0.20f;
        }

        /*public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(Scale);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            Projectile.scale = reader.ReadSingle();
        }*/
    }
}