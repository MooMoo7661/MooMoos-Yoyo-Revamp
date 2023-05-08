using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using System;
using CombinationsMod.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.GameContent;
using CombinationsMod.Items.Bars;
using CombinationsMod.Items.Misc;
using System.Collections.Generic;

namespace CombinationsMod.Items.Yoyos
{
    public class TrueSmudge : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Yoyo[Item.type] = true;

            // DisplayName.SetDefault("True Smudge");
            // Tooltip.SetDefault("Does increased damage to spectral targets.\nWhen in a graveyard biome, the swirls recieve a 2x damage boost.\n\"Has a 12 second grace period.\"");
        }

        public override void SetDefaults()
        {
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.width = 38;
            Item.height = 34;
            Item.useAnimation = 25;
            Item.useTime = 25;
            Item.shootSpeed = 16f;
            Item.knockBack = 2.5f;
            Item.damage = 78;
            Item.rare = ItemRarityID.Yellow;
            Item.DamageType = DamageClass.Melee;
            Item.channel = true;
            Item.noMelee = true;
            Item.noUseGraphic = true;
            Item.UseSound = new SoundStyle?(SoundID.Item1);
            Item.value = Item.sellPrice(0, 1, 50, 2);
            Item.shoot = ModContent.ProjectileType<TrueSmudgeProjectile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ModContent.ItemType<Smudge>())
                .AddIngredient(ModContent.ItemType<NeutralineScrap>(), 10)
                .AddIngredient(ItemID.ChlorophyteBar, 10)
                .AddIngredient(ItemID.Ectoplasm, 15)
                .AddTile(TileID.MythrilAnvil)
                .AddCondition(Condition.InGraveyard)
                .Register();
        }

        public override void ModifyTooltips(List<TooltipLine> tooltips)
        {

            Player player = Main.LocalPlayer;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.yoyoRing)
            {
                tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on use]"));
                tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates a large damaging aura]")); // TODO: Implement Ability
            }
        }
    }
}