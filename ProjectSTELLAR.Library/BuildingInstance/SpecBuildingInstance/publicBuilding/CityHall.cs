using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ProjectStellar.Library
{
    class CityHall : Building, IPublicBuildings
    {
        int _x;
        int _y;
        int _size;

        public CityHall(int x, int y)
        {
            _x = x;
            _y = y;
            _size = 6;
        }
    }
}

        public CityHall(BuildingType type, int x, int y) : base(type, x, y)
    }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }
    }