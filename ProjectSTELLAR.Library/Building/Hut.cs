using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class Hut : BuildingType
    {
            
        public  Hut(Map ctx)
            :base(ctx, 25, 50, 15, 0, 5, 5, 0, 5, false, 20, 5)
        {

        }
    }
}
