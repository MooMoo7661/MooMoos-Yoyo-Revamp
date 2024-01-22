using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;

namespace CombinationsMod.Content.Utility
{
    public class CombinationsModUtils
    {
        public static Color MulticolorLerp(float increment, params Color[] colors)
        {
            increment %= 0.999f;
            int num = (int)(increment * colors.Length);
            Color value = colors[num];
            Color value2 = colors[(num + 1) % colors.Length];
            return Color.Lerp(value, value2, increment * colors.Length % 1f);
        }

        public static Vector2 StringPos()
        {
            return new Vector2(Main.screenWidth - 350, Main.screenHeight / 11);
        }

        public static Vector2 RightGlovePos()
        {
            return new Vector2(Main.screenWidth - 350, Main.screenHeight / 11 + 50);
        }

        public static Vector2 LeftGlovePos()
        {
            return new Vector2(Main.screenWidth - 397, Main.screenHeight / 11 + 50);
        }

        public static Vector2 CounterweightPos()
        {
            return new Vector2(Main.screenWidth - 350, Main.screenHeight / 11 + 100);
        }

        public static Vector2 DrillPos()
        {
            return new Vector2(Main.screenWidth - 397, Main.screenHeight / 11 + 100);
        }

        public static Vector2 RingPos1()
        {
            return new Vector2(Main.screenWidth - 397, Main.screenHeight / 11 + 150);
        }

        public static Vector2 RingPos2()
        {
            return new Vector2(Main.screenWidth - 350, Main.screenHeight / 11 + 150);
        }

        public static Vector2 TrickPos()
        {
            return new Vector2(Main.screenWidth - 450, Main.screenHeight / 11 + 77);
        }
    }
}