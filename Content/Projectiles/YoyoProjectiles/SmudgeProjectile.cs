using System;
using Microsoft.Xna.Framework;
using CombinationsMod.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class SmudgeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 242f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.5f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.2f;
        }

        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }

        public override void ModifyHitNPC(NPC npc, ref NPC.HitModifiers modifiers)
        {
            if (npc.type == NPCID.Ghost || npc.type == NPCID.Wraith || npc.type == NPCID.Poltergeist)
            modifiers.FinalDamage *= 3f;
        }

        public override void AI()
        {
            foreach(NPC npc in Main.ActiveNPCs)
            {
                if (npc.type == NPCID.Ghost || npc.type == NPCID.Poltergeist || npc.type == NPCID.Wraith)
                {
                    if (npc.Distance(Projectile.Center) < 250)
                    npc.velocity -= npc.DirectionTo(Projectile.Center) * 0.15f;
                    npc.velocity.X = Math.Clamp(npc.velocity.X, -3f, 3f);
                    npc.velocity.Y = Math.Clamp(npc.velocity.Y, -3f, 3f);
                }
            }
        }

        public override void OnHitNPC(NPC npc, NPC.HitInfo hit, int damageDone)
        {
            if (npc.type == NPCID.Ghost || npc.type == NPCID.Wraith || npc.type == NPCID.Poltergeist)
            {
                for (int i = 0; i < 50; i++)
                {
                    Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f);
                    Dust d = Dust.NewDustPerfect(npc.Center + speed * 32, DustID.BlueCrystalShard, speed * 2, Scale: 1.5f);
                    d.noGravity = true;
                }

                if (npc.life <= 0)
                {
                    SoundStyle GhostSound = new SoundStyle
                    {
                        SoundPath = "CombinationsMod/Content/Sounds/phasmo-ghost",
                        Volume = 0.8f,
                        PitchVariance = 0.2f,
                        SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                    };

                    SoundEngine.PlaySound(GhostSound);
                }
            }
        }

        public override void PostAI()
        {
            Dust d = Dust.NewDustPerfect(Projectile.Center + Projectile.velocity + Main.rand.NextVector2CircularEdge(1f, 1f) * 2, DustID.BlueCrystalShard, Projectile.velocity * 0.5f + Main.rand.NextVector2CircularEdge(1f, 1f), Scale: 1.5f);
            d.noGravity = true;
        }
    }
}
