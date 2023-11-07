using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace CombinationsMod
{
    public class ModDetector
    {
        public static bool CalamityLoaded => ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
    }
}
