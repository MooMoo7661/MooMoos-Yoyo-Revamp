using System;
using CombinationsMod.Content.Configs;
using Microsoft.Xna.Framework;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.ModPlayers
{
    public class YoyoModPlayer : ModPlayer
    {
        public int currentYoyo = 0;
        public int yoyoNumber = 1;

        public int chainTextureID = 0;

        /// <summary>
        /// For use with the `yoyoSpacers` bool, allows the mod to subtract the added stats to prevent exponential growth.<br>Unused</br>
        /// </summary>
        public bool wasEquipped = false;

        public bool wasEquippedDarkGreen = false;
        public bool wasEquippedDarkBlue = false;
        public bool wasEquippedLightPink = false;
        public bool wasEquippedNaniteString = false;

        /// <summary>
        ///  Used by the Upgraded Yoyo Glove / Solar Glove. Determines if the player can create a second yoyo
        /// </summary>
        public bool yoyoClip = false;
        public bool yoyoSpacers = false;
        public bool yoyoBag = false;
        public bool shimmerBag = false;
        public bool tier2Bag = false;
        public bool beetleBag = false;
        public bool alienBag = false;
        public bool moonlordBag = false;
        public bool playerHasYoyoBagEquipped = false;

        public bool eclipseString = false;
        public bool golemString = false;
        public bool frostbiteString = false;
        public bool slimeString = false;

        public bool solarString = false;
        public bool stardustString = false;
        public bool vortexString = false;
        public bool nebulaString = false;

        public bool darkGreenString = false;
        public bool darkBlueString = false;
        public bool lightPinkString = false;
        public bool naniteString = false;
        public bool darkTealString = false;
        public bool grapeString = false;

        public bool supportGlove = false;

        public bool ironDrill = false;
        public bool palladiumDrill = false;
        public bool cobaltDrill = false;
        public bool orichalcumDrill = false;
        public bool mythrilDrill = false;
        public bool adamantiteDrill = false;
        public bool titaniumDrill = false;
        public bool hallowedDrill = false; // Hakapik
        public bool chlorophyteDrill = false;
        public bool spectreDrill = false; // Spectral Shredder
        public bool shroomiteDrill = false;
        public bool golemDrill = false; // Tsurugi
        public bool horseDrill = false; // Horseman drill
        public bool christmasDrill = false;
        public bool solarDrill = false;
        public bool vortexDrill = false;
        public bool nebulaDrill = false;
        public bool stardustDrill = false;
        public bool celestialDrill = false;
        public bool moomooDrill = false;
        public bool excavatorDrill = false;

        public bool yoyoRing = false; // Power Ring
        public bool amberRing = false;                                  // 
        public bool topazRing = false;                                  //
        public bool amethystRing = false;                               //
        public bool rubyRing = false;                                   //   Highlighted rings are color based
        public bool sapphireRing = false;                               //
        public bool emeraldRing = false;                                // 
        public bool diamondRing = false;                                //
        public bool gemRing = false;                                    //
        public bool fortitudeRing = false; // Destroyer ring
        public bool omnipotenceRing = false; // Twins ring
        public bool trepidationRing = false; // Skeletron Prime ring

        public bool speedTracker = false; // Yoyo Radar
        public bool hitTracker = false;  // Mechanical Clicker
        public int HitCounter = 0; // Mechanical Clicker value

        public bool trick1 = false; // Around the World
        public bool trick2 = false; // Around the World Tier 2
        public bool dualYoyo = false; // Dual Yoyo trick
        public bool moonTrick = false; // Shoot to the Moon

        public override void ResetEffects() // Lets accessories be temporary.
        {
            currentYoyo = 0;

            yoyoClip = false;
            yoyoSpacers = false;
            yoyoBag = false;
            shimmerBag = false;
            tier2Bag = false;
            beetleBag = false;
            alienBag = false;
            moonlordBag = false;
            playerHasYoyoBagEquipped = false;

            supportGlove = false;

            eclipseString = false;
            golemString = false;
            frostbiteString = false;
            slimeString = false;

            solarString = false;
            stardustDrill = false;
            vortexString = false;
            nebulaString = false;

            darkGreenString = false;
            darkBlueString = false;
            lightPinkString = false;
            naniteString = false;
            darkTealString = false;
            grapeString = false;

            ironDrill = false;
            cobaltDrill = false;
            palladiumDrill = false;
            orichalcumDrill = false;
            mythrilDrill = false;
            adamantiteDrill = false;
            titaniumDrill = false;
            hallowedDrill = false;
            chlorophyteDrill = false;
            spectreDrill = false;
            shroomiteDrill = false;
            golemDrill = false;
            horseDrill = false;
            christmasDrill = false;
            solarDrill = false;
            vortexDrill = false;
            nebulaDrill = false;
            stardustDrill = false;
            celestialDrill = false;
            moomooDrill = false;
            excavatorDrill = false;

            yoyoRing = false;
            amberRing = false;
            topazRing = false;
            amethystRing = false;
            rubyRing = false;
            sapphireRing = false;
            emeraldRing = false;
            diamondRing = false;
            gemRing = false;
            fortitudeRing = false;
            omnipotenceRing = false;
            trepidationRing = false;

            speedTracker = false;
            hitTracker = false;

            trick1 = false;
            trick2 = false;
            dualYoyo = false;
            moonTrick = false;
        }

        public override void PostUpdateEquips()
        {
            YoyoModPlayer modPlayer = Player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.alienBag || modPlayer.beetleBag || modPlayer.moonlordBag || modPlayer.shimmerBag || modPlayer.tier2Bag || modPlayer.yoyoBag)
            {
                modPlayer.playerHasYoyoBagEquipped = true;
            }
        }

        /// <summary>
        /// Inputs regular yoyo string length, then returns the modified length depending on player bools.
        /// </summary>
        /// <returns>(float) New modified length of yoyo string</returns>
        public float GetModifiedPlayerYoyoStringLength(float length, Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.solarString || modPlayer.nebulaString || modPlayer.vortexString || modPlayer.stardustString)
            {
                length += 100f;
            }

            if (modPlayer.alienBag)
            {
                length += 9999;
            }

            return length;
        }

        /// <summary>
        /// Inputs regular yoyo speed, then returns the modified speed depending on player bools.
        /// </summary>
        /// <returns>(float) New modified speed of yoyo</returns>
        public float GetModifiedPlayerYoyoSpeed(float speed, Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.omnipotenceRing)
            {
                speed += 2f;
            }

            if (modPlayer.solarString || modPlayer.nebulaString || modPlayer.vortexString || modPlayer.stardustString)
            {
                speed += 3f;
            }
            else if (modPlayer.eclipseString || modPlayer.frostbiteString || modPlayer.golemString || modPlayer.naniteString)
            {
                speed += 2f;
            }
            else if (modPlayer.darkTealString || modPlayer.darkGreenString || modPlayer.darkBlueString || modPlayer.lightPinkString || modPlayer.grapeString || modPlayer.slimeString)
            {
                speed += 1f;
            }

            return speed;
        }

        /// <summary>
        /// Checks for yoyo bag
        /// </summary>
        public static bool TestForYoyoBag(Player player) => player.GetModPlayer<YoyoModPlayer>().playerHasYoyoBagEquipped;

        /// <summary>
        /// Returns the number of yoyos the player should have
        /// </summary>
        public static int GetNumPlayerYoyos(Player player)
        {
            int numYoyos = 1;
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.tier2Bag || modPlayer.shimmerBag)
            {
                numYoyos = 2;
            }

            if (modPlayer.beetleBag || modPlayer.moonlordBag)
            {
                numYoyos = 3;
            }

            return numYoyos;
        }

        public override void PlayerDisconnect() // Subtracts the added Yoyo stats when the player disconnects.
        {
            HitCounter = 0;
        }

        /// <summary>
        /// Checks for support glove
        /// </summary>
        public static bool TestForSupportGlove(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.supportGlove)
            {
                return true;
            }

            return false;
        }

        public static int GetYoyoToCast(Player player)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (player.selectedItem == 58)
            {
                return ContentSamples.ProjectilesByType[player.inventory[58].shoot].type;
            }

            int yoyoToCast = ContentSamples.ProjectilesByType[player.inventory[player.selectedItem].shoot].type;

            if (modPlayer.dualYoyo)
            {
                if (ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + 1].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + 1].type])
                {
                    return ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + 1].shoot].type;
                }
            }

            return yoyoToCast;
        }

        public override void Load()
        {
            // On_Player.Counterweight += DualYoyoDetour;
            IL_Player.Counterweight += ILDualYoyo;
        }

        public override void Unload()
        {
            // On_Player.Counterweight -= DualYoyoDetour;
            IL_Player.Counterweight -= ILDualYoyo;
        }

        // private void DualYoyoDetour(On_Player.orig_Counterweight orig, Player player, Vector2 hitPos, int dmg, float kb)
        // {
        //     DualYoyo(player, dmg, kb);
        // }

        /// <summary>
        /// Detoured hook of Player.Counterweight. <br>
        /// Handles all behavior related to the yoyo glove.</br>
        /// </summary>

        // private void DualYoyo(Player player, int dmg, float kb)
        // {
        //     if (!player.yoyoGlove && player.counterWeight <= 0)
        //     {
        //         return;
        //     }
        //
        //     int num = -1;
        //     int num2 = 0;
        //     int num3 = 0;
        //
        //     for (int i = 0; i < 1000; i++)
        //     {
        //         if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI)
        //         {
        //             if (Main.projectile[i].counterweight)
        //             {
        //                 num3++;
        //             }
        //             else if (Main.projectile[i].aiStyle == 99)
        //             {
        //                 num2++;
        //                 num = i;
        //             }
        //         }
        //     }
        //
        //     if (player.yoyoGlove && num2 < GetNumPlayerYoyos(player) + 1)
        //     {
        //         if (num >= 0)
        //         {
        //             int damage;
        //             float knockback;
        //
        //             if (player.selectedItem == 58)
        //             {
        //                 damage = player.inventory[58].damage;
        //                 knockback = player.inventory[58].knockBack;
        //             }
        //             else
        //             {
        //                 damage = player.inventory[player.selectedItem].damage;
        //                 knockback = player.inventory[player.selectedItem].knockBack;
        //             }
        //
        //             if (player.selectedItem != 58 && ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + 1].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + 1].type])
        //             {
        //                 damage = player.inventory[player.selectedItem + 1].damage;
        //                 knockback = player.inventory[player.selectedItem + 1].knockBack;
        //             }
        //
        //             if (TestForYoyoBag(player) && !ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
        //             {
        //                 int numYoyos = GetNumPlayerYoyos(player);
        //
        //                 for (int i = 0; i < numYoyos - 1; i++)
        //                 {
        //                     Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                     Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                 }
        //             }
        //
        //
        //             if (TestForSupportGlove(player))
        //             {
        //                 Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                 Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //
        //                 Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
        //                 Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector2.X, vector2.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                 return;
        //             }
        //             else
        //             {
        //                 Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                 Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                 return;
        //             }
        //
        //
        //         }
        //     }
        //     else if (num3 < num2)
        //     {
        //         for (int i = 0; i < yoyoNumber; i++)
        //         {
        //             Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
        //             vector2.Normalize();
        //             vector2 *= 16f;
        //             float knockBack = (kb + 6f) / 2f;
        //
        //             IEntitySource spawnSource = Terraria.Entity.InheritSource(Main.projectile[num]);
        //             if (num3 > 0)
        //             {
        //                 Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 1f, 0f);
        //                 return;
        //             }
        //             else
        //             {
        //                 Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 0f, 0f);
        //             }
        //         }
        //     }
        // }

        private void ILDualYoyo(ILContext context)
        {
            ILCursor c = new(context);
            if (!c.TryGotoNext(MoveType.After, i => i.MatchLdarg0(),
                    i => i.MatchLdfld<Player>(nameof(Player.yoyoGlove))))
                throw new ILPatchFailureException(this.Mod, context, new Exception("Failed to patch dual yoyo")); 
            c.Emit(OpCodes.Pop);
            c.EmitLdloc3();
            c.EmitLdloc1();
            c.EmitLdloc2();
            c.EmitLdarg0();
            c.EmitLdarg2();
            c.EmitLdarg3();
            c.EmitDelegate(ilEdit);
            c.EmitRet(); 
            c.Emit(OpCodes.Ldc_I4_0);
        }

        private void ilEdit(int index1, int num1, int num2, Player player, int dmg, float kb)
        {
            if (player.yoyoGlove && num2 < GetNumPlayerYoyos(player) + 1)
            {
                if (index1 >= 0)
                {
                    int damage;
                    float knockback;

                    if (player.selectedItem == 58)
                    {
                        damage = player.inventory[58].damage;
                        knockback = player.inventory[58].knockBack;
                    }
                    else
                    {
                        damage = player.inventory[player.selectedItem].damage;
                        knockback = player.inventory[player.selectedItem].knockBack;
                    }

                    if (player.selectedItem != 58 && ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + 1].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + 1].type])
                    {
                        damage = player.inventory[player.selectedItem + 1].damage;
                        knockback = player.inventory[player.selectedItem + 1].knockBack;
                    }

                    if (TestForYoyoBag(player) && !ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                    {
                        int numYoyos = GetNumPlayerYoyos(player);

                        for (int i = 0; i < numYoyos - 1; i++)
                        {
                            Vector2 vector = Main.rand.NextVector2Unit() * 16f;
                            Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[index1]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
                        }
                    }


                    if (TestForSupportGlove(player))
                    {
                        Vector2 vector = Main.rand.NextVector2Unit() * 16f;
                        Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[index1]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);

                        Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
                        Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[index1]), player.Center.X, player.Center.Y, vector2.X, vector2.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
                        return;
                    }
                    else
                    {
                        Vector2 vector = Main.rand.NextVector2Unit() * 16f;
                        Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[index1]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
                        return;
                    }


                }
            }
            else if (num2 < num1)
            {
                for (int i = 0; i < yoyoNumber; i++)
                {
                    Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
                    vector2.Normalize();
                    vector2 *= 16f;
                    float knockBack = (kb + 6f) / 2f;

                    IEntitySource spawnSource = Terraria.Entity.InheritSource(Main.projectile[index1]);
                    if (num2 > 0)
                    {
                        Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 1f, 0f);
                        return;
                    }
                    else
                    {
                        Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 0f, 0f);
                    }
                }
            }
        }
    }
}
