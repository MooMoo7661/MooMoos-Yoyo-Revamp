using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    class IDInfo : InfoDisplay
    {
        public override bool Active()
        {
            return ModContent.GetInstance<YoyoModConfig>().YoyoProjectileID;
        }
        public override string DisplayValue(ref Color displayColor)
        {
            Player player = Main.LocalPlayer;

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                return ContentSamples.ProjectilesByType[player.HeldItem.shoot].type.ToString();
            }
            else
            {
                displayColor = InactiveInfoTextColor;
                return "No Yoyo detected";
            }
        }
    }
}