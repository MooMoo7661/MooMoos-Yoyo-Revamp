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

                    if (npcCheck.type == ModContent.NPCType<YoyoMerchant>())
                    {
                        if (Main.rand.NextBool(3))
                        {
                            chat = "The thing I hate most about " + npcCheck.FullName + " is that I can never tell if he's smiling or not!";
                        }
                    }
                }
            }

            if (npc.type == ModContent.NPCType<YoyoMerchant>() && npc.GivenName == "James Boned")
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
    }
}

