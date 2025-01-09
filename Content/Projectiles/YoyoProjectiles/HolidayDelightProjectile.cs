using System;
using CombinationsMod.Content.Global_Classes.Projectiles;
using CombinationsMod.Content.Projectiles.Misc;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using YoyoStringLib;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class HolidayDelightProjectile : ModProjectile
    {
        public int timer = 0;
        public int rad = 0;

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
            Projectile.StringData().StringTexture = ModContent.Request<Texture2D>("CombinationsMod/Content/YoyoStringTextures/ChristmasString" + (Main.rand.NextBool() ? "2" : ""), ReLogic.Content.AssetRequestMode.ImmediateLoad);
        }

        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            if (!npc.active && npc.realLife == -1)
            {
                for (int i = 0; i < npc.width; i++)
                {
                    for (int j = 0; j < npc.height; j++)
                    {
                        if (i % 16 == 0 && j % 16 == 0)
                        {
                            Projectile.NewProjectileDirect(Projectile.GetSource_FromThis("ChristmasBulb"), new(npc.position.X + i, npc.position.Y + j), Vector2.UnitX.RotatedByRandom(360) * 2f, ProjectileID.SantaBombs, Projectile.damage / 2, 1f, Projectile.owner);
                        }
                    }
                }
            }

            npc.AddBuff(BuffID.Frostburn, 240);
        }

        public override void AI()
        {
            if (Projectile.YoyoData().MainYoyo && Projectile.YoyoData().Hits >= 15)
            {
                timer++;

                if (timer >= 20)
                {
                    timer = 0;
                    if (rad >= 360)
                        rad = 0;

                    rad += 1;
                    Vector2 vel = new Vector2(0, -1).RotatedBy(rad) * 4f;
                    Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis("ChristmasBulb"), Projectile.Center, vel, ProjectileID.Blizzard, Projectile.damage / 2, 1f, Projectile.owner);
                    proj.scale = 0.65f;
                    proj.timeLeft = 120;
                }
            }
        }
    }
}

