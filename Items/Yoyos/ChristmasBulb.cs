using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Projectiles.YoyoProjectiles;
using System.Collections.Generic;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CombinationsMod.Items.Yoyos;

public class ChristmasBulb : ModYoyo
{
    public override bool CanBeUnloaded => true;

    public override void SetStaticDefaults()
    {
        ItemID.Sets.Yoyo[Item.type] = true;

        // DisplayName.SetDefault("Christmas Bulb");
        // Tooltip.SetDefault("Wrapped tightly with Christmas Tree lights\nSmells like fresh pine");
    }

    public override void SetDefaults()
    {
        Item.useStyle = ItemUseStyleID.Shoot;
        Item.width = 32;
        Item.height = 32;
        Item.useAnimation = 25;
        Item.useTime = 25;
        Item.shootSpeed = 23f;
        Item.knockBack = 2.5f;
        Item.damage = 70;
        Item.rare = ItemRarityID.Yellow;
        Item.DamageType = DamageClass.Melee;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = new SoundStyle?(SoundID.Item1);
        Item.value = Item.sellPrice(0, 7, 8, 3);
        Item.shoot = ModContent.ProjectileType<ChristmasBulbProjectile>();


    }

    public override void ModifyTooltips(List<TooltipLine> tooltips)
    {
        Player player = Main.LocalPlayer;
        YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

        if (modPlayer.yoyoRing)
        {
            tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:30 hit trigger]"));
            tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Shoots damaging ornaments]"));
        }
    }

    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
    }

}
