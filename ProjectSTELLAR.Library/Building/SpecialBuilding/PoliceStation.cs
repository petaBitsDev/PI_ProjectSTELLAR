using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class PoliceStation : Building
    {
        public PoliceStation(Map ctx)
            : base(ctx, 45, 100, 60, 55, 25, 20, 15, 20, true, 40, 90)
        {

        }

    }
}
