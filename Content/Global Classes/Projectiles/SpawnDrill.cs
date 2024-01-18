using CombinationsMod.Content.Drills;
using CombinationsMod.Content.ModPlayers;
using CombinationsMod.Content.Utility;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses
{
    public class SpawnDrill : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            Player player = Main.player[projectile.owner];
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>(); // Getting modplayer and player

            if (projectile.type == ContentSamples.ProjectilesByType[player.HeldItem.shoot].type && projectile.aiStyle == 99 &&
                projectile.ai[0] != 1f && Main.myPlayer == projectile.owner) // If projectile is a Yoyo & it is the same one as the .shoot of the held yoyo.
            {
                if (modPlayer.CurrentDrillType != 0 && ProjectileSets.IsYoyoDrillProjectile[modPlayer.CurrentDrillType])
                {
                    Projectile drill = Projectile.NewProjectileDirect(projectile.GetSource_FromThis(), projectile.Center, Vector2.Zero, modPlayer.CurrentDrillType, projectile.damage, 0, projectile.owner, 0, projectile.whoAmI);
                    drill.scale = 1.3f;
                }
            }
        }
    }
}

