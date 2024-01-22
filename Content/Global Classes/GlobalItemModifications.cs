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

            if (item.type == ItemID.TheEyeOfCthulhu && GetInstance<YoyoModConfig>().EOCYoyoProgressionMovement)
            {
                item.damage = 49;
                item.knockBack = 3.9f;
                item.rare = ItemRarityID.Pink;
                item.value = Item.sellPrice(0, 4, 2, 0);
            }
            else if (item.type == ItemID.Gradient && damageChanges)
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
