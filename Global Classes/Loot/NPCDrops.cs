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

namespace CombinationsMod.GlobalClasses.Loot
{

    public class NPCDrops : GlobalNPC
	{
		public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
		{
			if (!(Main.masterMode || Main.expertMode) && (npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism))
			{
				var missingTwinRule = new LeadingConditionRule(new Conditions.MissingTwin());
				missingTwinRule.OnSuccess(ItemDropRule.Common(ItemID.TheEyeOfCthulhu, 2));
				npcLoot.Add(missingTwinRule);

			}

			switch (npc.type)
			{
				case NPCID.Drippler:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ThinMint>(), 5));
					break;

				case NPCID.Ghost:
					npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Smudge>(), 6));
					break;

				case NPCID.Poltergeist or NPCID.Wraith:
                    npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Smudge>(), 6));
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
            }
		}
    }
}