using Terraria;

namespace CombinationsMod.Content.Conditions
{
    public static class YoyoModConditions
    {
        public static Condition EaterOfWorldsOrBrain = new("Mods.CombinationsMod.Conditions.EaterOfWorldsOrBrain", () => Condition.DownedEaterOfWorlds.IsMet() || Condition.DownedBrainOfCthulhu.IsMet());
        public static Condition NPCNotShimmered = new("Mods.CombinationsMod.Conditions.NPCNotShimmered", () => !Condition.IsNpcShimmered.IsMet());
       
    }
}
