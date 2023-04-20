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

namespace CombinationsMod.GlobalClasses
{
    public class GlobalString : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            if (item.type == ItemID.TheEyeOfCthulhu)
            {
                item.damage = 49;
                item.knockBack = 3.9f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(0, 4, 2, 0);
            }
            else if (item.type == ItemID.Gradient)
            {
                item.damage = 57;
            }
        }


        public override bool? PrefixChance(Item item, int pre, UnifiedRandom rand)
        {
            if (item.type >= 3309 && item.type <= 3314)
            {
                return false;
            }

            return true;
        }
        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.trepidationRing && ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                damage *= 1.10f;
            }

            if (modPlayer.solarString)
            {
                damage *= 1.05f;
            }
        }
        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            if (item.type >= 3309 && item.type <= 3314)
            {
                return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<CounterweightSlot>().Type);
            }

            if (item.type == ItemID.YoYoGlove)
            {
                return modded && (LoaderManager.Get<AccessorySlotLoader>().Get(slot, player).Type == ModContent.GetInstance<YoyoGloveSlot>().Type);
            }

            return true;
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (item.type >= 3309 && item.type <= 3314) // Is a counterweight
            {
                tooltips.Insert(4, new TooltipLine(Mod, "CounterweightStackInfo", "[c/FFD7D7:Each Yoyo that hits a target will produce a counterweight]"));
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
        }
    }
}
