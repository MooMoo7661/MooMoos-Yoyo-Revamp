using CombinationsMod.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Accessories.Strings;
using CombinationsMod.Items.Yoyos;
using System.Collections.Generic;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using static Terraria.ModLoader.ModContent;
using System.Security.Cryptography.X509Certificates;
using Terraria.WorldBuilding;
using Terraria.GameContent.Generation;
using static Terraria.GameContent.Generation.WorldGenLegacyMethod;

namespace CombinationsMod
{

    public class CombinationsModSystem : ModSystem
    {
        public static RecipeGroup silverBarRecipeGroup; // Initializing new RecipeGroups
        public static RecipeGroup goldBarRecipeGroup;
        public static RecipeGroup copperBarRecipeGroup;
        public static RecipeGroup cobaltBarRecipeGroup;
        public static RecipeGroup adamantiteBarRecipeGroup;
        public static RecipeGroup mythrilBarRecipeGroup;
        public static RecipeGroup eclipseWeaponGroup;
        public static RecipeGroup yoyoStringGroup;

        public static RecipeGroup ironYoyoGroup;
        public static RecipeGroup cobaltYoyoGroup;
        public static RecipeGroup mythrilYoyoGroup;
        public static RecipeGroup corruptOrCrimsonYoyo;

        private readonly string stringFilePath = "CombinationsMod/YoyoStringTextures/";
        private Asset<Texture2D> upgradedStringFilePath => Request<Texture2D>(stringFilePath + "UpgradedString");
        private Asset<Texture2D> phantomStringPath => Request<Texture2D>(stringFilePath + "PhantomString");
        private Asset<Texture2D> christmasStringPath => Request<Texture2D>(stringFilePath + "ChristmasString");
        private Asset<Texture2D> pumpkinStringPath => Request<Texture2D>(stringFilePath + "SpookyString");

        /*
           Creating a dictionary to store specific string textures. This dictionary uses ItemIDs to assign textures to a specific item.
           Custom strings are entered into the dictionary in AddDictionaryEntries(), which is called in PostSetupContent() to allow the use of ModContent.ItemType IDs, since they aren't loaded yet in Load().
           Then, in CombinationsModClass, Main.DrawProj_DrawYoyoString() is detoured to Test(), which sends in the ItemID of the player's held item to the dictionary and retrieves the texture, if there is one.
        */

        public static Dictionary<int, StringTexture> yoyoStringDictionary = new Dictionary<int, StringTexture>();

        public StringTexture boneStringEntry = new StringTexture();
        public StringTexture upgradedStringEntry = new StringTexture();
        public StringTexture jungleStringEntry = new StringTexture();
        public StringTexture tempestStringEntry = new StringTexture();
        public StringTexture phantomStringEntry = new StringTexture();
        public StringTexture christmasStringEntry = new StringTexture();
        public StringTexture pumpkinStringEntry = new StringTexture();
        public StringTexture terrarianStringEntry = new StringTexture();

        public void AddDictionaryEntries()
        {
            upgradedStringEntry.setStringTexture(upgradedStringFilePath); yoyoStringDictionary.TryAdd(ItemType<TrueAbbhor>(), upgradedStringEntry);
            yoyoStringDictionary.TryAdd(ItemType<TrueCode3>(), upgradedStringEntry); yoyoStringDictionary.TryAdd(ItemType<TrueSmudge>(), upgradedStringEntry);

            boneStringEntry.setStringTexture(TextureAssets.Chain24); yoyoStringDictionary.TryAdd(ItemType<Catacomb>(), boneStringEntry);
            jungleStringEntry.setStringTexture(TextureAssets.Chain27); yoyoStringDictionary.TryAdd(ItemID.JungleYoyo, jungleStringEntry);
            tempestStringEntry.setStringTexture(TextureAssets.Chain23); yoyoStringDictionary.TryAdd(ItemType<TheTempest>(), tempestStringEntry);
            phantomStringEntry.setStringTexture(phantomStringPath); yoyoStringDictionary.TryAdd(ItemType<Smudge>(), phantomStringEntry);
            christmasStringEntry.setStringTexture(christmasStringPath); yoyoStringDictionary.TryAdd(ItemType<ChristmasBulb>(), christmasStringEntry);
            pumpkinStringEntry.setStringTexture(pumpkinStringPath); yoyoStringDictionary.TryAdd(ItemType<Mambele>(), pumpkinStringEntry);
            terrarianStringEntry.setStringTexture(TextureAssets.Chains[13]); yoyoStringDictionary.TryAdd(ItemID.Terrarian, terrarianStringEntry);
        }

