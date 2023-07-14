using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent.Drawing;
using Terraria.GameContent;

namespace CombinationsMod.Projectiles.YoyoProjectiles;

public class EmpressProjectile : ModProjectile
{
    public override void SetStaticDefaults()
    {
        ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
        ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 370f;
        ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 17.3f;

        ProjectileID.Sets.TrailCacheLength[base.Projectile.type] = 45;
        ProjectileID.Sets.TrailingMode[base.Projectile.type] = 2;
    }

    public override void SetDefaults()
    {
        Projectile.extraUpdates = 0;
        Projectile.width = 14;
        Projectile.height = 14;
        Projectile.aiStyle = 99;
        Projectile.friendly = true;
        Projectile.penetrate = -1;
        Projectile.DamageType = DamageClass.Melee;
        Projectile.scale = 1f;
        Projectile.rotation = 0.01f;
    }

    public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
    {
        Vector2 positionInWorld = Main.rand.NextVector2FromRectangle(target.Hitbox);
        ParticleOrchestraSettings particleOrchestraSettings = default(ParticleOrchestraSettings);
        particleOrchestraSettings.PositionInWorld = positionInWorld;
        ParticleOrchestraSettings settings = particleOrchestraSettings;
        ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.RainbowRodHit, settings, Projectile.owner);
        ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.TrueExcalibur, settings, Projectile.owner);
    }

    public override void PostAI()
    {
        if (Projectile.velocity.X >= 8 || Projectile.velocity.X <= -8) { return; }
        if (Projectile.velocity.Y >= 8 || Projectile.velocity.Y <= -8) { return; }

        Rectangle hitbox = Projectile.Hitbox;
        hitbox.Width *= 3;
        hitbox.Height *= 3;

        Vector2 positionInWorld = Main.rand.NextVector2FromRectangle(hitbox);
        ParticleOrchestraSettings particleOrchestraSettings = default(ParticleOrchestraSettings);
        particleOrchestraSettings.PositionInWorld = positionInWorld;
        ParticleOrchestraSettings settings = particleOrchestraSettings;

        if (Main.rand.NextBool(100))
        {
            ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.TrueExcalibur, settings, Projectile.owner);
        }

        if (Main.rand.NextBool(70))
        {
            ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.Excalibur, settings, Projectile.owner);
        }

        if (Main.rand.NextBool(60))
        {
            ParticleOrchestrator.RequestParticleSpawn(false, ParticleOrchestraType.Keybrand, settings, Projectile.owner);
        }
    }

    public override bool PreDraw(ref Color lightColor)
    {
        Texture2D texture = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Projectiles/YoyoProjectiles/GlowBallPremultiplied");
        float iterations = 6;

        float time = (float)Main.timeForVisualEffects;

        for (int i = Projectile.oldPos.Length - 1; i >= 1; i--)
        {


            for (float j = 0; j < 1; j += 1 / iterations)
            {
                float hueScrollRate = 0.005f;//can be any number you want
                float gradientSize = 0.02f;// once again any number you want

                Color color = Main.hslToRgb((i * gradientSize + hueScrollRate * time) % 1, 1, 0.5f);
                Color oldColor = Main.hslToRgb(((i - 1) * gradientSize + hueScrollRate * time) % 1, 1, 0.5f);
                color.A = 128;
                color *= 1 / iterations;
                color *= 1 - (float)i / Projectile.oldPos.Length;
                oldColor *= 1 / iterations;
                oldColor *= 1 - (float)(i - 1) / Projectile.oldPos.Length;
                color = Color.Lerp(oldColor, color, j) * Projectile.Opacity;

                color *= 0.6f;

                float curRot = i == 0 ? (Projectile.position - Projectile.oldPos[i]).ToRotation() : (Projectile.oldPos[i - 1] - Projectile.oldPos[i]).ToRotation();
                float oldRot = (i + 1) < Projectile.oldRot.Length ? (Projectile.oldPos[i] - Projectile.oldPos[i + 1]).ToRotation() : curRot;//curRot in this case is fallback value when we un out of indexes
                Vector2 pos = i == 0 ? Vector2.Lerp(Projectile.oldPos[i], Projectile.position, j) : Vector2.Lerp(Projectile.oldPos[i - 1], Projectile.oldPos[i], j);
                float rot = i == 0 ? Utils.AngleLerp(curRot, oldRot, j) : Utils.AngleLerp(curRot, oldRot, j);
                rot -= MathF.PI / 2;

                Main.EntitySpriteDraw(texture, pos + Projectile.Size / 2 - Main.screenPosition, null, color, rot, texture.Size() / 2, Projectile.scale * 0.5f, SpriteEffects.None);
            }
        }

        for (int i = Projectile.oldPos.Length - 1; i >= 1; i--)
        {


            for (float j = 0; j < 1; j += 1 / iterations)
            {
                Color color = new Color(255, 255, 255, 0);
                color *= 1 / iterations;
                color *= 1 - (float)i / Projectile.oldPos.Length;
                float curRot = i == 0 ? (Projectile.position - Projectile.oldPos[i]).ToRotation() : (Projectile.oldPos[i - 1] - Projectile.oldPos[i]).ToRotation();
                float oldRot = (i + 1) < Projectile.oldRot.Length ? (Projectile.oldPos[i] - Projectile.oldPos[i + 1]).ToRotation() : curRot;//curRot in this case is fallback value when we un out of indexes

                float scale = MathHelper.Lerp(1 - (i - 1f) / 60f, 1 - 1 / 60f, j) + 0.1f;
                Vector2 pos = i == 0 ? Vector2.Lerp(Projectile.oldPos[i], Projectile.position, j) : Vector2.Lerp(Projectile.oldPos[i - 1], Projectile.oldPos[i], j);
                float rot = i == 0 ? Utils.AngleLerp(curRot, oldRot, j) : Utils.AngleLerp(curRot, oldRot, j);
                rot -= MathF.PI / 2;

                Main.EntitySpriteDraw(texture, pos + Projectile.Size / 2 - Main.screenPosition, null, color, rot, texture.Size() / 2, Projectile.scale * 0.2f * new Vector2(0.3f, 0.9f), SpriteEffects.None);
            }
        }

        DrawGlowBallAdditive(Projectile.Center, 0.4f, Color.White, Color.White, true);

        int numberOfCloneImages = 6;
        Texture2D tex = ModContent.Request<Texture2D>("CombinationsMod/Projectiles/YoyoProjectiles/GrayscaleEOLYoyoWings").Value;
        Vector2 wingsOffset = new Vector2(7, 0);
        float wingRotation = MathF.Sin(Main.GlobalTimeWrappedHourly * 50) * 0.2f + 0.1f;
        //LAYERING AGONYYY
        //BlackBGLayer(numberOfCloneImages, tex, wingsOffset, wingRotation, 0.5f);
        ColorfulPart(numberOfCloneImages, tex, wingsOffset, wingRotation);
        return false;
    }

    void ColorfulPart(int numberOfCloneImages, Texture2D tex, Vector2 wingsOffset, float wingRotation)
    {
        for (int j = -1; j < 2; j += 2)
        {

            Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition + wingsOffset * j, null, Color.White with { A = 0 }, wingRotation * j, new Vector2(j == 1 ? 0 : tex.Width, tex.Height / 2), Projectile.scale, j == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
            for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
            {
                Color color = Main.hslToRgb((Main.GlobalTimeWrappedHourly + i) % 1f, 1f, 0.5f) * 0.5f;
                float cloneImageDistance = GetCloneImageDist(ref color);
                Vector2 drawPos = Projectile.Center + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f) - Main.screenPosition;
                Main.EntitySpriteDraw(tex, drawPos + wingsOffset * j, null, color, wingRotation * j, new Vector2(j == 1 ? 0 : tex.Width, tex.Height / 2), Projectile.scale, j == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None);
            }
        }
        tex = TextureAssets.Projectile[Type].Value;
        Main.EntitySpriteDraw(tex, Projectile.Center - Main.screenPosition, null, Color.White with { A = 0 }, Projectile.rotation, tex.Size() / 2, Projectile.scale, SpriteEffects.None);
        for (float i = 0; i < 1; i += 1f / numberOfCloneImages)
        {
            Color color = Main.hslToRgb((Main.GlobalTimeWrappedHourly + i) % 1f, 1f, 0.5f) * 0.5f;
            float cloneImageDistance = GetCloneImageDist(ref color);
            Vector2 drawPos = Projectile.Center + (i * MathF.Tau).ToRotationVector2() * (cloneImageDistance + 2f) - Main.screenPosition;
            Main.EntitySpriteDraw(tex, drawPos, null, color, Projectile.rotation, tex.Size() / 2, Projectile.scale, SpriteEffects.None);
        }
    }
    static float GetCloneImageDist(ref Color color, byte? colorAlpha = 0)
    {
        float cloneImageDistance = MathF.Cos(Main.GlobalTimeWrappedHourly / 2f * MathF.Tau / 2f) + 0.5f;
        cloneImageDistance = MathHelper.Max(cloneImageDistance, 0.2f);
        color *= 1.3f - cloneImageDistance * 0.3f;
        if (colorAlpha.HasValue)
            color.A = colorAlpha.Value;
        return cloneImageDistance * 3;
    }
    public static void DrawGlowBallAdditive(Vector2 pos, float scaleMultiplier, Color outerColor, Color innerColor, bool shiny = true)
    {
        Texture2D GlowBall = (Texture2D)ModContent.Request<Texture2D>("CombinationsMod/Projectiles/YoyoProjectiles/GlowBallPremultiplied");

        Vector2 origin = GlowBall.Size() / 2;
        Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, outerColor with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier, SpriteEffects.None);
        Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, innerColor with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier * 0.5f, SpriteEffects.None);
        if (shiny)
            Main.EntitySpriteDraw(GlowBall, pos - Main.screenPosition, null, Color.White with { A = 0 }, Main.rand.NextFloat() * MathF.Tau, origin, scaleMultiplier * 0.25f, SpriteEffects.None);
    }
}
