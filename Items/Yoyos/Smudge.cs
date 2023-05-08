using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CombinationsMod.Items.Yoyos
{
    public class Smudge : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            // DisplayName.SetDefault("Smudge");
            // Tooltip.SetDefault("Does increased damage to spectral targets.\nWhen in a graveyard biome, it receives a 2x damage boost marked by the emission of blue flames.\n\"Has a 6 second grace period.\"");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.5f;
            Item.damage = 14;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 1, 50, 2);
            Item.shoot = ModContent.ProjectileType<SmudgeProjectile>();
        }
    }
}