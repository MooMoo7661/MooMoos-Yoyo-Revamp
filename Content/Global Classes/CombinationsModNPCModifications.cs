using CombinationsMod.Content.Debuffs;
using CombinationsMod.Content.Items.Accessories.Strings;
using System.Collections.Generic;

namespace CombinationsMod.GlobalClasses
{
    public class CombinationsModNPCModifications : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        int timer = 60;
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

                foreach(int item in shopToRemove)
                {
                    if (shop.TryGetEntry(item, out var entry))
                        entry.Disable();
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
                shop.Add(ModContent.ItemType<NaniteString>(), Condition.DownedGolem);
        }

        public override void PostAI(NPC npc)
        {
            if (npc.HasBuff(ModContent.BuffType<RootedDebuff>()) && Main.netMode != NetmodeID.MultiplayerClient)
            {
                timer--;
                if (timer <= 0)
                {
                    var dir = Vector2.One.RotatedByRandom(MathHelper.TwoPi) * 8f;
                    var proj = Projectile.NewProjectileDirect(Projectile.GetSource_NaturalSpawn(), npc.Center, Vector2.Zero, ProjectileID.Seed, 12, 0f);
                    proj.usesLocalNPCImmunity = false;
                    proj.localNPCHitCooldown = 10;
                    proj.timeLeft = 12;
                    proj.scale = 0.01f;
                    timer = 30;
                }
            }
            else
                timer = 60;
        }
    }
}

