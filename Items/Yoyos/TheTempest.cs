using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using CombinationsMod.Items.Misc;

namespace CombinationsMod.Items.Yoyos
{
    public class TheTempest : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            // DisplayName.SetDefault("The Tempest");
            // Tooltip.SetDefault("");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 38;
            Item.height = 34;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 20f;
            Item.knockBack = 7f;    
            Item.damage = 97;
            Item.rare = ItemRarityID.Yellow;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 20, 0, 0);
            Item.shoot = ModContent.ProjectileType<TempestProjectile>();


        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on use]"));
                tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates a very large damaging aura]"));
            }
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<TrueAbbhor>())
                .AddIngredient(ModContent.ItemType<TrueCode3>())
                .AddIngredient(ModContent.ItemType<TrueSmudge>())
                .AddIngredient(ModContent.ItemType<BrokenHeroYoyo>())
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }
    }
}