﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Buffs
{
    public class Corrupt : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.lifeRegen = 0;
            npc.lifeRegen -= 4;

            for (int i = 0; i < 2; i++)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.CorruptionThorns);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.3f;
            }

            Dust dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.ScourgeOfTheCorruptor);
            dust2.noGravity = true;
            dust2.noLight = false;
            dust2.scale = 1.3f;
        }
    }
}