using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoProjectiles;
using System.Collections.Generic;

namespace CombinationsMod.Items.Yoyos;

public class MythrilYoyo : ModItem
{
    public override void SetStaticDefaults()
    {
        ItemID.Sets.Yoyo[Item.type] = true;

        // DisplayName.SetDefault("Mythril Yoyo");
        // Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 32;
        Item.height = 32;
        Item.useAnimation = 25;
        Item.useTime = 25;
        Item.shootSpeed = 16f;
        Item.knockBack = 5.2f;
        Item.damage = 44;
        Item.rare = ItemRarityID.LightRed;
        Item.DamageType = DamageClass.Melee;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = new SoundStyle?(SoundID.Item1);
        Item.value = Item.sellPrice(0, 2, 2, 0);
        Item.shoot = ModContent.ProjectileType<MythrilYoyoProjectile>();


    }

    public override void AddRecipes()
    {
        Recipe recipe = CreateRecipe();
        recipe.AddIngredient(ItemID.MythrilBar, 10);
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
            tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates a damaging aura]"));
        }
    }
}
