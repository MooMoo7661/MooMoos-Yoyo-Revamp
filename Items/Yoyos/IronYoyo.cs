using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Projectiles.YoyoProjectiles;

namespace CombinationsMod.Items.Yoyos
{
    public class IronYoyo : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.3f;
            Item.damage = 13;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 0, 80, 3);
            Item.shoot = ModContent.ProjectileType<IronYoyoProjectile>();


        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }
    }
}