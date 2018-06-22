using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    class CityHelper
    {
        List<IEvent> events;
        Map _ctx;
        public CityHelper(Map map)
        {
            _ctx = map;
     events = new List<IEvent>();

            events.Add(new Fire(map));
            events.Add(new Disease(map));
            events.Add(new Crime(map));
        }



    }
}
