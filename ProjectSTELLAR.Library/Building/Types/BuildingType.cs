using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.Building
{
    public abstract class BuildingType
    {
        public abstract void CreateInstance(int x, int y);

        public abstract void DeleteInstance(int x, int y);
        
        public abstract int Count();
    }

}
