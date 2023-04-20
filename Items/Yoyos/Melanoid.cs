using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoProjectiles;
using System.Collections.Generic;
using CombinationsMod.Tiles;
using CombinationsMod.Items.Bars;

namespace CombinationsMod.Items.Yoyos
{
    public class Melanoid : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            DisplayName.SetDefault("Melanoid");
            Tooltip.SetDefault("Inflicts minor burns");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 22f;
            Item.knockBack = 8.4f;
            Item.damage = 17;
            Item.rare = ItemRarityID.Orange;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 1, 64, 3);
            Item.shoot = ModContent.ProjectileType<SpheruliteProjectile>();
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Obsidian, 45);
            recipe.AddIngredient(ItemID.LavaBucket, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:15 hit trigger]"));
                tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates explosive fire]"));
            }
        }
    }
}