using CombinationsMod.Projectiles.YoyoProjectiles;
using CombinationsMod.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod
{
    /// <summary>
    /// This is to make it so the user can choose whether or not to include every item. Returns `LoadModdedItems` bool from YoyoModConfig.
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

    public abstract class ModRing : ItemLoader
    {
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
        public abstract bool CanBeUnloaded { get; }

        public override bool IsLoadingEnabled(Mod mod)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().LoadModdedAccessories)
                return false;

            if (!CanBeUnloaded)
                return true;

            return ModContent.GetInstance<YoyoModConfig>().LoadModdedItems;
        }
        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            if (!ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
            {
                return true;
            }

            return modded && LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<StringSlot>().Type;
        }
    }

    public abstract class ModYoyo : ItemLoader
    {
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