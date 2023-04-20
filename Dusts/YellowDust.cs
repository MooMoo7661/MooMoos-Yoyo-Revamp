using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Dusts
{
    public class YellowDust : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = false;
            dust.scale = 2f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X;
            dust.scale -= 0.1f;

            float light = 0.35f * dust.scale;

            Lighting.AddLight(dust.position, light, light, light);

            if (dust.scale < 0.5f)
            {
                dust.active = false;
            }

            return false;
        }
    }
}