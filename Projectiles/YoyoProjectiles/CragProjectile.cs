using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Projectiles.Explosions;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.Projectiles.YoyoEffects.Solid;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{

    public class CragProjectile : ModProjectile
    {
        public int counter = 0;
        public int cragTimer = 0;
        public int storeData = -1;
        public int storeData2 = -1;
        public int storeData3 = -1;
        public int storeData4 = -1;
        public int explosionCounter = 0;
        
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 243f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.8f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 40;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 180);

            explosionCounter++;
            counter++;

            if (explosionCounter == 2)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                        Main.rand.NextBool() ? 1 : -1, ModContent.ProjectileType<FireExplosion>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
                Main.projectile[proj].usesLocalNPCImmunity = true;
                explosionCounter = 0;
            }
        }


        public override void AI()
        {

            if (Main.rand.NextBool(5))
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.CopperCoin, Projectile.velocity.X * 0.5f, Projectile.velocity.Y * 0.5f, 0, default, 1f);
            }

            if (counter >= 5)
            {
                cragTimer++;
                if (cragTimer == 20)
                {
                    cragTimer = 0;
                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y - 1f, Main.rand.NextBool() ? 1 : -1,
                    Main.rand.NextBool() ? 1 : -1, ModContent.ProjectileType<CragHomingExplosive>(), (int)(Projectile.damage * 1f), 0, Projectile.owner);
                }
            }

        }

        public override void PostAI()   
        {
                
            if (storeData == -1 && Projectile.owner == Main.myPlayer && counter >= 20)
            {
                storeData = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<CurveEffect>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData2 == -1 && Projectile.owner == Main.myPlayer && counter >= 20)
            {
                storeData2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<Background>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData3 == -1 && Projectile.owner == Main.myPlayer && counter >= 20)
            {
                storeData3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<Swirl>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }
            if (storeData4 == -1 && Projectile.owner == Main.myPlayer && counter >= 20)
            {
                storeData4 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<OuterSwirlRed>(), 8, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (counter >= 20)
            {
                if (Main.rand.NextBool())
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Smoke);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.6f;
                }
            }

            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.FlameBurst);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.6f;
            }

            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.Lava);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.3f;
            }
        }

        
    }
}
