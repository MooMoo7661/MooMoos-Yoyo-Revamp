using CombinationsMod.Items.Yoyos;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static MooMooLib.MooMooLibModsystem;

namespace CombinationsMod
{
    public partial class CombinationsModSystem : ModSystem
    {
        /*
          Ability Dictionary -
          Creating a dictionary to store specific localized tooltips for specific yoyos. This dictionary also uses ItemIDs to assign localized text.
          Same method for assigning and retrieving text, however the actual getting of the text is done in the mod's GlobalItemModifications class.
       */

        private readonly string stringFilePath = "CombinationsMod/YoyoStringTextures/";
        private readonly string abilityFilePath = "Mods.CombinationsMod.LocalizedText.Abilities.";
        private Asset<Texture2D> upgradedStringFilePath => Request<Texture2D>(stringFilePath + "UpgradedString");
        private Asset<Texture2D> phantomStringPath => Request<Texture2D>(stringFilePath + "PhantomString");
        private Asset<Texture2D> christmasStringPath => Request<Texture2D>(stringFilePath + "ChristmasString");
        private Asset<Texture2D> pumpkinStringPath => Request<Texture2D>(stringFilePath + "SpookyString");

        public static Dictionary<int, LocalizedAbilityString> yoyoAbilityDictionary = new Dictionary<int, LocalizedAbilityString>();

        #region StringTextures
        public StringTexture boneStringEntry = new StringTexture();
        public StringTexture upgradedStringEntry = new StringTexture();
        public StringTexture jungleStringEntry = new StringTexture();
        public StringTexture tempestStringEntry = new StringTexture();
        public StringTexture phantomStringEntry = new StringTexture();
        public StringTexture christmasStringEntry = new StringTexture();
        public StringTexture pumpkinStringEntry = new StringTexture();
        public StringTexture terrarianStringEntry = new StringTexture();
        public StringTexture cultistStringEntry = new StringTexture();
        public StringTexture blackHoleStringEntry = new StringTexture();
        #endregion

        #region LocalizedAbilityStrings
        public LocalizedAbilityString LocalizedBlackHole = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedChristmasBulb = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCode3 = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedConvergence = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCultistYoyo = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedMambele = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedHardmodeYoyo = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedTempest = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedAbbhor = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedTrueYoyos = new LocalizedAbilityString();

        public LocalizedAbilityString LocalizedCascade = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedValor = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedEvilYoyos = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedRally = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCode1 = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedFormatC = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedHelFire = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedAmarok = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedGradient = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedEOCYoyo = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCode2 = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedYelets = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCrowyo = new LocalizedAbilityString();
        public LocalizedAbilityString LocalizedCatacomb = new LocalizedAbilityString();
        #endregion

        #region Colors
        public StringColor GolemString = new StringColor();
        public StringColor GreenString = new StringColor();
        public StringColor DarkBlueString = new StringColor();
        public StringColor LightPinkString = new StringColor();
        public StringColor DarkTealString = new StringColor();
        public StringColor GrapeString = new StringColor();
        public StringColor StardustString = new StringColor();
        public StringColor SolarString = new StringColor();
        public StringColor VortexString = new StringColor();
        public StringColor NebulaString = new StringColor();
        #endregion

