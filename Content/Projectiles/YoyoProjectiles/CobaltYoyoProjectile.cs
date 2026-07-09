using System;
using CombinationsMod.Content.Configs;
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
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 200f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15.5f;

            if (ModLoader.HasMod("CalamityMod") || ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror)
            {
                CalamityBalancing.RebalanceYoyoOnDemand(24f, 280f, 17f, 0, this.Projectile, 12);
            }
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
            Projectile.ArmorPenetration = 10;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (Projectile.YoyoData().Hits % 20 == 0 && Projectile.YoyoData().Hits > 0)
            {
                SoundStyle HitSound = new()
                {
                    SoundPath = "CombinationsMod/Content/Sounds/fist",
                    Volume = 0.85f,
                    PitchVariance = 0.2f,
                    SoundLimitBehavior = SoundLimitBehavior.IgnoreNew
                };
                SoundEngine.PlaySound(HitSound);

                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, new(8, 0), ModContent.ProjectileType<CobaltFist>(), (int)(Projectile.damage * (Projectile.YoyoData().MainYoyo ? 1.4f : 0.85f)), 0f, Projectile.owner).scale = Projectile.YoyoData().MainYoyo ? 1f : 0.8f;
                Projectile.NewProjectileDirect(Projectile.GetSource_FromThis(), Projectile.Center, new(-8, 0), ModContent.ProjectileType<CobaltFist>(), (int)(Projectile.damage * (Projectile.YoyoData().MainYoyo ? 1.4f : 0.85f)), 0f, Projectile.owner).scale = Projectile.YoyoData().MainYoyo ? 1f : 0.8f;

                foreach (NPC npc in Main.ActiveNPCs)
                {
                    if (npc.Distance(Projectile.Center) > (Projectile.YoyoData().MainYoyo ? 250f : 200f))
                        continue;

                    if (!npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f)
                    {
                        npc.velocity -= npc.DirectionTo(Projectile.GetOwner().Center) * (Projectile.YoyoData().MainYoyo ? 10f : 6f);
                        npc.velocity.Y -= 2f;

                        NPC.HitInfo info = npc.CalculateHitInfo((int)(Projectile.damage * (Main.rand.NextFloat(0, 0.5f) + (Projectile.YoyoData().MainYoyo ? 1.3f : 1f))), -npc.direction, false, 0f);
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
