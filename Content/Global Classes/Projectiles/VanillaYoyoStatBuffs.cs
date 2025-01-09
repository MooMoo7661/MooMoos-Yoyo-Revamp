using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class VanillaStatBuffs : GlobalProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Rally] = 8f;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.CorruptYoyo] = 12f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.CorruptYoyo] = 220f;
            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.CorruptYoyo] = 13;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.CrimsonYoyo] = 10f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.CrimsonYoyo] = 230f;
            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.CrimsonYoyo] = 13.3f;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.JungleYoyo] = 9f;
            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.JungleYoyo] = 11;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.JungleYoyo] = 170;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.FormatC] = 16f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.FormatC] = 250;

            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.RedsYoyo] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.RedsYoyo] = 360;
            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.ValkyrieYoyo] = 18f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.ValkyrieYoyo] = 360;

            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.Kraken] = 17.5f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.Kraken] = 380;

            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.Kraken] = 17.5f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.Kraken] = 380;

            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.TheEyeOfCthulhu] = 18.5f;
            ProjectileID.Sets.YoyosMaximumRange[ProjectileID.TheEyeOfCthulhu] = 400;

            ProjectileID.Sets.YoyosTopSpeed[ProjectileID.Terrarian] = 19.4f;

            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Yelets] = -1f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Code1] = 13f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Gradient] = 18f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.Amarok] = 17f;
            ProjectileID.Sets.YoyosLifeTimeMultiplier[ProjectileID.HelFire] = 17f;
        }
    }
}
