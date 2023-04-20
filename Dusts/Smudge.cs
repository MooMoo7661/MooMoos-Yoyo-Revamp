using Terraria;
using Terraria.ModLoader;

namespace CombinationsMod.Dusts
{
    public class Smudge : ModDust
    {
        public override void OnSpawn(Dust dust)
        {
            dust.noGravity = true;
            dust.velocity *= 0.5f;
            dust.velocity.Y -= 0.5f;
        }

        public override bool Update(Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.1f;
            dust.scale -= 0.07f;

            float light = 0.35f * dust.scale;

            Lighting.AddLight(dust.position, light, light, light);

            if (dust.scale < 0.8f)
            {
                dust.active = false;
            }
            return false;
        }
    }
}