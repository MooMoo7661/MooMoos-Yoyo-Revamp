using CombinationsMod.Projectiles.Explosions;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Buffs
{
	public class Combustion : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Combustion");
			Description.SetDefault("Exploding in fire");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			
		}

		public override void Update(NPC npc, ref int buffIndex)
		{
			npc.lifeRegen = 0;
			npc.lifeRegen -= 12;

			if (Main.rand.NextBool(8))
			{
				for (int i = 0; i < 6; i++)
				{
                    Dust dust2 = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Torch);
                    dust2.noGravity = true;
                    dust2.noLight = false;
                    dust2.scale = 1.8f;

                    Vector2 speed = Main.rand.NextVector2Circular(1f, 1f) * 6f;
                    dust2.velocity = speed;

					if (Main.rand.NextBool(20))
					{
						int goreSmoke = Gore.NewGore(NPC.GetSource_None(), npc.position, default, Main.rand.Next(61, 64));
						Main.gore[goreSmoke].velocity *= 0.4f;

						Vector2 direction = Utils.RotatedByRandom(new(1f, 1f), MathHelper.ToRadians(360f));
						Main.gore[goreSmoke].velocity.X += direction.X;
						Main.gore[goreSmoke].velocity.Y += direction.Y;
					}
                }
			}

            Dust dust = Dust.NewDustDirect(npc.position, npc.width, npc.height, DustID.Torch);
            dust.noGravity = true;
			dust.noLight = false;
            dust.scale = 1.8f;

			if (Main.rand.NextBool(10))
			{
				for (int i = 0; i < 8; i++)
				{
                    Vector2 speed = Main.rand.NextVector2Circular(1f, 1f) * 6f;
                    dust.velocity = speed;
				}
			}
        }
	}
}