﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    class House : Building
    {
        public House(BuildingType type, int x, int y) : base(type, x, y)
        {
        }
    }
}
