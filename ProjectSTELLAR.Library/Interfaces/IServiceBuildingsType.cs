using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public interface IServiceBuildingsType
    {
     //   void ServiceBuildingWorking();
        void BuildingDistance(Map map);
        void CreateTruck(Building building, int x, int y);
        void CheckTruckStatement();

        Building Target { get; set; }
        Building Origin { get; set; }

        Double Distance { get; set; }

        double TimeToGo { get; set; }
       // double TimeMax { get; }
        DateTime StartTime { get; set; }

        Truck TruckSelected { get; set; }




    }
}
