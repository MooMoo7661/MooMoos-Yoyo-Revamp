using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using CombinationsMod.GlobalClasses.Projectiles;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class CultistYoyoProjectile : ModProjectile
    {
        private bool isOriginalYoyo = false;

        public int counter = 0;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 380f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.7f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
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
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRing1>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

                isOriginalYoyo = true;
            }

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (isOriginalYoyo)
            {
                counter++;

                if (counter == 20 && Main.myPlayer == Projectile.owner)
                {
                    int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRing2>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

                    int proj3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.85f), 8f, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[proj3].Resize(263, 263);
                }
            }
        }
    }
}
