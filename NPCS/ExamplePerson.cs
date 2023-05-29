using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;
using Terraria.GameContent.Personalities;
using Terraria.DataStructures;
using System.Collections.Generic;
using ReLogic.Content;
using Terraria.ModLoader.IO;
using CombinationsMod.Items.Accessories.Rings;

using static Terraria.ModLoader.ModContent;
using CombinationsMod.Items.Accessories.InfoAccessories;
using CombinationsMod.Items.Accessories.Strings;
using CombinationsMod.Items.Yoyos;
using CombinationsMod.Items.Accessories.Drills;
using CombinationsMod.Projectiles.TrickYoyos;
using CombinationsMod.Items.Accessories.Tricks;
using CombinationsMod.Items.Accessories.YoyoGloves;

namespace CombinationsMod.NPCS
{
    [AutoloadHead]
    public class ExamplePerson : ModNPC
    {
        public int NumberOfTimesTalkedTo = 0;
        public static bool useFirstShop;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Skeleton Peddler");
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.SkeletonMerchant];

            NPCID.Sets.ExtraFramesCount[Type] = NPCID.Sets.ExtraFramesCount[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackFrameCount[Type] = NPCID.Sets.AttackFrameCount[NPCID.SkeletonMerchant];
            NPCID.Sets.DangerDetectRange[Type] = 900;
            NPCID.Sets.AttackType[Type] = NPCID.Sets.AttackType[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackTime[Type] = NPCID.Sets.AttackTime[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackAverageChance[Type] = 30;

            NPCID.Sets.HatOffsetY[Type] = 0;



            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new NPCID.Sets.NPCBestiaryDrawModifiers(0)
            {
                Velocity = 1f,
                Direction = -1
            };

            NPCID.Sets.NPCBestiaryDrawOffset.Add(Type, drawModifiers);

            NPC.Happiness
                .SetBiomeAffection<DesertBiome>(AffectionLevel.Like)
                .SetBiomeAffection<ForestBiome>(AffectionLevel.Love)
                .SetBiomeAffection<SnowBiome>(AffectionLevel.Dislike)
                .SetNPCAffection(NPCID.Merchant, AffectionLevel.Love)
                .SetNPCAffection(NPCID.Demolitionist, AffectionLevel.Dislike);
        }

        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 18;
            NPC.height = 40;
            NPC.aiStyle = 7;
            NPC.damage = 10;
            NPC.defense = 29;
            NPC.lifeMax = 325;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.knockBackResist = 0.5f;

            NPC.lavaImmune = true;
            

            AnimationType = NPCID.Guide;
        }

        public override List<string> SetNPCNameList()
        {
            return new List<string>()
            {
                "Jim Reaper",
                "Vincent Van Bone",
                "McRibbs",
                "Jerry Spinefeld",
                "Jack Marrow",
                "James Boned",
            };
        }

        public override void SetBestiary(BestiaryDatabase database, BestiaryEntry bestiaryEntry)
        {
            bestiaryEntry.Info.AddRange(new IBestiaryInfoElement[] {
                BestiaryDatabaseNPCsPopulator.CommonTags.SpawnConditions.Biomes.Surface,

				new FlavorTextBestiaryInfoElement("This skeleton yearns to explore. He hates the underground and will do anything to stay away from it. He collects yoyos as a hobby, and will gladly sell them to you, for a price."),
            });
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Bone);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            // Requirements for the town NPC to spawn.

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                // Player has to have either an ExampleItem or an ExampleBlock in order for the NPC to spawn
                if (player.inventory.Any(item => ItemID.Sets.Yoyo[item.type]))
                {
                    return true;
                }
            }

