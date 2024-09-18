using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Accessories.Drills;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Accessories.YoyoBags;
using CombinationsMod.Content.Items.Yoyos;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses.Loot
{
    public class BossBags : GlobalItem
    {
        public override void ModifyItemLoot(Item item, ItemLoot itemLoot)
        {
            switch (item.type)
            {
                case ItemID.SkeletronBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<Catacomb>(), 2));
                    break;

                case ItemID.GolemBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TsurugiDrillCasing>()));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<GolemsteelString>(), 2));
                    break;

                case ItemID.PlanteraBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<TheQueensGambit>(), 3));
                    break;

                case ItemID.KingSlimeBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<SlimyString>(), 2));
                    break;

                case ItemID.FairyQueenBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<EmpressYoyo>(), 2));
                    break;

                case ItemID.WallOfFleshBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<YoyoDrillCasing>()));
                    break;

                case ItemID.MoonLordBossBag:
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<MoonlordBag>(), 3));
                    itemLoot.Add(ItemDropRule.Common(ModContent.ItemType<CelestialDrillCasing>(), 3));
                    break;
            }
        }
    }
}