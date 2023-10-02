using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;
using CombinationsMod.Items.Accessories.InfoAccessories;
using CombinationsMod.Items.Yoyos;
using CombinationsMod.Items.Souls;
using CombinationsMod.Drills;
using CombinationsMod.Items.Accessories.Drills;
using Steamworks;
using CombinationsMod.Items.Misc;
using CombinationsMod.Items.Accessories.Strings;
using CombinationsMod.Items.Accessories.YoyoBags;

namespace CombinationsMod.GlobalClasses.Loot
{

    public class NPCDrops : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (!(Main.masterMode || Main.expertMode) && (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism))
			{
				if (ModContent.GetInstance<YoyoModConfig>().EOCYoyoProgressionMovement)
				{
					var missingTwinRule = new LeadingConditionRule(new Conditions.MissingTwin());
					missingTwinRule.OnSuccess(ItemDropRule.Common(ItemID.TheEyeOfCthulhu, 2));
					npcLoot.Add(missingTwinRule);
				}
			}

			switch (npc.type)
			{
				case NPCID.Drippler:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThinMint>(), 8));
					break;

				case NPCID.Ghost:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Smudge>(), 9));
					break;

				case NPCID.Poltergeist or NPCID.Wraith:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Smudge>(), 11));
					break;

                case NPCID.HeadlessHorseman or NPCID.MourningWood or NPCID.Pumpking:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Mambele>(), 13));
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HorsemansDrillCasing>(), 13));
					break;

				case NPCID.Reaper or NPCID.Eyezor or NPCID.Frankenstein or NPCID.SwampThing or NPCID.Vampire or
					 NPCID.CreatureFromTheDeep or NPCID.Fritz or NPCID.ThePossessed or NPCID.Mothron or NPCID.MothronSpawn or
					 NPCID.Butcher or NPCID.DeadlySphere or NPCID.DrManFly or NPCID.Nailhead or NPCID.Psycho:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SoulOfEclipse>(), 5));
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroRing>(), 120));
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<BrokenHeroYoyo>(), 120));
					break;

				case NPCID.Everscream or NPCID.SantaNK1 or NPCID.IceQueen:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TreeClippersDrillCasing>(), 20));
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChristmasBulb>(), 20));
					break;

				case NPCID.IceGolem:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostbiteString>(), 2));
					break;

				case NPCID.IceMimic:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<FrostbiteString>()));
                    break;

				case NPCID.QueenBee:
					LeadingConditionRule notExpertRule = new LeadingConditionRule(new Conditions.NotExpert());
					notExpertRule.OnSuccess(ItemDropRule.Common(ModContent.ItemType<TheQueensGambit>()));
					npcLoot.Add(notExpertRule);
					break;

				case NPCID.Skeleton:
                    LeadingConditionRule notExpertRule2 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule2.OnSuccess(ItemDropRule.Common(ModContent.ItemType<Catacomb>()));
                    npcLoot.Add(notExpertRule2);
                    break;

				case NPCID.Golem:
                    LeadingConditionRule notExpertRule3 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule3.OnSuccess(ItemDropRule.Common(ModContent.ItemType<GolemsteelString>()));
                    notExpertRule3.OnSuccess(ItemDropRule.Common(ModContent.ItemType<TsurugiDrillCasing>()));
                    npcLoot.Add(notExpertRule3);
                    break;

				case NPCID.CultistBoss:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<CultistYoyo>()));
                    break;

				case NPCID.KingSlime:
                    LeadingConditionRule notExpertRule5 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule5.OnSuccess(ItemDropRule.Common(ModContent.ItemType<SlimyString>()));
                    npcLoot.Add(notExpertRule5);
					break;

				case NPCID.HallowBoss:
                    LeadingConditionRule notExpertRule6 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule6.OnSuccess(ItemDropRule.Common(ModContent.ItemType<EmpressYoyo>()));
                    npcLoot.Add(notExpertRule6);
					break;

				case NPCID.MartianSaucer:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AdvancedYoyoBag>(), 3));
					break;

				case NPCID.WallofFlesh:
                    LeadingConditionRule notExpertRule7 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule7.OnSuccess(ItemDropRule.Common(ModContent.ItemType<YoyoDrillCasing>()));
                    npcLoot.Add(notExpertRule7);
                    break;

				case NPCID.MoonLordCore:
                    LeadingConditionRule notExpertRule8 = new LeadingConditionRule(new Conditions.NotExpert());
                    notExpertRule8.OnSuccess(ItemDropRule.Common(ModContent.ItemType<MoonlordBag>(), 3));
                    npcLoot.Add(notExpertRule8);
					break;
            }
		}
    }
}