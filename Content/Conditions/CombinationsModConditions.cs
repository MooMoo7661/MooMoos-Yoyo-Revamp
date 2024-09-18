using Terraria;

namespace CombinationsMod.Content.Conditions
{
    public static class YoyoModConditions
    {
        public static Condition EaterOfWorldsOrBrain = new Condition("Mods.CombinationsMod.Conditions.EaterOfWorldsOrBrain", () => Condition.DownedEaterOfWorlds.IsMet() || Condition.DownedBrainOfCthulhu.IsMet());
    }
}
