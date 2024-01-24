using CombinationsMod.Content.Configs;
using Terraria.ModLoader;

namespace CombinationsMod.Content
{
    /// <summary>
    /// This is to make it so the user can choose whether or not to include every item, using the Mod Config. Returns `LoadModdedItems` bool from YoyoModConfig.
    /// </summary>
    public abstract class ItemLoader : ModItem
    {
        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
    }

    public abstract class ModDrill : ItemLoader
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

    public abstract class ModRing : ItemLoader
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


    public abstract class ModString : ItemLoader
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

    public abstract class ModYoyo : ItemLoader
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
