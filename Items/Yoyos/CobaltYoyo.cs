using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoProjectiles;
using System.Collections.Generic;

namespace CombinationsMod.Items.Yoyos;

public class CobaltYoyo : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.Yoyo[Item.type] = true;

        DisplayName.SetDefault("Cobalt Yoyo");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 32;
        Item.height = 32;
        Item.useAnimation = 25;
        Item.useTime = 25;
        Item.shootSpeed = 16f;
        Item.knockBack = 5f;
        Item.damage = 36;
        Item.rare = ItemRarityID.LightRed;
        Item.DamageType = DamageClass.Melee;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = new SoundStyle?(SoundID.Item1);
        Item.value = Item.sellPrice(0, 1, 68, 0);
        Item.shoot = ModContent.ProjectileType<CobaltYoyoProjectile>();


    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.CobaltBar, 8);
        recipe.AddTile(TileID.Anvils);
        recipe.Register();
    }
}
