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
    public class TempestProjectile : ModProjectile
    {
        private bool isOriginalYoyo;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.4f;

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;

            //if (ModDetector.CalamityLoaded) ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 12f;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            //Projectile.extraUpdates = 2;
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
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                isOriginalYoyo = true;

                if (Main.myPlayer == Projectile.owner)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<JaggedShieldSwirlTempest>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<TempestSpike>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<JaggedSwirlTempest>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<TempestSpike>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                    int hitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                                ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.75f), 5f, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[hitbox].Resize(150, 150);

                    int dustProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                           ModContent.ProjectileType<Sparkle1>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[dustProj].Resize(140, 140);
                    Main.projectile[dustProj].localAI[0] = 1;
                }
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            float rotation = Main.rand.Next(30) + 1;
            rotation /= 10;

            if (Main.myPlayer == Projectile.owner)
            {
                int baseProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<Sparkle2>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[baseProj].rotation = rotation;
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

        public override void PostAI()
        {
            if (Main.rand.NextBool())
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height,
                DustID.TerraBlade, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 200, default, 0.7f);

                Main.dust[dust].velocity = Projectile.velocity * 1f;
                Main.dust[dust].velocity *= 0.2f;
            }
        }
    }
}
