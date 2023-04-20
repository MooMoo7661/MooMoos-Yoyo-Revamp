using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    // This example show how to create new informational display (like Radar, Watches, etc.)
    // Take a look at the ExampleInfoDisplayPlayer at the end of the file to see how to use it
    class IDInfo : InfoDisplay
    {
        public override void SetStaticDefaults()
        {
            // This is the name that will show up when hovering over icon of this info display
            InfoName.SetDefault("Internal Projectile ID");
        }

        // This dictates whether or not this info display should be active
        public override bool Active()
        {
            return ModContent.GetInstance<YoyoModConfig>().YoyoProjectileID;
        }
        
        // Here we can change the value that will be displayed in the game
        public override string DisplayValue()
        {
            Player player = Main.LocalPlayer;

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                return ContentSamples.ProjectilesByType[player.HeldItem.shoot].type.ToString();
            }
            else
            {
                return "No Yoyo detected";
            }
        }
    }
}