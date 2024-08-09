using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.Items.Accessories.Drills
{

    public class ExcavatorCasing : ModDrill
    {
        public override bool CanBeUnloaded => true;
        public override int DrillProjectile => ModContent.ProjectileType<Excavator>();

        public override void SetDefaults()
        {
            Item.width = 82;
            Item.height = 80;
            Item.rare = ItemRarityID.Master;
            Item.accessory = true;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(gold: 12);
            Utility.ItemSets.DrillCasing[Type] = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {

            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            modPlayer.excavatorDrill = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemType<AdamantiteDrillCasing>())
                .AddIngredient(ItemType<CelestialDrillCasing>())
                .AddIngredient(ItemType<CobaltDrillCasing>())
                .AddIngredient(ItemType<HakapikDrillCasing>())
                .AddIngredient(ItemType<HorsemansDrillCasing>())
                .AddIngredient(ItemType<MattockDrillCasing>())
                .AddIngredient(ItemType<MythrilDrillCasing>())
                .AddIngredient(ItemType<OrichalcumDrillCasing>())
                .AddIngredient(ItemType<PalladiumCasing>())
                .AddIngredient(ItemType<ShroomiteShredderCasing>())
                .AddIngredient(ItemType<TitaniumDrillCasing>())
                .AddIngredient(ItemType<TreeClippersDrillCasing>())
                .AddIngredient(ItemType<TsurugiDrillCasing>())
                .AddIngredient(ItemType<YoyoDrillCasing>())
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }
    }
}