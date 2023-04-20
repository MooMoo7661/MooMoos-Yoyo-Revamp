using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using CombinationsMod.Projectiles.YoyoProjectiles;
using System.Collections.Generic;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using CombinationsMod.Rarities;

namespace CombinationsMod.Items.Misc;

public class BrokenHeroYoyo : ModItem
{
    public override void SetStaticDefaults()
    {
        DisplayName.SetDefault("Broken Hero Yoyo");
        Tooltip.SetDefault("");
    }

    public override void SetDefaults()
    {
        Item.width = 30;
        Item.height = 26;
        Item.maxStack = 99;
        Item.value = Item.sellPrice(gold: 6, silver: 20);
        Item.rare = ItemRarityID.Yellow;
    }
}
