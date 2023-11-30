using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Dusts;
using Microsoft.CodeAnalysis;
using CombinationsMod.ModSystems;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class SmudgeProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 242f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 13.87f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.2f;
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
        }

        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (Main.player[Projectile.owner].ZoneGraveyard)
            {
                modifiers.FinalDamage *= 2;
            }

            if (target.type == NPCID.Ghost || target.type == NPCID.Wraith || target.type == NPCID.PirateGhost)
            {
                modifiers.FinalDamage *= 8f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (target.type == NPCID.Ghost || target.type == NPCID.Wraith || target.type == NPCID.PirateGhost || target.type == NPCID.DungeonSpirit || target.type == NPCID.Poltergeist)
            {
                for (int i = 0; i < 20; i++)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, ModContent.DustType<SmudgeImpact>());
                    dust.noGravity = true;
                    dust.noLight = false;

                    int rand = Main.rand.Next(1);
                    if (rand < 1)
                        dust.scale = 3.3f;
                    else
                        dust.scale = 5f;
                }
            }

            if (Main.player[Projectile.owner].ZoneGraveyard)
            {
                target.AddBuff(BuffID.OnFire, 200);
            }
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, ModContent.DustType<Smudge>());
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 1.6f;
            }

            if (Main.player[Projectile.owner].ZoneGraveyard)
            {
                if (Main.rand.NextBool())
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, ModContent.DustType<SpiritFlameBlue>());
                    dust.noGravity = false;
                    dust.noLight = false;
                    dust.scale = 1.6f;

                    Dust dust2 = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, ModContent.DustType<SpiritFlameBlue2>());
                    dust2.noGravity = false;
                    dust2.noLight = false;
                    dust2.scale = 1.6f;
                }
            }

        }
    }
}
