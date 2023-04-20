﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Rarities
{
    public class EclipseRarity : ModRarity
    {
        public override Color RarityColor => new Color(255, 135, 30);
    }

    public class DevBagRarity : ModRarity
    {
        public override Color RarityColor => new Color(226, 93, 186);
    }
}
