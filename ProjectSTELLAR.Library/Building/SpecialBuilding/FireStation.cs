﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class FireStation : BuildingType
    {
        public FireStation(Map ctx)
            : base(ctx, 45, 10, 35, 80, 25, 70, 25, 22, true, 35, 45)
        {

        }

     

    }
}
