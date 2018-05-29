using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ProjectStellar.Library
{
    [Serializable]
    public class ResourcesManager
    {
        static Map _ctx;
        Dictionary<string, int> _nbResources = new Dictionary<string, int>();
       
        public ResourcesManager(Map ctx)
        {
            _ctx = ctx;
            _nbResources.Add("wood", 500);
            _nbResources.Add("rock", 500);
            _nbResources.Add("metal", 150);
            _nbResources.Add("coins", 5000);
            _nbResources.Add("pollution", 0);
            _nbResources.Add("nbPeople", 0);
            _nbResources.Add("electricity", 0);
            _nbResources.Add("water", 0);
            _nbResources.Add("cost", 0);

        }

        public Dictionary<string, int> NbResources => _nbResources;

        public void UpdateWhenCreate(BuildingType building)
        {
            _nbResources["wood"] -= building.Wood;
            _nbResources["rock"] -= building.Rock;
            _nbResources["metal"] -= building.Metal;
            _nbResources["coins"] -= building.Coin;
            _nbResources["pollution"] -= building.Pollution;
            _nbResources["water"] -= building.Water;
            _nbResources["electricity"] -= building.Electricity;
            _nbResources["cost"] += building.Cost;
            if (building.Type == "habitation")
            {
                _nbResources["nbPeople"] += building.NbPeople;
            }
        }


        public bool CheckResourcesNeeded(BuildingType building)
        {
            if (_nbResources["wood"] - building.Wood < 0) return false;
            else if (_nbResources["rock"] - building.Rock < 0) return false;
            else if (_nbResources["metal"] - building.Metal < 0) return false;
            else if (_nbResources["coins"] - building.Coin < 0) return false;

            return true;
        }
    }
}
