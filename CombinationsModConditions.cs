using Terraria.ID;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;

namespace CombinationsMod
{
    public static class YoyoModConditions
    {
        public static Condition MasterOrExpertMode = new Condition("Mods.CombinationsMod.Conditions.MasterOrExpertMode", () => Main.masterMode || Main.expertMode);

        public static Condition EaterOfWorldsOrBrain = new Condition("Mods.CombinationsMod.Conditions.EaterOfWorldsOrBrain", () => Condition.DownedEaterOfWorlds.IsMet() || Condition.DownedBrainOfCthulhu.IsMet());
    }
}
