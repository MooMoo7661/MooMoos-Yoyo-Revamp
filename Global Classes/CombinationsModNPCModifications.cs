using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CombinationsMod.Buffs;
using System.Linq;
using CombinationsMod.Items.Accessories.InfoAccessories;
using CombinationsMod.Items.Accessories.Rings;
using Terraria.GameContent.ItemDropRules;
using CombinationsMod.Items.Accessories.YoyoGloves;
using Terraria.ModLoader.UI.ModBrowser;
using CombinationsMod.Items.Accessories.YoyoBearings;
using CombinationsMod.NPCS;
using static Terraria.ID.ItemID;

namespace CombinationsMod.GlobalClasses
{
    public class CombinationsModNPCModifications : GlobalNPC
    {
        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            bool RemoveYoyoGlove = ModContent.GetInstance<YoyoModConfig>().RemoveYoyoGlove;

            if (type == NPCID.SkeletonMerchant)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (shop.item[i].type == YoYoGlove && RemoveYoyoGlove)
                    {
                        shop.item[i].SetDefaults(Bone);
                        shop.item[i].shopCustomPrice = Item.buyPrice(silver: 18);
                    }
                    else if (shop.item[i].type == Gradient || shop.item[i].type == Code2 || shop.item[i].type == FormatC)
                    {
                        shop.item[i].SetDefaults(StickyGlowstick);
                        shop.item[i].shopCustomPrice = Item.buyPrice(silver: 23);
                    }
                    else if (shop.item[i].type >= 3309 && shop.item[i].type <= 3314)
                    {
                        shop.item[i].SetDefaults(MagicMirror);
                        shop.item[i].shopCustomPrice = Item.buyPrice(gold: 7);
                    }
                }
            }

            if (type == NPCID.TravellingMerchant)
            {
                for (int i = 0; i < 40; i++)
                {
                    if (shop.item[i].type == Code2 || shop.item[i].type == Code1)
                    {
                        shop.item[i].SetDefaults(Wood);
                        shop.item[i].shopCustomPrice = Item.buyPrice(copper: 40);
                    }
                }
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

