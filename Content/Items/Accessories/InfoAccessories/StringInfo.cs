using CombinationsMod.Content.Configs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.InfoAccessories
{
    class StringInfo : InfoDisplay
    {
        public override bool Active()
        {
            return ModContent.GetInstance<YoyoModConfig>().YoyoStringStats;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)
        {
            Player player = Main.LocalPlayer;
            displayColor = Color.Sienna;

            if (player.stringColor > 28)
            {
                return player.stringColor.ToString() + " (custom string color ID)";
            }

            return player.stringColor.ToString();

        }
    }
}