using CombinationsMod.GlobalClasses.Projectiles;
using CombinationsMod.Projectiles.YoyoEffects;
using CombinationsMod.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class TempestProjectile : ModProjectile
    {
        private bool isOriginalYoyo;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 400f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 18.1f;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 12;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                isOriginalYoyo = true;

                if (Main.myPlayer == Projectile.owner)
                {
                    int baseProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<JaggedShieldSwirlTempest>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                    int baseProj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<TempestSpike>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);


                    int baseProj3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<JaggedSwirlTempest>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                    int baseProj4 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<TempestSpike>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                    int hitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                                ModContent.ProjectileType<SmudgeHitbox>(), (int)(Projectile.damage * 0.45f), 5f, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[hitbox].Resize(150, 150);
                    Main.projectile[hitbox].usesLocalNPCImmunity = true;

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

            for (int i = 0; i < base.Projectile.oldPos.Length; i++)
            {
                Vector2 drawPos = base.Projectile.oldPos[i] - Main.screenPosition + drawOrigin + new Vector2(0f, base.Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - i) / (float)Projectile.oldPos.Length) * 0.4f;
                Main.EntitySpriteDraw(texture, drawPos, null, color, base.Projectile.rotation, drawOrigin, base.Projectile.scale, 0, 0);
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
