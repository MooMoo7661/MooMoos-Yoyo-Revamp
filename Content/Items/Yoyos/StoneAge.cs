using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Yoyos
{
    public class StoneAge : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 3f;
            Item.knockBack = 6.5f;
            Item.damage = 11;
            Item.rare = ItemRarityID.Blue;
            Item.DamageType = DamageClass.MeleeNoSpeed;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 0, 10, 2);
            Item.shoot = ModContent.ProjectileType<StoneAgeProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.StoneBlock, 25)
                .AddTile(TileID.WorkBenches)
                .Register();
        }
    }
}