using CombinationsMod.Content;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CombinationsMod.Global_Classes
{
    /// <summary>
    /// Making drills rotate in the world. Doing it this way since items (understandably), don't have a rotation.
    /// </summary>
    public class GlobalDrill : GlobalItem
    {
        public float rot = 0;
        public override bool InstancePerEntity => true;

        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.ModItem is ModDrill || ItemSets.DrillCasing[entity.type] == true;
        }

        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(item.Center, Color.LawnGreen.ToVector3() * 0.8f);
            rot += 0.15f;
            Main.EntitySpriteDraw(TextureAssets.Item[item.type].Value, item.Center - Main.screenPosition, null, Color.White, rot, TextureAssets.Item[item.type].Value.Size() / 2, scale, SpriteEffects.None);
            return false;
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.ModItem is ModDrill drill)
            {
                player.GetModPlayer<YoyoModPlayer>().CurrentDrillType = drill.DrillProjectile;
            }
        }
    }
}
