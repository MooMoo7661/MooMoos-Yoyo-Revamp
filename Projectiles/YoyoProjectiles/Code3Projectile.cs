using CombinationsMod.Projectiles.YoyoEffects.Solid;
using CombinationsMod.Projectiles.YoyoEffects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.GlobalClasses.Projectiles;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class Code3Projectile : ModProjectile
    {
        private int counter = 0;
        private bool isOriginalYoyo;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 325f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 14.3f;

            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 3;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 65;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
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
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing && Main.myPlayer == Projectile.owner)
            {
                isOriginalYoyo = true;
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
