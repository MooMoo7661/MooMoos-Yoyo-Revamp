using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using CombinationsMod.Rarities;
using CombinationsMod.Tiles;

namespace CombinationsMod.Items.Yoyos
{
    public class TheAbbhor : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            DisplayName.SetDefault("The Abbhor");
            Tooltip.SetDefault("An amalgamation of pure power");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 34;
            Item.height = 30;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.5f;
            Item.damage = 32;
            Item.crit = 16;
            Item.rare = ModContent.RarityType<PHPink>();
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 9, 8, 3);
            Item.shoot = ModContent.ProjectileType<TheAbbhorProjectile>();


        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on use]"));
                tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates a damaging aura]\n[c/B3FDFF:After 20 consecutive hits, a larger aura will be created]")); // TODO: Implement Ability
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Cascade);
            recipe.AddIngredient(ItemID.Valor);
            recipe.AddIngredient(ItemID.CrimsonYoyo);
            recipe.AddIngredient(ItemID.JungleYoyo);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Cascade);
            recipe2.AddIngredient(ItemID.Valor);
            recipe2.AddIngredient(ItemID.CorruptYoyo);
            recipe2.AddIngredient(ItemID.JungleYoyo);
            recipe2.AddTile(TileID.Anvils);
            recipe2.Register();
        }
    }
}