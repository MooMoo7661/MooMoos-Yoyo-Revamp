using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using CombinationsMod.Items;
using CombinationsMod.Dusts;
using CombinationsMod.Projectiles.YoyoEffects;
using Terraria.Audio;
using CombinationsMod.GlobalClasses.Projectiles;

namespace CombinationsMod.Projectiles.YoyoProjectiles
{
    public class ConverganceProjectile : ModProjectile
    {
        public int timer = 10;
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[Projectile.type] = -1f;
            ProjectileID.Sets.YoyosMaximumRange[Projectile.type] = 420f;
            ProjectileID.Sets.YoyosTopSpeed[Projectile.type] = 20f;
        }

        public override void SetDefaults()
        {
            Projectile.extraUpdates = 0;
            Projectile.width = 28;
            Projectile.height = 28;
            Projectile.aiStyle = 99;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.scale = 1f;
        }

        public override void OnSpawn(IEntitySource source)
        {
            if (ModContent.GetInstance<VanillaYoyoEffects>().ReturnProjectileFlag(Projectile) && Main.player[Projectile.owner].GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                int damage = (int)(Projectile.damage * 1.75f);

                if (Main.myPlayer == Projectile.owner)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.WoodYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<IronYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<LeadYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Rally, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.CorruptYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.CrimsonYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.JungleYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Valor, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Cascade, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Code2, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<SmudgeProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<Code3Projectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<TheAbbhorProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<ThinMintProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CatacombProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<TheQueensGambitProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Code1, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CobaltYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<PalladiumYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<MythrilYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<OrichalcumYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Chik, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.FormatC, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.HelFire, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Amarok, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Gradient, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Yelets, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.RedsYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.ValkyrieYoyo, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<ChristmasBulbProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<MambeleProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Kraken, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.TheEyeOfCthulhu, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<TempestProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ModContent.ProjectileType<CultistYoyoProjectile>(), damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Terrarian, damage, Projectile.knockBack, Projectile.owner);
                        Projectile.NewProjectile(source, Projectile.position, new Vector2(0, 0), ProjectileID.Terrarian, damage, Projectile.knockBack, Projectile.owner);
                    }
                }
            }
        }
    }
}
