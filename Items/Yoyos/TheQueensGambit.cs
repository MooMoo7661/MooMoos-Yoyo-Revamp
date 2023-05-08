using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using CombinationsMod.Projectiles.YoyoProjectiles;

namespace CombinationsMod.Items.Yoyos
{
    public class TheQueensGambit : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            // DisplayName.SetDefault("The Queen's Gambit");
            // Tooltip.SetDefault("Releases bees on hit and has a chance to poison the target\nBees make up for lack of initial damage\nHas a chance to leave bees in it's wake\n\"Now includes added Hive Pack support!\"");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 32;
            Item.height = 32;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 1f;
            Item.damage = 23;
            Item.rare = ItemRarityID.Green;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 6, 0, 0);
            Item.shoot = ModContent.ProjectileType<TheQueensGambitProjectile>();
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {
            tooltips.Insert(1, new TooltipLine(Mod, "YoyoType", "[c/6FD4FF:Boss Drop]"));
        }
    }
}