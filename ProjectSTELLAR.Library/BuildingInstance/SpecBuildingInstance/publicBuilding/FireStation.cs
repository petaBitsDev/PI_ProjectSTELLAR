using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    public class FireStation : Building
    {
        int _x;
        int _y;
        int _size;
        int _nbTruck;
        bool _onFire;

        public FireStation(int x, int y)
            : base()
        {
            _x = x;
            _y = y;
            _size = 4;
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
