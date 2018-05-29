using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class PoliceStation : Building
    {
        int _x;
        int _y;
        int _size;

        public PoliceStation(int x, int y)
            : base()
        {
            _x = x;
            _y = y;
            _size = 4;
        }
    }
}
