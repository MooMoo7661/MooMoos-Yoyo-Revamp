using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Vector2 stringSlotPos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    stringSlotPos = new Vector2(Main.screenWidth - 350, Main.screenHeight / 11);
                    break;

                case 2:
                    stringSlotPos = new Vector2(Main.screenWidth - 980, Main.screenHeight / 11);
                    break;

                case 3:
                    stringSlotPos = new Vector2(Main.screenWidth - 1212, Main.screenHeight / 3 - 45);
                    break;

                case 4:
                    stringSlotPos = new Vector2(Main.screenWidth / 2 + 110, (Main.screenHeight / 2 - 68));
                    break;
            }

            return stringSlotPos;
        }

        public static Vector2 RightGlovePos()
        {
            Vector2 rightGlovePos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    rightGlovePos = new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 50);
                    break;

                case 2:
                    rightGlovePos = new Vector2(Main.screenWidth - 980, (Main.screenHeight / 11) + 50);
                    break;

                case 3:
                    rightGlovePos = new Vector2(Main.screenWidth - 1212, Main.screenHeight / 3 + 2);
                    break;

                case 4:
                    rightGlovePos = new Vector2(Main.screenWidth / 2 + 110, (Main.screenHeight / 2 - 19));
                    break;
            }

            return rightGlovePos;
        }

        public static Vector2 LeftGlovePos()
        {
            Vector2 leftGlovePos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    leftGlovePos = new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 50);
                    break;

                case 2:
                    leftGlovePos = new Vector2(Main.screenWidth - 1027, (Main.screenHeight / 11) + 50);
                    break;

                case 3:
                    leftGlovePos = new Vector2(Main.screenWidth - 1259, (Main.screenHeight / 3 + 2));
                    break;

                case 4:
                    leftGlovePos = new Vector2(Main.screenWidth / 2 + 63, (Main.screenHeight / 2 - 19));
                    break;
            }

            return leftGlovePos;
        }

        public static Vector2 CounterweightPos()
        {
            Vector2 counterweightPos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    counterweightPos = new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11) + 100);
                    break;

                case 2:
                    counterweightPos = new Vector2(Main.screenWidth - 980, (Main.screenHeight / 11) + 100);
                    break;

                case 3:
                    counterweightPos = new Vector2(Main.screenWidth - 1212, (Main.screenHeight / 3 + 49));
                    break;

                case 4:
                    counterweightPos = new Vector2(Main.screenWidth / 2 + 110, (Main.screenHeight / 2 + 30));
                    break;
            }

            return counterweightPos;
        }

        public static Vector2 DrillPos()
        {
            Vector2 drillPos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    drillPos = new Vector2(Main.screenWidth - 397, (Main.screenHeight / 11) + 100);
                    break;

                case 2:
                    drillPos = new Vector2(Main.screenWidth - 1027, (Main.screenHeight / 11) + 100);
                    break;

                case 3:
                    drillPos = new Vector2(Main.screenWidth - 1259, (Main.screenHeight / 3 + 49));
                    break;

                case 4:
                    drillPos = new Vector2(Main.screenWidth / 2 + 63, (Main.screenHeight / 2 + 30));
                    break;
            }

            return drillPos;
        }

        public static Vector2 RingPos1()
        {
            Vector2 ringPos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    ringPos = new Vector2(Main.screenWidth -  397, (Main.screenHeight / 11 + 150));
                    break;

                case 2:
                    ringPos = new Vector2(Main.screenWidth - 1027, (Main.screenHeight / 11) + 150);
                    break;

                case 3:
                    ringPos = new Vector2(Main.screenWidth - 1259, (Main.screenHeight / 3 + 96));
                    break;

                case 4:
                    ringPos = new Vector2(Main.screenWidth / 2 + 110, (Main.screenHeight / 2 + 79));
                    break;
            }

            return ringPos;
        }

        public static Vector2 RingPos2()
        {
            Vector2 ringPos = new Vector2();
            int pos = ModContent.GetInstance<YoyoModConfig>().AccessorySlotPosition;

            switch (pos)
            {
                case 1:
                    ringPos = new Vector2(Main.screenWidth - 350, (Main.screenHeight / 11 + 150));
                    break;

                case 2:
                    ringPos = new Vector2(Main.screenWidth - 980, (Main.screenHeight / 11) + 150);
                    break;

                case 3:
                    ringPos = new Vector2(Main.screenWidth - 1212, (Main.screenHeight / 3 + 96));
                    break;

                case 4:
                    ringPos = new Vector2(Main.screenWidth / 2 + 63, (Main.screenHeight / 2 + 79));
                    break;
            }

            return ringPos;
        }
    }
}
