using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class MetalMine : Building
    {
        int _metalProdution;
        public MetalMine(Map ctx, int metalProduction)
            : base(ctx, 15, 15, 25, 0, 10, 10, 20, 15, false, 0, 20)
        {
            _metalProdution = metalProduction;
        }

        public int MetalProduction => _metalProdution;

    }
}
