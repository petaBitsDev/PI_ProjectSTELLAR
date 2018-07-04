using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public interface IEvent 
    {
       bool EventHandle { get; set; }

       void BuildingEvent(GameTime gt);

       void NewEvent(GameTime gt);
    }
}
