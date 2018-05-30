using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class SpaceStation : Building, IPublicBuildings
    {
        public SpaceStation(BuildingType type, int x, int y) : base(type, x, y)
        {
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }
    }
}
