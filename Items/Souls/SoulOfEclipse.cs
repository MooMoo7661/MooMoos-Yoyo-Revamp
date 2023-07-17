using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Bestiary;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using CombinationsMod.Rarities;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.GameContent;

namespace CombinationsMod.Items.Souls
{
    public class SoulOfEclipse : ItemLoader
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul of Eclipse");
            // Tooltip.SetDefault("'The essence of otherworldly creatures'");
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
            ItemID.Sets.AnimatesAsSoul[Item.type] = true;

            ItemID.Sets.ItemIconPulse[Item.type] = true;
            ItemID.Sets.ItemNoGravity[Item.type] = true;

            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 62);
            Item.rare = ModContent.RarityType<EclipseRarity>();
        }

        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
            Lighting.AddLight(Item.Center, (float)1.2, 0, 0);
        }
    }
}