using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Sawmill : Building
    {

        int _woodProduction;
        public Sawmill(Map ctx, int woodProduction)
            : base(ctx, 15, 0, 25, 5, 10, 10, 20, 15, false, 0, 20)
        {
            _woodProduction = woodProduction;
        }

 
        public int WoodProduction => _woodProduction;


    }
}