            return false;
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return new ExamplePersonProfile();
        }

        public override void FindFrame(int frameHeight)
        {
            /*npc.frame.Width = 40;
			if (((int)Main.time / 10) % 2 == 0)
			{
				npc.frame.X = 40;
			}
			else
			{
				npc.frame.X = 0;
			}*/
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            // These are things that the NPC has a chance of telling you when you talk to it.
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue1"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue2"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue3"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue4"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue5"));

            NumberOfTimesTalkedTo++;
           /* if (NumberOfTimesTalkedTo >= 10)
            {
                //This counter is linked to a single instance of the NPC, so if ExamplePerson is killed, the counter will reset.
                chat.Add(Language.GetTextValue("Mods.ExampleMod.Dialogue.ExamplePerson.TalkALot"));
            }*/

            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = "Yoyo " + Language.GetTextValue("LegacyInterface.28");
            button2 = "Accessory " + Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                useFirstShop = true;
                shop = true;
            }
            else
            {
                useFirstShop = false;
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (useFirstShop)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Rally);
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 7);
                nextSlot++;

                if (Main.bloodMoon)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Rally);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 5);
                    nextSlot++;
                }

                if (WorldGen.crimson)
                {
                    if (NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.CrimsonYoyo);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                        nextSlot++;
                    }
                }
                else
                {
                    if (!NPC.downedBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.CorruptYoyo);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                    }
                }

                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemType<Catacomb>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 16);
                    nextSlot++;
                }

                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemType<TheQueensGambit>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 20);
                    nextSlot++;
                }

                if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
                {
                    if (NPC.downedSlimeKing)
                    {
                        shop.item[nextSlot].SetDefaults(veridianMod.Find<ModItem>("Stickler").Type);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 13);
                        nextSlot++;
                    }
                }

                if (NPC.downedBoss1 && NPC.downedBoss2 && NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Code1);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 14);
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Code2);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 20);
                    nextSlot++;

                    if (NPC.downedMechBoss1)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.HelFire);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 23);
                        nextSlot++;
                    }

                    if (NPC.downedMechBoss2)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Amarok);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 26);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.TheEyeOfCthulhu);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 30);
                        nextSlot++;
                    }

                    if (NPC.downedMechBoss3)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Gradient);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 34);
                        nextSlot++;
                    }

                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Yelets);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 37);
                        nextSlot++;
                    }

                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.RedsYoyo);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 40);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.ValkyrieYoyo);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 40);
                        nextSlot++;
                    }

                    if (NPC.downedAncientCultist)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<CultistYoyo>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(platinum: 1);
                        nextSlot++;
                    }

                    if (NPC.downedFishron)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Kraken);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 42);
                        nextSlot++;
                    }

                    if (ModLoader.TryGetMod("TysYoyoRedux", out Mod tysYoyoRedux))
                    {
                        if (NPC.downedEmpressOfLight)
                        {
                            shop.item[nextSlot].SetDefaults(tysYoyoRedux.Find<ItemLoader>("Spectrum").Type);
                            shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 48);
                            nextSlot++;

                        }
                    }

                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.Terrarian);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(platinum: 2);
                    }
                }

            }
            else // Second Shop
            {
                shop.item[nextSlot].SetDefaults(ItemType<HitDisplay>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 4);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemType<SpeedDisplay>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 6);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemType<DarkBlueString>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 9);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemType<DarkGreenString>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 9);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemType<AmethystRing>());
                shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 3);
                nextSlot++;

                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ItemType<LightPinkString>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 9);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<AbilityRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 15);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<TopazRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 4);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<AmberRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 4);
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.BlueCounterweight);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<RubyRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 7);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<SapphireRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 7);
                    nextSlot++;

                    if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.YoyoBag);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 18);
                        nextSlot++;
                    }
                }

                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.YellowCounterweight);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<EmeraldRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 13);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<DiamondRing>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 13);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<DarkTealString>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 9);
                    nextSlot++;
                }

                if (NPC.downedQueenBee)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.GreenCounterweight);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemType<GrapeString>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 9);
                    nextSlot++;
                }

                if (NPC.downedSlimeKing && (Main.expertMode || Main.masterMode))
                {
                    shop.item[nextSlot].SetDefaults(ItemType<SlimyString>());
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 14);
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.YoYoGlove);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 25);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.BlackCounterweight);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                    nextSlot++;

                    if (ModContent.GetInstance<YoyoModConfig>().EnableModifiedYoyoBag)
                    {
                        shop.item[nextSlot].SetDefaults(ItemID.YoyoBag);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 30);
                        nextSlot++;
                    }

                    if (NPC.downedPlantBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<SupportGlove>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 15);
                        nextSlot++;
                    }

                    if (NPC.downedGolemBoss)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<TsurugiDrillCasing>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 30);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemID.RedCounterweight);
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 12);
                        nextSlot++;
                    }

                    if (NPC.downedMoonlord)
                    {
                        shop.item[nextSlot].SetDefaults(ItemType<SolarString>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 26);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemType<NebulaString>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 26);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemType<VortexString>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 26);
                        nextSlot++;

                        shop.item[nextSlot].SetDefaults(ItemType<StardustString>());
                        shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 26);
                        nextSlot++;
                    }
                }
            }
        }
            
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Rally));
        }

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue) => true;

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }

                Dust.NewDustPerfect(NPC.Center + position, DustID.WaterCandle, Vector2.Zero).noGravity = true;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        // todo: implement
         public override void TownNPCAttackProj(ref int projType, ref int attackDelay) 
        {
            projType = ProjectileID.Bone;
        	attackDelay = 1;
         }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 18f;
            randomOffset = 0.2f;
        }

        public override void LoadData(TagCompound tag)
        {
            NumberOfTimesTalkedTo = tag.GetInt("numberOfTimesTalkedTo");
        }

        public override void SaveData(TagCompound tag)
        {
            tag["numberOfTimesTalkedTo"] = NumberOfTimesTalkedTo;
        }
    }

    public class ExamplePersonProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
                return ModContent.Request<Texture2D>("CombinationsMod/NPCS/ExamplePerson");

            if (npc.altTexture == 1)
                return ModContent.Request<Texture2D>("CombinationsMod/NPCS/ExamplePerson_Alt");

            return ModContent.Request<Texture2D>("CombinationsMod/NPCS/ExamplePerson");
        }

        public int GetHeadTextureIndex(NPC npc) => ModContent.GetModHeadSlot("CombinationsMod/NPCS/ExamplePerson_Head");
    }
}