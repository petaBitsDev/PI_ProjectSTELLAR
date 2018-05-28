using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public abstract class BuildingType
    {
        public void CreateInstance(int x, int y, ResourcesManager resources)
        {
            
        }

        public void DeleteInstance(int x, int y)
        {

        }

        public abstract int Cost { get; }
        public abstract int Coin { get; }
        public abstract int Wood { get; }
        public abstract int Rock { get; }
        public abstract int Metal { get; }
        public abstract int Water { get; }
        public abstract int Electricity { get; }
        public abstract int Pollution { get; }
        public abstract int NbPeople { get; }
    }

}
