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
    public class TrueSmudgeProjectile: ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 385f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 16.1f;
            ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 8;
            ProjectileID.Sets.TrailingMode[base.Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = 65;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }
        public override void OnSpawn(IEntitySource source)
        {
            if (source is not YoyoClipClassEarth && source is not YoyoClipClassFire && source is not YoyoClipClassWater
                        && source is not YoyoClipClassElectricity && source is not YoyoClipClass && source is not YoyoClipClassNormal && 
                        Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int baseProj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedShieldSwirlDarkBlue>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int baseProj2 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedShieldSwirlYellow>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[baseProj2].rotation = 3f;

                int baseProj3 = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                        ModContent.ProjectileType<JaggedSwirlSmudge>(), 0, 0, Main.myPlayer, 0, Projectile.whoAmI);

                int hitbox = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0, 0,
                            ModContent.ProjectileType<SmudgeHitbox>(), (int)(Projectile.damage * 0.40f), 5f, Main.myPlayer, 0, Projectile.whoAmI);
                Main.projectile[hitbox].Resize(150, 150);
                Main.projectile[hitbox].usesLocalNPCImmunity = true;
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
           
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
