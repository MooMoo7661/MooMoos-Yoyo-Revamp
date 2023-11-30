using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace CombinationsMod.ModSystems
{
    public class ModDetector : ModSystem
    {
        public static bool CalamityLoaded;

        public override void PostSetupContent()
        {
            CalamityLoaded = ModLoader.TryGetMod("CalamityMod", out Mod Calamity);
        }
    }
}
