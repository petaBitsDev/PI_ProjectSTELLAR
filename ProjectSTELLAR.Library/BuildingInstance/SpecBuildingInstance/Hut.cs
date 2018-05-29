using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class Hut : Building
    {

        int _x;
        int _y;
        int _size;
        bool _onFire;

        public Hut(int x, int y)
            : base()
        {
            _x = x;
            _y = y;
            _size = 1;
            _onFire = false;
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        } 
    }
}
