using CombinationsMod.Content.Items.Accessories.Drills;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace CombinationsMod.Content.Drills
{
    public class IronDrill : BaseDrill
    {
        // Called "drills" because this is the default drill stats. 

        protected override int DrillTier => 100; //Hellstone Pickaxe
        protected override int DrillCooldown => 33; // Time it takes in ticks to mine blocks.

        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22; // Sound ID 22 is drill, sound 23 is drill end

        protected override int Width => 32;
        protected override int Height => 32;

        public override int DrillItem => ModContent.ItemType<YoyoDrillCasing>();
    }

    public class PalladiumDrill : BaseDrill
    {
        protected override int DrillTier => 130; // Palladium Pickaxe
        protected override int DrillCooldown => 29;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 36;
        protected override int Height => 36;

        public override int DrillItem => ModContent.ItemType<PalladiumCasing>();
    }
    public class CobaltDrill : BaseDrill
    {
        protected override int DrillTier => 110; // Cobalt Pickace
        protected override int DrillCooldown => 29;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 36;
        protected override int Height => 36;

        public override int DrillItem => ModContent.ItemType<CobaltDrillCasing>();
    }

    public class OrichalcumDrill : BaseDrill
    {
        protected override int DrillTier => 165; // Orichalcum Drill
        protected override int DrillCooldown => 27;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 40;
        protected override int Height => 40;

        public override int DrillItem => ModContent.ItemType<OrichalcumDrillCasing>();
    }
    public class MythrilDrill : BaseDrill
    {
        protected override int DrillTier => 150; // Mythril Drill
        protected override int DrillCooldown => 27;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 40;
        protected override int Height => 40;

        public override int DrillItem => ModContent.ItemType<MythrilDrillCasing>();
    }
    public class AdamantiteDrill : BaseDrill
    {
        protected override int DrillTier => 180; // Adamantite Drill
        protected override int DrillCooldown => 23;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 44;
        protected override int Height => 44;

        public override int DrillItem => ModContent.ItemType<AdamantiteDrillCasing>();
    }
    public class TitaniumDrill : BaseDrill
    {
        protected override int DrillTier => 190; // Titanium Drill
        protected override int DrillCooldown => 22;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 44;
        protected override int Height => 44;

        public override int DrillItem => ModContent.ItemType<TitaniumDrillCasing>();
    }
    public class Hakapik : BaseDrill
    {
        protected override int DrillTier => 200; // Hallowed Drill
        protected override int DrillCooldown => 19;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<HakapikDrillCasing>();
    }
    public class Mattock : BaseDrill
    {
        protected override int DrillTier => 200; // Chlorophyte Drill
        protected override int DrillCooldown => 19;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<MattockDrillCasing>();
    }
    public class SpectralShredder : BaseDrill
    {
        protected override int DrillTier => 200; // Spectre Drill
        protected override int DrillCooldown => 19;
        protected override int BlockRangeStyle => 3; // Diamond Shape
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<SpectralShredderCasing>();
    }
    public class ShroomiteShredder : BaseDrill
    {
        protected override int DrillTier => 200; // Shroomite Claws
        protected override int DrillCooldown => 17;
        protected override int BlockRangeStyle => 1;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<ShroomiteShredderCasing>();
    }
    public class Tsurugi : BaseDrill
    {
        protected override int DrillTier => 210; // Picksaw
        protected override int DrillCooldown => 18;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 52;
        protected override int Height => 52;

        public override int DrillItem => ModContent.ItemType<TsurugiDrillCasing>();
    }
    public class HorsemansDrill : BaseDrill
    {
        protected override int DrillTier => 200; // Same as Shroomite Shredder and Spectral Shredder
        protected override int DrillCooldown => 15;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<HorsemansDrillCasing>();
    }
    public class TreeClippers : BaseDrill
    {
        protected override int DrillTier => 200; // Same as Shroomite Shredder and Spectral Shredder
        protected override int DrillCooldown => 15;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 48;
        protected override int Height => 48;

        public override int DrillItem => ModContent.ItemType<TreeClippersDrillCasing>();
    }
    public class SolarDrill : BaseDrill
    {
        protected override int DrillTier => 225; // Solar Pickaxe
        protected override int DrillCooldown => 13;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 52;
        protected override int Height => 52;

        public override int DrillItem => ModContent.ItemType<SolarDrillCasing>();
    }

    public class VortexDrill : BaseDrill
    {
        protected override int DrillTier => 225; // Vortex Pickaxe
        protected override int DrillCooldown => 13;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 52;
        protected override int Height => 52;

        public override int DrillItem => ModContent.ItemType<VortexDrillCasing>();
    }

    public class NebulaDrill : BaseDrill
    {
        protected override int DrillTier => 225; // Nebula Pickaxe
        protected override int DrillCooldown => 13;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 52;
        protected override int Height => 52;

        public override int DrillItem => ModContent.ItemType<NebulaDrillCasing>();
    }

    public class StardustDrill : BaseDrill
    {
        protected override int DrillTier => 225; // Stardust Pickaxe
        protected override int DrillCooldown => 13;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 52;
        protected override int Height => 52;

        public override int DrillItem => ModContent.ItemType<StardustDrillCasing>();
    }

    public class CelestialDrill : BaseDrill
    {
        protected override int DrillTier => 250;
        protected override int DrillCooldown => 10;
        protected override int BlockRangeStyle => 2;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 60;
        protected override int Height => 60;

        public override int DrillItem => ModContent.ItemType<CelestialDrillCasing>();
    }

    public class MooMooDrill : BaseDrill
    {
        protected override int DrillTier => 250;
        protected override int DrillCooldown => 1;
        protected override int BlockRangeStyle => 4; // Larger Square
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 64;
        protected override int Height => 64;

        public override int DrillItem => ModContent.ItemType<MooMooDrillCasing>();
    }

    public class Excavator : BaseDrill
    {
        protected override int DrillTier => 250;
        protected override int DrillCooldown => 1;
        protected override int BlockRangeStyle => 5;
        protected override SoundStyle DrillSound => SoundID.Item22;

        protected override int Width => 68;
        protected override int Height => 68;

        public override int DrillItem => ModContent.ItemType<ExcavatorCasing>();
    }
}
