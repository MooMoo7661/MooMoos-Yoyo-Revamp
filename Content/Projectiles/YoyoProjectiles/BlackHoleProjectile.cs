using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.Misc;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.GlobalClasses.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YoyoStringLib;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class BlackHoleProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 364f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;

            //if (CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 2;
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
            if (Projectile.ai[2] == 0 && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                Dust dust2 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, DustID.PinkTorch, 0f, 0f, 0, default, Main.rand.NextFloat(0.5f, 2.4f));
                dust2.velocity = VectorHelper.VelocityToPoint(dust2.position, Projectile.Center, Vector2.Distance(dust2.position, Projectile.Center) * 0.05f);
                dust2.color = Color.Black;
                dust2.noGravity = true;

                Dust dust3 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, DustID.Wraith, 0f, 0f, 0, default, Main.rand.NextFloat(0.5f, 2.4f));
                dust3.velocity = VectorHelper.VelocityToPoint(dust3.position, Projectile.Center, Vector2.Distance(dust3.position, Projectile.Center) * 0.05f);
                dust3.color = Color.Black;
                dust3.noGravity = true;


                if (Main.rand.NextBool(7))
                {
                    for (int j = 0; j < 1; j++)
                    {
                        Vector2 velocity = VectorHelper.CircularRandom() * 3f;
                        Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X + Projectile.velocity.X, Projectile.Center.Y + Projectile.velocity.Y, velocity.X, velocity.Y, ModContent.ProjectileType<BlackHoleSparkle>(), 0, 1f, Projectile.owner, 0f, Main.rand.Next(-0, 0));
                    }
                }
            }
        }

        public override void AI()
        {
            if (!Projectile.YoyoData().MainYoyo)
                return;

            float pullRadius = 400f;
            float pullStrength = 0.15f;

            foreach(NPC npc in Main.ActiveNPCs)
            {
                if (npc.active && !npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f)
                {
                    // Calculate direction from NPC to projectile
                    Vector2 direction = Projectile.Center - npc.Center;
                    float distance = direction.Length();
                    float npcSize = Math.Max(npc.width, npc.height);
                    if (npcSize > 85)
                    {
                        // Scale pull strength inversely with NPC size
                        pullStrength *= Math.Max(0.1f, 1f - ((npcSize - 55) / 55f));
                    }

                    // Determine strength multiplier based on distance from the center of the projectile
                    float strengthMultiplier = 1f;
                    if (distance < pullRadius)
                    {
                        strengthMultiplier = 1f - (distance / pullRadius); // Linear decrease
                    }

                    if (distance < pullRadius && distance > 0)
                    {
                        npc.velocity.X += npc.DirectionTo(Projectile.Center).X * pullStrength * strengthMultiplier;
                        npc.velocity.Y += npc.DirectionTo(Projectile.Center).Y * pullStrength * 4f * strengthMultiplier;

                        if (distance < 70)
                            npc.velocity = npc.DirectionTo(Projectile.Center) * pullStrength * 20f;
                    }
                }
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.StringData().StringTexture = TextureAssets.Chains[16];

            if (Projectile.ai[2] == 0 && Main.myPlayer == Projectile.owner && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
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
                    0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.7f) + 1, 0,
                    Main.myPlayer, 0, Projectile.whoAmI);

                Main.projectile[proj].Resize(270, 270);
            }
        }

        public static void DrawGlowBallAdditive(Vector2 pos, float scaleMultiplier, Color outerColor, Color innerColor, bool shiny = true)
        {
            Texture2D GlowBall = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Content/Projectiles/YoyoProjectiles/GlowBallPremultiplied");

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
