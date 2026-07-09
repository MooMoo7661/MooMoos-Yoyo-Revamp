using Terraria;

namespace CombinationsMod.Content.Conditions
{
    public static class YoyoModConditions
    {
        public static Condition EaterOfWorldsOrBrain = new("Mods.CombinationsMod.Conditions.EaterOfWorldsOrBrain", () => Condition.DownedEaterOfWorlds.IsMet() || Condition.DownedBrainOfCthulhu.IsMet());
        public static Condition NPCNotShimmered = new("Mods.CombinationsMod.Conditions.NPCNotShimmered", () => !Condition.IsNpcShimmered.IsMet());
        public static Condition MoonFullOrNew = new("Mods.CombinationsMod.Conditions.MoonFullOrNew", () => Condition.MoonPhaseFull.IsMet() || Condition.MoonPhaseNew.IsMet());
        public static Condition MoonWaningGibbousOrWaxingCrescent = new("Mods.CombinationsMod.Conditions.MoonWaningGibbousOrWaxingCrescent", () => Condition.MoonPhaseWaningGibbous.IsMet() || Condition.MoonPhaseWaxingCrescent.IsMet());
        public static Condition MoonThirdQuarterOrFirstQuarter = new("Mods.CombinationsMod.Conditions.MoonThirdQuarterOrFirstQuarter", () => Condition.MoonPhaseFirstQuarter.IsMet() || Condition.MoonPhaseThirdQuarter.IsMet());
        public static Condition MoonWaningCrescentOrWaxingGibbous = new("Mods.CombinationsMod.Conditions.MoonWaningCrescentOrWaxingGibbous", () => Condition.MoonPhaseWaningCrescent.IsMet() || Condition.MoonPhaseWaxingGibbous.IsMet());
    }
}
