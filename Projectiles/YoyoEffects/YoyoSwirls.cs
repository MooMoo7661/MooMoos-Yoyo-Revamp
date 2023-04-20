using CombinationsMod.Dusts;
using Microsoft.Xna.Framework;
using CombinationsMod.Projectiles.YoyoEffects;
using Terraria;
using System.Configuration;
using Terraria.ID;
using Terraria.DataStructures;

namespace CombinationsMod.Projectiles.YoyoEffects
{
    
    /* For anyone using this code for reference, I'm sorry. The names could be heavily optimized but when I made all of these,
       I didn't think to choose better names.
       Credit to Turbanik (Discord Name) for making most of these effects. */
    
    // Clay Swirls - Have a sort of "clay" look, hence the name.
    public class FormatClaySwirl : BaseSwirl // Format C
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.19f;
        protected override int Width => 55;
        protected override int Height => 55;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Format Clay Swirl";
        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ClaySwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ClaySwirlTemplateTransparent";

        protected override Color Color => new(255, 0, 0, 0);
    }

    public class GradientClaySwirl : BaseSwirl // Gradient
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.19f;
        protected override int Width => 55;
        protected override int Height => 55;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Gradient Clay Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ClaySwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ClaySwirlTemplateTransparent";

        protected override Color Color => new Color(255, 141, 141, 0);
    }

    // Curves - Either singular or double "curves". So why not just spawn the same projectile and rotate it for the double ones? Because I'm lazy, and making another png was easier.
    public class CurveCat : BaseSwirl // Catamity
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Cat";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveDuoTemplateTransparent";

        protected override Color Color => new Color(87, 255, 239, 0);
    }

    public class CurveDuo : BaseSwirl // Sovereign
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Duo";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveDuoTemplateTransparent";

        protected override Color Color => new Color(2, 144, 215, 0);
    }

    public class CurveEffect : BaseSwirl // Crag
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Orange Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveTemplateTransparent";

        protected override Color Color => new Color(255, 136, 0, 0);
    }

    public class CurveNebula : BaseSwirl // Terrarian - Nebula
    {
        protected override float Scale => 2.2f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Nebula";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveTemplateTransparent";

        protected override Color Color => new Color(255, 51, 186, 0);
    }

    public class CurveOrange : BaseSwirl // Terrarian - Solar
    {
        protected override float Scale => 2.2f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Orange";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveTemplateTransparent";

        protected override Color Color =>  new Color(244, 93, 2, 0);
    }

    public class CurveStardust : BaseSwirl // Terrarian - Stardust
    {
        protected override float Scale => 2.2f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65; 
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Stardust";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveTemplateTransparent";

        protected override Color Color => new Color(86, 214, 254, 0);
    }

    public class CurveVortex : BaseSwirl // Terrarian - Vortex
    {
        protected override float Scale => 2.2f;

        protected override float Rotation => -0.11f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Vortex";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveTemplateTransparent";

        protected override Color Color => new Color(66, 212, 167, 0);
    }

    public class CurveTuna : BaseSwirl // Tuna
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.09f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Curve Tuna";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveDuoTemplateTransparent";

        protected override Color Color => new Color(224, 95, 255, 0);
    }

    public class MotaiCurveDuo : BaseSwirl // Motai
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.19f;
        protected override int Width => 65;
        protected override int Height => 65;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Motai Curve Duo";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/CurveDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/CurveDuoTemplateTransparent";

        protected override Color Color => new Color(255, 239, 0, 0);
    }
    
    // These use the InnerSwirl png. It creates nice effects to help shade in the center of the swirl effect.
    // All of the Glove[COLOR] swirls are scaled down to nicely fit around yoyos that have a scale in the range of 0.9f - 1.2f. Larger yoyos, or yoyos with unique shapes may cover the swirl. (cough cough calamity)
    
    public class GloveBlue : BaseSwirl // Blue Glove
    {
        protected override float Scale => 0.6f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Glove Blue";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/GloveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/GloveTemplateTransparent";

        protected override Color Color => new Color(0, 0, 255, 0);
    }

    public class GloveGreen : BaseSwirl // Green Glove
    {
        protected override float Scale => 0.6f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Glove Green";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/GloveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/GloveTemplateTransparent";

        protected override Color Color => new Color(0, 255, 0, 0);
    }

    public class GloveRed : BaseSwirl // Red Glove
    {
        protected override float Scale => 0.6f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Glove Red";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/GloveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/GloveTemplateTransparent";

        protected override Color Color => new Color(255, 0, 0, 0);
    }

    public class GloveWhite : BaseSwirl // White Glove
    {
        protected override float Scale => 0.6f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Glove White";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/GloveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/GloveTemplateTransparent";

        protected override Color Color => new Color(255, 255, 255, 0);
    }

    public class GloveYellow : BaseSwirl // Yellow Glove
    {
        protected override float Scale => 0.6f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Glove Yellow";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/GloveTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/GloveTemplateTransparent";

        protected override Color Color => new Color(255, 255, 0, 0);
    }
     // These use the Inner Swirl template png. Creates a sort of ripple effect.

    public class IceSwirlInner : BaseSwirl // Amarok
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.19f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Ice Swirl Inner";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(124, 252, 255, 0);
    }

    public class MotaiSwirl2 : BaseSwirl // Motai
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Ice Swirl Inner";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 255, 0, 0);
    }

    public class MythrilSwirl : BaseSwirl // Mythril Yoyo
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.17f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => true;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Mythril Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(24, 126, 126, 0);
    }

    public class PinkSwirl : BaseSwirl // Oricalchum Yoyo
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.17f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => true;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Pink Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 182, 254, 0);
    }


    public class Swirl : BaseSwirl // Cascade
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Cascade Inner Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 115, 73, 0);
    }

    public class SwirlBlue : BaseSwirl // Sovereign
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Swirl Sovereign";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(36, 109, 255, 0);
    }

    public class SwirlGreen : BaseSwirl // Unused?
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Swirl Green";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(112, 240, 129, 0);
    }

    public class SwirlPurple : BaseSwirl // Enervation
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Swirl Purple";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(188, 0, 255, 0);
    }

    public class SwirlRed : BaseSwirl // The Muscle - When in Crimson Biome
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Swirl Red";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 0, 0, 0);

        public override bool PreDraw(ref Color lightColor)
        {
            if (!Main.player[Projectile.owner].ZoneCrimson)
            {
                return false;
            }

            return true;
        }
    }

    public class SwirlTeal : BaseSwirl // Amarok
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.11f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Swirl Teal";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(87, 255, 239, 0);
    }

    public class TunaSwirlInner : BaseSwirl // Tuna
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.13f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Tuna Swirl Inner";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirlTemplateTransparent";

        protected override Color Color => new Color(224, 95, 255, 0);
    }

    public class InnerSwirl2Red : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.13f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Inner Swirl Red 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirl2Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirl2TemplateTransparent";

        protected override Color Color => new Color(235, 0, 0, 0);
    }

    public class InnerSwirl2Yellow : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Inner Swirl Yellow 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/InnerSwirl2Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/InnerSwirl2TemplateTransparent";

        protected override Color Color => new Color(255, 255, 0, 0);
    }

    // Jagged Swirls come in either single or double. They create a very cool looking effect, similar to the Shield Swirls.

    public class JaggedSwirlPurple : BaseSwirl // Abbhor
    {
        protected override float Scale => 1.7f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl Purple";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";

        protected override Color Color => new Color(130, 38, 222, 0);
    }

    public class JaggedSwirlRed : BaseSwirl // Code 3
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl Red";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";


        protected override Color Color => new Color(200, 0, 40, 0);
    }

    public class JaggedSwirlWhite : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl White";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 255, 255, 0);
    }

    public class JaggedSwirlYellow : BaseSwirl // Yelets
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl Yellow";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 255, 0, 0);
    }

    public class JaggedSwirlSmudge: BaseSwirl // True Smudge
    {
        protected override float Scale => 2.8f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl Smudge";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";

        protected override Color Color => new Color(35, 176, 0, 0);


        public override bool PreDraw(ref Color lightColor)
        {
            if (!Main.player[Projectile.owner].ZoneGraveyard)
            {
                return false;
            }

            return true;
        }
    }

    public class JaggedSwirlTempest : BaseSwirl // Tempest
    {
        protected override float Scale => 2.8f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Jagged Swirl Tempest";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedSwirlTemplateTransparent";

        protected override Color Color => new Color(15, 225, 15, 0);
    }
    // Outer Swirls are used in effects that seem more "fire like" or wispy.

    public class IceSwirl : BaseSwirl // Amarok
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.17f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Ice Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/OuterSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/OuterSwirlTemplateTransparent";

        protected override Color Color => new Color(124, 252, 255, 0);
    }

    public class OuterSwirlRed : BaseSwirl // Crag
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.16f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Outer Swirl Red";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/OuterSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/OuterSwirlTemplateTransparent";

        protected override Color Color => new Color(255, 136, 0, 0);
    }

    public class TunaOuterSwirl : BaseSwirl // Tuna
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.16f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Tuna Outer Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/OuterSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/OuterSwirlTemplateTransparent";

        protected override Color Color => new Color(224, 95, 255, 0);
    }

    public class BlueShieldSwirlDuo : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Blue Duo";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlDuoTemplateTransparent";

        protected override Color Color => new Color(0, 69, 209, 0);
    }

    public class GreenShieldSwirlDuo : BaseSwirl // Terrarian
    {
        protected override float Scale => 1.65f;

        protected override float Rotation => 0.20f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Green Duo";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlDuoTemplateTransparent";

        protected override Color Color => new Color(78, 255, 161, 0);
    }

    public class RedShieldSwirlDuo : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.16f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Red Duo";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlDuoTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlDuoTemplateTransparent";

        protected override Color Color => new Color(255, 0, 0, 0);
    }

    public class JaggedShieldSwirlGreen : BaseSwirl // True Abbhor
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Green";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(28, 208, 2, 0);
    }

    public class JaggedShieldSwirlPurple : BaseSwirl // True Abbhor
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Purple";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(130, 38, 222, 0);
    }

    public class JaggedShieldSwirlRed : BaseSwirl // True Code 3
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Purple";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(235, 0, 0, 0);
    }

    public class JaggedShieldSwirlSkyBlue : BaseSwirl // True Code 3
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Sky Blue";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(0, 230, 255, 0);
    }

    public class JaggedShieldSwirlDarkBlue : BaseSwirl // True Smudge
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Dark Blue";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(0, 89, 210, 0);
    }

    public class JaggedShieldSwirlYellow : BaseSwirl // True Smudge
    {
        protected override float Scale => 1.1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Yellow";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(233, 255, 85, 0);
    }

    public class JaggedShieldSwirlTempest : BaseSwirl // Tempest
    {
        protected override float Scale => 1.3f;

        protected override float Rotation => 0.24f;
        protected override int Width => 150;
        protected override int Height => 150;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Jagged Shield Swirl Tempest";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/JaggedShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/JaggedShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(144, 247, 131, 0);
    }

    public class PurpleShieldSwirl : BaseSwirl // Valkyrie Yoyo
    {
        protected override float Scale => 1.4f;
            
        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Purple";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(0, 218, 244, 0);
    }

    public class BlueShieldSwirl : BaseSwirl // Red's Yoyo
    {
        protected override float Scale => 1.4f;

        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Blue";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(129, 131, 202, 0);
    }

    public class PurpleShieldSwirl2 : BaseSwirl // Abbhor
    {
        protected override float Scale => 2.3f;

        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Purple 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(75, 38, 222, 0);
    }

    public class RedShieldSwirl2 : BaseSwirl // Code 3
    {
        protected override float Scale => 2.3f;

        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Red 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(200, 0, 40, 0);
    }

    public class PurpleShieldSwirlReverse : BaseSwirl // Valkyrie Yoyo
    {
        protected override float Scale => 1.4f;

        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Purple Reverse";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlReverseTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlReverseTemplateTransparent";

        protected override Color Color => new Color(157, 113, 206, 0);
    }

    public class BlueShieldSwirlReverse : BaseSwirl // Red's Yoyo
    {
        protected override float Scale => 1.4f;

        protected override float Rotation => 0.18f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Red Reverse";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlReverseTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlReverseTemplateTransparent";

        protected override Color Color => new Color(218, 211, 126, 0);
    }

    public class RedShieldSwirl : BaseSwirl // Code 3
    {
        protected override float Scale => 1.6f;

        protected override float Rotation => 0.20f;
        protected override int Width => 80;
        protected override int Height => 80;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Shield Swirl Red";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/ShieldSwirlTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/ShieldSwirlTemplateTransparent";

        protected override Color Color => new Color(200, 0, 40, 0);
    }
        // Swirl 1s are just a basic effect similar to the Outer Swirls.

        public class Code1Swirl : BaseSwirl // probably the code 1 if i had to guess
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Code 1 Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(0, 89, 206, 0);
    }

    public class IcePartSwirl : BaseSwirl // Amarok - again
    {
        protected override float Scale => 1f;
        protected override bool DoesFrostburnDamage => true;

        protected override float Rotation => 0.20f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => true;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Ice Part Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(124, 252, 255, 0);
    }

    public class MotaiSwirl : BaseSwirl // Motai
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.24f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Motai Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(255, 255, 0, 0);
    }

    public class MythrilPartSwirl : BaseSwirl // Mythril Yoyo
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => true;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Mythril Part Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(24, 126, 126, 0);
    }

    public class PinkPartSwirl : BaseSwirl // Orichalcum Yoyo
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 50;
        protected override int Height => 50;
        protected override bool Friendly => true;
        protected override bool Hostile => false;
        protected override int Penetrate => -1;
        protected override string ProjectileName => "Pink Part Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(255, 182, 254, 0);
    }

    public class SwirlStar : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => -0.20f;
        protected override int Width => 60;
        protected override int Height => 60;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Star Yoyo Swirl";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl1Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl1TemplateTransparent";

        protected override Color Color => new Color(243, 26, 221, 0);
    }

    public class BlueSwirl2 : BaseSwirl // Kraken
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.20f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Blue Swirl 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl2Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl2TemplateTransparent";

        protected override Color Color => new Color(128, 218, 255, 0);
    }
    public class RedSwirl2 : BaseSwirl // Unused
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.13f;
        protected override int Width => 70;
        protected override int Height => 70;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Red Swirl 2";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/Swirl2Template";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/Swirl2TemplateTransparent";

        protected override Color Color => new Color(255, 0, 0, 0);
    }

    public class TempestSpike : BaseSwirl // Tempest Spike
    {
        protected override float Scale => 1f;

        protected override float Rotation => 0.09f;
        protected override int Width => 200;
        protected override int Height => 200;
        protected override bool Friendly => false;
        protected override bool Hostile => false;
        protected override int Penetrate => 1;
        protected override string ProjectileName => "Tempest Spike";

        protected override string TexturePath => "CombinationsMod/Projectiles/YoyoEffects/TempestSpikeTemplate";
        protected override string TexturePathTransparent => "CombinationsMod/Projectiles/YoyoEffects/Transparent/TempestSpikeTransparent";

        protected override Color Color => new Color(166, 255, 159, 0);
    }


}
