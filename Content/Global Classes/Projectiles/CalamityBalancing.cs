using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using static CombinationsMod.Content.Global_Classes.Projectiles.CalamityBalancing;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    // Definitely did not borrow code from calamity :)
    public class CalamityBalancing : GlobalProjectile
    {
        public interface IProjectileTweak
        {
            bool AppliesTo(Projectile proj);
            void ApplyTweak(Projectile proj);
        }

        internal static bool IsAYoyo(Projectile proj) => proj.aiStyle == ProjAIStyleID.Yoyo;

        internal class ExtraUpdatesExactRule : IProjectileTweak
        {
            internal readonly int newExtraUpdates = 0;

            public ExtraUpdatesExactRule(int eu) => newExtraUpdates = eu;
            public bool AppliesTo(Projectile proj) => true;
            public void ApplyTweak(Projectile proj)
            {
                proj.extraUpdates = newExtraUpdates;
                if (proj.extraUpdates < 0)
                    proj.extraUpdates = 0;
            }
        }

        internal static IProjectileTweak ExtraUpdatesExact(int eu) => new ExtraUpdatesExactRule(eu);

        internal class LocalIFrameRule : IProjectileTweak
        {
            internal readonly int localIFrameValue = -2;

            public LocalIFrameRule(int f) => localIFrameValue = f;
            public bool AppliesTo(Projectile proj) => true;
            public void ApplyTweak(Projectile proj)
            {
                proj.usesLocalNPCImmunity = true;
                proj.localNPCHitCooldown = localIFrameValue;
                proj.usesIDStaticNPCImmunity = false;
                proj.idStaticNPCHitCooldown = 0;
            }
        }
        internal static IProjectileTweak LocalIFrames(int f) => new LocalIFrameRule(f);

        internal class YoyoLifetimeRule : IProjectileTweak
        {
            internal readonly float newLifetime = -1f; // -1 is unlimited. Otherwise it's the lifetime in seconds

            public YoyoLifetimeRule(float l) => newLifetime = l;
            public bool AppliesTo(Projectile proj) => IsAYoyo(proj);
            public void ApplyTweak(Projectile proj) => ProjectileID.Sets.YoyosLifeTimeMultiplier[proj.type] = newLifetime;
        }
        internal static IProjectileTweak YoyoLifetime(float l) => new YoyoLifetimeRule(l);

        internal class YoyoRangeRule : IProjectileTweak
        {
            internal readonly float newMaxRange = 0f; // Range is measured in pixels

            public YoyoRangeRule(float r) => newMaxRange = r;
            public bool AppliesTo(Projectile proj) => IsAYoyo(proj);
            public void ApplyTweak(Projectile proj) => ProjectileID.Sets.YoyosMaximumRange[proj.type] = newMaxRange;
        }
        internal static IProjectileTweak YoyoRange(float r) => new YoyoRangeRule(r);

        internal class YoyoTopSpeedRule : IProjectileTweak
        {
            internal readonly float newTopSpeed = 0f;

            public YoyoTopSpeedRule(float s) => newTopSpeed = s;
            public bool AppliesTo(Projectile proj) => IsAYoyo(proj);
            public void ApplyTweak(Projectile proj) => ProjectileID.Sets.YoyosTopSpeed[proj.type] = newTopSpeed;
        }
        internal static IProjectileTweak YoyoTopSpeed(float r) => new YoyoTopSpeedRule(r);

        internal static SortedDictionary<int, IProjectileTweak[]> vanillaTweaks = null;
        internal static SortedDictionary<int, IProjectileTweak[]> currentTweaks = null;

        public static IProjectileTweak[] RebalanceYoyo(float lifetime, float range, float topSpeed, int extraUpdates, int iframes = 10) => new IProjectileTweak[]
        {
                ExtraUpdatesExact(extraUpdates),
                LocalIFrames(iframes * (extraUpdates + 1)),
                YoyoLifetime(lifetime <= 0f ? -1f : lifetime * (extraUpdates + 1)),
                YoyoRange(range),
                YoyoTopSpeed(topSpeed / (extraUpdates + 1)),
        };

        public static void RebalanceYoyoOnDemand(float lifetime, float range, float topSpeed, int extraUpdates, Projectile proj, int iframes = 10)
        {
            proj.extraUpdates = extraUpdates;
            if (proj.extraUpdates < 0)
                proj.extraUpdates = 0;

            proj.usesLocalNPCImmunity = true;
            proj.localNPCHitCooldown = iframes;
            proj.usesIDStaticNPCImmunity = false;
            proj.idStaticNPCHitCooldown = 0;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[proj.type] = lifetime;
            ProjectileID.Sets.YoyosMaximumRange[proj.type] = range;
            ProjectileID.Sets.YoyosTopSpeed[proj.type] = topSpeed;
        }

        internal static void LoadTweaks()
        {

            /// TODO: Fix modded yoyos not gaining the stats properly

            if (ModLoader.HasMod("CalamityMod") || (!ModLoader.HasMod("CalamityMod") && ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror))
            {
                if (ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror)
                {
                    currentTweaks = new SortedDictionary<int, IProjectileTweak[]>
                    {                                                           /// lifetime, range, top speed, extra updates, i frames
                    { ModContent.ProjectileType<IronYoyoProjectile>(), RebalanceYoyo(17f, 260f, 14.8f, 0, 20) },
                    { ModContent.ProjectileType<LeadYoyoProjectile>(), RebalanceYoyo(17f, 260f, 14.8f, 0, 20) },
                    { ModContent.ProjectileType<BlackHoleProjectile>(), RebalanceYoyo(-1f, 440f, 28f, 2) },
                    { ModContent.ProjectileType<CatacombProjectile>(), RebalanceYoyo(22f, 315f, 17f, 2) },
                    { ModContent.ProjectileType<ConvergenceProjectile>(), RebalanceYoyo(-1f, 550f, 60f, 2) },
                    { ModContent.ProjectileType<CultistYoyoProjectile>(), RebalanceYoyo(-1f, 500f, 40f, 0) },
                    { ModContent.ProjectileType<EmpressProjectile>(), RebalanceYoyo(-1f, 480f, 60f, 2) },
                    };
                }
            }


            if (!ModLoader.HasMod("CalamityMod") && ModContent.GetInstance<YoyoModConfig>().CalamityStatChangeMirror)
            vanillaTweaks = new SortedDictionary<int, IProjectileTweak[]>
            {
                { ProjectileID.Amarok, RebalanceYoyo(-1f, 432f, 28f, 1, 12) },

                // original: 13s lifetime | 235px range | 14px/f top speed | 0 extra updates
                { ProjectileID.Cascade, RebalanceYoyo(30f, 384f, 28f, 1, 12) },

                // original: 16s lifetime | 275px range | 17px/f top speed | 0 extra updates
                { ProjectileID.Chik, RebalanceYoyo(-1f, 400f, 32f, 1, 12) },

                // original: 9s lifetime | 220px range | 13px/f top speed | 0 extra updates
                { ProjectileID.Code1, RebalanceYoyo(21f, 320f, 25f, 1, 15) },

                // original: INF lifetime | 280px range | 17px/f top speed | 0 extra updates
                { ProjectileID.Code2, RebalanceYoyo(-1f, 432f, 42f, 1, 12) },

                // original: 7s lifetime | 195px range | 12.5px/f top speed | 0 extra updates
                { ProjectileID.CorruptYoyo, RebalanceYoyo(18f, 288f, 22f, 0, 20) }, // Malaise

                // original: 6s lifetime | 207px range | 12px/f top speed | 0 extra updates
                { ProjectileID.CrimsonYoyo, RebalanceYoyo(18f, 288f, 22f, 0, 20) }, // Artery

                // original: 8s lifetime | 235px range | 15px/f top speed | 0 extra updates
                { ProjectileID.FormatC, RebalanceYoyo(-1f, 384f, 36f, 1, 12) },

                // original: 10s lifetime | 250px range | 12px/f top speed | 0 extra updates
                { ProjectileID.Gradient, RebalanceYoyo(-1f, 384f, 36f, 1, 12) },

                // original: 12s lifetime | 275px range | 15px/f top speed | 0 extra updates
                { ProjectileID.HelFire, RebalanceYoyo(-1f, 320f, 42f, 2, 12) },

                // original: 11s lifetime | 225px range | 14px/f top speed | 0 extra updates
                { ProjectileID.HiveFive, RebalanceYoyo(24f, 320f, 20f, 0, 15) },

                // original: 8s lifetime | 215px range | 13px/f top speed | 0 extra updates
                { ProjectileID.JungleYoyo, RebalanceYoyo(20f, 288f, 17f, 0, 20) }, // Amazon

                // original: INF lifetime | 340px range | 16px/f top speed | 0 extra updates
                { ProjectileID.Kraken, RebalanceYoyo(-1f, 480f, 54f, 2) },

                // original: 5s lifetime | 170px range | 11px/f top speed | 0 extra updates
                { ProjectileID.Rally, RebalanceYoyo(16f, 272f, 20f, 0, 20) },

                // original: INF lifetime | 370px range | 16px/f top speed | 0 extra updates
                { ProjectileID.RedsYoyo, RebalanceYoyo(-1f, 480f, 42f, 2, 12) }, // Red's Throw

                // original: INF lifetime | 400px range | 17.5px/f top speed | 0 extra updates
                { ProjectileID.Terrarian, RebalanceYoyo(-1f, 512f, 54f, 2) },

                // original: INF lifetime | 360px range | 16.5px/f top speed | 0 extra updates
                { ProjectileID.TheEyeOfCthulhu, RebalanceYoyo(-1f, 480f, 36f, 1) }, // the yoyo, of course

                // original: INF lifetime | 370px range | 16px/f top speed | 0 extra updates
                { ProjectileID.ValkyrieYoyo, RebalanceYoyo(-1f, 480f, 42f, 2, 12) },

                // original: 11s lifetime | 225px range | 14px/f top speed | 0 extra updates
                { ProjectileID.Valor, RebalanceYoyo(30f, 400f, 36f, 1, 12) },

                // original: 3s lifetime | 130px range | 9px/f top speed | 0 extra updates
                { ProjectileID.WoodYoyo, RebalanceYoyo(15f, 240f, 14f, 0, 20) },

                // original: 14s lifetime | 290px range | 16px/f top speed | 0 extra updates
                { ProjectileID.Yelets, RebalanceYoyo(-1f, 400f, 36f, 1, 12) },
            };
        }

        internal static void UnloadTweaks()
        {
            vanillaTweaks?.Clear();
            vanillaTweaks = null;

            currentTweaks?.Clear();
            currentTweaks = null;
        }

        internal static void SetDefaults_ApplyProj(Projectile proj)
        {
            if (vanillaTweaks is not null)
            {

                bool needsTweaking = vanillaTweaks.TryGetValue(proj.type, out IProjectileTweak[] tweaks);
                if (needsTweaking)
                {
                    foreach (IProjectileTweak tweak in tweaks)
                        if (tweak.AppliesTo(proj))
                            tweak.ApplyTweak(proj);
                }
            }

            if (currentTweaks is not null)
            {
                bool needsTweaking = currentTweaks.TryGetValue(proj.type, out IProjectileTweak[] tweaks);
                if (!needsTweaking)
                    return;

                foreach (IProjectileTweak tweak in tweaks)
                    if (tweak.AppliesTo(proj))
                        tweak.ApplyTweak(proj);
            }
        }
    }

    public class TweakApplier : GlobalProjectile
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Projectile proj)
        {
            SetDefaults_ApplyProj(proj);
        }
    }
}
