using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Accessories.InfoAccessories
{
    class SpeedInfo : InfoDisplay
    {
        public override bool Active()
        {
            return Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().speedTracker;
        }

        public override string DisplayValue(ref Color displayColor, ref Color displayShadowColor)/* tModPorter Suggestion: Set displayColor to InactiveInfoTextColor if your display value is "zero"/shows no valuable information */
        {
            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            Item held = player.HeldItem;
            Projectile projectile = ContentSamples.ProjectilesByType[player.HeldItem.shoot];

            if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].aiStyle == 99)
            {
                if (ContentSamples.ProjectilesByType[player.HeldItem.shoot].MaxUpdates != 0)
                {
                    float speed2 = ProjectileID.Sets.YoyosTopSpeed[player.HeldItem.shoot] * projectile.MaxUpdates;

                    return modPlayer.GetModifiedPlayerYoyoSpeed(speed2, player).ToString();
                }

                float speed = ProjectileID.Sets.YoyosTopSpeed[player.HeldItem.shoot];

                return modPlayer.GetModifiedPlayerYoyoSpeed(speed, player).ToString();
            }
            else
            {
                return "No Yoyo detected";
            }
        }
    }
}