using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CombinationsMod.Dusts;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class MotaiProjectile : ModProjectile
    {
        public int counter = 0;
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
            if (Main.rand.NextBool())
            {
                for (int i = 0; i < 8; i++)
                {
                    Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, DustID.GoldCoin);
                    dust.noGravity = false;
                    dust.noLight = false;
                    dust.scale = 1f;

                }
            }

            counter++;

            Player player = Main.player[Projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                if (counter >= 15)
                {
                    SpecialEffect();
                }
            }
        }

        public void SpecialEffect()
        {
            for (int i = 0; i < 16; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 23)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.Meteor1, 27, 1, Projectile.owner);
                Main.projectile[proj].scale = 0.6f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }

            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.MolotovFire, 12, 1, Projectile.owner);
                Main.projectile[proj].scale = 0.6f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }

        }


        public override void OnSpawn(IEntitySource source)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                Projectile.Center.Y, 0, 0, ModContent.ProjectileType<MotaiSwirl>(),
                (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                Projectile.Center.Y, 0, 0, ModContent.ProjectileType<MotaiCurveDuo>(),
                (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);

            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X,
                Projectile.Center.Y, 0, 0, ModContent.ProjectileType<MotaiSwirl2>(),
                (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
        }
        public override void PostAI()
        {
            int rand = Main.rand.Next(4);
            float scale = 0;

            switch (rand)
            {
                case 0:
                    scale = 1.1f;
                    break;
                case 1:
                    scale = 1.3f;
                    break;
                case 2:
                    scale = 1.5f;
                    break;
                case 3:
                    scale = 1.9f;
                    break;
            }


            Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 5, ModContent.DustType<YellowDust>());
            dust.noGravity = false;
            dust.noLight = false;
            dust.scale = scale;

            
        }
    }
}
