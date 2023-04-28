using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using CombinationsMod.Rarities;
using CombinationsMod.Tiles;
using CombinationsMod.Items.Bars;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using Microsoft.Xna.Framework.Graphics;

namespace CombinationsMod.Items.Yoyos
{
    public class Convergance : ModItem
    {

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            DisplayName.SetDefault("The Convergance");
            Tooltip.SetDefault("The pinnacle of destruction\nLight shines through the center");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 40;
            Item.height = 34;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 32f;
            Item.knockBack = 8f;
            Item.damage = 250;
            Item.crit = 50; 
            Item.rare = ItemRarityID.Red;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 50, 90, 83);
            Item.shoot = ModContent.ProjectileType<ConverganceProjectile>();


        }
        public override void AddRecipes()
        {

            CreateRecipe()
                .AddIngredient(ItemID.WoodYoyo)
                .AddRecipeGroup(CombinationsModSystem.ironYoyoGroup )
                .AddIngredient(ItemID.Rally)
                .AddIngredient(ModContent.ItemType<ThinMint>())
                .AddIngredient(ModContent.ItemType<Catacomb>())
                .AddIngredient(ModContent.ItemType<TheQueensGambit>())
                .AddIngredient(ItemID.Code1)
                .AddRecipeGroup(CombinationsModSystem.cobaltYoyoGroup)
                .AddRecipeGroup(CombinationsModSystem.mythrilYoyoGroup)
                .AddIngredient(ItemID.Chik)
                .AddIngredient(ItemID.FormatC)
                .AddIngredient(ItemID.HelFire)
                .AddIngredient(ItemID.Amarok)
                .AddIngredient(ItemID.Gradient)
                .AddIngredient(ItemID.Yelets)
                .AddIngredient(ItemID.RedsYoyo)
                .AddIngredient(ItemID.ValkyrieYoyo)
                .AddIngredient(ModContent.ItemType<ChristmasBulb>())
                .AddIngredient(ModContent.ItemType<Mambele>())
                .AddIngredient(ItemID.Kraken)
                .AddIngredient(ItemID.TheEyeOfCthulhu)
                .AddIngredient(ModContent.ItemType<TheTempest>())
                .AddIngredient(ModContent.ItemType<CultistYoyo>())
                .AddIngredient(ItemID.Terrarian)
                .AddTile(TileID.LunarCraftingStation)
                .Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on use]"));
                tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates a large damaging aura]")); // TODO: Implement Ability
            }
        }
    }
}