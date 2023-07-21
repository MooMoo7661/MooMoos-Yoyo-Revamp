using CombinationsMod.Projectiles.YoyoProjectiles;
using CombinationsMod.UI;
using Terraria.GameContent;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Terraria;
using Terraria.Graphics.Shaders; 
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.DataStructures;
using CombinationsMod.Projectiles.TrickYoyos;

using static Terraria.ModLoader.ModContent;
using static CombinationsMod.CombinationsModUtils.YoyoStrings;
using CombinationsMod.Items.Accessories.Strings;
using CombinationsMod.Items.Accessories.YoyoBags;

namespace CombinationsMod.GlobalClasses
{
    public class GlobalString : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            bool damageChanges = ModContent.GetInstance<YoyoModConfig>().VanillaYoyoDamageChanges;
            

            if (item.type == ItemID.TheEyeOfCthulhu && ModContent.GetInstance<YoyoModConfig>().EOCYoyoProgressionMovement)
            {
                item.damage = 49;
                item.knockBack = 3.9f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(0, 4, 2, 0);
            }
            else if (item.type == ItemID.Gradient && damageChanges)
            {
                item.damage = 57;
            }
            else if (item.type == ItemID.Code1 && damageChanges)
            {
                item.damage = 24;
            }
            else if ((item.type == ItemID.ValkyrieYoyo || item.type == ItemID.RedsYoyo) && damageChanges)
            {
                item.damage = 64;
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {

            player.GetModPlayer<YoyoModPlayer>().yoyoBag = true;
        }

        

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.trepidationRing && ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                damage *= 1.05f;
            }

            if (modPlayer.solarString || modPlayer.stardustString || modPlayer.vortexString || modPlayer.nebulaString
                && (ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99 || ItemID.Sets.Yoyo[item.type]))
            {
                damage *= 1.05f;
            }
        }

        public override void ModifyWeaponKnockback(Item item, Player player, ref StatModifier knockback)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (modPlayer.fortitudeRing)
            {
                knockback.Flat += 2f;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type >= 3309 && item.type <= 3314) // Is a counterweight
            {
                tooltips.Add(new TooltipLine(Mod, "CounterweightStackInfo", "[c/FFD7D7:Each Yoyo that hits a target will produce a counterweight]"));
            }

            if (Main.LocalPlayer.GetModPlayer<YoyoModPlayer>().yoyoRing)
            {
                switch (item.type)
                {
                    case ItemID.Cascade:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Automatically triggers]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates an explosion every 5 hits, which does 1.5x the yoyo damage]"));
                        break;

                    case ItemID.Valor:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Automatically triggers]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates homing water bolts that explode on contact, dealing area damage]"));
                        break;

                    case ItemID.CrimsonYoyo or ItemID.CorruptYoyo:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on hit]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Heals the user on hit]"));
                        break;

                    case ItemID.Rally:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates 3 swirling copies that deal 1/2 of the yoyo's damage]"));
                        break;

                    case ItemID.Code1:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates 6 swirling copies that deal 0.8x the yoyo damage]"));
                        break;

                    case ItemID.FormatC:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates 4 swirling copies that deal 100% of the yoyo's damage]\n[c/B3FDFF:These copies will split apart and fly away after the yoyo has been recalled]"));
                        break;

                    case ItemID.HelFire:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers on hit]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Inflicts the target with Combustion, dealing a large amount of fire damage]"));
                        break;

                    case ItemID.Amarok:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Shoots out 8 ice spikes every second that deal 0.6x the yoyo's damage]"));
                        break;

                    case ItemID.Gradient:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Creates 8 swirling copies that deal 100% of the yoyo damage]\n[c/B3FDFF:These copies will split apart and fly away after the yoyo has been recalled]\n[c/B3FDFF:When near an enemy, they will home in on them]"));
                        break;

                    case ItemID.TheEyeOfCthulhu:
                        tooltips.Insert(2, new TooltipLine(Mod, "Yoyo Ability", "[c/B3FDFF:Triggers automatically]"));
                        tooltips.Insert(3, new TooltipLine(Mod, "Yoyo Ability Description", "[c/B3FDFF:Special Ability : Has 2 stages]\n[c/B3FDFF:The first stage: The yoyo shoots lasers that deal 2x the yoyo's damage]\n[c/B3FDFF:The second stage: Triggers after 50 hits, the yoyo will shoot cursed flames]\n[c/B3FDFF:These flames deal half damage, but inflict cursed inferno]"));
                        break;
                }
            }

            switch (item.type)
            {
                case (int)blackString:
                case (int)whiteString:
                case (int)redString:
                case (int)orangeString:
                case (int)yellowString:
                case (int)limeString:
                case (int)greenString:
                case (int)tealString:
                case (int)cyanString:
                case (int)skyBlueString:
                case (int)blueString:
                case (int)purpleString:
                case (int)violetString:
                case (int)pinkString:
                case (int)brownString:
                case (int)rainbowString:
                    tooltips.Add(new TooltipLine(Mod, "YoyoStringInfo", "[c/6EAE6E:+150 yoyo range]"));
                    break;
                        
                case ItemID.YoyoBag:
                    if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                    {
                        int index = tooltips.FindIndex(tip => tip.Name.StartsWith("Tooltip"));
                        tooltips.RemoveAll(tip => tip.Name.StartsWith("Tooltip"));
                        tooltips.Add(new TooltipLine(Mod, "YoyoBagInfo", "Yoyos are recalled faster\nGives the user more accessory slots for yoyos"));
                    }
                    break;
            }
        }
    }
}
