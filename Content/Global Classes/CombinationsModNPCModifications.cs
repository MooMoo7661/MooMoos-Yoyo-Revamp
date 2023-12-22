using CombinationsMod.Content.Buffs;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.NPCS;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ID.ItemID;

namespace CombinationsMod.GlobalClasses
{
    public class CombinationsModNPCModifications : GlobalNPC
    {
        public override void ModifyShop(NPCShop shop)
        {
            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                int[] arr = new int[3];
                arr[0] = ItemID.Gradient;
                arr[1] = ItemID.FormatC;
                arr[2] = ItemID.YoYoGlove;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (shop.TryGetEntry(arr[i], out var entry))
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

                for (int k = 0; k < 255; k++)
                {
                    Player player = Main.player[k];
                    if (!player.active)
                    {
                        continue;
                    }

                    for (int i = 0; i < 50; i++)
                    {
                        Item item = player.inventory[i];
                        if (Sets.Yoyo[item.type])
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
            if (npc.HasBuff<Clotted>()) // Npcs draw as a red color when Clotted debuff is applied. For reference, this is applied by the Muscle Yoyo
            {
                Color lightColor = new Color(208, 6, 6);
                drawColor = lightColor;
            }
            else if (npc.HasBuff<Corrupt>()) // Npcs draw as a purple color when Corrupt debuff is applied. For reference, this is applied by the Enervation Yoyo
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
                //Color lightColor = new Color(254, 255, 199);
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

