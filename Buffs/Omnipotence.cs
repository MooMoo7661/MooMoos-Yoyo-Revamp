using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Buffs
{
	public class Omnipotence : ModBuff
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Omnipotence");
			Description.SetDefault("Glowing");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = false;
			Main.buffNoSave[Type] = true;
			BuffID.Sets.LongerExpertDebuff[Type] = true;
			
		}
	}
}