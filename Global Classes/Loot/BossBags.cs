﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.GameContent.ItemDropRules;
using CombinationsMod.Items.Yoyos;
using CombinationsMod.Items.Accessories.Drills;
using CombinationsMod.Items.Accessories.Rings;
using CombinationsMod.Items.Accessories.Strings;

namespace CombinationsMod.GlobalClasses.Loot
{
    public class BossBags : GlobalItem
	{
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot) // Using ModifyItemLoot to change the loot from certain boss bags
        {
            switch (item.type)
            {
                case ItemID.QueenBeeBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheQueensGambit>()));
                    break;

                case ItemID.SkeletronBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Catacomb>()));
                    break;

                case ItemID.GolemBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TsurugiDrillCasing>()));
                    break;

                case ItemID.TwinsBossBag:   
                    itemLoot.Add(ItemDropRule.Common(ItemID.TheEyeOfCthulhu));
                    break;

                case ItemID.CultistBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistYoyo>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<ShadowflameDrillCasing>()));
                    break;

                case ItemID.KingSlimeBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimyString>()));
                    break;
            }
        }
    }
}