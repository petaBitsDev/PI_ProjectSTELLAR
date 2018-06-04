using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class SawMill : Building, IResourcesBuildings
    {
        bool _onFire;
        bool _isSick;
        bool _isCrimeVictim;
        public SawMill(BuildingType type, int x, int y) : base(type, x , y)
        {
            _onFire = false;
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }

        public override bool IsSick
        {
            get { return _isSick; }
            set { _isSick = value; }
        }
        public override bool IsVictimCrime
        {
            get { return _isCrimeVictim; }
            set { _isCrimeVictim = value; }
        }
    }
}
