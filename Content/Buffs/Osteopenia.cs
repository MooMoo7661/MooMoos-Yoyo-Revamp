﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Buffs
{
    public class Osteopenia : ModBuff
    {
        public int timer = 0;
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = true;

        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            timer++;

            if (timer == 20)
            {
                Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Bone);
                dust.noGravity = true;
                dust.noLight = false;
                dust.scale = 1.3f;
                timer = 0;
            }
        }
    }
}