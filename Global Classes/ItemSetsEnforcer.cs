using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Global_Classes
{
    public class ItemSetsEnforcer : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            if (ModLoader.TryGetMod("VeridianMod", out Mod VeridianMod))
            {
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("CrimsonString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("CrossString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("CursedString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("FrogString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("FrostString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("HellString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("HoneyString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("HorseshoeString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("IchorString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("JungleString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("LavaString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("MythString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("PumpkinString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("RegenString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("ShadowString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("SharktoothString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("VeilString").Type] = true;
                ItemSets.YoyoString[VeridianMod.Find<ModItem>("HellString").Type] = true;
            }
        }
    }
}
