using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class VanillaStatBuffs : GlobalProjectile
    {
        public override void SetDefaults(Projectile proj)
        {
            int type = proj.type;
            switch (proj.type)
            {
                case ProjectileID.Rally:
                    ProjectileID.Sets.YoyosLifeTimeMultiplier[type] = 8f;
                    break;
                case ProjectileID.CorruptYoyo:
                    ProjectileID.Sets.YoyosLifeTimeMultiplier[type] = 12f;
                    ProjectileID.Sets.YoyosMaximumRange[type] = 220f;
                    ProjectileID.Sets.YoyosTopSpeed[type] = 13;
                    break;
                case ProjectileID.CrimsonYoyo:
                    ProjectileID.Sets.YoyosLifeTimeMultiplier[type] = 10f;
                    ProjectileID.Sets.YoyosMaximumRange[type] = 230f;
                    ProjectileID.Sets.YoyosTopSpeed[type] = 13.3f;
                    break;
                case ProjectileID.JungleYoyo:
                    ProjectileID.Sets.YoyosLifeTimeMultiplier[type] = 9f;
                    ProjectileID.Sets.YoyosTopSpeed[type] = 11;
                    ProjectileID.Sets.YoyosMaximumRange[type] = 170;
                    break;
                case ProjectileID.Code1:
                    ProjectileID.Sets.YoyosLifeTimeMultiplier[type] = 13f;
                    break;

            }
        }
    }
}
