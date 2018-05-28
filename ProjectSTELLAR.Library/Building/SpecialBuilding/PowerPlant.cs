using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class PowerPlant : BuildingType
    {
        int _electricityProduction;
        public PowerPlant(Map ctx, int electricityProduction)
            : base(ctx, 25, 38, 25, 30, 0, 30, 15, 15, true, 12, 40)
        {
            _electricityProduction = electricityProduction;
        }

        public int ElectricityProduction => _electricityProduction;
    }
}
