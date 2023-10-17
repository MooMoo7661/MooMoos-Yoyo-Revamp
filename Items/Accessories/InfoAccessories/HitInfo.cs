using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace CombinationsMod.Items.Accessories.InfoAccessories
{
    class HitInfo : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().hitTracker;
        }
        public override string DisplayValue(ref Color displayColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            Item held = Main.LocalPlayer.HeldItem;

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                return modPlayer.HitCounter.ToString();
            }
            else
            {
                return "No Yoyo detected";
            }
        }
    }
}