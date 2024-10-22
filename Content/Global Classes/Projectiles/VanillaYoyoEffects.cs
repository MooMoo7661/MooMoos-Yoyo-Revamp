using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Debuffs;
using CombinationsMod.Content.Global_Classes.Projectiles;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.Explosions;
using CombinationsMod.Content.Projectiles.Misc;
using CombinationsMod.Content.Projectiles.RotationalYoyos;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.GlobalClasses.Projectiles
{
    public class VanillaYoyoEffects : GlobalProjectile
    {
        // This class is a result of really bad code organization on my part.
        // However I'm too lazy to go back and organize and clean it up at the moment.

        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation)
        {
            return entity.aiStyle == 99;
        }

        public override bool InstancePerEntity => true;
        private bool isOriginalYoyo = false;
        private int explosionCounter = 0;
        private int homingCounter = 0;
        private int code2ExplosionCounter = 0;
        private int iceSpikeCounter = 0;
        private int leafCounter = 0;
        private int eocBreathTimer = 0;
        private int eocLazerTimer = 0;

        private bool eocStage2 = false;
        private int eocHits = 0;
        private bool roar = false;

        bool recall = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            isOriginalYoyo = projectile.GetGlobalProjectile<YoyoDataHouse>().mainYoyo;

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && projectile.GetOwner().GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int damage = projectile.damage;
                float knockback = projectile.knockBack;

                if (isOriginalYoyo)
                    switch (projectile.type) // Adding swirl effects to vanilla yoyos
                    {
                        case ProjectileID.Code1:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Code1Swirl>(),
                                (int)(projectile.damage * 0.50f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);

                                for (int i = 0; i < 6; i++)
                                {
                                    Projectile code1 = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Code1Effect>(),
                                    (int)(projectile.damage * 0.50f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    code1.localAI[1] = i * 45;
                                    code1.usesIDStaticNPCImmunity = false;
                                    code1.usesLocalNPCImmunity = true;
                                    code1.localNPCHitCooldown = 30 * code1.MaxUpdates;
                                }

                                //140
                            }
                            break;

                        case ProjectileID.Cascade:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Swirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).damage = projectile.damage / 3;
                            }
                            break;

                        case ProjectileID.Rally:
                            for (int i = 0; i < 3; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Projectile rally = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<RallyEffect>(),
                                    (int)(projectile.damage / 2f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    rally.localAI[1] = i * 90;
                                    rally.usesIDStaticNPCImmunity = false;
                                    rally.usesLocalNPCImmunity = true;
                                    rally.localNPCHitCooldown = 30 * rally.MaxUpdates;
                                }
                            }
                            break;

                        case ProjectileID.HelFire:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Swirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<MotaiSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 1.4f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Background>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                            }
                            break;

                        case ProjectileID.Amarok:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<IceSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.8f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<IcePartSwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 1.7f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<IceSwirlInner>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 1.2f;
                            }
                            break;

                        case ProjectileID.Gradient:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<GradientClaySwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.8f;

                                for (int i = 0; i < 6; i++)
                                {
                                    Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<GradientEffect>(),
                                    (int)(projectile.damage * 0.8f), 3f, Main.myPlayer, 0, projectile.whoAmI).localAI[1] = i * 45f;
                                }
                            }
                            break;

                        case ProjectileID.FormatC:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<FormatClaySwirl>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.8f;

                                for (int i = 0; i < 4; i++)
                                {
                                    Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<FormatCEffect>(),
                                    (int)(projectile.damage * 0.80f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).localAI[1] = i * 67.5f;
                                }
                            }
                            break;

                        case ProjectileID.Yelets:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<JaggedSwirlYellow>(),
                                (int)(projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.8f;
                            }
                            break;

                        case ProjectileID.ValkyrieYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<PurpleShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<PurpleShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI).Resize(100, 100);
                            }
                            break;

                        case ProjectileID.RedsYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI).Resize(100, 100);
                            }
                            break;

                        case ProjectileID.Kraken:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueSwirl2>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                            }
                            break;

                        case ProjectileID.Terrarian:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<GreenShieldSwirlDuo>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 1.4f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CurveOrange>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 1.9f;

                                Projectile nebula = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CurveNebula>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                nebula.rotation = 2;
                                nebula.scale = 1.9f;

                                Projectile stardust = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CurveStardust>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                stardust.rotation = 3;
                                stardust.scale = 1.9f;

                                Projectile vortex = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CurveVortex>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                vortex.rotation = 5;
                                vortex.scale = 1.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, Main.myPlayer, 0, projectile.whoAmI).Resize(120, 120);
                            }
                            break;
                    }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects)
            {
                switch (projectile.type)
                {
                    case ProjectileID.Cascade:
                        if (modPlayer.yoyoRing)
                        {
                            explosionCounter++;
                            if (explosionCounter == 5)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, new Vector2(0, 0),
                                    ProjectileType<FireExplosion>(), (int)(projectile.damage * 1.5f), 8f, projectile.owner, projectile.owner).Resize(70, 70);
                                }
                                explosionCounter = 0;
                            }
                        }
                        break;

                    case ProjectileID.HelFire:
                        if (Main.myPlayer == projectile.owner)
                        {
                            Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, new Vector2(0, 0),
                            ProjectileType<HelFireExplosion>(), (int)(projectile.damage * 1.5f), 8f, projectile.owner, projectile.owner);
                        }
                        break;

                    case ProjectileID.CrimsonYoyo or ProjectileID.CorruptYoyo:
                        if (!target.CountsAsACritter && !(target.type == NPCID.TargetDummy) && projectile.GetOwner().GetModPlayer<YoyoModPlayer>().yoyoRing)
                        {
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero,
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
                            code2ExplosionCounter++;
                            if (code2ExplosionCounter == 5)
                            {
                                int proj2 = Projectile.NewProjectile(projectile.GetSource_FromThis(),
                                projectile.Center.X, projectile.Center.Y - 1f, 0,
                                0, ProjectileType<FireExplosion>(), (int)(projectile.damage * 0.50f), 8f,
                                projectile.owner);
                                code2ExplosionCounter = 0;
                            }
                        }
                        break;

                    case ProjectileID.TheEyeOfCthulhu:
                        eocHits++;
                        if (eocHits == 50)
                            eocStage2 = true;
                        break;

                    case ProjectileID.JungleYoyo:
                        target.AddBuff(ModContent.BuffType<RootedDebuff>(), 180);
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

                            Projectile.NewProjectile(projectile.GetSource_FromThis(),
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
                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                                Main.rand.NextBool() ? 1 : -1, ProjectileType<HomingWaterBolt>(), projectile.damage / 3, 0, projectile.owner);
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
                                            ProjectileID.EyeLaser, (int)(projectile.damage * 0.45f), 3f, projectile.owner, 1, 1);
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
                Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Content/Projectiles/Misc/EOCYoyoSpazmatism");
                Vector2 drawOrigin = new(texture.Width * 0.5f, projectile.height * 0.5f);
                Vector2 drawPos = projectile.Center - Main.screenPosition;
                var rectangle = new Rectangle(0, 0, texture.Width, texture.Height);

                Main.EntitySpriteDraw(texture, drawPos, rectangle, lightColor, projectile.rotation, drawOrigin, 1f, 0, 0);
                return false;
            }

            return true;
        }
    }
}