        public void AddLocalizedDictionaryEntries()
        {
            #region AbilityDictionaryInputs
            LocalizedBlackHole.SetStringValue(Language.GetTextValue(abilityFilePath + "BlackHole")); yoyoAbilityDictionary.TryAdd(ItemType<BlackHole>(), LocalizedBlackHole);

            LocalizedChristmasBulb.SetStringValue(Language.GetTextValue(abilityFilePath + "ChristmasBulb")); yoyoAbilityDictionary.TryAdd(ItemType<ChristmasBulb>(), LocalizedChristmasBulb);

            LocalizedCode3.SetStringValue(Language.GetTextValue(abilityFilePath + "Code3")); yoyoAbilityDictionary.TryAdd(ItemType<Code3>(), LocalizedCode3);

            LocalizedConvergence.SetStringValue(Language.GetTextValue(abilityFilePath + "Convergence")); yoyoAbilityDictionary.TryAdd(ItemType<Convergance>(), LocalizedConvergence);

            LocalizedCultistYoyo.SetStringValue(Language.GetTextValue(abilityFilePath + "CultistYoyo")); yoyoAbilityDictionary.TryAdd(ItemType<CultistYoyo>(), LocalizedCultistYoyo);
            LocalizedMambele.SetStringValue(Language.GetTextValue(abilityFilePath + "Mambele")); yoyoAbilityDictionary.TryAdd(ItemType<Mambele>(), LocalizedMambele);
            LocalizedHardmodeYoyo.SetStringValue(Language.GetTextValue(abilityFilePath + "HardmodeYoyos")); yoyoAbilityDictionary.TryAdd(ItemType<MythrilYoyo>(), LocalizedHardmodeYoyo); yoyoAbilityDictionary.TryAdd(ItemType<OrichalcumYoyo>(), LocalizedHardmodeYoyo);
            LocalizedTempest.SetStringValue(Language.GetTextValue(abilityFilePath + "Tempest")); yoyoAbilityDictionary.TryAdd(ItemType<TheTempest>(), LocalizedTempest);
            LocalizedAbbhor.SetStringValue(Language.GetTextValue(abilityFilePath + "Abbhor")); yoyoAbilityDictionary.TryAdd(ItemType<TheAbbhor>(), LocalizedAbbhor);
            LocalizedTrueYoyos.SetStringValue(Language.GetTextValue(abilityFilePath + "TrueYoyos")); yoyoAbilityDictionary.TryAdd(ItemType<TrueAbbhor>(), LocalizedTrueYoyos); yoyoAbilityDictionary.TryAdd(ItemType<TrueCode3>(), LocalizedTrueYoyos); yoyoAbilityDictionary.TryAdd(ItemType<TrueSmudge>(), LocalizedTrueYoyos);
            LocalizedCascade.SetStringValue(Language.GetTextValue(abilityFilePath + "Cascade")); yoyoAbilityDictionary.TryAdd(ItemID.Cascade, LocalizedCascade);
            LocalizedValor.SetStringValue(Language.GetTextValue(abilityFilePath + "Valor")); yoyoAbilityDictionary.TryAdd(ItemID.Valor, LocalizedValor);
            LocalizedEvilYoyos.SetStringValue(Language.GetTextValue(abilityFilePath + "EvilYoyos")); yoyoAbilityDictionary.TryAdd(ItemID.CrimsonYoyo, LocalizedEvilYoyos); yoyoAbilityDictionary.TryAdd(ItemID.CorruptYoyo, LocalizedEvilYoyos);
            LocalizedRally.SetStringValue(Language.GetTextValue(abilityFilePath + "Rally")); yoyoAbilityDictionary.TryAdd(ItemID.Rally, LocalizedRally);
            LocalizedCode1.SetStringValue(Language.GetTextValue(abilityFilePath + "Code1")); yoyoAbilityDictionary.TryAdd(ItemID.Code1, LocalizedCode1);
            LocalizedFormatC.SetStringValue(Language.GetTextValue(abilityFilePath + "FormatC")); yoyoAbilityDictionary.TryAdd(ItemID.FormatC, LocalizedFormatC);
            LocalizedHelFire.SetStringValue(Language.GetTextValue(abilityFilePath + "HelFire")); yoyoAbilityDictionary.TryAdd(ItemID.HelFire, LocalizedHelFire);
            LocalizedAmarok.SetStringValue(Language.GetTextValue(abilityFilePath + "Amarok")); yoyoAbilityDictionary.TryAdd(ItemID.Amarok, LocalizedAmarok);
            LocalizedGradient.SetStringValue(Language.GetTextValue(abilityFilePath + "Gradient")); yoyoAbilityDictionary.TryAdd(ItemID.Gradient, LocalizedGradient);
            LocalizedEOCYoyo.SetStringValue(Language.GetTextValue(abilityFilePath + "EOCYoyo")); yoyoAbilityDictionary.TryAdd(ItemID.TheEyeOfCthulhu, LocalizedEOCYoyo);
            LocalizedCode2.SetStringValue(Language.GetTextValue(abilityFilePath + "Code2")); yoyoAbilityDictionary.TryAdd(ItemID.Code2, LocalizedCode2);
            LocalizedYelets.SetStringValue(Language.GetTextValue(abilityFilePath + "Yelets")); yoyoAbilityDictionary.TryAdd(ItemID.Yelets, LocalizedYelets);
            LocalizedCrowyo.SetStringValue(Language.GetTextValue(abilityFilePath + "Crowyo")); yoyoAbilityDictionary.TryAdd(ItemType<TheCrowyo>(), LocalizedCrowyo);
            LocalizedCatacomb.SetStringValue(Language.GetTextValue(abilityFilePath + "Catacomb")); yoyoAbilityDictionary.TryAdd(ItemType<Catacomb>(), LocalizedCatacomb);
            #endregion
        }

