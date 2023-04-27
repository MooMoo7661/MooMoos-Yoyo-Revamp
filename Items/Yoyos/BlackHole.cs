using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework;
using Terraria.GameContent;

namespace CombinationsMod.Items.Yoyos
{
    public class BlackHole : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Type] = true;
            DisplayName.SetDefault("Black Hole");
            Tooltip.SetDefault("Spins fast enough to generate a vortex of energy, forming a devastating black hole\nCreated by Turbanik");

        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 30;
            Item.height = 26;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 3f;
            Item.knockBack = 15f;
            Item.damage = 127;
            Item.rare = ItemRarityID.Lime;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 17, 0, 0);
            Item.shoot = ModContent.ProjectileType<BlackHoleProjectile>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Insert(1, new TooltipLine(Mod, "YoyoType", "[c/6FD4FF:Boss Drop]"));
        }
    }
}