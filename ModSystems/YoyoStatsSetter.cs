using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.ModSystems
{
    public class YoyoStatsSetter : ModSystem
    {
        public override void PostSetupContent()
        {
            if (ModDetector.CalamityLoaded)
            {

            }
        }
    }

    public class GlobalYoyoProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile projectile, bool lateInstantiation) => projectile.aiStyle == 99;
    }
}
