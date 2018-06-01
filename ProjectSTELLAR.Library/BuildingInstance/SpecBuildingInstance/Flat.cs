using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    class Flat : Building, IResidences
    {
        public Flat(BuildingType type, int x, int y) : base(type, x, y)
        {
        }
    }
}
        