        public Asset<Texture2D> GetStringFromDictionary(int itemID)
        {
            if (yoyoStringDictionary.TryGetValue(itemID, out StringTexture instance))
            {
                return instance.getStringTexture();
            }

            return TextureAssets.FishingLine; // Defaults to this if the entry is not found
        }

        
        public override void PostSetupContent()
        {
            TextureAssets.Item[ItemID.YoYoGlove] = ModContent.Request<Texture2D>("CombinationsMod/VanillaTexturesOverride/YoYoGlove");
            TextureAssets.Item[ItemID.Code2] = ModContent.Request<Texture2D>("CombinationsMod/VanillaTexturesOverride/Code2");
            TextureAssets.Item[ItemID.Code1] = ModContent.Request<Texture2D>("CombinationsMod/VanillaTexturesOverride/Code1");

            AddDictionaryEntries();
        }

        public override void AddRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.Code2);
            recipe.AddIngredient(ItemID.Obsidian, 70);
            recipe.AddRecipeGroup(adamantiteBarRecipeGroup, 20);
            recipe.Register();

            Recipe recipe2 = Recipe.Create(ItemID.GiantHarpyFeather);
            recipe2.AddIngredient(ItemID.Feather, 50);
            recipe2.AddIngredient(ItemID.SoulofFlight, 20);
            recipe2.Register();

