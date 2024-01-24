using Terraria.ModLoader;

namespace CombinationsMod.Content.Keybindings
{
    public class KeybindSystem : ModSystem
    {
        public static ModKeybind DrillKeybind { get; private set; }
        public static ModKeybind AbilityKeybind { get; private set; }

        public override void Load()
        {
            Mod.Logger.Info("Registered Keybinds for yoyo drills and abilities");
            DrillKeybind = KeybindLoader.RegisterKeybind(Mod, "DrillKeybind", "Mouse2");
            AbilityKeybind = KeybindLoader.RegisterKeybind(Mod, "AbilityKeybind", "S");
        }

        public override void Unload()
        {
            DrillKeybind = null;
            AbilityKeybind = null;
        }
    }
}