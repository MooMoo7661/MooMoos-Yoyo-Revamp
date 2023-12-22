using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using CombinationsMod.Content.Rarities;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Yoyos
{
    public class TheAbbhor : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 34;
            Item.height = 30;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.1f;
            Item.damage = 31;
            Item.crit = 16;
            Item.rare = ModContent.RarityType<PHPink>();
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 9, 8, 3);
            Item.shoot = ModContent.ProjectileType<TheAbbhorProjectile>();


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

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }
    }
}