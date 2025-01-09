using System;
using System.IO;
using System.Linq;
using Terraria.DataStructures;
using Terraria.ModLoader.IO;

namespace CombinationsMod.Content.Global_Classes.Projectiles
{
    public class YoyoDataHouse : GlobalProjectile
    {
        public override bool InstancePerEntity => true;
        public override bool AppliesToEntity(Projectile proj, bool lateInstantiation) => proj.aiStyle == 99;

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

        public override void OnSpawn(Projectile proj, IEntitySource source)
        {
            MainYoyo = proj.ai[2] == 0;
        }

        public override void SendExtraAI(Projectile projectile, BitWriter bitWriter, BinaryWriter binaryWriter)
        {
            for(int i = 0; i < AbilityTimer.Length; i++)
            {
                 binaryWriter.Write(AbilityTimer[i]);
            }
        }

        public override void ReceiveExtraAI(Projectile projectile, BitReader bitReader, BinaryReader binaryReader)
        {
            for (int i = 0; i < AbilityTimer.Length; i++)
            {
                AbilityTimer[i] = binaryReader.Read();
            }
        }
    }
}
