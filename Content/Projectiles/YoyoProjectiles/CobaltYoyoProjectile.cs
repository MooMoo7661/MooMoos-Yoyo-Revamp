using System;
using CombinationsMod.Content.Projectiles.Misc;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class CobaltYoyoProjectile : ModProjectile
    {
        public int timer = 10;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 260f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13.9f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.6f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
            Projectile.ArmorPenetration = 10;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.YoyoData().MainYoyo && Projectile.YoyoData().Hits % 20 == 0 && Projectile.YoyoData().Hits > 0)
            {
                SoundStyle HitSound = new()
                {
                    SoundPath = "CombinationsMod/Content/Sounds/fist",
                    Volume = 0.85f,
                    PitchVariance = 0.2f,
                    SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                };

                SoundEngine.PlaySound(HitSound);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, new(10, 0), ModContent.ProjectileType<CobaltFist>(), (int)(Projectile.damage * 1.4f), 12f, Projectile.owner);
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, new(-10, 0), ModContent.ProjectileType<CobaltFist>(), (int)(Projectile.damage * 1.4f), 12f, Projectile.owner);

                foreach (NPC npc in Main.ActiveNPCs)
                {
                    if (npc.Distance(Projectile.Center) > 250f)
                        continue;

                    if (!npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f)
                    {
                        npc.velocity -= npc.DirectionTo(Projectile.Center) * 8;
                        npc.velocity.Y -= 2f;
                        NPC.HitInfo info = npc.CalculateHitInfo((int)(Projectile.damage * (Main.rand.NextFloat(0, 0.5f) + 1.3f)), -npc.direction, false, 0f);

                        npc.AddBuff(BuffID.Confused, 120);
                        npc.StrikeNPC(info, true);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendStrikeNPC(npc, info);
                        }
                    }
                }

                for (int i = 0; i < 35; i++)
                {
                    Vector2 speed = -Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * 4f;
                    Dust.NewDust(new(target.Center.X, target.Center.Y), 20, 5, DustID.Dirt, speed.X, speed.Y);
                }
            }
        }
    }
}
