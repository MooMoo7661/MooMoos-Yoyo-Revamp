using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.Explosions;
using CombinationsMod.Projectiles.YoyoEffects;
using Terraria.GameContent;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework.Graphics;
using CombinationsMod.GlobalClasses.Projectiles;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TheAbbhorProjectile : ModProjectile
    {
        private int counter = 0;
        private int storeData = -1;
        private bool isOriginalYoyo;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 315f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.86f;

            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];

            counter++;

            if (player.GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                if (counter == 20 && isOriginalYoyo && Main.myPlayer == Projectile.owner)
                {
                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<PurpleShieldSwirl2>(), (int)(Projectile.damage * 0.75f), 0, Main.myPlayer, 0, Projectile.whoAmI);
                    //Main.projectile[proj].scale = 1.8f;

                    int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.6f), 1.4f, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[proj2].Resize(180, 180);
                }
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                isOriginalYoyo = true;

                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<JaggedSwirlPurple>(), (int)(Projectile.damage * 0.75f), 0, Main.myPlayer, 0, Projectile.whoAmI);
                //Main.projectile[proj].scale = 1.3f;

                int projHitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                    0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.4f), 1.4f, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[projHitbox].Resize(120, 120);

                int dustProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                       ModContent.ProjectileType<Sparkle1>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[dustProj].Resize(80, 80);
                Main.projectile[dustProj].localAI[0] = 2;
                Main.projectile[dustProj].localAI[1] = 2;
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {

            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(texture.Width * 0.5f, Projectile.height * 0.5f);

            for (int i = 0; i < base.Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = base.Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, base.Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.4f;
                Main.EntitySpriteDraw(texture, drawPos, null, color, base.Projectile.rotation, drawOrigin, base.Projectile.scale, 0, 0);
            }
            return false;
        }
    }
}
