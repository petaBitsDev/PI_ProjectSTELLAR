using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar { 
    class House : HouseType
    {

    float _x;
    float _y;
        public House(float x, float y)
            : base()
        {
        _x = x;
        _y = y;
        }
    }
}
