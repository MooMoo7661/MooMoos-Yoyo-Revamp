using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.Misc;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Terraria.DataStructures;
using CombinationsMod.GlobalClasses.Projectiles;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TheCrowyoProjectile : ModProjectile
    {
        private int timer = 0;
        public override void SetStaticDefaults()
        {

            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 389f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.15f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.extraUpdates = 0;
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
                timer++;
                if (timer == 90)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        if (Main.myPlayer == Projectile.owner)
                        {
                            Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 7f;

                            int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                                ModContent.ProjectileType<CrowyoFeather>(), (int)(Projectile.damage * 0.4f), 1, Projectile.owner, 0, 1f);
                            Main.projectile[proj].tileCollide = true;
                            Main.projectile[proj].timeLeft = 120;
                            Main.projectile[proj].friendly = true;
                            Main.projectile[proj].hostile = false;
                        }
                    }
                    timer = 0;
                }
            }
        }

        public override void OnSpawn(IEntitySource source)
        {

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
            DrawGlowBallAdditive(Projectile.Center, 0.4f, Color.White, Color.White, true);
            return true;
        }
    }
}
