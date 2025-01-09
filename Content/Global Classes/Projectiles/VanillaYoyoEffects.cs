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
using System.Collections.Generic;
using System.Reflection;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;
using YoyoStringLib;
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

        private bool eocStage2 = false;
        private bool roar = false;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            bool isOriginalYoyo = projectile.YoyoData().MainYoyo;

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && projectile.GetOwner().GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int damage = projectile.damage;
                float knockback = projectile.knockBack;

                if (isOriginalYoyo)
                    switch (projectile.type)
                    {
                        case ProjectileID.Yelets:
                            projectile.YoyoData().AbilityTimer[0] = 60;
                            break;

                        case ProjectileID.Code1:
                            if (Main.myPlayer == projectile.owner)
                            {
                                for (int i = 0; i < 6; i++)
                                {
                                    Projectile code1 = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<Code1Effect>(),
                                    (int)(projectile.damage * 0.50f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    code1.localAI[1] = i * 45;
                                    code1.usesIDStaticNPCImmunity = true;
                                    code1.usesLocalNPCImmunity = false;
                                    code1.idStaticNPCHitCooldown = 17;
                                }
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
                                    rally.usesIDStaticNPCImmunity = true;
                                    rally.idStaticNPCHitCooldown = 17;
                                }
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
                                    Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<GradientEffect>(),
                                    (int)(projectile.damage * 0.8f), 3f, Main.myPlayer, 0, projectile.whoAmI);
                                    proj.localAI[1] = i * 45f;
                                    proj.usesIDStaticNPCImmunity = true;
                                    proj.usesLocalNPCImmunity = false;
                                    proj.idStaticNPCHitCooldown = 10;
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
                                    Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<FormatCEffect>(),
                                    (int)(projectile.damage * 0.80f) + 1, 0, Main.myPlayer, 0, projectile.whoAmI);
                                    proj.localAI[1] = i * 67.5f;
                                    proj.usesIDStaticNPCImmunity = true;
                                    proj.usesLocalNPCImmunity = false;
                                    proj.idStaticNPCHitCooldown = 10;
                                }
                            }
                            break;

                        case ProjectileID.ValkyrieYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<PurpleShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<PurpleShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI);
                                proj.Resize(100, 100);
                                proj.usesLocalNPCImmunity = true;
                                proj.localNPCHitCooldown = 17;
                            }
                            break;

                        case ProjectileID.RedsYoyo:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueShieldSwirl>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueShieldSwirlReverse>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI).scale = 0.9f;

                                Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(),
                                (int)(damage * 0.85f), knockback * 0.75f, Main.myPlayer, 0, projectile.whoAmI);
                                proj.Resize(100, 100);
                                proj.usesLocalNPCImmunity = true;
                                proj.localNPCHitCooldown = 17;

                            }
                            break;

                        case ProjectileID.Kraken:
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<BlueSwirl2>(),
                                0, 0, Main.myPlayer, 0, projectile.whoAmI);
                                Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(),
                                (int)(projectile.damage * 0.75f), 1, Main.myPlayer, 0, projectile.whoAmI);
                                proj.Resize(60, 60);
                                proj.usesLocalNPCImmunity = true;
                                proj.localNPCHitCooldown = 25;
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

                                Projectile proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ProjectileType<CultistRingDamage>(), (int)(projectile.damage * 0.75f), 1, projectile.whoAmI);
                                proj.Resize(120, 120);
                                proj.usesLocalNPCImmunity = true;
                                proj.localNPCHitCooldown = 20;
                            }
                            break;
                    }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = projectile.GetOwner();
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            ref int timer0 = ref projectile.YoyoData().AbilityTimer[0];
            ref int timer1 = ref projectile.YoyoData().AbilityTimer[1];
            ref int timer2 = ref projectile.YoyoData().AbilityTimer[2];


            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && modPlayer.yoyoRing && projectile.YoyoData().MainYoyo)
            {
                switch (projectile.type)
                {
                    case ProjectileID.Yelets:
                        if (projectile.YoyoData().AbilityTimer[0] <= 0 && projectile.YoyoData().AbilityTimer[1] == 0)
                        {
                            projectile.YoyoData().AbilityTimer[0] = 180;
                            projectile.YoyoData().AbilityTimer[1] = 1;

                            SoundStyle HitSound = new()
                            {
                                SoundPath = "CombinationsMod/Content/Sounds/rock2",
                                Volume = 0.3f,
                                PitchVariance = 0.3f,
                                SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                            };

                            SoundEngine.PlaySound(HitSound);

                            foreach (NPC npc in Main.ActiveNPCs)
                            {
                                if (npc.Distance(projectile.Center) > 250 || npc.boss /*|| npc.Size.X > 60 || npc.Size.Y > 60*/)
                                    continue;

                                if (!npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f && npc != null)
                                {
                                    npc.velocity -= npc.DirectionTo(projectile.Center) * 4;
                                    npc.velocity.Y -= 6f;
                                    NPC.HitInfo info = npc.CalculateHitInfo((int)(projectile.damage * 0.8f), -npc.direction, false, 0f);

                                    npc.StrikeNPC(info, true);
                                    if (Main.netMode == NetmodeID.MultiplayerClient)
                                    {
                                        NetMessage.SendStrikeNPC(npc, info);
                                    }

                                }
                            }
                        }
                        break;
                    case ProjectileID.HelFire:
                        if (Main.myPlayer == projectile.owner && projectile.YoyoData().Hits % 3 == 0)
                        {
                            Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, new Vector2(0, 0),
                            ProjectileType<HelFireExplosion>(), (int)(projectile.damage * 1.5f), 8f, Main.myPlayer);
                        }

                        if (Main.rand.NextBool(2))
                        {
                            foreach(NPC npc in Main.ActiveNPCs)
                            {
                                if (projectile.Distance(npc.Center) > 65 /*|| npc == target*/)
                                    continue;

                                npc.AddBuff(BuffID.OnFire, 180);
                            }
                        }
                        break;

                    case ProjectileID.CrimsonYoyo or ProjectileID.CorruptYoyo:
                        if (!target.CountsAsACritter && !(target.type == NPCID.TargetDummy) && projectile.GetOwner().GetModPlayer<YoyoModPlayer>().yoyoRing)
                        {
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero,
                                ProjectileID.VampireHeal, 0, 0, Main.myPlayer, projectile.owner, 1);
                            }
                        }
                        break;

                    case ProjectileID.Chik:
                        if (projectile.YoyoData().Hits >= 3)
                        {
                            SoundEngine.PlaySound(SoundID.Item110, projectile.position);
                            for (int num308 = 0; num308 < 20; num308++)
                            {
                                int num309 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CrystalPulse, projectile.velocity.X * 0.1f, projectile.velocity.Y * 0.1f, 0, default(Color), 0.5f);
                                Dust dust;
                                if (Main.rand.NextBool(3))
                                {
                                    Main.dust[num309].fadeIn = 1.1f + (float)Main.rand.Next(-10, 11) * 0.01f;
                                    Main.dust[num309].scale = 0.35f + (float)Main.rand.Next(-10, 11) * 0.01f;
                                    dust = Main.dust[num309];
                                    dust.type++;
                                }
                                else
                                {
                                    Main.dust[num309].scale = 1.2f + (float)Main.rand.Next(-10, 11) * 0.01f;
                                }
                                Main.dust[num309].noGravity = true;
                                dust = Main.dust[num309];
                                dust.velocity *= 2.5f;
                                dust = Main.dust[num309];
                                dust.velocity -= projectile.oldVelocity / 10f;
                            }
                            if (Main.myPlayer == projectile.owner)
                            {
                                int num310 = Main.rand.Next(3, 6);
                                for (int num311 = 0; num311 < num310; num311++)
                                {
                                    Vector2 vector36 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                                    while (vector36.X == 0f && vector36.Y == 0f)
                                    {
                                        vector36 = new Vector2(Main.rand.Next(-100, 101), Main.rand.Next(-100, 101));
                                    }
                                    vector36.Normalize();
                                    vector36 *= (float)Main.rand.Next(70, 101) * 0.1f;
                                    Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.oldPosition.X + (float)(projectile.width / 2), projectile.oldPosition.Y + (float)(projectile.height / 2), vector36.X, vector36.Y, 522, (int)((double)projectile.damage * 0.8), projectile.knockBack * 0.8f, projectile.owner);
                                }
                            }

                            projectile.YoyoData().Hits = 0;
                        }

                        for (int num239 = 0; num239 < 3; num239++)
                        {
                            int num240 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CrystalPulse, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 1.2f);
                            Main.dust[num240].position = (Main.dust[num240].position + projectile.Center) / 2f;
                            Main.dust[num240].noGravity = true;
                            Dust dust2 = Main.dust[num240];
                            dust2.velocity *= 0.5f;
                        }
                        for (int num241 = 0; num241 < 2; num241++)
                        {
                            int num240 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, DustID.CrystalPulse2, projectile.velocity.X, projectile.velocity.Y, 50, default(Color), 0.4f);
                            switch (num241)
                            {
                                case 0:
                                    Main.dust[num240].position = (Main.dust[num240].position + projectile.Center * 5f) / 6f;
                                    break;
                                case 1:
                                    Main.dust[num240].position = (Main.dust[num240].position + (projectile.Center + projectile.velocity / 2f) * 5f) / 6f;
                                    break;
                            }
                            Dust dust2 = Main.dust[num240];
                            dust2.velocity *= 0.1f;
                            Main.dust[num240].noGravity = true;
                            Main.dust[num240].fadeIn = 1f;
                        }

                        for (int i = 0; i < 10; i++)
                        {
                            if (Main.rand.NextBool(5))
                            {
                                Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.BlueCrystalShard, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1f);
                            }
                        }
                        break;

                    case ProjectileID.TheEyeOfCthulhu:
                        projectile.YoyoData().Hits++;
                        if (projectile.YoyoData().Hits == 50)
                            eocStage2 = true;
                        break;

                    case ProjectileID.JungleYoyo:
                        target.AddBuff(ModContent.BuffType<RootedDebuff>(), 180);
                        break;

                    case ProjectileID.Cascade:
                        if (Main.rand.NextBool(14))
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 90)) * (1 + i / 15f) * Main.rand.NextFloat(3f, 6.5f);

                                    int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                        326 + Main.rand.Next(0, 3), projectile.damage, 1, projectile.owner, 0, 1f);
                                    Main.projectile[proj].tileCollide = true;
                                    Main.projectile[proj].timeLeft = 120;
                                    Main.projectile[proj].friendly = true;
                                    Main.projectile[proj].hostile = false;
                                    Main.projectile[proj].usesLocalNPCImmunity = true;
                                    Main.projectile[proj].localNPCHitCooldown = 25;

                                }
                            }
                        }
                        break;
                }
            }
        }

        public override void AI(Projectile projectile)
        {
            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && projectile.YoyoData().MainYoyo && Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                ref int timer0 = ref projectile.YoyoData().AbilityTimer[0];
                ref int timer1 = ref projectile.YoyoData().AbilityTimer[1];
                ref int timer2 = ref projectile.YoyoData().AbilityTimer[2];

                switch (projectile.type)
                {
                    case ProjectileID.Kraken:
                        if (timer0 > 0)
                            timer0--;

                        if (Main.rand.NextBool(15) && Main.myPlayer == projectile.owner)
                        {
                            Vector2 circular = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 5f;

                            Projectile.NewProjectile(projectile.GetSource_FromThis(),
                            projectile.Center.X, projectile.Center.Y - 1f, circular.X,
                            circular.Y, ProjectileID.Bubble, (int)(projectile.damage * 0.65f), 8f,
                            projectile.owner);
                        }
                        break;

                    case ProjectileID.Yelets:
                        if (timer0 > 0)
                            timer0--;

                        if (timer0 == 0)
                        {

                            SoundStyle HitSound = new()
                            {
                                SoundPath = "CombinationsMod/Content/Sounds/ability-ready",
                                Volume = 0.6f,
                                Pitch = 1,
                                SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                            };

                            SoundEngine.PlaySound(HitSound);

                            for (int i = 0; i < 50; i++)
                            {
                                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f) * 5f;
                                Dust d = Dust.NewDustPerfect(projectile.Center, DustID.BlueFairy, speed, Scale: 1.5f);
                                d.noGravity = true;

                            }

                            timer0 = -1;
                        }

                        if (timer1 == 1 && (!Main.tile[(int)(projectile.Center.X / 16), (int)(projectile.Center.Y / 16) + 1].HasTile))
                        {
                            timer1 = 0;
                        }

                       // Main.NewText(timer0);


                        break;        

                    case ProjectileID.Cascade:
                        timer0++;
                        if (timer0 >= 120)
                        {
                            if (Main.myPlayer == projectile.owner)
                            {
                                var proj = Projectile.NewProjectileDirect(projectile.GetSource_FromThis("Cascade"),
                                projectile.Center, Main.rand.NextVector2CircularEdge(1f, 1f) * Main.rand.NextFloat(3f, 4.5f), 326 + Main.rand.Next(0, 3), (int)(projectile.damage * 0.85f), 1f,projectile.owner);
                                proj.friendly = true;
                                proj.hostile = false;
                                proj.usesIDStaticNPCImmunity = true;
                                proj.idStaticNPCHitCooldown = 20;

                                for (int i = 0; i < 12; i++)
                                {
                                    var vel = Main.rand.NextVector2CircularEdge(1f, 1f) * 5f;
                                    var dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, DustID.Torch, vel.X, vel.Y);
                                    dust.scale = 1.4f;
                                    dust.noGravity = true;
                                }
                            }

                            timer0 = 0;
                        }

                        Projectile trail = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, ModContent.ProjectileType<CascadeFireTrail>(), 18, 1f);
                        trail.timeLeft = 1;
                        trail.usesIDStaticNPCImmunity = true;
                        trail.idStaticNPCHitCooldown = 20;
                        break;

                    case ProjectileID.Code2:
                        timer0++;
                        if (timer0 >= 120)
                        {
                            for (int i = 0; i < 50; i++)
                            {
                                Vector2 speed = Main.rand.NextVector2CircularEdge(1f, 1f) * 5f;
                                Dust d = Dust.NewDustPerfect(projectile.Center, DustID.VenomStaff, speed, Scale: 1.5f);
                                d.noGravity = true;

                            }

                            for (int i = 0; i < 8; i++)
                            {
                                if (Main.myPlayer == projectile.owner)
                                {
                                    Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 8f;

                                    int proj = Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center, vel,
                                        ProjectileID.VenomFang, (int)(projectile.damage * 1.2f), 1, projectile.owner, 1, 1);
                                    Main.projectile[proj].scale = 0.9f;
                                    Main.projectile[proj].tileCollide = true;
                                    Main.projectile[proj].timeLeft = 180;
                                    Main.projectile[proj].friendly = true;
                                    Main.projectile[proj].hostile = false;
                                    Main.projectile[proj].penetrate = -1;
                                }
                            }

                            foreach (NPC npc in Main.ActiveNPCs)
                            {
                                if (projectile.Distance(npc.Center) > 65 /*|| npc == target*/)
                                    continue;

                                npc.AddBuff(BuffID.Venom, 180);
                            }

                            timer0 = 0;
                        }
                        break;

                    case ProjectileID.Valor:
                        timer0++;
                        if (timer0 == 40)
                        {
                            timer0 = 0;
                            if (Main.myPlayer == projectile.owner)
                            {
                                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.Center.X, projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                                Main.rand.NextBool() ? 1 : -1, ProjectileType<HomingWaterBolt>(), projectile.damage / 3, 0, projectile.owner);
                            }
                        }
                        break;

                    case ProjectileID.Amarok:
                        timer0++;
                        if (timer0 == 5 && projectile.ai[0] != -1 && projectile.YoyoData().MainYoyo)
                        {
                            Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, new(0, 5), ProjectileID.NorthPoleSnowflake, (int)(projectile.damage * 0.75f), 1f);
                            timer0 = 0;
                        }
                        break;

                    case ProjectileID.TheEyeOfCthulhu:
                        if (!eocStage2)
                        {
                            timer0++;
                            if (timer0 == 60)
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

                                timer0 = 0;
                            }
                        }
                        else if (eocStage2)
                        {
                            if (!roar)
                            {
                                SoundEngine.PlaySound(SoundID.Roar, projectile.position);
                                roar = true;
                            }

                            timer1++;
                            if (timer1 == 60)
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
                                timer1 = 0;
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
                switch (projectile.type)
                {
                    case ProjectileID.Cascade:
                        if (Main.rand.NextBool(5))
                        {
                            Dust.NewDust(projectile.position + projectile.velocity * 0.75f, projectile.width, projectile.height, DustID.CopperCoin, projectile.velocity.X * 0.5f, projectile.velocity.Y * 0.5f, 0, default, 1f);
                        }
                        break;

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

        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            int x = (int)(projectile.Center.X / 16);
            int y = (int)(projectile.Center.Y / 16);
            Tile tile = Framing.GetTileSafely(x, y + 1);

            if (!tile.HasTile || !WorldGen.InWorld(x, y))
                return true;

            if (GetInstance<YoyoModConfig>().VanillaYoyoEffects && projectile.YoyoData().MainYoyo && Main.player[projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                switch (projectile.type)
                {
                    case ProjectileID.Yelets:
                        if (projectile.YoyoData().AbilityTimer[0] <= 0 && projectile.YoyoData().AbilityTimer[1] == 0)
                        {
                            projectile.YoyoData().AbilityTimer[0] = 120;
                            projectile.YoyoData().AbilityTimer[1] = 1;

                            SoundStyle HitSound = new()
                            {
                                SoundPath = "CombinationsMod/Content/Sounds/rock2",
                                Volume = 0.3f,
                                PitchVariance = 0.3f,
                                SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                            };

                            SoundEngine.PlaySound(HitSound);

                            int dustType = Main.dust[WorldGen.KillTile_MakeTileDust(x, y, tile)].type;

                            //Main.NewText(oldVelocity.Y / 8);

                            for (int i = 0; i < 35; i++)
                            {
                                Vector2 speed = -Main.rand.NextVector2Unit((float)MathHelper.Pi / 4, (float)MathHelper.Pi / 2) * Math.Clamp(oldVelocity.Y / 2, 0.01f, 7f);
                                Dust.NewDust(new(projectile.Center.X, projectile.Center.Y + 16), 20, 5, dustType, speed.X, speed.Y);
                            }

                            foreach (NPC npc in Main.ActiveNPCs)
                            {
                                float distance = 250 * Math.Clamp(oldVelocity.Y / 8, 0.3f, 1.8f);
                                if (npc.Distance(projectile.Center) > distance || npc.boss /*|| npc.Size.X > 60 || npc.Size.Y > 60*/)
                                    continue;

                                if (!npc.friendly && !npc.dontTakeDamage && !npc.boss && !npc.immortal && npc.knockBackResist != 0f && npc != null)
                                {
                                    npc.velocity -= npc.DirectionTo(projectile.Center) * (5 + oldVelocity.Y / 5);
                                    npc.velocity.Y -= 6f;
                                    int damage = (int)(projectile.damage * 0.8f); // Setting initial damage
                                    damage = (int)(damage * Math.Clamp(oldVelocity.Y / 8, 0.7f, 2f)); // Multiplying by impact force
                                    damage += Main.rand.Next(-12, 12); // adding some randomness
                                    damage = (int)Math.Clamp(damage, 0, projectile.damage * 2.2f);

                                    NPC.HitInfo hitInfo = npc.CalculateHitInfo(damage, -npc.direction, false, 0f);

                                    npc.StrikeNPC(hitInfo, true);
                                    if (Main.netMode == NetmodeID.MultiplayerClient)
                                    {
                                        NetMessage.SendStrikeNPC(npc, hitInfo);
                                    }

                                }
                            }
                        }

                        break;
                }
            }

            return true;
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