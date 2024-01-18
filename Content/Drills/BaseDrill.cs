using CombinationsMod.Content.Keybindings;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CombinationsMod.Content.Drills
{
    public abstract class BaseDrill : ModProjectile
    {
        // Credit to David F Dev

        // Cooldown between drill sound in ticks
        private const int DrillSoundCooldown = 27;

        private int _drillTimer;
        private int _drillSoundTimer;

        // Sound to play periodically whilst drilling
        protected virtual SoundStyle DrillSound { get; }

        // Tier of the drill (pickaxe tier)
        protected abstract int DrillTier { get; }

        //Block mining modification
        protected abstract int BlockRangeStyle { get; }

        // Cooldown between drill 'picks' in ticks
        protected abstract int DrillCooldown { get; }

        protected abstract int Width { get; }
        protected abstract int Height { get; }

        public abstract int DrillItem { get; }

        // Drill is enabled and should be visible
        protected bool IsDrillEnabled
        {
            get => Projectile.ai[0] == 1f;
            set => Projectile.ai[0] = value ? 1f : 0f;
        }

        public override void SetDefaults()
        {
            Projectile.width = Width;
            Projectile.height = Height;
            Projectile.friendly = false;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;

            // Trail?
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 35;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void OnSpawn(IEntitySource source)
        {
            _drillTimer = DrillCooldown;
            _drillSoundTimer = DrillSoundCooldown;
        }
        public override void AI()
        {

            Projectile.timeLeft = 2;

            // Handle enabling/disabling the drill function
            if (Projectile.owner == Main.myPlayer)
            {
                bool shouldBeActive = KeybindSystem.DrillKeybind.Current;
                if (IsDrillEnabled && !shouldBeActive)
                {

                    // Disable the drill
                    IsDrillEnabled = false;
                    _drillTimer = DrillCooldown;
                    _drillSoundTimer = DrillSoundCooldown;
                    Projectile.netUpdate = true;
                }
                else if (!IsDrillEnabled && shouldBeActive)
                {

                    // Enable the drill
                    IsDrillEnabled = true;
                    Projectile.netUpdate = true;
                }
            }

            // Find the parent yoyo
            Projectile proj = Main.projectile[(int)Projectile.ai[1]];

            if (!proj.active || proj.owner != Projectile.owner || proj.aiStyle != 99)
            {
                Projectile.Kill();
                return;
            }

            if (!IsDrillEnabled)
            {
                // Do not update if the drill is disabled
                return;
            }

            // Follow the parent yoyo around
            Projectile.Center = proj.Center;
            Projectile.rotation -= 0.35f;

            // Play the drill sound periodically
            if (Main.netMode != NetmodeID.Server && !string.IsNullOrEmpty(DrillSound.SoundPath) && _drillSoundTimer > 0)
            {
                _drillSoundTimer--;
                if (_drillSoundTimer == 0)
                {
                    SoundEngine.PlaySound(DrillSound, Projectile.position);
                    _drillSoundTimer = DrillSoundCooldown;
                }
            }

            // Prevent the projectile from 'picking' a tile until this timer has depleted
            if (_drillTimer > 0)
            {
                _drillTimer--;
            }
            else
            {

                // Attempt to 'pick' any nearby solid tiles
                Player player = Main.player[Projectile.owner];
                bool success = false;

                void TryPick(int cX, int cY)
                {
                    int x = (int)((proj.Center.X + (cX * proj.width * 0.5f + 8 * cX)) / 16);
                    int y = (int)((proj.Center.Y + (cY * proj.height * 0.5f + 8 * cY)) / 16);

                    if (!Main.tile[x, y].HasTile || !Main.tileSolid[Main.tile[x, y].TileType] || Main.tileSolidTop[Main.tile[x, y].TileType])
                    {
                        return;
                    }



                    player.PickTile(x, y, DrillTier);
                    if (!Main.tile[x, y].HasTile)
                    {
                        success = true;
                    }
                }
                if (BlockRangeStyle == 2) // 2 x 2 grid. For more visual understanding, put the coords on a grid to see the blocks it mines
                {
                    for (int i = 0; i < 2; i++)
                    {
                        TryPick(0, 0);
                        TryPick(-1, 0);
                        TryPick(0, 1);
                        TryPick(1, 0);
                        TryPick(0, -1);
                        TryPick(-1, -1);
                        TryPick(1, -1);
                        TryPick(-1, 1);
                        TryPick(1, 1);
                        TryPick(-2, 0);
                        TryPick(0, 2);
                        TryPick(2, 0);
                        TryPick(0, -2);
                        TryPick(-2, -2);
                        TryPick(2, -2);
                        TryPick(-2, 2);
                        TryPick(2, 2);
                        TryPick(2, 1);
                        TryPick(-2, 1);
                        TryPick(-1, 2);
                        TryPick(1, 2);
                        TryPick(2, -1);
                        TryPick(-2, -1);
                        TryPick(-1, -2);
                        TryPick(1, -2);
                    }
                }
                else if (BlockRangeStyle == 3)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        TryPick(0, 0);
                        TryPick(-1, 0);
                        TryPick(0, 1);
                        TryPick(1, 0);
                        TryPick(0, -1);
                        TryPick(-1, -1);
                        TryPick(1, -1);
                        TryPick(-1, 1);
                        TryPick(1, 1);
                        TryPick(-2, 0);
                        TryPick(2, 0);
                        TryPick(0, 2);
                        TryPick(0, -2);
                    }
                }
                else if (BlockRangeStyle == 4) // 3 x 3 grid. For more visual understanding, put the coords on a grid to see the blocks it mines
                {
                    for (int i = 0; i < 2; i++)
                    {
                        TryPick(0, 0); // 1 x 1 (technically 3 x 3)
                        TryPick(-1, 0);
                        TryPick(0, 1);
                        TryPick(1, 0);
                        TryPick(0, -1);
                        TryPick(-1, -1);
                        TryPick(1, -1);
                        TryPick(-1, 1);
                        TryPick(1, 1);

                        TryPick(-2, 0); // 2 x 2 (technically 5 x 5)
                        TryPick(0, 2);
                        TryPick(2, 0);
                        TryPick(0, -2);
                        TryPick(-2, -2);
                        TryPick(2, -2);
                        TryPick(-2, 2);
                        TryPick(2, 2);
                        TryPick(2, 1);
                        TryPick(-2, 1);
                        TryPick(-1, 2);
                        TryPick(1, 2);
                        TryPick(2, -1);
                        TryPick(-2, -1);
                        TryPick(-1, -2);
                        TryPick(1, -2);

                        TryPick(-3, 0); // 3 x 3 (technically 7 x 7)
                        TryPick(-3, 1);
                        TryPick(-3, 2);
                        TryPick(-3, 3);
                        TryPick(-3, -1);
                        TryPick(-3, -2);
                        TryPick(-3, -3);
                        TryPick(-2, -3);
                        TryPick(-2, 3);
                        TryPick(-1, -3);
                        TryPick(-1, 3);
                        TryPick(0, -3);
                        TryPick(0, 3);
                        TryPick(1, -3);
                        TryPick(1, 3);
                        TryPick(2, -3);
                        TryPick(2, 3);
                        TryPick(3, 0);
                        TryPick(3, -1);
                        TryPick(3, -2);
                        TryPick(3, -3);
                        TryPick(3, 1);
                        TryPick(3, 2);
                        TryPick(3, 3);
                    }
                }
                else if (BlockRangeStyle == 5)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            TryPick(i, j);
                        }
                    }

                    for (int k = -10; k <= 0; k++)
                    {
                        for (int l = -10; l <= 0; l++)
                        {
                            TryPick(k, l);
                        }
                    }

                    for (int k = -10; k <= 0; k++)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            TryPick(k, l);
                        }
                    }

                    for (int k = 0; k < 10; k++)
                    {
                        for (int l = -10; l <= 0; l++)
                        {
                            TryPick(k, l);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < 2; i++)
                    {
                        TryPick(0, 0);
                        TryPick(-1, 0);
                        TryPick(0, 1);
                        TryPick(1, 0);
                        TryPick(0, -1);
                        TryPick(-1, -1);
                        TryPick(1, -1);
                        TryPick(-1, 1);
                        TryPick(1, 1);
                    }
                }

                // Reset the cooldown if successful
                if (success)
                {
                    _drillTimer = DrillCooldown;
                }
            }
        }


        public override bool PreDraw(ref Color lightColor)
        {

            return IsDrillEnabled;
        }
    }
}