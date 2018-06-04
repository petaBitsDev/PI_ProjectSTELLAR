using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    class FireStation : Building, IPublicBuildings, IServiceBuildings
    {
        bool _onFire;
        int _nbTruck;
        bool _isSick;
        int _nbCellule;
        bool _isVictimCrime;
        public FireStation(BuildingType type, int x, int y) : base(type, x, y)
        {
            _nbTruck = 1;
            _nbCellule = 2;
            
        }

        public int NbVehicule
        {
            get { return _nbTruck; }
            set { _nbTruck = value; }
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
            get { return _isVictimCrime; }
            set { _isVictimCrime = value; }
        }
    }
    }
