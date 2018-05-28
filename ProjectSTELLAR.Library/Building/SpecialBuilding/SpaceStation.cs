using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class SpaceStation : BuildingType
    {
        public SpaceStation(Map ctx)
            : base(ctx, 70, 120, 100, 90, 70, 50, 25, 30, true, 70, 1500)
        {

        }


    }
}
