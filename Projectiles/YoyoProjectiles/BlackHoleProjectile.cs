using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.Misc;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Terraria.DataStructures;
using CombinationsMod.GlobalClasses.Projectiles;
using Microsoft.Xna.Framework.Graphics;
using static CombinationsMod.ModSystems.ModDetector;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class BlackHoleProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 364f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 18.8f;

            //if (CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
            Projectile.rotation = 0.32f;
        }
        public override void PostAI()
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                Dust dust2 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, DustID.PinkTorch, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                dust2.velocity = VectorHelper.VelocityToPoint(dust2.position, Projectile.Center, Vector2.Distance(dust2.position, Projectile.Center) * 0.05f);
                dust2.color = Color.Black;
                dust2.noGravity = true;

                Dust dust3 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, DustID.Wraith, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                dust3.velocity = VectorHelper.VelocityToPoint(dust3.position, Projectile.Center, Vector2.Distance(dust3.position, Projectile.Center) * 0.05f);
                dust3.color = Color.Black;
                dust3.noGravity = true;


                if (Main.rand.NextBool(7))
                {
                    for (int j = 0; j < 1; j++)
                    {
                        Vector2 velocity = VectorHelper.CircularRandom() * 3f;
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + base.Projectile.velocity.X, base.Projectile.Center.Y + base.Projectile.velocity.Y, velocity.X, velocity.Y, ModContent.ProjectileType<BlackHoleSparkle>(), 0, 1f, Projectile.owner, 0f, Main.rand.Next(-0, 0));
                    }
                }
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Main.myPlayer == Projectile.owner && ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                   0, 0, ModContent.ProjectileType<BlackHole4>(), (int)(Projectile.damage * 0.75f) + 1, 0,
                   Main.myPlayer, 0, Projectile.whoAmI);

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<BlackHole2>(), (int)(Projectile.damage * 0.75f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<BlackHoleCenter1>(), (int)(Projectile.damage * 0.75f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<BlackHoleCenter2>(), (int)(Projectile.damage * 0.75f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<BlackHole>(), (int)(Projectile.damage * 0.75f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);


                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.4f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);

                Main.projectile[proj].Resize(270, 270);
            }
        }

        public static void DrawGlowBallAdditive(Vector2 pos, float scaleMultiplier, Color outerColor, Color innerColor, bool shiny = true)
        {
            Texture2D GlowBall = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Projectiles/YoyoProjectiles/GlowBallPremultiplied");

            Vector2 origin = GlowBall.Size() / 2;
            Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, outerColor with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier, SpriteEffects.None);
            Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, innerColor with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier * 0.5f, SpriteEffects.None);
            if (shiny)
                Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, Color.White with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier * 0.25f, SpriteEffects.None);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            DrawGlowBallAdditive(Projectile.Center, 0.8f, Color.White, Color.White, true);
            return true;
        }
    }
}
