using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace CombinationsMod.Global_Classes
{
    public class GlobalDrill : GlobalItem
    {
        public float rot = 0;
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Item entity, bool lateInstantiation)
        {
            return entity.ModItem is ModDrill;
        }

        public override bool PreDrawInWorld(Item item, SpriteBatch spriteBatch, Color lightColor, Color alphaColor, ref float rotation, ref float scale, int whoAmI)
        {
            Lighting.AddLight(item.Center, Color.LawnGreen.ToVector3() * 0.8f);

            Texture2D tex = TextureAssets.Item[item.type].Value;
            rot += 0.15f;
            Main.EntitySpriteDraw(tex, item.Center - Main.screenPosition, null, Color.White, rot, tex.Size() / 2, scale, SpriteEffects.None);
            return false;
        }
    }
}
