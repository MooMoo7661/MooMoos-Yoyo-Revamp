using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Dusts
{
    public class AmethystSparkle : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            
            dust.noGravity = true;
            dust.scale *= 1.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.scale *= 0.99f;
         
            if (dust.scale < 1f)
            {
                dust.active = false;
            }

            return false;
        }
    }
}