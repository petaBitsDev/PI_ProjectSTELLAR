using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class House : Building, IResidences
    {
        bool _onFire;
        bool _isSick;
        bool _isCrimeVictim;
        public House(BuildingType type, int x, int y) : base(type, x, y)
        {
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
