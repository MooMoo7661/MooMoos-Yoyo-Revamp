using CombinationsMod.Buffs;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;


namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TheEnervationProjectile : ModProjectile
    {
        public int counter = 0;
        public int storeData = -1;
        public int storeData2 = -1;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 240f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12.7f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 90;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;

        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            if (!target.CountsAsACritter && !(target.type == NPCID.TargetDummy) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int rand = Main.rand.Next(2) + 1;

                Vector2 vector = new(0, 0);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, vector,
                ProjectileID.VampireHeal, 0, 0, Projectile.owner, Projectile.owner, rand);
            }

            target.AddBuff(ModContent.BuffType<Corrupt>(), 420);
        }

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 10, DustID.Demonite);
                dust.noGravity = true;
                dust.noLight = true;
                dust.scale = 0.8f;
            }

            if (Main.player[Projectile.owner].ZoneCorrupt == true)
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, 20, DustID.CorruptTorch);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.35f;


                Lighting.AddLight(Projectile.Center, 0, 0, (float)1.2);


                if (storeData == -1 && Projectile.owner == Main.myPlayer)
                {
                    storeData = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0, ModContent.ProjectileType<SwirlPurple>(), (int)(Projectile.damage * 0.75f) + 1, 0, Main.myPlayer, 0, Projectile.whoAmI);
                }
            }
        }
    }
}
