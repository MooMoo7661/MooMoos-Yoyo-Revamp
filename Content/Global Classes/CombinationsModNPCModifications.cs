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
            if (shop.NpcType == NPCID.Cyborg)
                shop.Add(ModContent.ItemType<NaniteString>(), Condition.DownedGolem);

            if (shop.NpcType == NPCID.SkeletonMerchant)
            {
                if (shop.TryGetEntry(ItemID.YoYoGlove, out var entry1))
                    entry1.Disable();
                
                if (shop.TryGetEntry(ItemID.Gradient, out var entry2))
                    entry2.Disable();
                
                if (shop.TryGetEntry(ItemID.FormatC, out var entry3))
                    entry3.Disable();

                for (int i = ItemID.BlackCounterweight; i <= ItemID.YellowCounterweight; i++)
                {
                    if (shop.TryGetEntry(i, out var entry))
                        entry.Disable();
                }
            }
        }

        public override void PostAI(NPC npc)
        {
            if (!npc.HasBuff(ModContent.BuffType<RootedDebuff>()) || Main.netMode == NetmodeID.MultiplayerClient)
            {
                timer = 60;
                return;
            }

            timer--;
            
            if (timer > 0)
            {
                return;
            }

            var proj = Projectile.NewProjectileDirect(Projectile.GetSource_NaturalSpawn(), npc.Center, Vector2.Zero, ProjectileID.Seed, 12, 0f);
            proj.usesLocalNPCImmunity = false;
            proj.localNPCHitCooldown = 10;
            proj.timeLeft = 12;
            proj.scale = 0.01f;

            timer = 30;
        }
    }
}

