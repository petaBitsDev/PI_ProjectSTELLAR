﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class Flat : BuildingType
    {
        public Flat(Map ctx)
          : base(ctx, 75, 100, 55, 40, 45, 60, 22, 100, false, 80,50)
        {

        }
     
    }
}
