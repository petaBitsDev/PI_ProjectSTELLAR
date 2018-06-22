using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    public class ExplorationShips
    {
        bool _available;
        string _resource;
        int _nbResources;

        public ExplorationShips()
        {
            _available = true;
            _resource = "";
            _nbResources = 0;
        }

        public string Resource
        {
            get { return _resource; }
            set { _resource = value; }
        }

        public int NbResources
        {
            get { return _nbResources; }
            set { _nbResources = value; }
        }

        public bool IsAvailable
        {
            get { return _available; }
            set { _available = value; }
        }
    }
}
