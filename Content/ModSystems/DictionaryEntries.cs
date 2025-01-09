using CombinationsMod.Content.Items.Yoyos;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using static Terraria.ModLoader.ModContent;
using static CombinationsMod.Content.Utility.Extensions;

namespace CombinationsMod.Content.ModSystems
{
    public partial class CombinationsModSystem : ModSystem
    {
        /*
          Ability Dictionary -
          Creating a dictionary to store specific localized tooltips for specific yoyos. This dictionary also uses ItemIDs to assign localized text.
          Same method for assigning and retrieving text, however the actual getting of the text is done in the mod's GlobalItemModifications class.
       */

        private readonly string abilityFilePath = "Mods.CombinationsMod.LocalizedText.Abilities.";

        public static Dictionary<int, LocalizedAbilityString> yoyoAbilityDictionary = new Dictionary<int, LocalizedAbilityString>();

        #region LocalizedAbilityStrings
        public LocalizedAbilityString LocalizedBlackHole = new();
        public LocalizedAbilityString LocalizedChristmasBulb = new();
        public LocalizedAbilityString LocalizedConvergence = new();
        public LocalizedAbilityString LocalizedCultistYoyo = new();
        public LocalizedAbilityString LocalizedMambele = new();
        public LocalizedAbilityString LocalizedHardmodeYoyo = new();
        public LocalizedAbilityString LocalizedTempest = new();
        public LocalizedAbilityString LocalizedAbbhor = new();
        public LocalizedAbilityString LocalizedTrueYoyos = new();
        public LocalizedAbilityString LocalizedCobaltYoyo = new();

        public LocalizedAbilityString LocalizedCascade = new();
        public LocalizedAbilityString LocalizedValor = new();
        public LocalizedAbilityString LocalizedEvilYoyos = new();
        public LocalizedAbilityString LocalizedRally = new();
        public LocalizedAbilityString LocalizedCode1 = new();
        public LocalizedAbilityString LocalizedFormatC = new();
        public LocalizedAbilityString LocalizedHelFire = new();
        public LocalizedAbilityString LocalizedAmarok = new();
        public LocalizedAbilityString LocalizedGradient = new();
        public LocalizedAbilityString LocalizedEOCYoyo = new();
        public LocalizedAbilityString LocalizedCode2 = new();
        public LocalizedAbilityString LocalizedYelets = new();
        public LocalizedAbilityString LocalizedCrowyo = new();
        public LocalizedAbilityString LocalizedCatacomb = new();
        public LocalizedAbilityString LocalizedAmazon = new();
        public LocalizedAbilityString LocalizedChik = new();
        public LocalizedAbilityString LocalizedRedsYoyo = new();
        public LocalizedAbilityString LocalizedValkyrie = new();
        #endregion

        public void AddLocalizedDictionaryEntries()
        {
            Mod.Logger.Info("Adding Localized Dictionary Entries for yoyo abilities");

            #region AbilityDictionaryInputs

            LocalizedBlackHole.Register(Language.GetTextValue(abilityFilePath + "BlackHole"), ItemType<BlackHole>());
            LocalizedChristmasBulb.Register(Language.GetTextValue(abilityFilePath + "ChristmasBulb"), ItemType<HolidayDelight>());
            LocalizedConvergence.Register(Language.GetTextValue(abilityFilePath + "Convergence"), ItemType<Convergence>());
            LocalizedCultistYoyo.Register(Language.GetTextValue(abilityFilePath + "CultistYoyo"), ItemType<CultistYoyo>());
            LocalizedMambele.Register(Language.GetTextValue(abilityFilePath + "Mambele"), ItemType<PumpkinPatcher>());
            LocalizedHardmodeYoyo.Register(Language.GetTextValue(abilityFilePath + "HardmodeYoyos"), ItemType<MythrilYoyo>());
            yoyoAbilityDictionary.TryAdd(ItemType<OrichalcumYoyo>(), LocalizedHardmodeYoyo);
            LocalizedTempest.Register(Language.GetTextValue(abilityFilePath + "Tempest"), ItemType<TheTempest>());
            LocalizedAbbhor.Register(Language.GetTextValue(abilityFilePath + "Abbhor"), ItemType<TheAbbhor>());
            LocalizedTrueYoyos.Register(Language.GetTextValue(abilityFilePath + "TrueYoyos"), ItemType<TrueAbbhor>());
            LocalizedCascade.Register(Language.GetTextValue(abilityFilePath + "Cascade"), ItemID.Cascade);
            LocalizedValor.Register(Language.GetTextValue(abilityFilePath + "Valor"), ItemID.Valor);
            LocalizedEvilYoyos.Register(Language.GetTextValue(abilityFilePath + "EvilYoyos"), ItemID.CrimsonYoyo);
            yoyoAbilityDictionary.TryAdd(ItemID.CorruptYoyo, LocalizedEvilYoyos);
            LocalizedRally.Register(Language.GetTextValue(abilityFilePath + "Rally"), ItemID.Rally);
            LocalizedCode1.Register(Language.GetTextValue(abilityFilePath + "Code1"), ItemID.Code1);
            LocalizedFormatC.Register(Language.GetTextValue(abilityFilePath + "FormatC"), ItemID.FormatC);
            LocalizedHelFire.Register(Language.GetTextValue(abilityFilePath + "HelFire"), ItemID.HelFire);
            LocalizedAmarok.Register(Language.GetTextValue(abilityFilePath + "Amarok"), ItemID.Amarok);
            LocalizedGradient.Register(Language.GetTextValue(abilityFilePath + "Gradient"), ItemID.Gradient);
            LocalizedEOCYoyo.Register(Language.GetTextValue(abilityFilePath + "EOCYoyo"), ItemID.TheEyeOfCthulhu);
            LocalizedCode2.Register(Language.GetTextValue(abilityFilePath + "Code2"), ItemID.Code2);
            LocalizedYelets.Register(Language.GetTextValue(abilityFilePath + "Yelets"), ItemID.Yelets);
            LocalizedCrowyo.Register(Language.GetTextValue(abilityFilePath + "Crowyo"), ItemType<TheCrowyo>());
            LocalizedCatacomb.Register(Language.GetTextValue(abilityFilePath + "Catacomb"), ItemType<Catacomb>());
            LocalizedAmazon.Register(Language.GetTextValue(abilityFilePath + "Amazon"), ItemID.JungleYoyo);
            LocalizedChik.Register(Language.GetTextValue(abilityFilePath + "Chik"), ItemID.Chik);
            LocalizedRedsYoyo.Register(Language.GetTextValue(abilityFilePath + "RedsYoyo"), ItemID.RedsYoyo);
            LocalizedValkyrie.Register(Language.GetTextValue(abilityFilePath + "RedsYoyo"), ItemID.ValkyrieYoyo);
            LocalizedCobaltYoyo.Register(Language.GetTextValue(abilityFilePath + "CobaltYoyo"), ItemType<CobaltYoyo>());
            #endregion
        }

        public static string GetLocalizedStringFromDictionary(int itemId)
        {
            if (yoyoAbilityDictionary.TryGetValue(itemId, out LocalizedAbilityString localizedString))
            {
                return localizedString.GetStringValue();
            }
            return null;
        }

        public class LocalizedAbilityString
        {
            public string LocalizedTooltip;

            public void SetStringValue(string value)
            {
                LocalizedTooltip = value;
            }

            public string GetStringValue()
            {
                return LocalizedTooltip;
            }
        }
    }
}
