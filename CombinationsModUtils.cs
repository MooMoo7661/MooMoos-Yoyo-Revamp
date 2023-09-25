﻿using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria;

namespace CombinationsMod
{
    public class CombinationsModUtils
    {
        public static Color MulticolorLerp(float increment, params Color[] colors)
        {
            increment %= 0.999f;
            int num = (int)(increment * (float)colors.Length);
            Color value = colors[num];
            Color value2 = colors[(num + 1) % colors.Length];
            return Color.Lerp(value, value2, increment * (float)colors.Length % 1f);
        }

        public enum YoyoStrings
        {
            whiteString = ItemID.WhiteString,
            blackString = ItemID.BlackString,
            redString = ItemID.RedString,
            orangeString = ItemID.OrangeString,
            yellowString = ItemID.YellowString,
            limeString = ItemID.LimeString,
            greenString = ItemID.GreenString,
            tealString = ItemID.TealString,
            cyanString = ItemID.CyanString,
            skyBlueString = ItemID.SkyBlueString,
            blueString = ItemID.BlueString,
            purpleString = ItemID.PurpleString,
            violetString = ItemID.VioletString,
            pinkString = ItemID.PinkString,
            brownString = ItemID.BrownString,
            rainbowString = ItemID.RainbowString
        }

        public static Vector2 StringPos()
        {
            return new Vector2(Main.screenWidth - 350, Main.screenHeight / 11);
        }

        public static Vector2 RightGlovePos()
        {
            return new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 50);
        }

        public static Vector2 LeftGlovePos()
        {
            return new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 50);
        }

        public static Vector2 CounterweightPos()
        {
            return new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 100);
        }

        public static Vector2 DrillPos()
        {
            return new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 100);
        }

        public static Vector2 RingPos1()
        {
            return new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11 + 150)); 
        }

        public static Vector2 RingPos2()
        {
            return new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11 + 150));
        }

        public static Vector2 TrickPos()
        {
            return new Vector2(Main.screenWidth - 450, (Main.screenHeight / 11 + 77));
        }
    }
}