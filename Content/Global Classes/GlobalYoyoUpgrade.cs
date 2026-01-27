using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Items.Accessories.Drills;
using CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Axles;
using CombinationsMod.Content.Items.Accessories.YoyoUpgrades.Bearings;
using CombinationsMod.Content.Items.Bars;
using CombinationsMod.Content.Items.Yoyos;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace CombinationsMod.Content.Global_Classes
{
    public class GlobalYoyoUpgrade : GlobalItem
    {
        public override bool AppliesToEntity(Item entity, bool lateInstantiation) => ItemID.Sets.Yoyo[entity.type];
        public override bool InstancePerEntity => true;
        bool BeenGivenAxleAndBearing = false;

        /// <summary>
        /// [0] - cores
        /// [1] - axles
        /// [2] - bearing
        /// [3] - rgb
        /// </summary>
        public List<Item> yoyoUpgrades = new List<Item>
        {
            new Item(ItemID.None),
            new Item(ItemID.None),
            new Item(ItemID.None),
            new Item(ItemID.None),
        };

        public bool HasAxle(Item item)
        {
            if (!ItemID.Sets.Yoyo[item.type])
                return false;

            foreach(var val in item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades)
            {
                if (ItemSets.YoyoAxle[val.type])
                    return true;
            }

            return false;
        }

        public bool HasBearing(Item item)
        {
            if (!ItemID.Sets.Yoyo[item.type])
                return false;

            foreach (var val in item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades)
            {
                if (ItemSets.YoyoBearing[val.type])
                    return true;
            }

            return false;
        }

        public override void SetDefaults(Item item)
        {
            BeenGivenAxleAndBearing = false;
            item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[1] = new Item((WorldGen.SavedOreTiers.Iron == TileID.Iron) ? ModContent.ItemType<IronAxle>() : ModContent.ItemType<LeadAxle>());
            item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[2] = new Item((WorldGen.SavedOreTiers.Iron == TileID.Iron) ? ModContent.ItemType<IronBearing>() : ModContent.ItemType<LeadBearing>());
            BeenGivenAxleAndBearing = true;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (!BeenGivenAxleAndBearing)
            {
                item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[1] = new Item((WorldGen.SavedOreTiers.Iron == TileID.Iron) ? ModContent.ItemType<IronAxle>() : ModContent.ItemType<LeadAxle>());
                item.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades[2] = new Item((WorldGen.SavedOreTiers.Iron == TileID.Iron) ? ModContent.ItemType<IronBearing>() : ModContent.ItemType<LeadBearing>());
                BeenGivenAxleAndBearing = true;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (!HasAxle(item))
            {
                AdvancedPopupRequest request = new()
                {
                    Text = "Missing axle!",
                    Color = Color.Red,
                    Velocity = new(0, -2f),
                    DurationInFrames = 120
                };
                PopupText.NewText(request, player.Top);
                return false;
            }

            return true;
        }

        public override void SaveData(Item item, TagCompound tag)
        {
            tag["YoyoUpgrades"] = yoyoUpgrades;
            tag["AxleAndBearing"] = BeenGivenAxleAndBearing;
        }

        public override void LoadData(Item item, TagCompound tag)
        {
            if(tag.TryGet<List<Item>>("YoyoUpgrades", out var upgrades))
            {
                yoyoUpgrades = upgrades;
            }

            if(tag.TryGet<bool>("AxleAndBearing", out bool value))
            {
                BeenGivenAxleAndBearing = value;
            }
        }

        public override GlobalItem Clone(Item item, Item itemClone)
        {
            GlobalYoyoUpgrade clone = (GlobalYoyoUpgrade)base.Clone(item, itemClone);
            clone.yoyoUpgrades = yoyoUpgrades;
            for (int i = 0; i < yoyoUpgrades.Count; i++)
            {
                clone.yoyoUpgrades[i] = yoyoUpgrades[i].Clone();
                clone.BeenGivenAxleAndBearing = BeenGivenAxleAndBearing;
            }
            return clone;
        }
    }
}
