using CombinationsMod.Content.Items.Yoyos;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using static MooMooLib.MooMooLibModsystem;
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

        private readonly string stringFilePath = "CombinationsMod/Content/YoyoStringTextures/";
        private readonly string abilityFilePath = "Mods.CombinationsMod.LocalizedText.Abilities.";
        private Asset<Texture2D> upgradedStringFilePath => Request<Texture2D>(stringFilePath + "UpgradedString");
        private Asset<Texture2D> phantomStringPath => Request<Texture2D>(stringFilePath + "PhantomString");
        private Asset<Texture2D> christmasStringPath => Request<Texture2D>(stringFilePath + "ChristmasString");
        private Asset<Texture2D> pumpkinStringPath => Request<Texture2D>(stringFilePath + "SpookyString");

        public static Dictionary<int, LocalizedAbilityString> yoyoAbilityDictionary = new Dictionary<int, LocalizedAbilityString>();

        #region StringTextures
        public StringTexture boneStringEntry = new();
        public StringTexture upgradedStringEntry = new();
        public StringTexture jungleStringEntry = new();
        public StringTexture tempestStringEntry = new();
        public StringTexture phantomStringEntry = new();
        public StringTexture christmasStringEntry = new();
        public StringTexture pumpkinStringEntry = new();
        public StringTexture terrarianStringEntry = new();
        public StringTexture cultistStringEntry = new();
        public StringTexture blackHoleStringEntry = new();
        #endregion

        #region LocalizedAbilityStrings
        public LocalizedAbilityString LocalizedBlackHole = new();
        public LocalizedAbilityString LocalizedChristmasBulb = new();
        public LocalizedAbilityString LocalizedCode3 = new();
        public LocalizedAbilityString LocalizedConvergence = new();
        public LocalizedAbilityString LocalizedCultistYoyo = new();
        public LocalizedAbilityString LocalizedMambele = new();
        public LocalizedAbilityString LocalizedHardmodeYoyo = new();
        public LocalizedAbilityString LocalizedTempest = new();
        public LocalizedAbilityString LocalizedAbbhor = new();
        public LocalizedAbilityString LocalizedTrueYoyos = new();

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
        #endregion

        #region Colors
        public StringColor GolemString = new();
        public StringColor GreenString = new();
        public StringColor DarkBlueString = new();
        public StringColor LightPinkString = new();
        public StringColor DarkTealString = new();
        public StringColor GrapeString = new();
        public StringColor StardustString = new();
        public StringColor SolarString = new();
        public StringColor VortexString = new();
        public StringColor NebulaString = new();
        #endregion

        public void AddLocalizedDictionaryEntries()
        {
            Mod.Logger.Info("Adding Localized Dictionary Entries for yoyo abilities");

            #region AbilityDictionaryInputs

            LocalizedBlackHole.Register(Language.GetTextValue(abilityFilePath + "BlackHole"), ItemType<BlackHole>());
            LocalizedChristmasBulb.Register(Language.GetTextValue(abilityFilePath + "ChristmasBulb"), ItemType<ChristmasBulb>());
            LocalizedCode3.Register(Language.GetTextValue(abilityFilePath + "Code3"), ItemType<Code3>());
            LocalizedConvergence.Register(Language.GetTextValue(abilityFilePath + "Convergence"), ItemType<Convergance>());
            LocalizedCultistYoyo.Register(Language.GetTextValue(abilityFilePath + "CultistYoyo"), ItemType<CultistYoyo>());
            LocalizedMambele.Register(Language.GetTextValue(abilityFilePath + "Mambele"), ItemType<Mambele>());
            LocalizedHardmodeYoyo.Register(Language.GetTextValue(abilityFilePath + "HardmodeYoyos"), ItemType<MythrilYoyo>());
            yoyoAbilityDictionary.TryAdd(ItemType<OrichalcumYoyo>(), LocalizedHardmodeYoyo);
            LocalizedTempest.Register(Language.GetTextValue(abilityFilePath + "Tempest"), ItemType<TheTempest>());
            LocalizedAbbhor.Register(Language.GetTextValue(abilityFilePath + "Abbhor"), ItemType<TheAbbhor>());
            LocalizedTrueYoyos.Register(Language.GetTextValue(abilityFilePath + "TrueYoyos"), ItemType<TrueAbbhor>());
            yoyoAbilityDictionary.TryAdd(ItemType<TrueCode3>(), LocalizedTrueYoyos);
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
            #endregion
        }

        public void AddDictionaryEntries()
        {
            Mod.Logger.Info("Adding Dictionary Entries for yoyo strings");
            #region StringDictionaryInputs
            upgradedStringEntry.Register(upgradedStringFilePath, ItemType<TrueAbbhor>());
            upgradedStringEntry.Register(upgradedStringFilePath, ItemType<TrueCode3>());

            boneStringEntry.Register(TextureAssets.Chain24, ItemType<Catacomb>());
            jungleStringEntry.Register(TextureAssets.Chain27, ItemID.JungleYoyo);
            tempestStringEntry.Register(TextureAssets.Chain23, ItemType<TheTempest>());
            phantomStringEntry.Register(phantomStringPath, ItemType<Smudge>());
            christmasStringEntry.Register(christmasStringPath, ItemType<ChristmasBulb>());
            pumpkinStringEntry.Register(pumpkinStringPath, ItemType<Mambele>());
            terrarianStringEntry.Register(TextureAssets.Chains[13], ItemID.Terrarian);
            cultistStringEntry.Register(TextureAssets.Chain9, ItemType<CultistYoyo>());
            blackHoleStringEntry.Register(TextureAssets.Chains[16], ItemType<BlackHole>());
            #endregion

            Mod.Logger.Info("Adding Dictionary Entries for yoyo string colors");
            #region Color Entries
            GolemString.Register(new(162, 108, 60), 28);
            GreenString.Register(new(41, 96, 0), 29);
            DarkBlueString.Register(new(0, 37, 106), 30);
            LightPinkString.Register(new(255, 164, 228), 31);
            DarkTealString.Register(new(60, 151, 146), 33);
            GrapeString.Register(new(168, 59, 153), 34);
            StardustString.Register(new(90, 195, 248), 35);
            SolarString.Register(new(255, 180, 56), 36);
            VortexString.Register(new(131, 238, 220), 37);
            NebulaString.Register(new(254, 14, 177), 38);
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
