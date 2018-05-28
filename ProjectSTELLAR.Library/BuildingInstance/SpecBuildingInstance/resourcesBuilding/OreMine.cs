using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{

    class OreMine : OreMineType
    {
        float _x;
        float _y;
        public OreMine(float x, float y)
            :base()
        {
            _x = x;
            _y = y;
        }
    }
}
