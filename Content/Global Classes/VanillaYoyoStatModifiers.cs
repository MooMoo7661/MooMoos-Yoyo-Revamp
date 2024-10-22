using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CombinationsMod.Content.Global_Classes
{
    public class VanillaYoyoStatModifiers : GlobalItem
    {
        public override void SetDefaults(Item item)
        {
            int type = item.type;

            switch (type)
            {
                case ItemID.JungleYoyo:
                    item.damage = 16;
                    item.rare = ItemRarityID.Blue;
                    break;
                case ItemID.CorruptYoyo:
                    item.damage = 18;
                    item.rare = ItemRarityID.Orange;
                    break;
                case ItemID.CrimsonYoyo:
                    item.damage = 19;
                    item.rare = ItemRarityID.Orange;
                    break;
            }
        }
    }
}
