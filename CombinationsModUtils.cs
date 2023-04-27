using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
