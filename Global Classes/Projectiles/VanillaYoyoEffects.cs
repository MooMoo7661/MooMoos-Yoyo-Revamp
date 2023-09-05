using CombinationsMod.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Projectiles.YoyoEffects;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Terraria.ID;
using static Terraria.ModLoader.ModContent;
using CombinationsMod.Buffs;
using CombinationsMod.Projectiles.Explosions;
using System;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.TrickYoyos;
using CombinationsMod.Projectiles.RotationalYoyos;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace CombinationsMod.GlobalClasses.Projectiles
{
    public class VanillaYoyoEffects : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.aiStyle == 99;
        }

        public override bool InstancePerEntity => true;
        private bool isOriginalYoyo = false;
        private int thornCounter = 0;
        private int explosionCounter = 0;
        private int homingCounter = 0;
        private bool isYoyo;
        private int iceSpikeCounter = 0;
        private int leafCounter = 0;
        private int eocBreathTimer = 0;
        private int eocLazerTimer = 0;

        private bool eocStage2 = false;
        private int eocHits = 0;
        private bool roar = false;

        public bool flag = false; // false = main yoyo, true = second yoyo

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.aiStyle == 99 && !projectile.counterweight) { isYoyo = true; }

           isOriginalYoyo = ReturnProjectileFlag(projectile);

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int damage = projectile.damage;
                float knockback = projectile.knockBack;


                if (isOriginalYoyo)
                    switch (projectile.type) // Adding swirl effects to vanilla yoyos
                    {
                        case ProjectileID.Code1:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<Code1Swirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                            }

                            for (int i = 0; i < 6; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    int projCode1 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                    projectile.Center.Y, 0, 0, ProjectileType<Code1Effect>(),
                                    (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    Main.projectile[projCode1].damage = (int)(projectile.damage * 0.8f);
                                    Main.projectile[projCode1].localAI[1] = i * 45;
                                }
                            }

                            break;

                        case ProjectileID.Cascade:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj2 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                 projectile.Center.Y, 0, 0, ProjectileType<Swirl>(),
                                 (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                Main.projectile[proj2].damage = projectile.damage / 3;
                            }
                            break;

                        case ProjectileID.Rally:
                            for (int i = 0; i < 3; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    int projRally = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                    projectile.Center.Y, 0, 0, ProjectileType<RallyEffect>(),
                                    (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    Main.projectile[projRally].damage = projectile.damage / 2;
                                    Main.projectile[projRally].localAI[1] = i * 90;
                                }
                            }
                            break;

                        case ProjectileID.HelFire:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj3 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<Swirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj3].scale = 0.9f;

                                int proj4 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<MotaiSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj4].scale = 1.4f;

                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<Background>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                            }
                            break;

                        case ProjectileID.Amarok:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj5 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<IceSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj5].scale = 0.8f;

                                int proj6 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<IcePartSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj6].scale = 1.7f;

                                int proj7 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<IceSwirlInner>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj7].scale = 1.2f;
                            }
                            break;

                        case ProjectileID.Gradient:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj8 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<GradientClaySwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj8].scale = 0.8f;

                                for (int i = 0; i < 6; i++)
                                {
                                    int projFormatSwirl = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                     projectile.Center.Y, 0, 0, ProjectileType<GradientEffect>(),
                                     (int)(projectile.damage * 0.8f), 3f, Main.myPlayer, 0, projectile.whoAmI);
                                    Main.projectile[projFormatSwirl].localAI[1] = i * 45f;
                                }
                            }
                            break;

                        case ProjectileID.FormatC:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj9 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<FormatClaySwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj9].scale = 0.8f;

                                for (int i = 0; i < 4; i++)
                                {
                                    int projFormatSwirl = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                     projectile.Center.Y, 0, 0, ProjectileType<FormatCEffect>(),
                                     (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    Main.projectile[projFormatSwirl].localAI[1] = i * 67.5f;
                                }
                            }
                            break;

                        case ProjectileID.Yelets:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj10 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<JaggedSwirlYellow>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj10].scale = 0.8f;
                            }
                            break;

                        case ProjectileID.ValkyrieYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj12 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<PurpleShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj12].scale = 0.9f;

                                int projballin = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<PurpleShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[projballin].scale = 0.9f;

                                int hitboxValkyrie = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[hitboxValkyrie].Resize(100, 100);
                            }
                            break;

                        case ProjectileID.RedsYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int projRed = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<BlueShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[projRed].scale = 0.9f;

                                int projRed2 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<BlueShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[projRed2].scale = 0.9f;

                                int hitboxRed = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[hitboxRed].Resize(100, 100);
                            }
                            break;

                        case ProjectileID.Kraken:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj13 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<BlueSwirl2>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                            }
                            break;

                        case ProjectileID.Terrarian:
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj14 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<GreenShieldSwirlDuo>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj14].scale = 1.4f;

                                int proj15 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CurveOrange>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[proj15].scale = 1.9f;

                                int proj16 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CurveNebula>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                Main.projectile[proj16].rotation = 2;

                                Main.projectile[proj16].scale = 1.9f;

                                int proj17 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CurveStardust>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                Main.projectile[proj17].rotation = 3;

                                Main.projectile[proj17].scale = 1.9f;

                                int proj18 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X,
                                projectile.Center.Y, 0, 0, ProjectileType<CurveVortex>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                Main.projectile[proj18].rotation = 5;

                                Main.projectile[proj18].scale = 1.9f;

                                int dustProj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y, 0, 0,
                                ProjectileType<Sparkle3>(), 0, 0, Main.myPlayer, 0, projectile.whoAmI);

                                Main.projectile[dustProj].Resize(120, 120);
                            }
                            break;
                    }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects)
            {
                switch (projectile.type) // Adding vanilla yoyo hit effects
                {
                    case ProjectileID.Cascade:
                        if (modPlayer.yoyoRing)
                        {
                            explosionCounter++;
                            if (explosionCounter == 5)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    int explosion = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, new Vector2(0, 0),
                                    ProjectileType<FireExplosion>(), (int)(projectile.damage * 1.5f), 8f, projectile.owner, projectile.owner);
                                    Main.projectile[explosion].Resize(70, 70);
                                }
                                explosionCounter = 0;
                            }
                        }
                        break;

                    case ProjectileID.HelFire:
                        target.AddBuff(BuffType<Combustion>(), 600);
                        if (Main.myPlayer == projectile.owner)
                        {
                            int explosion2 = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, new Vector2(0, 0),
                                ProjectileType<HelFireExplosion>(), (int)(projectile.damage * 1.5f), 8f, projectile.owner, projectile.owner);
                        }
                        break;

                    case ProjectileID.CrimsonYoyo or ProjectileID.CorruptYoyo:
                        if (!target.CountsAsACritter && !(target.type == NPCID.TargetDummy) && Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
                        {
                            Vector2 vector = new(0, 0);
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vector,
                                ProjectileID.VampireHeal, 0, 0, projectile.owner, projectile.owner, 1);
                            }
                        }
                        break;

                    case ProjectileID.Chik:
                        for (int i = 0; i < 10; i++)
                        {
                            if (Main.rand.NextBool(5))
                            {
                                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BlueCrystalShard, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1f);
                            }
                        }
                        break;


                    case ProjectileID.Code2:
                        if (modPlayer.yoyoRing && Main.myPlayer == projectile.owner)
                        {
                            int proj2 = Projectile.NewProjectile(projectile.GetSource_FromThis(),
                              projectile.Center.X, projectile.Center.Y - 1f, 0,
                              0, ProjectileType<FireExplosion>(), (int)(projectile.damage * 0.65f), 8f,
                              projectile.owner);
                        }
                        break;

                    case ProjectileID.TheEyeOfCthulhu:
                        eocHits++;
                        if (eocHits == 50)
                        {
                            eocStage2 = true;
                        }
                        break;
                }
            }
        }

        public override void AI(Projectile projectile)
        {
            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && isOriginalYoyo)
            {
                switch (projectile.type)
                {
                    case ProjectileID.Kraken:
                        if (Main.rand.NextBool(20) && Main.myPlayer == projectile.owner)
                        {
                            Vector2 circular = Vector2.One.RotatedByRandom(MathHelper.TwoPi);
                            int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(),
                              projectile.Center.X, projectile.Center.Y - 1f, circular.X,
                              circular.Y, ProjectileID.Bubble, (int)(projectile.damage * 0.65f), 8f,
                              projectile.owner);
                        }
                        break;

                    case ProjectileID.Valor:
                        homingCounter++;
                        if (homingCounter == 40)
                        {
                            homingCounter = 0;
                            if (Main.myPlayer == projectile.owner)
                            {
                                int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                                Main.rand.NextBool() ? 1 : -1, ProjectileType<CombinationsMod.Projectiles.Misc.HomingWaterBolt>(), projectile.damage / 3, 0, projectile.owner);
                            }
                        }
                        break;

                    case ProjectileID.Amarok:
                        iceSpikeCounter++;
                        if (iceSpikeCounter == 60 && projectile.ai[0] != -1 && isOriginalYoyo)
                        {
                            SoundEngine.PlaySound(SoundID.Item27, projectile.position);

                            for (int i = 0; i < 8; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;

                                    int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                        ProjectileID.IceSpike, (int)(projectile.damage * 0.6f), 1, projectile.owner, 1, 1);
                                    Main.projectile[proj].scale = 0.9f;
                                    Main.projectile[proj].penetrate = 5;
                                    Main.projectile[proj].tileCollide = true;
                                    Main.projectile[proj].timeLeft = 180;
                                    Main.projectile[proj].friendly = true;
                                    Main.projectile[proj].hostile = false;
                                    Main.projectile[proj].penetrate = 1;
                                    Main.projectile[proj].usesLocalNPCImmunity = true;
                                }
                            }

                            iceSpikeCounter = 0;
                        }
                        break;

                    case ProjectileID.Yelets:
                        leafCounter++;
                        if (leafCounter == 60 && isOriginalYoyo)
                        {
                            for (int i = 0; i < 8; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;

                                    int projLeaf = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                        ProjectileID.Leaf, projectile.damage / 2, 1, projectile.owner, 1, 1);
                                    Main.projectile[projLeaf].scale = 0.9f;
                                    Main.projectile[projLeaf].tileCollide = true;
                                    Main.projectile[projLeaf].timeLeft = 60;
                                    Main.projectile[projLeaf].friendly = true;
                                    Main.projectile[projLeaf].hostile = false;
                                    Main.projectile[projLeaf].usesLocalNPCImmunity = true;
                                }
                            }

                            leafCounter = 0;
                        }

                        break;

                    case ProjectileID.TheEyeOfCthulhu:
                        if (!eocStage2)
                        {
                            eocLazerTimer++;
                            if (eocLazerTimer == 60)
                            {
                                SoundEngine.PlaySound(SoundID.Item33, projectile.position);

                                for (int i = 0; i < 8; i++)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                                    if (Main.myPlayer == projectile.owner)
                                    {
                                        int projLeaf = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                            ProjectileID.EyeLaser, projectile.damage * 2, 3f, projectile.owner, 1, 1);
                                        Main.projectile[projLeaf].tileCollide = true;
                                        Main.projectile[projLeaf].timeLeft = 180;
                                        Main.projectile[projLeaf].friendly = true;
                                        Main.projectile[projLeaf].hostile = false;
                                        Main.projectile[projLeaf].usesLocalNPCImmunity = true;
                                    }
                                }

                                eocLazerTimer = 0;
                            }
                        }
                        else if (eocStage2)
                        {
                            if (!roar)
                            {
                                SoundEngine.PlaySound(SoundID.Roar, projectile.position);
                                roar = true;
                            }

                            eocBreathTimer++;
                            if (eocBreathTimer == 60)
                            {
                                SoundEngine.PlaySound(SoundID.Item20, projectile.position);
                                projectile.localAI[1] = 2;
                                for (int i = 0; i < 8; i++)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;

                                    if (Main.myPlayer == projectile.owner)
                                    {
                                        int projLeaf = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                            ProjectileID.CursedFlameFriendly, projectile.damage, 0f, Main.myPlayer, 0, projectile.owner);
                                        Main.projectile[projLeaf].tileCollide = true;
                                        Main.projectile[projLeaf].timeLeft = 60;
                                    }
                                }
                                eocBreathTimer = 0;
                            }
                        }
                        break;
                }
            }
        }

        public override void PostAI(Projectile projectile)
        {
            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects)
            {
                switch (projectile.type) // Making vanilla yoyos do special things
                {
                    case ProjectileID.JungleYoyo:
                        thornCounter++;
                        if (thornCounter >= 35)
                        {
                            if (Main.myPlayer == projectile.owner)
                            {
                                Vector2 circular = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 6f;
                                int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(),
                                projectile.Center.X, projectile.Center.Y - 1f, circular.X,
                                circular.Y, ProjectileID.Stinger, (int)(projectile.damage * 0.65f), 0,
                                projectile.owner);
                                Main.projectile[proj].friendly = true;
                                Main.projectile[proj].hostile = false;
                            }

                            thornCounter = 0;
                        }
                        break;

                    case ProjectileID.Cascade:
                        if (Main.rand.NextBool(5))
                        {
                            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.CopperCoin, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1f);
                        }
                        break;
                }

                switch (projectile.type) // Making vanilla yoyos emit dust
                {
                    case ProjectileID.CorruptYoyo:
                        if (Main.rand.NextBool())
                        {
                            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.CorruptionThorns);
                            dust.noGravity = true;
                            dust.noLight = false;
                            dust.scale = 1.1f;
                        }
                        break;

                    case ProjectileID.CrimsonYoyo:
                        if (Main.rand.NextBool())
                        {
                            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.CrimsonPlants);
                            dust.noGravity = true;
                            dust.noLight = false;
                            dust.scale = 1.1f;
                        }
                        break;

                    case ProjectileID.JungleYoyo:
                        if (Main.rand.NextBool())
                        {
                            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.JunglePlants);
                            dust.noGravity = true;
                            dust.noLight = false;
                            dust.scale = 1.1f;

                            Dust dust2 = Dust.NewDustDirect(projectile.position, projectile.width, 5, DustID.t_LivingWood);
                            dust2.noGravity = true;
                            dust2.noLight = false;
                            dust2.scale = 1.3f;

                        }
                        break;

                    case ProjectileID.Chik:
                        if (Main.rand.NextBool(5))
                            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height,
                                 DustID.PinkCrystalShard, projectile.velocity.X * 0.3f, projectile.velocity.Y * 0.3f, 0, default, 1f);
                        break;

                    case ProjectileID.HelFire:
                        if (Main.rand.NextBool(5))
                            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height,
                                 DustID.CopperCoin, projectile.velocity.X * 0.56f, projectile.velocity.Y * 0.56f, 0, default, 1f);
                        break;

                    case ProjectileID.Valor:
                        if (Main.rand.NextBool(5))
                            Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height,
                                 DustID.WaterCandle, projectile.velocity.X * 0.56f, projectile.velocity.Y * 0.56f, 0, default, 1f);
                        break;
                }
            }
        }

        public override bool PreDraw(Projectile projectile, ref Color lightColor)
        {
            if (projectile.type == ProjectileID.TheEyeOfCthulhu && projectile.localAI[1] == 2)
            {
                Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Projectiles/Misc/EOCYoyoSpazmatism");
                Vector2 drawOrigin = new(texture.Width * 0.5f, projectile.height * 0.5f);
                Vector2 drawPos = projectile.Center - Main.screenPosition;
                var rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

                Main.EntitySpriteDraw(texture, drawPos, rectangle, lightColor, projectile.rotation, drawOrigin, 1f, 0, 0);
                return false;
            }

            return true;
        }

        public override void Load()
        {
            Terraria.On_Projectile.AI_099_2 += YoyoAIDetour;
        }

        public override void Unload()
        {
            Terraria.On_Projectile.AI_099_2 -= YoyoAIDetour;
        }

        private void YoyoAIDetour(Terraria.On_Projectile.orig_AI_099_2 orig, Projectile projectile)
        {
            Player player = Main.player[projectile.owner];

            flag = false;

            for (int i = 0; i < projectile.whoAmI; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == projectile.type && !Main.projectile[i].counterweight)
                {
                    flag = true;
                }
            }

            if (projectile.owner == Main.myPlayer)
            {
                projectile.localAI[0] += 1f; // Timer in ticks

                if (flag)
                {
                    projectile.localAI[0] += (float)Main.rand.Next(10, 31) * 0.1f;
                }

                float num = projectile.localAI[0] / 60f; // Timer in seconds

                num /= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee)) / 2f;

                float num2 = ProjectileID.Sets.YoyosLifeTimeMultiplier[projectile.type];

                if (num2 != -1f && num > num2)
                {
                    projectile.ai[0] = -1f; // Sets when the yoyo is killed
                }
            }

            if (projectile.type == 603 && projectile.owner == Main.myPlayer) // All of this is for terrarian beam[?]
            {
                projectile.localAI[1] += 1f;
                if (projectile.localAI[1] >= 6f)
                {
                    float num3 = 400f;
                    Vector2 vector = projectile.velocity;
                    Vector2 vector2 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                    vector2.Normalize();
                    vector2 *= (float)Main.rand.Next(10, 41) * 0.1f;
                    if (Main.rand.NextBool(3))
                    {
                        vector2 *= 2f;
                    }
                    vector *= 0.25f;
                    vector += vector2;
                    for (int j = 0; j < 200; j++)
                    {
                        if (Main.npc[j].CanBeChasedBy(this))
                        {
                            float num4 = Main.npc[j].position.X + (float)(Main.npc[j].width / 2);
                            float num5 = Main.npc[j].position.Y + (float)(Main.npc[j].height / 2);
                            float num6 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num4) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num5);
                            if (num6 < num3 && Collision.CanHit(projectile.position, projectile.width, projectile.height, Main.npc[j].position, Main.npc[j].width, Main.npc[j].height))
                            {
                                num3 = num6;
                                vector.X = num4;
                                vector.Y = num5;
                                vector -= projectile.Center;
                                vector.Normalize();
                                vector *= 8f;
                            }
                        }
                    }
                    vector *= 0.8f; // Terrarian Beam
                    Projectile.NewProjectile(Projectile.InheritSource(projectile), projectile.Center.X - vector.X, projectile.Center.Y - vector.Y, vector.X, vector.Y, 604, projectile.damage, projectile.knockBack, projectile.owner);
                    projectile.localAI[1] = 0f;
                }
            }

            bool flag2 = false; // Flag2 is counterweights

            if (projectile.type >= 556 && projectile.type <= 561) // Counterweights
            {
                flag2 = true;
            }

            if (Main.player[projectile.owner].dead) // kill projectile when owner is dead
            {
                projectile.Kill();
                return;
            }

            if (!flag2 && !flag) // if not counterweight and current yoyo
            {
                Main.player[projectile.owner].heldProj = projectile.whoAmI;
                Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().currentYoyo = projectile.whoAmI;
                //projectile.localAI[0] = -1;

                if (ModContent.GetInstance<YoyoModConfig>().MainYoyoDust)
                {
                    if (Main.rand.NextBool(5))
                    {
                        int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height,
                        DustID.CrimsonTorch, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 200, default, 0.7f);
                        Main.dust[dust].noLight = true;
                        Main.dust[dust].scale = 1.3f;
                    }
                }

                Main.player[projectile.owner].SetDummyItemTime(2);

                // Below 2 set the player's direction depending on where the yoyo is (left, right)
                if (projectile.position.X + (float)(projectile.width / 2) > Main.player[projectile.owner].position.X + (float)(Main.player[projectile.owner].width / 2))
                {
                    Main.player[projectile.owner].ChangeDir(1);
                    projectile.direction = 1;
                }
                else
                {
                    Main.player[projectile.owner].ChangeDir(-1);
                    projectile.direction = -1;
                }
            }

            if (projectile.velocity.HasNaNs())
            {
                projectile.Kill();
            }

            projectile.timeLeft = 6;
            float num7 = 10f;
            float yoyoSpeed = 10f;
            float num9 = 3f;

            float stringLength = 200f;
            stringLength = ProjectileID.Sets.YoyosMaximumRange[projectile.type];

            yoyoSpeed = player.GetModPlayer<YoyoModPlayer>().GetModifiedPlayerYoyoSpeed(ProjectileID.Sets.YoyosTopSpeed[projectile.type], player);

            float modifiedStringLength = stringLength;
            modifiedStringLength = Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().GetModifiedPlayerYoyoStringLength(stringLength, player);

            if (projectile.type == 545) // 545 is cascade
            {
                if (Main.rand.NextBool(6))
                {
                    int num11 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                    Main.dust[num11].noGravity = true;
                }
            }
            else if (projectile.type == 553 && Main.rand.NextBool(2)) // 553 is hel-fire
            {
                int num12 = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
                Main.dust[num12].noGravity = true;
                Main.dust[num12].scale = 1.6f;
            }
            if (Main.player[projectile.owner].yoyoString) // Extends range
            {
                // modifiedStringLength is ProjectileID.Sets.YoyosMaximumRange + modifictions from modplayer to increase range
                modifiedStringLength = modifiedStringLength + 150f;
            }
            modifiedStringLength *= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee) * 3f) / 4f;
            yoyoSpeed *= (1f + Main.player[projectile.owner].GetAttackSpeed(DamageClass.Melee) * 3f) / 4f;
            num7 = 14f - yoyoSpeed / 2f;
            if (num7 < 1f)
            {
                num7 = 1f;
            }
            num9 = 5f + yoyoSpeed / 2f;
            if (flag)
            {
                num9 += 20f;
            }
            if (projectile.ai[0] >= 0f)
            {
                if (projectile.velocity.Length() > yoyoSpeed)
                {
                    projectile.velocity *= 0.98f;
                }
                bool flag3 = false;
                bool flag4 = false;
                Vector2 vector3 = Main.player[projectile.owner].Center - projectile.Center;
                if (vector3.Length() > modifiedStringLength)
                {
                    flag3 = true;
                    if ((double)vector3.Length() > (double)modifiedStringLength * 1.3)
                    {
                        flag4 = true;
                    }
                }
                if (projectile.owner == Main.myPlayer)
                {
                    if (!Main.player[projectile.owner].channel || Main.player[projectile.owner].stoned || Main.player[projectile.owner].frozen)
                    {
                        projectile.ai[0] = -1f; // ai[0] = -1 kills projectile. I assume this is to recall yoyos when the player is dead / should not be active
                        projectile.ai[1] = 0f;
                        projectile.netUpdate = true;
                    }
                    else
                    {   
                        Vector2 vector4 = Main.ReverseGravitySupport(Main.MouseScreen) + Main.screenPosition;
                        float x = vector4.X;
                        float y = vector4.Y;
                        Vector2 vector5 = new Vector2(x, y) - Main.player[projectile.owner].Center;
                        if (vector5.Length() > modifiedStringLength)
                        {
                            vector5.Normalize();
                            vector5 *= modifiedStringLength;
                            vector5 = Main.player[projectile.owner].Center + vector5;
                            x = vector5.X;
                            y = vector5.Y;
                        }
                        if (projectile.ai[0] != x || projectile.ai[1] != y) // If the yoyo's ai is not equal to the position
                        {
                            Vector2 vector6 = new Vector2(x, y) - Main.player[projectile.owner].Center;
                            if (vector6.Length() > modifiedStringLength - 1f)
                            {
                                vector6.Normalize();
                                vector6 *= modifiedStringLength - 1f;
                                Vector2 vector7 = Main.player[projectile.owner].Center + vector6;
                                x = vector7.X;
                                y = vector7.Y;
                            }
                            projectile.ai[0] = x;
                            projectile.ai[1] = y;
                            projectile.netUpdate = true;
                        }
                    }
                }
                if (flag4 && projectile.owner == Main.myPlayer)
                {
                    projectile.ai[0] = -1f;
                    projectile.netUpdate = true;
                }
                if (projectile.ai[0] >= 0f)
                {
                    if (flag3)
                    {
                        num7 /= 2f;
                        yoyoSpeed *= 2f;
                        if (projectile.Center.X > Main.player[projectile.owner].Center.X && projectile.velocity.X > 0f)
                        {
                            projectile.velocity.X *= 0.5f;
                        }
                        if (projectile.Center.Y > Main.player[projectile.owner].Center.Y && projectile.velocity.Y > 0f)
                        {
                            projectile.velocity.Y *= 0.5f;
                        }
                        if (projectile.Center.X < Main.player[projectile.owner].Center.X && projectile.velocity.X < 0f)
                        {
                            projectile.velocity.X *= 0.5f;
                        }
                        if (projectile.Center.Y < Main.player[projectile.owner].Center.Y && projectile.velocity.Y < 0f)
                        {
                            projectile.velocity.Y *= 0.5f;
                        }
                    }
                    Vector2 vector8 = new Vector2(projectile.ai[0], projectile.ai[1]) - projectile.Center;
                    if (flag3)
                    {
                        num7 = 1f;
                    }
                    projectile.velocity.Length();
                    float num13 = vector8.Length();
                    if (num13 > num9)
                    {
                        vector8.Normalize();
                        float num14 = Math.Min(num13 / 2f, yoyoSpeed);
                        if (flag3)
                        {
                            num14 = Math.Min(num14, yoyoSpeed / 2f);
                        }
                        vector8 *= num14;
                        projectile.velocity = (projectile.velocity * (num7 - 1f) + vector8) / num7;
                    }
                    else if (flag)
                    {
                        if ((double)projectile.velocity.Length() < (double)yoyoSpeed * 0.6)
                        {
                            vector8 = projectile.velocity;
                            vector8.Normalize();
                            vector8 *= yoyoSpeed * 0.6f;
                            projectile.velocity = (projectile.velocity * (num7 - 1f) + vector8) / num7;
                        }
                    }
                    else
                    {
                        projectile.velocity *= 0.8f;
                    }
                    if (flag && !flag3 && (double)projectile.velocity.Length() < (double)yoyoSpeed * 0.6)
                    {
                        projectile.velocity.Normalize();
                        projectile.velocity *= yoyoSpeed * 0.6f;
                    }
                }
            }
            else
            {
                num7 = (int)((double)num7 * 0.8);

                if ((player.GetModPlayer<YoyoModPlayer>().yoyoBag || player.GetModPlayer<YoyoModPlayer>().shimmerBag || player.GetModPlayer<YoyoModPlayer>().tier2Bag) && !ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                {
                    yoyoSpeed *= 3f;
                }
                else
                {
                    yoyoSpeed *= 1.8f;
                }

                projectile.tileCollide = false;
                Vector2 vector9 = Main.player[projectile.owner].Center - projectile.Center;
                float num15 = vector9.Length();

                if (num15 < yoyoSpeed + 10f || num15 == 0f || num15 > 2000f)
                {
                    projectile.Kill();
                }
                else
                {
                    vector9.Normalize();
                    vector9 *= yoyoSpeed;
                    projectile.velocity = (projectile.velocity * (num7 - 1f) + vector9) / num7;
                }
            }
            projectile.rotation += 0.45f;
        }

        public bool ReturnProjectileFlag(Projectile projectile)
        {
            for (int i = 0; i < projectile.whoAmI; i++)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == projectile.owner && Main.projectile[i].type == projectile.type && !Main.projectile[i].counterweight)
                {
                    return false;
                }
            }
            return true;
        }
    }
}