using CombinationsMod.Content.Conditions;
using CombinationsMod.Content.Items.Accessories.Rings;
using CombinationsMod.Content.Items.Accessories.Strings;
using CombinationsMod.Content.Items.Accessories.YoyoGloves;
using CombinationsMod.Content.Items.Yoyos;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent.Bestiary;
using Terraria.GameContent.ItemDropRules;
using Terraria.GameContent.Personalities;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.Content.NPCS
{
    [AutoloadHead]
    [LegacyName("ExamplePerson")]
    public class YoyoMerchant : ModNPC
    {
        public int NumberOfTimesTalkedTo = 0;
        private static int ShimmerHeadIndex;

        private const string AccessoriesShop = "Accessories";
        private const string YoyoShop = "Yoyos";

        private static Profiles.StackedNPCProfile YoyoMerchantProfile;

        public override void Load()
        {
            ShimmerHeadIndex = Mod.AddNPCHeadTexture(Type, Texture + "_Shimmer_Head");
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[Type] = 25;
            NPCID.Sets.ExtraFramesCount[Type] = 9;
            NPCID.Sets.ShimmerTownTransform[Type] = true;

            NPCID.Sets.AllowDoorInteraction[Type] = true;
            NPCID.Sets.ActsLikeTownNPC[Type] = true;
            NPCID.Sets.DangerDetectRange[Type] = 900;
            NPCID.Sets.AttackAverageChance[Type] = 30;
            NPCID.Sets.SpawnsWithCustomName[Type] = true;
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

            YoyoMerchantProfile = new Profiles.StackedNPCProfile(
                new Profiles.DefaultNPCProfile(Texture, NPCHeadLoader.GetHeadSlot(HeadTexture), Texture + "_Party"),
                new Profiles.DefaultNPCProfile(Texture + "_Shimmer", ShimmerHeadIndex, Texture + "_Shimmer_Party")
            );
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

        public override bool CanChat()
        {
            return true;
        }

        public override List<string> SetNPCNameList()
        {
            return new()
            {
                "Jim Reaper",
                "Vincent Van Bone",
                "Mc Ribbs",
                "Jerry Spinefeld",
                "Jack Marrow",
                "James Boned",
                "Cal Cium",
                "Bony Stark",
                "Marrow Lynd",
                "Jack Skellington",
                "Bones Malone",
                "Reaper Ron"
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

        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                if (player.inventory.Any(item => ItemID.Sets.Yoyo[item.type]))
                {
                    return true;
                }
            }

            return false;
        }

        public override ITownNPCProfile TownNPCProfile()
        {
            return YoyoMerchantProfile;
        }

        public override string GetChat()
        {
            WeightedRandom<string> chat = new WeightedRandom<string>();

            if (Main.bloodMoon)
            {
                for (int i = 1; i < 8; i++)
                {
                    chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.YoyoMerchant.StandardDialogue" + i + "_BloodMoon"));
                }
            }
            else if (NPC.IsShimmerVariant)
            {
                for (int i = 1; i < 8; i++)
                {
                    chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.YoyoMerchant.StandardDialogue" + i + "_Shimmer"));
                }
            }
            else
            {
                for (int i = 1; i < 8; i++)
                {
                    chat.Add(Language.GetTextValue("Mods.CombinationsMod.Dialogue.YoyoMerchant.StandardDialogue" + i));
                }
            }
            

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
                .AddWithValue(ItemID.Rally, Item.buyPrice(0, 4, 50, 3))
                .AddWithValue(ItemType<ThinMint>(), Item.buyPrice(0, 3, 18, 0), Condition.BloodMoon)
                .AddWithValue(ItemID.CrimsonYoyo, Item.buyPrice(0, 7, 19, 58), Condition.DownedBrainOfCthulhu)
                .AddWithValue(ItemID.CorruptYoyo, Item.buyPrice(0, 7, 19, 58), Condition.DownedEaterOfWorlds)
                .AddWithValue(ItemType<Catacomb>(), Item.buyPrice(0, 6, 32, 4), Condition.InExpertMode, Condition.DownedSkeletron)
                .AddWithValue(ItemID.Valor, Item.buyPrice(0, 11, 31, 0), Condition.DownedSkeletron)
                .Add(ItemID.Code1, Condition.DownedEyeOfCthulhu, YoyoModConditions.EaterOfWorldsOrBrain, Condition.DownedSkeletron)
                .AddWithValue(ItemID.FormatC, Item.buyPrice(0, 16, 45, 32), Condition.Hardmode)
                .AddWithValue(ItemID.Gradient, Item.buyPrice(0, 18, 32, 12), Condition.DownedMechBossAll)
                .Add(ItemID.RedsYoyo, Condition.DownedGolem, Condition.Hardmode)
                .Add(ItemID.ValkyrieYoyo, Condition.DownedGolem, Condition.Hardmode)
                .AddWithValue(ItemType<CultistYoyo>(), Item.buyPrice(0, 43, 59, 32), Condition.DownedCultist, Condition.Hardmode)
                .AddWithValue(ItemID.Terrarian, Item.buyPrice(0, 56, 32, 69), Condition.DownedMoonLord, Condition.Hardmode);

            if (ModLoader.TryGetMod("VeridianMod", out Mod veridianMod))
                yoyosShop.Add(veridianMod.Find<ModItem>("Stickler").Type, Condition.DownedKingSlime);
            if (ModLoader.TryGetMod("TysYoyoRedux", out Mod tysYoyoRedux))
                yoyosShop.Add(tysYoyoRedux.Find<YoyoModItemLoader>("Spectrum").Type, Condition.DownedEmpressOfLight, Condition.Hardmode);
            yoyosShop.Register();

            var accessoriesShop = new NPCShop(Type, AccessoriesShop)

            .AddWithValue(ItemType<DarkBlueString>(), Item.buyPrice(0, 3, 20, 85))
            .AddWithValue(ItemType<DarkGreenString>(), Item.buyPrice(0, 3, 20, 85))
            .AddWithValue(ItemType<LightPinkString>(), Item.buyPrice(0, 3, 20, 85), Condition.DownedEyeOfCthulhu)
            .AddWithValue(ItemType<GrapeString>(), Item.buyPrice(0, 3, 20, 85), Condition.DownedQueenBee)
            .AddWithValue(ItemType<DarkTealString>(), Item.buyPrice(0, 3, 20, 85), YoyoModConditions.EaterOfWorldsOrBrain)
            .AddWithValue(ItemType<SlimyString>(), Item.buyPrice(0, 5, 37, 52), Condition.DownedKingSlime, Condition.InExpertMode)

            .AddWithValue(ItemType<AbilityRing>(), Item.buyPrice(0, 4, 10, 50), YoyoModConditions.NPCNotShimmered)
            .AddWithValue(ItemType<ShimmeringRing>(), Item.buyPrice(0, 4, 10, 50), Condition.DownedSkeletron, Condition.IsNpcShimmered)
            .AddWithValue(ItemType<AmberRing>(), Item.buyPrice(0, 1, 38, 12), Condition.DownedEyeOfCthulhu)
            .AddWithValue(ItemType<TopazRing>(), Item.buyPrice(0, 1, 38, 12), Condition.DownedEyeOfCthulhu)
            .AddWithValue(ItemType<AmethystRing>(), Item.buyPrice(0, 1, 38, 12), Condition.DownedEyeOfCthulhu)
            .AddWithValue(ItemType<RubyRing>(), Item.buyPrice(0, 1, 38, 12), Condition.DownedSkeletron)
            .AddWithValue(ItemType<SapphireRing>(), Item.buyPrice(0, 1, 38, 12), Condition.DownedSkeletron)
            .AddWithValue(ItemType<EmeraldRing>(), Item.buyPrice(0, 4, 21, 59), YoyoModConditions.EaterOfWorldsOrBrain)
            .AddWithValue(ItemType<DiamondRing>(), Item.buyPrice(0, 7, 20, 0), YoyoModConditions.EaterOfWorldsOrBrain)

            .AddWithValue(ItemID.BlueCounterweight, Item.buyPrice(0, 5, 28, 41), Condition.DownedSkeletron)
            .AddWithValue(ItemID.GreenCounterweight, Item.buyPrice(0, 5, 28, 41), Condition.DownedQueenBee)
            .AddWithValue(ItemID.YellowCounterweight, Item.buyPrice(0, 5, 28, 41), YoyoModConditions.EaterOfWorldsOrBrain)
            .AddWithValue(ItemID.BlackCounterweight, Item.buyPrice(0, 5, 28, 41), Condition.Hardmode)
            .AddWithValue(ItemID.RedCounterweight, Item.buyPrice(0, 5, 28, 41), Condition.DownedMechBossAny, Condition.Hardmode)

            .AddWithValue(ItemID.YoYoGlove, Item.buyPrice(0, 8, 49, 0), Condition.Hardmode)
            .AddWithValue(ItemType<SupportGlove>(), Item.buyPrice(0, 12, 0, 42), Condition.DownedPlantera)
            .AddWithValue(ItemID.YoyoBag, Item.buyPrice(0, 12, 53, 0), Condition.DownedSkeletron);

            accessoriesShop.Register();
        }

        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ItemID.Rally));
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
}