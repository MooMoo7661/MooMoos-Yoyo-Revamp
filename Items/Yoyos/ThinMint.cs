using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;

namespace CombinationsMod.Items.Yoyos
{
    public class ThinMint : ModYoyo
    {
        public override bool CanBeUnloaded => true;

        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            // DisplayName.SetDefault("The Thin Mint");
            // Tooltip.SetDefault("\"Please do not eat the mints\"");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 18f;
            Item.knockBack = 4.5f;
            Item.damage = 16;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 1, 0, 89);
            Item.shoot = ModContent.ProjectileType<ThinMintProjectile>();
        }

        public override bool IsLoadingEnabled(Mod mod)
        {
            return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
        }
    }
}