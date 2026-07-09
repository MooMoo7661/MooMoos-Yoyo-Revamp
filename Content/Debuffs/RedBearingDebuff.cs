using Terraria;

namespace CombinationsMod.Content.Debuffs
{
    public class RedBearingDebuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            if (Main.rand.NextBool(2))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Main.rand.NextBool(4))
                        continue;

                    var vel = Main.rand.NextVector2CircularEdge(1f, 1f);
                    var dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Blood, vel.X, vel.Y);
                    dust.scale = 0.8f + Main.rand.NextFloat(-0.4f, 0.3f);
                }
            }
        }
    }
}
