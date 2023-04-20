using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class CatProjectile : ModProjectile
    {
        public int counter = 0;
        public int storeData = -1;
        public int storeData2 = -1;
        public int storeData3 = -1;
        public int storeData4 = -1;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 18f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
           


            Player player = Main.player[Projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                counter++;
                if (counter >= 15)
                {
                    SpecialEffect(target);
                }
            }
        }

        public void SpecialEffect(NPC target)
        {
            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.VortexBeaterRocket, 12, 1, Projectile.owner);
                Main.projectile[proj].scale = 0.6f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].usesLocalNPCImmunity = true;


                Dust dust = Dust.NewDustDirect(Projectile.Center, Projectile.width, 20, DustID.Vortex);
            }

            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.BallofFrost, 12, 1, Projectile.owner);
                Main.projectile[proj].scale = 0.6f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].penetrate = 3;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }
        }

        public override void PostAI()
        {
            if (storeData == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<CurveCat>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData2 == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<SwirlTeal>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData3 == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<Code1Swirl>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }

            if (storeData4 == -1 && Projectile.owner == Main.myPlayer)
            {
                storeData4 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<OuterSwirlRed>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
            }



            int rand = Main.rand.Next(50);
            if (rand == 1 || rand == 2 || rand == 3)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.BlueTorch);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 2f;

            }
        }
    }
}
