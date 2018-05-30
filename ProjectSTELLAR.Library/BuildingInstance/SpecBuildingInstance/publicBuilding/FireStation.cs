using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class FireStation : Building, IPublicBuildings
    {
        public FireStation(BuildingType type, int x, int y) : base(type, x, y)
        {
            _nbTruck = 1;
            _onFire = false;
        }

        public int NbTruck
        {
            get { return _nbTruck; }
            set { _nbTruck = value; }
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }
    }
}
