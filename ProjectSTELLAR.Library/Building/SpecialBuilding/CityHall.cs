using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class CityHall : BuildingType
    {
        public CityHall(Map ctx)
            : base(ctx, 100, 150, 80, 50, 20, 20, 5, 50, true, 200, 1000)
        {

        }

    

    }
}
