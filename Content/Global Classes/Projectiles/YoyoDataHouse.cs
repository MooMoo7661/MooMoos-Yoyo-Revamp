using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    // Naming (mostly) unrelated to a certain vicodin-fueled individual
    public class YoyoDataHouse : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile proj, bool lateInstantiation) => proj.aiStyle == 99;

        public int hits = 0;
        public bool mainYoyo = false;

        public override void OnSpawn(Projectile proj, IEntitySource source)
        {
            mainYoyo = proj.ai[2] == 0;
        }
    }
}
