using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public interface IEvent
    {
        bool PreviousEvent { get; set; }

        bool IsEventHappening { get; set; }

        bool EventHandle { get; set; }

        int NbEventMax { get; set; }

        int NbEventReal { get; set; }

        float EventProbability { get; set; }


        List<Building> BuildingHasEvent { get; set; }

        void CalculNbEventMax();
        void CalculNbEventReal();
        void CalculEventProbability();

        void BuildingEvent();

        void IsBuildingGettingEvent();

        void NewEvent(GameTime);

    }
}
