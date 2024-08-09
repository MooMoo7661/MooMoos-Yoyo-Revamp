using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.InfoAccessories
{
    class HitInfo : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().hitTracker;
        }
        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                return (modPlayer.HitCounter.ToString() + " " + Language.GetTextValue("Mods.CombinationsMod.LocalizedText.YoyoHits"));
            }
            else
            {
                return "No Yoyo detected";
            }
        }
    }
}