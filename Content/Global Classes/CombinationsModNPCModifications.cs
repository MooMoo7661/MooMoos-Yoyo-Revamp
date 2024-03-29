﻿using CombinationsMod.Content.Buffs;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.NPCS;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.GlobalClasses
{
    public class CombinationsModNPCModifications : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                List<int> shopToRemove = new List<int>
                {
                    ItemID.YoYoGlove,
                    ItemID.Gradient,
                    ItemID.FormatC,
                };

                for (int i = 0; i < shopToRemove.Count; i++)
                {
                    if (shop.TryGetEntry(shopToRemove[i], out var entry))
                    {
                        entry.Disable();
                    }
                }

                for (int i = ItemID.BlackCounterweight; i <= ItemID.YellowCounterweight; i++)
                {
                    if (shop.TryGetEntry(i, out var entry))
                    {
                        entry.Disable();
                    }
                }
            }

            if (shop.NpcType == NPCID.Cyborg)
            {
                shop.Add(ModContent.ItemType<NaniteString>(), Condition.DownedGolem);
            }
        }

        public override void GetChat(NPC npc, ref string chat)
        {
            if (npc.type == NPCID.Merchant || npc.type == NPCID.Cyborg || npc.type == NPCID.TravellingMerchant || npc.type == NPCID.GoblinTinkerer)
            {
                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    NPC npcCheck = Main.npc[i];

                    if (npcCheck.type == ModContent.NPCType<ExamplePerson>())
                    {
                        if (Main.rand.NextBool(3))
                        {
                            chat = "The thing I hate most about " + npcCheck.FullName + " is that I can never tell if he's smiling or not!";
                        }
                    }
                }
            }

            if (npc.type == ModContent.NPCType<ExamplePerson>() && npc.GivenName == "James Boned")
            {
                if (Main.rand.NextBool(5))
                {
                    chat = "The name's Boned. James Boned.";
                }
            }

            if (npc.type == NPCID.SkeletonMerchant)
            {
                bool hasAYoyo = false;

                foreach(Player player in Main.player)
                {
                    if (!player.active)
                    {
                        continue;
                    }

                    for (int i = 0; i < player.inventory.Length; i++)
                    {
                        Item item = player.inventory[i];
                        if (ItemID.Sets.Yoyo[item.type])
                        {
                            hasAYoyo = true;
                        }
                    }
                }

                if (!hasAYoyo && Main.rand.NextBool(2))
                {
                    chat = "Have you seen my brother? I bet if you collect a yoyo, he might decide to move in.";
                }
            }
        }
        public override void DrawEffects(NPC npc, ref Color drawColor)
        {
            if (npc.HasBuff<Clotted>())
            {
                Color lightColor = new Color(208, 6, 6);
                drawColor = lightColor;
            }
            else if (npc.HasBuff<Corrupt>())
            {
                Color lightColor = new Color(98, 75, 107);
                drawColor = lightColor;
            }

            if (npc.HasBuff<Omnipotence>())
            {
                Color lightColor = new Color(247, 255, 0);
                drawColor = lightColor;
            }

            if (npc.HasBuff<Hallowed>())
            {
                Color lightColor = new Color(244, 78, 255, 500);
                drawColor = lightColor;
            }

            if (npc.HasBuff<Frostbite>())
            {
                Color lightcolor = new Color(118, 255, 251, 255);
                drawColor = lightcolor;
            }
        }
    }
}

