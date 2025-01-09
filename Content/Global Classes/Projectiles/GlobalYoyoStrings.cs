using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CombinationsMod.Content.Items.Yoyos;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Projectiles.YoyoProjectiles;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using YoyoStringLib;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class GlobalYoyoStrings : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.aiStyle == 99;

        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            switch(projectile.type)
            {
                case ProjectileID.JungleYoyo:
                    projectile.StringData().StringTexture = TextureAssets.Chain27;
                    break;
                case ProjectileID.Terrarian:
                    projectile.StringData().StringTexture = TextureAssets.Chains[13];
                    break;
            }
            if (projectile.GetOwner().GetModPlayer<YoyoModPlayer>().YoyoStringColor != Color.White)
            {
                projectile.StringData().StringColor = projectile.GetOwner().GetModPlayer<YoyoModPlayer>().YoyoStringColor;
            }

            if (projectile.GetOwner().GetModPlayer<YoyoModPlayer>().naniteString)
                projectile.StringData().StringDrawType = DrawSets.StringDrawTypes.Invisible;
        }
    }
}
