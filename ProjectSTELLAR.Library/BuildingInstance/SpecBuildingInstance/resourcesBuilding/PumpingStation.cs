using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{ 
    class PumpingStation : PumpingStationType
    {
    float _x;
    float _y;

    public PumpingStation(float x, float y)
        : base()
    {
        _x = x;
        _y = y;
    }
    }
}
