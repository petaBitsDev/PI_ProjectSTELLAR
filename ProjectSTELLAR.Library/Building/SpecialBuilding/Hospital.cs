using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class Hospital : BuildingType
    {
        public Hospital(Map ctx)
            : base(ctx, 70, 40, 67, 75, 45, 60, 15, 25, true, 30, 45)
        {

        }

     
    }
}