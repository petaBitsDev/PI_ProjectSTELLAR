using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class OreMine : Building, IResourcesBuildings
    {
        bool _onFire;
        public OreMine(BuildingType type, int x, int y) : base(type, x, y)
        {
            _onFire = false;
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }
    }
}
