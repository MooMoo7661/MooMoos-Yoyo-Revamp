using Terraria.ModLoader;

namespace CombinationsMod.Content.ModSystems
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
