﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    class House : Building, IResidences
    {

        int _x;
        int _y;
        int _size;

        public House(int x, int y)
            : base()
        {
            _x = x;
            _y = y;
            _size = 1;
        }
    }
}
