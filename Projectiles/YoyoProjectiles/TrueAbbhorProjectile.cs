using CombinationsMod.Dusts;
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
    public class TrueAbbhorProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 350f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15.5f;

            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 6;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }
        public override void PostAI()
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                Dust dust2 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, 75, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                dust2.velocity = VectorHelper.VelocityToPoint(dust2.position, Projectile.Center, Vector2.Distance(dust2.position, Projectile.Center) * 0.05f);
                dust2.color = Color.Black;
                dust2.noGravity = true;

                Dust dust3 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, 98, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                dust3.velocity = VectorHelper.VelocityToPoint(dust3.position, Projectile.Center, Vector2.Distance(dust3.position, Projectile.Center) * 0.05f);
                dust3.color = Color.Black;
                dust3.noGravity = true;

            }
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 65;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                int baseProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedSwirlPurple>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedShieldSwirlPurple>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[proj].rotation = 3;

                int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedShieldSwirlGreen>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);


                int hitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.60f), 5f, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[hitbox].Resize(150, 150);
                Main.projectile[hitbox].usesLocalNPCImmunity = true;
            }

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int j = 0; j < 5; j++)

                if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
                {
                    Dust dust4 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, 75, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                    dust4.velocity = VectorHelper.VelocityToPoint(dust4.position, Projectile.Center, Vector2.Distance(dust4.position, Projectile.Center) * -0.09f);
                    dust4.color = Color.Black;
                    dust4.scale = 2f;
                    dust4.noGravity = true;

                    Dust dust5 = Dust.NewDustDirect(Projectile.Center - new Vector2(75f, 75f), 150, 150, 98, 0f, 0f, 0, default(Color), Main.rand.NextFloat(0.5f, 2.4f));
                    dust5.velocity = VectorHelper.VelocityToPoint(dust5.position, Projectile.Center, Vector2.Distance(dust5.position, Projectile.Center) * -0.09f);
                    dust5.color = Color.Black;
                    dust5.scale = 2f;
                    dust5.noGravity = true;

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
