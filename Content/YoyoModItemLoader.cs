using CombinationsMod.Content.Configs;
using Terraria.ModLoader;

namespace CombinationsMod.Content
{
    /// <summary>
    /// This is to make it so the user can choose whether or not to include every item, using the Mod Config. Returns `LoadModdedItems` bool from YoyoModConfig.
    /// </summary>
    /// Renamed to YoyoModItemLoader to avoid confusion with terraria's ItemLoader
    public abstract class YoyoModItemLoader : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }

    public abstract class ModDrill : YoyoModItemLoader
    {
        [CloneByReference]
        public abstract bool CanBeUnloaded { get; }
        [CloneByReference]
        public abstract int DrillProjectile { get; }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            if (!CanBeUnloaded)
                return true;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }

    public abstract class ModRing : YoyoModItemLoader
    {
        [CloneByReference]
        public abstract bool CanBeUnloaded { get; }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            if (!CanBeUnloaded)
                return true;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }


    public abstract class ModString : YoyoModItemLoader
    {
        [CloneByReference]
        public abstract bool CanBeUnloaded { get; }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            if (!CanBeUnloaded)
                return true;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }

    public abstract class ModYoyo : YoyoModItemLoader
    {
        [CloneByReference]
        public abstract bool CanBeUnloaded { get; }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos)
                return false;

            if (!CanBeUnloaded)
                return true;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }
}
