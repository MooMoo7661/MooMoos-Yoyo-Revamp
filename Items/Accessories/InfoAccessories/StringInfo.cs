using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    // This example show how to create new informational display (like Radar, Watches, etc.)
    // Take a look at the ExampleInfoDisplayPlayer at the end of the file to see how to use it
    class StringInfo : InfoDisplay
    {
        public override void SetStaticDefaults()
        {
            // This is the name that will show up when hovering over icon of this info display
            // DisplayName.SetDefault("Internal String Color");
        }

        // This dictates whether or not this info display should be active
        public override bool Active()
        {
            return ModContent.GetInstance<YoyoModConfig>().YoyoStringStats;
        }
        
        // Here we can change the value that will be displayed in the game
        public override string DisplayValue(ref Color displayColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player player = Main.LocalPlayer;

            if (player.stringColor > 28) // Vanilla Yoyo String Color values stop at 28. 28 being the brown string.
            {
                return player.stringColor.ToString() + " (custom string color ID)";
            }

            return player.stringColor.ToString();
            
        }
    }
}