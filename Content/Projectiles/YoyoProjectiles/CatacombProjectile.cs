using Microsoft.Xna.Framework;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Terraria.Audio;
using CombinationsMod.Content.Items.Accessories.InfoAccessories;
using System;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class CatacombProjectile : ModProjectile
    {
        public int hitCounter = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 16f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 238.2f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.2f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;

            Projectile.velocity *= 0.8f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            hitCounter++;
            if (hitCounter >= 20)
            {
                foreach(NPC npc in Main.ActiveNPCs)
                {
                    if (npc.Distance(Projectile.Center) > 250f)
                        continue;

                    if (!npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f)
                    {
                        npc.velocity -= npc.DirectionTo(Projectile.Center) * 8;
                        npc.velocity.Y -= 6f;
                    }
                }

                SoundStyle HitSound = new SoundStyle
                {
                    SoundPath = "CombinationsMod/Content/Sounds/rock",
                    Volume = 0.4f,
                    PitchVariance = 0.3f,
                    SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                };

                for (int i = 0; i < 16; i++)
                {
                    Vector2 speed = -Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Main.rand.NextFloat();
                    Projectile proj = Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), new Vector2(Projectile.position.X, Projectile.position.Y - 16f), speed * 10f, ProjectileID.Bone, Projectile.damage, 4f);
                    proj.hostile = false;
                    proj.friendly = true;
                    proj.scale = 0.8f;
                }

                SoundEngine.PlaySound(HitSound);

                hitCounter = 0;
            }
        }
    }
}
