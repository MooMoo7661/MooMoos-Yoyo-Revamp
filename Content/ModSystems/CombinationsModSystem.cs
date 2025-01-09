using System.Collections.Generic;
using System.Numerics;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.ModSystems
{
    public partial class CombinationsModSystem : ModSystem
    {
        public static RecipeGroup silverBarRecipeGroup;
        public static RecipeGroup goldBarRecipeGroup;
        public static RecipeGroup copperBarRecipeGroup;
        public static RecipeGroup cobaltBarRecipeGroup;
        public static RecipeGroup adamantiteBarRecipeGroup;
        public static RecipeGroup mythrilBarRecipeGroup;
        public static RecipeGroup yoyoStringGroup;

        public static RecipeGroup ironYoyoGroup;
        public static RecipeGroup cobaltYoyoGroup;
        public static RecipeGroup mythrilYoyoGroup;
        public static RecipeGroup corruptOrCrimsonYoyo;

        public Asset<Texture2D> code2;
        public Asset<Texture2D> code1;
        public Asset<Texture2D> glove;

        // Deals with loading / unloading custom yoyo / glove textures
        public override void PostSetupContent()
        {
            code2 = TextureAssets.Item[ItemID.Code2];
            code1 = TextureAssets.Item[ItemID.Code1];
            glove = TextureAssets.Item[ItemID.YoYoGlove];

            TextureAssets.Item[ItemID.YoYoGlove] = Request<Texture2D>("CombinationsMod/Content/VanillaTexturesOverride/YoYoGlove");

            TextureAssets.Item[ItemID.Code2] = Request<Texture2D>("CombinationsMod/Content/VanillaTexturesOverride/Code2");
            TextureAssets.Item[ItemID.Code1] = Request<Texture2D>("CombinationsMod/Content/VanillaTexturesOverride/Code1");

            AddLocalizedDictionaryEntries();
        }

        public override void OnLocalizationsLoaded()
        {
            AddLocalizedDictionaryEntries();
        }

        public override void Unload()
        {
            TextureAssets.Item[ItemID.YoYoGlove] = glove;
            TextureAssets.Item[ItemID.Code2] = code2;
            TextureAssets.Item[ItemID.Code1] = code1;
        }

        public override void PostAddRecipes()
        {
            foreach (Recipe recipe in Main.recipe)
            {
                if (recipe.createItem.type == ItemID.YoyoBag)
                {
                    recipe.DisableRecipe();
                }
            }
        }

        public override void AddRecipes()
        {
            Recipe.Create(ItemID.Code2)
                .AddIngredient(ItemID.Obsidian, 70)
                .AddRecipeGroup(adamantiteBarRecipeGroup, 10)
                .Register();

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

            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
            {
                yoyoStringGroup = new RecipeGroup(() => "Any Yoyo String", ItemID.WhiteString, ItemID.BlueString, ItemID.BrownString,
                ItemID.CyanString, ItemID.GreenString, ItemID.LimeString, ItemID.OrangeString, ItemID.PinkString, ItemID.PurpleString,
                ItemID.RainbowString, ItemID.RedString, ItemID.SkyBlueString, ItemID.TealString, ItemID.VioletString, ItemID.BlackString, ItemID.YellowString,

                veridianMod.Find<ModItem>("CrimsonString").Type,
                veridianMod.Find<ModItem>("CrossString").Type,
                veridianMod.Find<ModItem>("CursedString").Type,
                veridianMod.Find<ModItem>("FrogString").Type,
                veridianMod.Find<ModItem>("FrostString").Type,
                veridianMod.Find<ModItem>("HoneyString").Type,
                veridianMod.Find<ModItem>("HorseshoeString").Type,
                veridianMod.Find<ModItem>("IchorString").Type,
                veridianMod.Find<ModItem>("LavaString").Type,
                veridianMod.Find<ModItem>("MythString").Type,
                veridianMod.Find<ModItem>("PumpkinString").Type,
                veridianMod.Find<ModItem>("RegenString").Type,
                veridianMod.Find<ModItem>("ShadowString").Type,
                veridianMod.Find<ModItem>("SharktoothString").Type,
                veridianMod.Find<ModItem>("VeilString").Type,
                veridianMod.Find<ModItem>("HellString").Type);
            }
            else
            {
                yoyoStringGroup = new RecipeGroup(() => "Any Yoyo String", ItemID.WhiteString, ItemID.BlueString, ItemID.BrownString,
                ItemID.CyanString, ItemID.GreenString, ItemID.LimeString, ItemID.OrangeString, ItemID.PinkString, ItemID.PurpleString,
                ItemID.RainbowString, ItemID.RedString, ItemID.SkyBlueString, ItemID.TealString, ItemID.VioletString, ItemID.BlackString, ItemID.YellowString);
            }

            RecipeGroup.RegisterGroup("CombinationsMod:YoyoStrings", yoyoStringGroup);

            ironYoyoGroup = new RecipeGroup(() => "Iron or Lead Yoyo", ItemType<IronYoyo>(), ItemType<LeadYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:IronOrLeadYoyo", ironYoyoGroup);

            cobaltYoyoGroup = new RecipeGroup(() => "Cobalt or Palladium Yoyo", ItemType<CobaltYoyo>(), ItemType<PalladiumYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:CobaltOrPalladiumYoyo", cobaltYoyoGroup);

            mythrilYoyoGroup = new RecipeGroup(() => "Mythril or Orichalcum Yoyo", ItemType<MythrilYoyo>(), ItemType<OrichalcumYoyo>());
            RecipeGroup.RegisterGroup("CombinationsMod:MythrilOrOrichalcumYoyo", mythrilYoyoGroup);
        }

        public override void PreSaveAndQuit()
        {
            YoyoModPlayer modPlayer = Main.LocalPlayer.GetModPlayer<YoyoModPlayer>();
            modPlayer.HitCounter = 0;
        }
    }
}