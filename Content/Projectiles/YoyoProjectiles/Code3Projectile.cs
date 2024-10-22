using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.YoyoEffects;
using CombinationsMod.Content.Projectiles.YoyoEffects.Solid;
using Microsoft.Xna.Framework.Graphics;
using Terraria.DataStructures;
namespace CombinationsMod.Content.Projectiles.YoyoProjectiles
{
    public class Code3Projectile : ModProjectile
    {
        private int counter = 0;

        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 325f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 15.3f;

            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.MaxUpdates = 1;
            //if (ModDetector.CalamityLoaded) Projectile.MaxUpdates = 2;
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 65;
            Projectile.DamageType = DamageClass.MeleeNoSpeed;
            Projectile.scale = 1f;
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Player player = Main.player[Projectile.owner];

            counter++;

            if (player.GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                if (counter == 20 && Projectile.YoyoData().mainYoyo && Main.myPlayer == Projectile.owner)
                {
                    int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<RedShieldSwirl2>(), (int)(Projectile.damage * 0.75f), 0, Main.myPlayer, 0, Projectile.whoAmI);
                    //Main.projectile[proj].scale = 1.8f;

                    int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y,
                        0, 0, ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.75f), 9f, Main.myPlayer, 0, Projectile.whoAmI);
                    Main.projectile[proj2].Resize(180, 180);
                }
            }
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (Projectile.YoyoData().mainYoyo && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<RedShieldSwirl>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[proj].rotation = 3;

                int proj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<RedShieldSwirl>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int hitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<CultistRingDamage>(), (int)(Projectile.damage * 0.65f), 5f, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[hitbox].Resize(120, 120);
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
