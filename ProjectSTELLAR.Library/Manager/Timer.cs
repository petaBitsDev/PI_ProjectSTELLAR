using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
     public class Timer
    {
        Map _ctx;
        GameTime _gt;
        public Timer(Map ctx, GameTime gt)
        {
            _ctx = ctx;
            _gt = gt;
        }
        public void TimeToUpdate()
        {
            foreach(IServiceBuildingsType serviceBT in _ctx.ListServicesBuildingType)
            {
                DateTime endTime = new DateTime();
                endTime = serviceBT.StartTime.AddSeconds(serviceBT.TimeToGo);
                if (endTime == _gt.InGameTime)
                {
                    serviceBT.TruckSelected.IsFree = false;

                    if(Equals(serviceBT, _ctx.BuildingTypes[1]))
                    {
                        serviceBT.Target.OnFire = false;
                    }
                    else if(Equals(serviceBT, _ctx.BuildingTypes[3]))
                    {
                        serviceBT.Target.IsSick = false;
                    }
                    else if(Equals(serviceBT, _ctx.BuildingTypes[8]))
                    {
                        serviceBT.Target.IsVictimCrime = false;
                    }
                }
            }
        }
    }
}
