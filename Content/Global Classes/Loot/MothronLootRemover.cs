using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses.Loot
{
    public class MothronLootRemover : GlobalNPC
    {
        public override bool AppliesToEntity(NPC entity, bool lateInstantiation) => entity.type == NPCID.Mothron;
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            foreach (var rule in npcLoot.Get())
            {
                if (rule is LeadingConditionRule downedAllMechBossesRule && downedAllMechBossesRule.condition is Conditions.DownedAllMechBosses)
                {
                    foreach (var chain in downedAllMechBossesRule.ChainedRules)
                    {
                        if (chain.RuleToChain is LeadingConditionRule downedPlanteraRule && downedPlanteraRule.condition is Conditions.DownedPlantera)
                        {
                            downedPlanteraRule.ChainedRules.RemoveAll(chain => chain.RuleToChain is DropBasedOnExpertMode expertDrop && expertDrop.ruleForExpertMode is CommonDropWithRerolls rerollDrop && rerollDrop.itemId == ItemID.TheEyeOfCthulhu);
                        }
                    }
                }
            }
        }
    }
}
