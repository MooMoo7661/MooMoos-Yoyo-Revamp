using System.Linq;
using CombinationsMod.Content;
using CombinationsMod.Content.Configs;
using CombinationsMod.Content.Drills;
using CombinationsMod.Content.Keybindings;
using CombinationsMod.Content.ModPlayers;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CombinationsMod.GlobalClasses
{
    public class GlobalString : GlobalItem
    {
        public override bool InstancePerEntity => true;

        public override void SetDefaults(Item item)
        {
            bool damageChanges = GetInstance<YoyoModConfig>().VanillaYoyoDamageChanges;

            if (item.type == ItemID.Gradient && damageChanges)
            {
                item.damage = 57;
            }
            else if (item.type == ItemID.Code1 && damageChanges)
            {
                item.damage = 24;
            }
            else if ((item.type == ItemID.ValkyrieYoyo || item.type == ItemID.RedsYoyo) && damageChanges)
            {
                item.damage = 64;
            }
        }

        public override bool CanAccessoryBeEquippedWith(Item equippedItem, Item incomingItem, Player player)
        {
            if (ItemSets.YoyoBag[equippedItem.type] && ItemSets.YoyoBag[incomingItem.type])
                return false;

            if (ItemSets.YoyoString[equippedItem.type] && ItemSets.YoyoString[incomingItem.type])
                return false;

            if (ItemSets.DrillCasing[equippedItem.type] && ItemSets.DrillCasing[incomingItem.type])
                return false;

            return true;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            if (ItemID.Sets.Yoyo[item.type] && player.HeldItem == item)
            {
                player.GetModPlayer<YoyoModPlayer>().hitTracker = true;
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ItemID.YoyoBag)
                player.GetModPlayer<YoyoModPlayer>().yoyoBag = true;
        }

        public override void ModifyWeaponDamage(Item item, Player player, ref StatModifier damage)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();

            if (modPlayer.trepidationRing && ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                damage *= 1.05f;
            }

            if (modPlayer.solarString || modPlayer.stardustString || modPlayer.vortexString || modPlayer.nebulaString && (ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99 || ItemID.Sets.Yoyo[item.type]))
            {
                damage *= 1.05f;
            }

            if (modPlayer.shimmerBag)
            {
                damage *= 1.025f;
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            if (ItemID.Sets.Yoyo[item.type] || ContentSamples.ProjectilesByType[item.shoot].aiStyle == 99)
            {
                return player.ownedProjectileCounts[item.shoot] == 0;   
            }

            return true;
        }

        public override void ModifyWeaponKnockback(Item item, Player player, ref StatModifier knockback)
        {
            YoyoModPlayer modPlayer = player.GetModPlayer<YoyoModPlayer>();
            if (modPlayer.fortitudeRing)
            {
                knockback.Flat += 2f;
            }
        }
    }
}
