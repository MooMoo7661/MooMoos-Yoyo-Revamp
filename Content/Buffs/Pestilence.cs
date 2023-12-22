using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Buffs
{
    public class Pestilence : ModBuff
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
            npc.lifeRegen -= 12;

            if (Main.rand.NextBool(5))
            {
                for (int i = 0; i < 2; i++)
                {
                    Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Poisoned);
                    dust.noGravity = true;
                    dust.noLight = false;
                    dust.scale = 1.8f;

                    Dust dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Blood);
                    dust2.noGravity = true;
                    dust2.noLight = false;
                    dust2.scale = 1.3f;
                }
            }
        }
    }
}