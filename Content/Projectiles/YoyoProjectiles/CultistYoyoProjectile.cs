using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.GlobalClasses.Projectiles;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class CultistYoyoProjectile : ModProjectile
    {
        //Shakiryo

        private bool isOriginalYoyo = false;
        public int counter = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 380f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 19.7f;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.5f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 3;
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
            if (Projectile.ai[2] == 0 && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRing1>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);


                int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[proj2].Resize(150, 150);

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
