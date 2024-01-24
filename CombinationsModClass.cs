using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.Achievements;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod
{
    public class CombinationsModClass : Mod
    {
        public override void Load()
        {
            On_Player.ApplyEquipFunctional += On_Player_ApplyEquipFunctional;
        }

        public override void Unload()
        {
            On_Player.ApplyEquipFunctional -= On_Player_ApplyEquipFunctional;
        }

        private void On_Player_ApplyEquipFunctional(On_Player.orig_ApplyEquipFunctional orig, Player self, Item item, bool hideVisual)
        {
            if (item.type != ItemID.YoyoBag)
                orig.Invoke(self, item, hideVisual);

            if (!ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag && item.type == ItemID.YoyoBag)
            {
                orig.Invoke(self, item, hideVisual);
            }

            if (item.type == ItemID.YoyoBag)
            {
                self.GetModPlayer<YoyoModPlayer>().yoyoBag = true;
            }
        }

        public override void PostSetupContent()
        {
            if (ModLoader.TryGetMod("TMLAchievements", out Mod mod))
            {
                Logger.Info("TML Achivements Mod detected - Adding custom achievements");
                mod.Call("AddAchievement", this, "Code1Achievement", AchievementCategory.Collector, "CombinationsMod/Content/Crossmod/Achievements/AchievementCode1", null, false, true, 1f, new string[] { "Collect_" + ItemID.Code1 });
                mod.Call("AddAchievement", this, "AbbhorAchievement", AchievementCategory.Collector, "CombinationsMod/Content/Crossmod/Achievements/AchievementAbbhor", null, false, false, 2f, new string[] { "Collect_" + ItemType<TheAbbhor>() });
                mod.Call("AddAchievement", this, "Code2Achievement", AchievementCategory.Collector, "CombinationsMod/Content/Crossmod/Achievements/AchievementCode2", "CombinationsMod/Content/Crossmod/Achievements/RareBorder", false, true, 3f, new string[] { "Collect_" + ItemID.Code2 });
                mod.Call("AddAchievement", this, "ConverganceAchievement", AchievementCategory.Collector, "CombinationsMod/Content/Crossmod/Achievements/AchievementConvergance", "CombinationsMod/Content/Crossmod/Achievements/SpecialBorder", false, true, 4f, new string[] { "Collect_" + ItemType<Convergance>() });
            }
            else
            {
                Logger.Info("TML Achivements Mod not detected - Custom achievements will not be added.");
            }
        }
    }
}

