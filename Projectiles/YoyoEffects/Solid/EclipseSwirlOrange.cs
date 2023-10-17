using CombinationsMod.Dusts;
using CombinationsMod.Projectiles.Explosions;
using Terraria.DataStructures;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.YoyoEffects.Solid
{

    public class EclipseSwirlOrange : ModProjectile
    {
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

        
        public override string Texture => "CombinationsMod/Projectiles/YoyoEffects/Solid/EclipseSwirl";
        public override Color? GetAlpha(Color lightColor) => new(255, 45, 0, 0); // Orange

        public override void AI()
        {
            Projectile.rotation += 0.20f;
        }
    }
}