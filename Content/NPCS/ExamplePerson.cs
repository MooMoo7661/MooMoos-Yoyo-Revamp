using CombinationsMod.Content.Conditions;
using CombinationsMod.Content.Items.Accessories.Drills;
using CombinationsMod.Content.Items.Accessories.InfoAccessories;
using CombinationsMod.Content.Items.Accessories.Rings;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Accessories.YoyoGloves;
using CombinationsMod.Content.Items.Yoyos;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.NPCS
{
    [AutoloadHead]
    public class ExamplePerson : ModNPC
    {
        public int NumberOfTimesTalkedTo = 0;

        public const string AccessoriesShop = "Accessories";
        public const string YoyoShop = "Yoyos";

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = Main.npcFrameCount[NPCID.SkeletonMerchant];

            NPCID.Sets.ExtraFramesCount[Type] = NPCID.Sets.ExtraFramesCount[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackFrameCount[Type] = NPCID.Sets.AttackFrameCount[NPCID.SkeletonMerchant];
            NPCID.Sets.DangerDetectRange[Type] = 900;
            NPCID.Sets.AttackType[Type] = NPCID.Sets.AttackType[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackTime[Type] = NPCID.Sets.AttackTime[NPCID.SkeletonMerchant];
            NPCID.Sets.AttackAverageChance[Type] = 30;

            NPCID.Sets.HatOffsetY[Type] = 0;

            NPCID.Sets.NPCBestiaryDrawModifiers drawModifiers = new()
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

        public override void HitEffect(NPC.HitInfo hit)
        {
            int num = NPC.life > 0 ? 1 : 5;

            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Bone);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs)/* tModPorter Suggestion: Copy the implementation of NPC.SpawnAllowed_Merchant in vanilla if you to count money, and be sure to set a flag when unlocked, so you don't count every tick. */
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

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue1"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue2"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue3"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue4"));
            chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.ExamplePerson.StandardDialogue5"));

            NumberOfTimesTalkedTo++;
            return chat;
        }

        public override void SetChatButtons(ref string button, ref string button2)
        { // What the chat buttons are when you open up the chat UI
            button = "Yoyo " + Language.GetTextValue("LegacyInterface.28");
            button2 = "Accessory " + Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref string shop)
        {
            if (firstButton)
            {
                shop = YoyoShop;
            }
            else
            {
                shop = AccessoriesShop;
            }
        }

        public override void AddShops()
        {
            var yoyosShop = new NPCShop(Type, YoyoShop)
                .Add(ItemID.Rally)
                .Add(ItemType<ThinMint>(), Condition.BloodMoon)
                .Add(ItemID.CrimsonYoyo, Condition.DownedBrainOfCthulhu)
                .Add(ItemID.CorruptYoyo, Condition.DownedEaterOfWorlds)
                .Add(ItemType<Catacomb>(), YoyoModConditions.MasterOrExpertMode, Condition.DownedSkeletron)
                .Add(ItemType<TheQueensGambit>(), YoyoModConditions.MasterOrExpertMode, Condition.DownedQueenBee)
                .Add(ItemID.Valor, Condition.DownedSkeletron)
                .Add(ItemID.Code1, Condition.DownedEyeOfCthulhu, YoyoModConditions.EaterOfWorldsOrBrain, Condition.DownedSkeletron, Condition.DownedQueenBee, Condition.DownedKingSlime)
                .Add(ItemID.FormatC, Condition.Hardmode)
                .Add(ItemID.HelFire, Condition.DownedDestroyer, Condition.Hardmode)
                .Add(ItemID.Amarok, Condition.DownedTwins, Condition.Hardmode)
                .Add(ItemID.TheEyeOfCthulhu, Condition.DownedTwins, Condition.Hardmode)
                .Add(ItemID.Gradient, Condition.DownedSkeletronPrime, Condition.Hardmode)
                .Add(ItemID.Yelets, Condition.DownedPlantera, Condition.Hardmode)
                .Add(ItemID.RedsYoyo, Condition.DownedGolem, Condition.Hardmode)
                .Add(ItemID.ValkyrieYoyo, Condition.DownedGolem, Condition.Hardmode)
                .Add(ItemType<ChristmasBulb>(), Condition.DownedIceQueen, Condition.Hardmode)
                .Add(ItemType<Mambele>(), Condition.DownedPumpking, Condition.Hardmode)
                .Add(ItemType<CultistYoyo>(), Condition.DownedCultist, Condition.Hardmode)
                .Add(ItemID.Kraken, Condition.DownedDukeFishron, Condition.Hardmode)
                .Add(ItemID.Terrarian, Condition.DownedMoonLord, Condition.Hardmode);

            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
                yoyosShop.Add(veridianMod.Find<ModItem>("Stickler").Type, Condition.DownedKingSlime);
            if (ModLoader.TryGetMod("TysYoyoRedux", out Mod tysYoyoRedux))
                yoyosShop.Add(tysYoyoRedux.Find<ItemLoader>("Spectrum").Type, Condition.DownedEmpressOfLight, Condition.Hardmode);
            yoyosShop.Register();

            var accessoriesShop = new NPCShop(Type, AccessoriesShop)
            .Add(ItemType<HitDisplay>())
            .Add(ItemType<SpeedDisplay>())
            .Add(ItemType<DarkBlueString>())
            .Add(ItemType<DarkGreenString>())
            .Add(ItemType<LightPinkString>(), Condition.DownedEyeOfCthulhu)
            .Add(ItemType<AbilityRing>(), Condition.DownedSkeletron)
            .Add(ItemID.BlueCounterweight, Condition.DownedSkeletron)
            .Add(ItemType<RubyRing>(), Condition.DownedSkeletron)
            .Add(ItemType<SapphireRing>(), Condition.DownedSkeletron)
            .Add(ItemID.GreenCounterweight, Condition.DownedQueenBee)
            .Add(ItemType<GrapeString>(), Condition.DownedQueenBee)
            .Add(ItemID.YoYoGlove, Condition.Hardmode)
            .Add(ItemID.BlackCounterweight, Condition.Hardmode)
            .Add(ItemType<SlimyString>(), Condition.DownedKingSlime, YoyoModConditions.MasterOrExpertMode)
            .Add(ItemType<AmberRing>(), Condition.DownedEyeOfCthulhu)
            .Add(ItemType<TopazRing>(), Condition.DownedEyeOfCthulhu)
            .Add(ItemType<AmethystRing>(), Condition.DownedEyeOfCthulhu)
            .Add(ItemID.YellowCounterweight, YoyoModConditions.EaterOfWorldsOrBrain)
            .Add(ItemType<EmeraldRing>(), YoyoModConditions.EaterOfWorldsOrBrain)
            .Add(ItemType<DiamondRing>(), YoyoModConditions.EaterOfWorldsOrBrain)
            .Add(ItemType<DarkTealString>(), YoyoModConditions.EaterOfWorldsOrBrain)
            .Add(ItemID.YoyoBag, Condition.DownedSkeletron)
            .Add(ItemType<SupportGlove>(), Condition.DownedPlantera)


            .Add(ItemType<TreeClippersDrillCasing>(), Condition.DownedIceQueen, Condition.Hardmode)
            .Add(ItemType<HorsemansDrillCasing>(), Condition.DownedPumpking, Condition.Hardmode)
            .Add(ItemType<TsurugiDrillCasing>(), Condition.DownedGolem, Condition.Hardmode)
            .Add(ItemID.RedCounterweight, Condition.DownedGolem, Condition.Hardmode);

            accessoriesShop.Register();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Rally));
        }

        public override bool CanGoToStatue(bool toKingStatue) => true;

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
    }

    public class ExamplePersonProfile : ITownNPCProfile
    {
        public int RollVariation() => 0;
        public string GetNameForVariant(NPC npc) => npc.getNewNPCName();

        public Asset<Texture2D> GetTextureNPCShouldUse(NPC npc)
        {
            if (npc.IsABestiaryIconDummy && !npc.ForcePartyHatOn)
                return Request<Texture2D>("CombinationsMod/Content/NPCS/ExamplePerson");

            if (npc.altTexture == 1)
                return Request<Texture2D>("CombinationsMod/Content/NPCS/ExamplePerson_Alt");

            return Request<Texture2D>("CombinationsMod/Content/NPCS/ExamplePerson");
        }

        public int GetHeadTextureIndex(NPC npc) => GetModHeadSlot("CombinationsMod/Content/NPCS/ExamplePerson_Head");
    }
}