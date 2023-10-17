using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    class StringInfo : InfoDisplay
    {
        public override bool Active()
        {
            return ModContent.GetInstance<YoyoModConfig>().YoyoStringStats;
        }

        public override string DisplayValue(ref Color displayColor)
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