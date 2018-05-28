using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{ 
    class Hut : HutType
    {

    float _x;
    float _y;
        public Hut(float x, float y)
            : base()
        {
        _x = x;
        _y = y;
        }
    }
}