            Recipe.Create(ItemID.Cascade)
                .AddIngredient(ItemID.HellstoneBar, 15)
                .AddTile(TileID.Hellforge)
                .Register();
        }

        public override void AddRecipeGroups()
        {
            silverBarRecipeGroup = new RecipeGroup(() => "Silver or Tungsten", ItemID.TungstenBar, ItemID.SilverBar);
            RecipeGroup.RegisterGroup("CombinationsMod:SilverOrTungsten", silverBarRecipeGroup);

            goldBarRecipeGroup = new RecipeGroup(() => "Gold or Platinum", ItemID.GoldBar, ItemID.PlatinumBar);
            RecipeGroup.RegisterGroup("CombinationsMod:GoldOrPlatinum", goldBarRecipeGroup);

            copperBarRecipeGroup = new RecipeGroup(() => "Copper or Tin", ItemID.CopperBar, ItemID.TinBar);
            RecipeGroup.RegisterGroup("CombinationsMod:CopperOrTin", copperBarRecipeGroup);

            cobaltBarRecipeGroup = new RecipeGroup(() => "Cobalt or Palladium", ItemID.CobaltBar, ItemID.PalladiumBar);
            RecipeGroup.RegisterGroup("CombinationsMod:CobaltOrPalladium", cobaltBarRecipeGroup);

            adamantiteBarRecipeGroup = new RecipeGroup(() => "Adamantite or Titanium", ItemID.AdamantiteBar, ItemID.TitaniumBar);   
            RecipeGroup.RegisterGroup("CombinationsMod:AdamantiteOrTitanium", adamantiteBarRecipeGroup);

            mythrilBarRecipeGroup = new RecipeGroup(() => "Mythril or Orichalcum", ItemID.MythrilBar, ItemID.OrichalcumBar);
            RecipeGroup.RegisterGroup("CombinationsMod:MythrilOrOrichalcum", mythrilBarRecipeGroup);

            eclipseWeaponGroup = new RecipeGroup(() => "Any Solar Eclipse Weapon", ItemID.DeathSickle, ItemID.BrokenHeroSword,
                ItemID.ButchersChainsaw, ItemID.DeadlySphereStaff, ItemID.ToxicFlask, ItemID.NailGun, ItemID.PsychoKnife);
            RecipeGroup.RegisterGroup("CombinationsMod:SolarEclipseWeapons", eclipseWeaponGroup);

            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
            {
                yoyoStringGroup = new RecipeGroup(() => "Any Yoyo String", ItemID.WhiteString, ItemID.BlueString, ItemID.BrownString,
                ItemID.CyanString, ItemID.GreenString, ItemID.LimeString, ItemID.OrangeString, ItemID.PinkString, ItemID.PurpleString, ModContent.ItemType<GolemsteelString>(),
                ItemID.RainbowString, ItemID.RedString, ItemID.SkyBlueString, ItemID.TealString, ItemID.VioletString, ItemID.BlackString, ItemID.YellowString,

                veridianMod.Find<ModItem>("CrimsonString").Type, veridianMod.Find<ModItem>("CrossString").Type,
                veridianMod.Find<ModItem>("CursedString").Type, veridianMod.Find<ModItem>("FrogString").Type, veridianMod.Find<ModItem>("FrostString").Type,
                veridianMod.Find<ModItem>("HoneyString").Type, veridianMod.Find<ModItem>("HorseshoeString").Type, veridianMod.Find<ModItem>("IchorString").Type,
                veridianMod.Find<ModItem>("LavaString").Type, veridianMod.Find<ModItem>("MythString").Type, veridianMod.Find<ModItem>("PumpkinString").Type,
                veridianMod.Find<ModItem>("RegenString").Type, veridianMod.Find<ModItem>("ShadowString").Type, veridianMod.Find<ModItem>("SharktoothString").Type,
                veridianMod.Find<ModItem>("VeilString").Type, veridianMod.Find<ModItem>("HellString").Type);
            }
            else
            {
                yoyoStringGroup = new RecipeGroup(() => "Any Yoyo String", ItemID.WhiteString, ItemID.BlueString, ItemID.BrownString,
                ItemID.CyanString, ItemID.GreenString, ItemID.LimeString, ItemID.OrangeString, ItemID.PinkString, ItemID.PurpleString, ModContent.ItemType<GolemsteelString>(),
                ItemID.RainbowString, ItemID.RedString, ItemID.SkyBlueString, ItemID.TealString, ItemID.VioletString, ItemID.BlackString, ItemID.YellowString);
            }

            RecipeGroup.RegisterGroup("CombinationsMod:YoyoStrings", yoyoStringGroup);

            ironYoyoGroup = new RecipeGroup(() => "Iron or Lead Yoyo", ModContent.ItemType<IronYoyo>(), ModContent.ItemType<LeadYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:IronOrLeadYoyo", ironYoyoGroup);

            cobaltYoyoGroup = new RecipeGroup(() => "Cobalt or Palladium Yoyo", ModContent.ItemType<CobaltYoyo>(), ModContent.ItemType<PalladiumYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:CobaltOrPalladiumYoyo", cobaltYoyoGroup);

            mythrilYoyoGroup = new RecipeGroup(() => "Mythril or Orichalcum Yoyo", ModContent.ItemType<MythrilYoyo>(), ModContent.ItemType<OrichalcumYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:MythrilOrOrichalcumYoyo", mythrilYoyoGroup);
        }

        public override void PreSaveAndQuit()
        {
            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoSpacers)
            {
                for (int i = 0; i < ProjectileLoader.ProjectileCount; i++) // Cycling through every projectile
                {
                    if (ContentSamples.ProjectilesByType[i].aiStyle == 99 && !ContentSamples.ProjectilesByType[i].counterweight) // If it is a yoyo
                    {
                        ProjectileID.Sets.YoyosTopSpeed[i] -= 1.8f;

                        // Subtracting the values added by the Yoyo Bearing on save and exit. This is to prevent building up of stats
                    }
                }
                modPlayer.yoyoSpacers = false;
            }

            modPlayer.HitCounter = 0;
        }
    }

    public class StringTexture
    {
        public Asset<Texture2D> texture;

        public void setStringTexture(Asset<Texture2D> asttex)
        {
            this.texture = asttex;
        }

        public Asset<Texture2D> getStringTexture()
        {
            return this.texture;
        }
    }
}