using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class BuildingFactory
    {
        Map _ctx;
        ResourcesManager _resourcesManager;

        public BuildingFactory(Map ctx, ResourcesManager resourcesManager)
        {
            _ctx = ctx;
            _resourcesManager = resourcesManager;
        }

        public void CreateBuilding(int x , int y, Building building)
        {
            _ctx.AddBuilding(x, y);
            _resourcesManager.UpdateWhenCreate(building);


            if (_ctx._nbBuilding.ContainsKey(building))
            {
                _ctx._nbBuilding[building]++;
            }
            else
            {
                _ctx._nbBuilding.Add(building, 1);
            }
        }

        public void DestroyBuilding(int x, int y, Building building)
        {
            _ctx.RemoveBuilding(x, y);
            if (_ctx._nbBuilding.ContainsKey(building))
            {
                _ctx._nbBuilding[building]--;
            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public Map Map
        {
            get { return _ctx; }
            set { _ctx = value; }
        }
    }
}
