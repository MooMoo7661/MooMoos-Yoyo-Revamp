using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.Localization;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Content.ModPlayers
{
    public class MiscYoyoModPlayer : ModPlayer
    {
        public override void PlayerDisconnect()
        {
            Player.GetModPlayer<YoyoModPlayer>().HitCounter = 0;
        }

        public override void OnEnterWorld()
        {
            if (!ModLoader.TryGetMod("TMLAchievements", out Mod mod))
                Main.NewText(Language.GetTextValue("Mods.CombinationsMod.LocalizedText.AchievementsNotification"), Color.LightGoldenrodYellow);
        }

        public override void PostUpdateEquips()
        {
            YoyoModPlayer modPlayer = Player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.beetleBag || modPlayer.moonlordBag || modPlayer.shimmerBag || modPlayer.tier2Bag || modPlayer.yoyoBag)
            {
                modPlayer.playerHasYoyoBagEquipped = true;
            }
        }
    }
}
