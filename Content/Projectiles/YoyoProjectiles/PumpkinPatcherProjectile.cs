using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YoyoStringLib;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class PumpkinPatcherProjectile : ModProjectile
    {
        int timer = 0;
        int rad = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 450;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.4f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 9.1f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 2;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            Projectile.StringData().StringTexture = ModContent.Request<Texture2D>("CombinationsMod/Content/YoyoStringTextures/SpookyString", ReLogic.Content.AssetRequestMode.ImmediateLoad);
        }

        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            npc.AddBuff(BuffID.Inferno, 240);

            if (!npc.active && npc.realLife == -1)
            {
                for (int i = 0; i < npc.width; i++)
                {
                    for (int j = 0; j < npc.height; j++)
                    {
                        if (i % 16 == 0 && j % 16 == 0)
                        {
                            if (Main.rand.NextBool(2))
                            {
                                Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), new(npc.position.X + i, npc.position.Y + j), Vector2.UnitX.RotatedByRandom(360) * 2f, 326 + Main.rand.Next(0, 3), Projectile.damage / 2, 1f, Projectile.owner);
                                proj.hostile = false;
                                proj.friendly = true;
                                proj.timeLeft = 120;
                                proj.scale = 0.8f;
                                proj.penetrate = 1;
                            }
                        }
                    }
                }
            }
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.SpookyWood);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 0.9f;


                if (Main.rand.NextBool())
                {
                    Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.BatScepter);
                    dust2.noGravity = true;
                    dust2.noLight = false;
                    dust2.scale = 0.8f;
                }
            }

            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1.4f);
            }
        }

        public override void AI()
        {
            if (Projectile.YoyoData().MainYoyo && Projectile.YoyoData().Hits >= 15)
            {
                timer++;

                if (timer >= 40)
                {
                    timer = 0;
                    if (rad >= 360)
                        rad = 0;

                    rad += 1;
                    Vector2 vel = new Vector2(0, -1).RotatedBy(rad) * 4f;
                    Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis("PumpkinPatcher"), Projectile.Center, vel, 664, Projectile.damage / 2, 1f, Projectile.owner);
                    proj.scale = 0.65f;
                    proj.timeLeft = 120;
                }
            }
        }
    }
}
