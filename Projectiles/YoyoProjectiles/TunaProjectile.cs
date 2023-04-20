using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using CombinationsMod.Projectiles.YoyoEffects;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TunaProjectile : ModProjectile
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
            Projectile.scale = 1.1f;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
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
            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.NebulaLaser, 43, 4.3f, Projectile.owner);
                Main.projectile[proj].scale = 1.2f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].usesLocalNPCImmunity = true;
            }

            for (int i = 0; i < 16; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 22)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.ClothiersCurse, 57, 1, Projectile.owner);
                Main.projectile[proj].scale = 1.2f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].penetrate = -1;
                Main.projectile[proj].usesLocalNPCImmunity = true;


            }

            for (int i = 0; i < 8; i++)
            {
                Vector2 vel = Vector2.UnitX.RotatedBy(MathHelper.ToRadians(i * 45)) * (1 + i / 15f) * 6f;
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vel,
                    ProjectileID.Shadowflames, 12, 1, Projectile.owner);
                Main.projectile[proj].scale = 1.2f;
                Main.projectile[proj].tileCollide = true;
                Main.projectile[proj].timeLeft = 120;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].hostile = false;
                Main.projectile[proj].friendly = true;
                Main.projectile[proj].penetrate = -1;
            }

        }

        public override void OnSpawn(IEntitySource source)
        {
            int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<CurveTuna>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
            int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<TunaSwirlInner>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
            int proj3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<TunaOuterSwirl>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
        }

    }
}
