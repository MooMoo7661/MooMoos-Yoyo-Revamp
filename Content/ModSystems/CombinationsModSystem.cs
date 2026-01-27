using System.Collections.Generic;
using System.Numerics;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Global_Classes;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Accessories.YoyoGloves;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.UI.UpgradeStationUI;
using Humanizer;
using Microsoft.Xna.Framework.Graphics;
using Newtonsoft.Json.Linq;
using ReLogic.Content;
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

        public override void PostWorldGen()
        {
            for (int chestIndex = 0; chestIndex < Main.maxChests; chestIndex++)
            {
                Chest chest = Main.chest[chestIndex];
                if (chest == null)
                {
                    continue;
                }

                if (WorldGen.genRand.NextBool(4))
                    continue;

                Tile chestTile = Main.tile[chest.x, chest.y];

                if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 0 && Main.rand.NextBool(3))
                {
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<LeatherWraps>());
                            break;
                        }
                    }
                }
                else if (chestTile.TileType == TileID.Containers && chestTile.TileFrameX == 1 * 36 && Main.rand.NextBool(2))
                {
                    for (int inventoryIndex = 0; inventoryIndex < Chest.maxItems; inventoryIndex++)
                    {
                        if (chest.item[inventoryIndex].type == ItemID.None)
                        {
                            chest.item[inventoryIndex].SetDefaults(ModContent.ItemType<SpelunkerGlove>());
                            break;  
                        }
                    }
                }
            }
        }

        public override void Load()
        {
            On_Item.GetShimmered += On_Item_GetShimmered;
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

                // scan items in recipe, if any item is a yoyo then add a craft callback
                // craft callback handles returning upgrades to the player, so they are not permanently deleted

                foreach(var item in recipe.requiredItem)
                {
                    if (ItemID.Sets.Yoyo[item.type])
                        AddCallback(recipe);

                    break;
                }
            }
        }

        internal void AddCallback(Recipe recipe)
        {
            recipe.AddOnCraftCallback(delegate (Recipe recipe, Item item, List<Item> ConsumedItems, Item destinationStack)
            {
                foreach (var recipeItem in ConsumedItems)
                {
                    if (!ItemID.Sets.Yoyo[recipeItem.type])
                        continue;

                    foreach (var upgrade in recipeItem.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades)
                    {
                        Main.NewText(upgrade);
                        if (!upgrade.IsAir)
                            Main.LocalPlayer.QuickSpawnItem(null, upgrade);
                    }
                }
                return;
            });
        }

        private void On_Item_GetShimmered(On_Item.orig_GetShimmered orig, Item self)
        {
            if (ItemID.Sets.Yoyo[self.type])
            {
                var Upgrade = self.GetGlobalItem<GlobalYoyoUpgrade>();
                foreach (var value in Upgrade.yoyoUpgrades)
                {
                    Item item = Main.item[Item.NewItem(Item.GetSource_NaturalSpawn(), self.position, value)];
                    item.shimmerWet = true;
                    item.shimmered = true;
                }
            }

            orig(self);
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

            ModContent.GetInstance<UpgradeStationUISystem>().HideMyUI();
        }
    }
}