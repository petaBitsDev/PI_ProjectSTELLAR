using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class OreMine : Building
    {
        int _rockProduction;
        public OreMine(Map ctx, int rockProduction)
            : base(ctx, 0, 15, 25, 5, 10, 10, 20, 15, false, 0, 20)
        {
            _rockProduction = rockProduction;
        }

       
        public int RockProduction => _rockProduction;
    }
}
