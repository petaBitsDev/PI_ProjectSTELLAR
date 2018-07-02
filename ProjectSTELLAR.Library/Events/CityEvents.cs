using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class CityEvents
    {
        int _nbDestroyedBuilding;
        bool _waitMeteors;

        public int Meteors(int level, Map map, ResourcesManager resources)
        {
            _nbDestroyedBuilding = Meteorite.Falls(level, map, resources);

            if (_nbDestroyedBuilding > 0) _waitMeteors = true;

            return _nbDestroyedBuilding;
        }

        public int NbDestroyedBuildings => _nbDestroyedBuilding;

        public bool WaitMeteors
        {
            get { return _waitMeteors; }
            set { _waitMeteors = value; }
        }
    }
}
