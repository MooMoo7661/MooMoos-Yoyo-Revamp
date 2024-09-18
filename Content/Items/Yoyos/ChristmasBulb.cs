using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Items.Yoyos;

public class ChristmasBulb : ModYoyo
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
        Item.shootSpeed = 23f;
        Item.knockBack = 2.5f;
        Item.damage = 78;
        Item.rare = ItemRarityID.Yellow;
        Item.DamageType = DamageClass.MeleeNoSpeed;
        Item.channel = true;
        Item.noMelee = true;
        Item.noUseGraphic = true;
        Item.UseSound = new SoundStyle?(SoundID.Item1);
        Item.value = Item.sellPrice(0, 7, 8, 3);
        Item.shoot = ModContent.ProjectileType<ChristmasBulbProjectile>();


    }

    public override bool IsLoadingEnabled(Mod mod)
    {
        return ModContent.GetInstance<YoyoModConfig>().LoadModdedYoyos;
    }
}
