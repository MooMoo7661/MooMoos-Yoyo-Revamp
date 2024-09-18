using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using CombinationsMod.GlobalClasses.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
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

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.4f;
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
            if (Projectile.ai[2] == 0 && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
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

            for (int i = 0; i < Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.4f;
                Main.EntitySpriteDraw(texture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, 0, 0);
            }
            return false;
        }
    }
}
