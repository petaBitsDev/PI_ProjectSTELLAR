using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    class ResourcesManager
    {
        Map _ctx;
        Dictionary<string, int> _nbResources = new Dictionary<string, int>();

        public ResourcesManager(Map ctx)
        {
            _ctx = ctx;
        }

        public Dictionary<string, int> NbResources => _nbResources;
    }
}
