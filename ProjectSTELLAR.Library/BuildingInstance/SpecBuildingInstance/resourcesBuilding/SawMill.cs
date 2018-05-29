using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class SawMill : Building, IResourcesBuildings
    {
        public SawMill(BuildingType type, int x, int y) : base(type, x , y)
        {
        }
    }
}
