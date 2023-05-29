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
    public class TrueAbbhor : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            DisplayName.SetDefault("True Abbhor");
            Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 34;
            Item.height = 30;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 4.5f;
            Item.damage = 81;
            Item.crit = 16; 
            Item.rare = ItemRarityID.Red;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 15, 90, 83);
            Item.shoot = ModContent.ProjectileType<TrueAbbhorProjectile>();


        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TheAbbhor>());
            recipe.AddIngredient(ModContent.ItemType<MightBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SightBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<FrightBar>(), 10);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
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