        public void AddDictionaryEntries()
        {
            #region StringDictionaryInputs
            upgradedStringEntry.setStringTexture(upgradedStringFilePath); yoyoStringDictionary.TryAdd(ItemType<TrueAbbhor>(), upgradedStringEntry);
            yoyoStringDictionary.TryAdd(ItemType<TrueCode3>(), upgradedStringEntry); yoyoStringDictionary.TryAdd(ItemType<TrueSmudge>(), upgradedStringEntry);

            boneStringEntry.setStringTexture(TextureAssets.Chain24); yoyoStringDictionary.TryAdd(ItemType<Catacomb>(), boneStringEntry);
            jungleStringEntry.setStringTexture(TextureAssets.Chain27); yoyoStringDictionary.TryAdd(ItemID.JungleYoyo, jungleStringEntry);
            tempestStringEntry.setStringTexture(TextureAssets.Chain23); yoyoStringDictionary.TryAdd(ItemType<TheTempest>(), tempestStringEntry);
            phantomStringEntry.setStringTexture(phantomStringPath); yoyoStringDictionary.TryAdd(ItemType<Smudge>(), phantomStringEntry);
            christmasStringEntry.setStringTexture(christmasStringPath); yoyoStringDictionary.TryAdd(ItemType<ChristmasBulb>(), christmasStringEntry);
            pumpkinStringEntry.setStringTexture(pumpkinStringPath); yoyoStringDictionary.TryAdd(ItemType<Mambele>(), pumpkinStringEntry);
            terrarianStringEntry.setStringTexture(TextureAssets.Chains[13]); yoyoStringDictionary.TryAdd(ItemID.Terrarian, terrarianStringEntry);
            cultistStringEntry.setStringTexture(TextureAssets.Chain9); yoyoStringDictionary.TryAdd(ItemType<CultistYoyo>(), cultistStringEntry);
            blackHoleStringEntry.setStringTexture(TextureAssets.Chains[16]); yoyoStringDictionary.TryAdd(ItemType<BlackHole>(), blackHoleStringEntry);
            #endregion

            #region Color Entries
            GolemString.setStringColor(new(162, 108, 60));  yoyoStringColorDictionary.TryAdd(28, GolemString);
            GreenString.setStringColor(new(41, 96, 0)); yoyoStringColorDictionary.TryAdd(29, GreenString);
            DarkBlueString.setStringColor(new(0, 37, 106)); yoyoStringColorDictionary.TryAdd(30, DarkBlueString);
            LightPinkString.setStringColor(new(255, 164, 228)); yoyoStringColorDictionary.TryAdd(31, LightPinkString);
            DarkTealString.setStringColor(new(60, 151, 146)); yoyoStringColorDictionary.TryAdd(33, DarkTealString);
            GrapeString.setStringColor(new(168, 59, 153)); yoyoStringColorDictionary.TryAdd(34, GrapeString);
            StardustString.setStringColor(new(90, 195, 248)); yoyoStringColorDictionary.TryAdd(35, StardustString);
            SolarString.setStringColor(new(255, 180, 56)); yoyoStringColorDictionary.TryAdd(36, SolarString);
            VortexString.setStringColor(new(131, 238, 220)); yoyoStringColorDictionary.TryAdd(37, VortexString);
            NebulaString.setStringColor(new(254, 14, 177)); yoyoStringColorDictionary.TryAdd(38, NebulaString);
            #endregion
        }

        public string GetLocalizedStringFromDictionary(int itemId)
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
