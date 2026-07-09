using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class VanillaStatBuffs : GlobalProjectile
    {
        public override bool AppliesToEntity(Projectile entity, bool lateInstantiation) => entity.aiStyle == 99;        

        //public override void SetDefaults(Projectile proj)
        //{
        //    if (!ModLoader.HasMod("CalamityMod") && proj.usesLocalNPCImmunity == false)
        //    {
        //        proj.usesLocalNPCImmunity = true;
        //        proj.localNPCHitCooldown = (10 + (proj.YoyoData().MainYoyo ? 0 : 10)) * (proj.extraUpdates + 1);

        //        proj.usesIDStaticNPCImmunity = false;
        //        proj.idStaticNPCHitCooldown = 0;
        //    }
        //}
    }
}
