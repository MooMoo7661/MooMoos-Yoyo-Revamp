using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Buffs
{
	public class Hallowed : ModBuff
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
			npc.lifeRegen -= 8;

            if (Main.rand.NextBool(5))
			{
				for (int i = 0; i < 2; i++)
				{
					Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.YellowStarDust);
					dust.noGravity = true;
					dust.noLight = false;
					dust.scale = 1.3f;
				}
			}

        }
	}
}