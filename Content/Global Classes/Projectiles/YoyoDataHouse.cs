using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class YoyoDataHouse : GlobalProjectile
    {
        private Item _parent = null;

        public List<IYoyoUpgrade> Upgrades = new();

        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile proj, bool lateInstantiation) => proj.aiStyle == 99;

        public float DamageMult = 1f;
        public float KnockbackMult = 1f;
        public float LifetimeMult = 1f;
        public float RangeBonus = 0f;
        public float RangeMult = 1f;
        public float SpeedBonus = 0f;
        public bool Bearing = true;
        private float _speedMult = 1f;
        

        /// <summary>
        /// Multiplied by (YoyosTopSpeed + YoyoModPlayer.YoyoSpeedBonus + YoyoData.SpeedBonus) * SpeedMult
        /// </summary>
        public float SpeedMult
        {
            get => _speedMult;
            set => _speedMult = Math.Min(value, 3f);
        }

        private int _hits;
        public int Hits
        {
            get { return _hits; }
            set { _hits = value; }
        }

        private int[] _abilityTimer;
        /// <summary>Used for storing multiple timers related to AI <br>Goes up to 3 slots</br></summary>
        public int[] AbilityTimer
        {
            get { return _abilityTimer ??= new int[3]; }
            set { _abilityTimer = value; }
        }

        private int[] _storedCounters;
        public int[] StoredCounters
        {
            get { return _storedCounters ??= new int[3]; }
            set { _storedCounters = value; }
        }

        /// <summary></summary>
        private bool _mainYoyo;
        public bool MainYoyo
        {
            get { return _mainYoyo; }
            private set { _mainYoyo = value; }
        }

        public YoyoDataHouse() 
        {
            _hits = 0;
            _abilityTimer = new int[3];
            _mainYoyo = false;
        }

        // yikes
        public override void OnSpawn(Projectile proj, IEntitySource source)
        {
            MainYoyo = proj.ai[0] != 1f;

            if (source is EntitySource_ItemUse parentSource)
            {
                var parent = parentSource.Item;
                _parent = parent;
                
                if (ItemID.Sets.Yoyo[parent.type])
                {
                    var upgrades = parent.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades;
                   
                    foreach (var item in upgrades)
                    {
                        if (item.ModItem is IYoyoUpgrade upgrade)
                        {
                            upgrade.ApplyEffects(proj);
                        }
                    }
                }

                if (!parent.GetGlobalItem<GlobalYoyoUpgrade>().HasBearing(parent))
                {
                    Bearing = false;
                }
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, NPC.HitInfo hit, int damageDone)
        {
            if (_parent == null)
                return;

            projectile.GetGlobalProjectile<YoyoDataHouse>().Hits++;

            if (ItemID.Sets.Yoyo[_parent.type])
            {
                var upgrades = _parent.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades;
                   
                    foreach (var item in upgrades)
                    {
                        if (item.ModItem is IYoyoUpgrade upgrade)
                        {
                            upgrade.ApplyOnHitEffect(projectile, target, hit, damageDone);
                        }
                    }
            }
        }

        public override void AI(Projectile projectile)
        {
            if (_parent == null)
                return;

            if (ItemID.Sets.Yoyo[_parent.type])
            {
                var upgrades = _parent.GetGlobalItem<GlobalYoyoUpgrade>().yoyoUpgrades;

                foreach (var item in upgrades)
                {
                    if (item.ModItem is IYoyoUpgrade upgrade)
                    {
                        upgrade.AI(projectile);
                    }
                }
            }
        }

        public override void SendExtraAI(Projectile projectile, BitWriter bitWriter, BinaryWriter binaryWriter)
        {
            for(int i = 0; i < AbilityTimer.Length; i++)
            {
                 binaryWriter.Write(AbilityTimer[i]);
            }

            for (int i = 0; i < StoredCounters.Length; i++)
            {
                binaryWriter.Write(StoredCounters[i]);
            }
        }

        public override void ReceiveExtraAI(Projectile projectile, BitReader bitReader, BinaryReader binaryReader)
        {
            for (int i = 0; i < AbilityTimer.Length; i++)
            {
                AbilityTimer[i] = binaryReader.Read();
            }

            for (int i = 0; i < StoredCounters.Length; i++)
            {
                StoredCounters[i] = binaryReader.Read();
            }
        }
    }
}
