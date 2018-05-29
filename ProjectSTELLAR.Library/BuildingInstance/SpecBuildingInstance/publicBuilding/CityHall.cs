using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class CityHall : Building
    {
        int _x;
        int _y;
        int _size;
        bool _onFire;

        public CityHall(int x, int y)
        {
            _x = x;
            _y = y;
            _size = 6;
            _onFire = false;
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }
    }
}
