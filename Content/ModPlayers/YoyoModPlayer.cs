using System;
using CombinationsMod.Content.Configs;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CombinationsMod.Content.ModPlayers
{
    public class YoyoModPlayer : ModPlayer
    {
        public float YoyoSpeedModifier { get; set; } = 0f;
        public float YoyoRangeModifier { get; set; } = 0f;
        public float YoyoLifetimeModifier { get; set; }
        public float YoyoAmountModifier { get; set; } = 1f;
        public Color YoyoStringColor { get; set; } = Color.White;

        public int currentYoyo = 0;
        public int yoyoNumber = 1;
        public int chainTextureID = 0;
        public int CurrentDrillType = 0;
        public bool phasingYoyos = false;

        public bool stringSlot = false;
        public bool gloveSlot = false;
        public bool supportGloveSlot = false;
        public bool counterweightSlot = false;
        public bool drillSlot = false;
        public bool ringSlot1 = false;
        public bool ringSlot2 = false;
        public bool trickSlot = false;

        public bool wasEquippedDarkGreen = false;
        public bool wasEquippedDarkBlue = false;
        public bool wasEquippedLightPink = false;
        public bool wasEquippedNaniteString = false;

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
        public bool christmasDrill = false; // Snowstorm Drill
        public bool solarDrill = false;
        public bool vortexDrill = false;
        public bool nebulaDrill = false;
        public bool stardustDrill = false;
        public bool celestialDrill = false;
        public bool moomooDrill = false;
        public bool excavatorDrill = false;

        public bool amberRing = false;    // 
        public bool topazRing = false;    //
        public bool amethystRing = false; //
        public bool rubyRing = false;     //   Highlighted rings are color based
        public bool sapphireRing = false; //
        public bool emeraldRing = false;  // 
        public bool diamondRing = false;  //
        public bool gemRing = false;      //
        public bool yoyoRing = false; // Power Ring
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
        public bool lifestealTrick = false; // Lifesteal Trick

        public override void ResetEffects()
        {
            YoyoAmountModifier = 1;
            YoyoSpeedModifier = 0;
            YoyoRangeModifier = 0;
            YoyoStringColor = Color.White;

            currentYoyo = 0;
            CurrentDrillType = 0;
            phasingYoyos = false;

            stringSlot = false;
            gloveSlot = false;
            supportGloveSlot = false;
            counterweightSlot = false;
            drillSlot = false;
            ringSlot1 = false;
            ringSlot2 = false;
            trickSlot = false;

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
            lifestealTrick = false;
        }

        public override void Load()
        {
            //On_Player.Counterweight += DualYoyoDetour;
            IL_Player.Counterweight += ILDualYoyo;
            Mod.Logger.Info("Loaded IL detour of Player.Counterweight");
        }

        public override void Unload()
        {
            //On_Player.Counterweight -= DualYoyoDetour;
            IL_Player.Counterweight -= ILDualYoyo;
            Mod.Logger.Info("Unloaded IL detour of Player.Counterweight");
        }

        public override void PreUpdate()
        {
            if (Player.yoyoGlove)
                Player.GetModPlayer<YoyoModPlayer>().YoyoAmountModifier += 1;
        }

        /// <summary>Gets the yoyo projectile ID to cast, and the index in the inventory of the item it belongs to.</summary>
        /// <returns>[0]: Yoyo projectile ID<br>[1]: Index in the inventory, based on position of selected item. (-1, 0, 1)</br></returns>
        public static int[] GetYoyoToCast(Player player, int yoyoNumber)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (player.selectedItem == 58)
            {
                return [ContentSamples.ProjectilesByType[player.inventory[58].shoot].type, 0];
            }

            int yoyoToCast = ContentSamples.ProjectilesByType[player.inventory[player.selectedItem].shoot].type;

            if (modPlayer.dualYoyo && yoyoNumber % 2 == 1)
            {
                int idx = 1;
                if (!ItemID.Sets.Yoyo[player.inventory[player.selectedItem + 1].type] && player.selectedItem > 0)
                    idx = -1;

                if (ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + idx].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + idx].type])
                {
                    return [ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + idx].shoot].type, idx];
                }
            }

            return [yoyoToCast, 0];
        }

        private void ILDualYoyo(ILContext context)
        {
            ILCursor c = new(context);
            if (!c.TryGotoNext(MoveType.After, i => i.MatchLdarg0(),
                    i => i.MatchLdfld<Player>(nameof(Player.yoyoGlove)),
                    i => i.MatchBrfalse(out ILLabel _)))
                throw new ILPatchFailureException(this.Mod, context, new Exception("Failed to patch dual yoyo"));
            c.Index--;
            c.EmitPop();
            c.EmitLdloc0();
            c.EmitLdloc1();
            c.EmitLdloc2();
            c.EmitLdarg0();
            c.EmitLdarg2();
            c.EmitLdarg3();
            c.EmitDelegate(ILEdit);
            c.EmitRet();
            c.Emit(OpCodes.Ldc_I4_0);
        }

        private void ILEdit(int index1, int yoyoCount, int counterweightCount, Player player, int dmg, float kb)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (player.yoyoGlove && yoyoCount < modPlayer.YoyoAmountModifier + 1)
            {
                if (index1 >= 0)
                {
                    int damage = player.inventory[player.selectedItem].damage;
                    float knockback = player.inventory[player.selectedItem].knockBack;
                    int[] yoyoInfo = GetYoyoToCast(player, yoyoCount); // Using [0] for the type & [1] for the index, for assigning correct damage & KB

                    if (player.selectedItem != 58 && ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + yoyoInfo[1]].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + yoyoInfo[1]].type])
                    {
                        damage = player.inventory[player.selectedItem + yoyoInfo[1]].damage;
                        knockback = player.inventory[player.selectedItem + yoyoInfo[1]].knockBack;
                    }

                    // +1 due to always having 1 yoyo active
                    for (int i = 0; i < modPlayer.YoyoAmountModifier + 1; i++)
                    {
                        Vector2 vector = Main.rand.NextVector2Unit() * 16f;
                        Projectile proj1 = Projectile.NewProjectileDirect(Terraria.Entity.InheritSource(Main.projectile[index1]), player.Center, vector, yoyoInfo[0], damage, knockback, player.whoAmI, 1f, 0f, 1f);
                        proj1.usesIDStaticNPCImmunity = false;
                        proj1.usesLocalNPCImmunity = true;
                        proj1.localNPCHitCooldown = 25 * proj1.MaxUpdates;
                        proj1.ai[2] = 1;
                        return;
                    }
                }
            }
            else if (counterweightCount < yoyoCount)
            {
                for (int i = 0; i < yoyoNumber; i++)
                {
                    Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
                    float knockBack = (kb + 6f) / 2f;

                    IEntitySource spawnSource = Terraria.Entity.InheritSource(Main.projectile[index1]);
                    Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, counterweightCount > 0 ? 1f : 0f, 0f);

                }
            }
        }

        #region Old Detour
        //private void DualYoyoDetour(On_Player.orig_Counterweight orig, Player player, Vector2 hitPos, int dmg, float kb)
        //{
        //    DualYoyo(player, dmg, kb);
        //}

        // /// <summary>
        // /// Detoured hook of Player.Counterweight. <br>
        // /// Handles all behavior related to the yoyo glove.</br>
        // /// </summary>

        // private void DualYoyo(Player player, int dmg, float kb)
        // {
        //    if (!player.yoyoGlove && player.counterWeight <= 0)
        //    {
        //        return;
        //    }

        //    int num = -1;
        //    int num2 = 0;
        //    int num3 = 0;

        //    for (int i = 0; i < 1000; i++)
        //    {
        //        if (Main.projectile[i].active && Main.projectile[i].owner == player.whoAmI)
        //        {
        //            if (Main.projectile[i].counterweight)
        //            {
        //                num3++;
        //            }
        //            else if (Main.projectile[i].aiStyle == 99)
        //            {
        //                num2++;
        //                num = i;
        //            }
        //        }
        //    }

        //    if (player.yoyoGlove && num2 < GetNumPlayerYoyos(player) + 1)
        //    {
        //        if (num >= 0)
        //        {
        //            int damage;
        //            float knockback;

        //            if (player.selectedItem == 58)
        //            {
        //                damage = player.inventory[58].damage;
        //                knockback = player.inventory[58].knockBack;
        //            }
        //            else
        //            {
        //                damage = player.inventory[player.selectedItem].damage;
        //                knockback = player.inventory[player.selectedItem].knockBack;
        //            }

        //            if (player.selectedItem != 58 && ContentSamples.ProjectilesByType[player.inventory[player.selectedItem + 1].shoot].aiStyle == 99 && ItemID.Sets.Yoyo[player.inventory[player.selectedItem + 1].type])
        //            {
        //                damage = player.inventory[player.selectedItem + 1].damage;
        //                knockback = player.inventory[player.selectedItem + 1].knockBack;
        //            }

        //            if (TestForYoyoBag(player) && !ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
        //            {
        //                int numYoyos = GetNumPlayerYoyos(player);

        //                for (int i = 0; i < numYoyos - 1; i++)
        //                {
        //                    Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                    Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                }
        //            }


        //            if (TestForSupportGlove(player))
        //            {
        //                Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);

        //                Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
        //                Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector2.X, vector2.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                return;
        //            }
        //            else
        //            {
        //                Vector2 vector = Main.rand.NextVector2Unit() * 16f;
        //                Projectile.NewProjectile(Terraria.Entity.InheritSource(Main.projectile[num]), player.Center.X, player.Center.Y, vector.X, vector.Y, GetYoyoToCast(player), damage, knockback, player.whoAmI, 1f, 0f);
        //                return;
        //            }


        //        }
        //    }
        //    else if (num3 < num2)
        //    {
        //        for (int i = 0; i < yoyoNumber; i++)
        //        {
        //            Vector2 vector2 = Main.rand.NextVector2Unit() * 16f;
        //            vector2.Normalize();
        //            vector2 *= 16f;
        //            float knockBack = (kb + 6f) / 2f;

        //            IEntitySource spawnSource = Terraria.Entity.InheritSource(Main.projectile[num]);
        //            if (num3 > 0)
        //            {
        //                Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 1f, 0f);
        //                return;
        //            }
        //            else
        //            {
        //                Projectile.NewProjectile(spawnSource, player.Center.X, player.Center.Y, vector2.X, vector2.Y, player.counterWeight, (int)(dmg * 0.8), knockBack, player.whoAmI, 0f, 0f);
        //            }
        //        }
        //    }
        //}
        #endregion
    }
}
