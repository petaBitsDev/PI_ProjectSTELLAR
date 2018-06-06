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
        int _maxPopulation;
        Dictionary<string, int> _nbResources = new Dictionary<string, int>();
       
        public ResourcesManager(Map ctx)
        {
            _ctx = ctx;
            _nbResources.Add("wood", 500000);
            _nbResources.Add("rock", 500000);
            _nbResources.Add("metal", 15000);
            _nbResources.Add("coins", 50000);
            _nbResources.Add("pollution", 0);
            _nbResources.Add("nbPeople", 0);
            _nbResources.Add("electricity", 0);
            _nbResources.Add("water", 0);
            _nbResources.Add("cost", 0);
            _maxPopulation = 0;
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

            if (building.Type == "habitation") _maxPopulation += building.NbPeople;
        }

        public void UpdateWhenDestroy(BuildingType building)
        {
            if (building.Type == "habitation")
            {
                _maxPopulation = _maxPopulation - building.NbPeople < 0 ? 0 : _maxPopulation - building.NbPeople;
                _nbResources["nbPeople"] = _nbResources["nbPeople"] - building.NbPeople < 0 ? 0 : _nbResources["nbPeople"] - building.NbPeople;
            }
            if (Equals(building, _ctx.BuildingTypes[9]))
            {
                PowerPlantType a = (PowerPlantType)_ctx.BuildingTypes.ElementAt(9);
                _nbResources["electricity"] += a.ElectricityProduction;
            }
            if(Equals(building, _ctx.BuildingTypes[10]))
            {
                PumpingStationType pumping = (PumpingStationType)_ctx.BuildingTypes.ElementAt(10);
                _nbResources["water"] += pumping.WaterProduction;
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

        public void UpdateResources()
        {
            int maxAdd = 20 + _nbResources["nbPeople"] > _maxPopulation ? _maxPopulation - _nbResources["nbPeople"] : 20;
            Random random = new Random();
            // Prochaine intégration de la satifaction
            if (0 < maxAdd)
                _nbResources["nbPeople"] += random.Next(0, maxAdd + 1);

            SawmillType sawmillType = (SawmillType)_ctx.BuildingTypes[11];
            OreMineType oreMineType = (OreMineType)_ctx.BuildingTypes[7];
            MetalMineType metalMineType = (MetalMineType)_ctx.BuildingTypes[6];
            WarehouseType warehouseType = (WarehouseType)_ctx.BuildingTypes[13];
            
            if (sawmillType.MaxWoodCapacity >= sawmillType.WoodProduction * sawmillType.NbBuilding)
            {
                _nbResources["wood"] += sawmillType.WoodProduction * sawmillType.NbBuilding;
                sawmillType.MaxWoodCapacity -= sawmillType.WoodProduction * sawmillType.NbBuilding;
            } 
            else if(sawmillType.MaxWoodCapacity < sawmillType.WoodProduction * sawmillType.NbBuilding)
            {
                if(warehouseType.MaxWoodCapacity >= sawmillType.WoodProduction * sawmillType.NbBuilding)
                {
                    _nbResources["wood"] += sawmillType.WoodProduction * sawmillType.NbBuilding;
                    warehouseType.MaxWoodCapacity -= sawmillType.WoodProduction * sawmillType.NbBuilding;
                }
            }

            if(oreMineType.MaxRockCapacity >= oreMineType.RockProduction * oreMineType.NbBuilding)
            {
                _nbResources["rock"] += oreMineType.RockProduction * oreMineType.NbBuilding;
                oreMineType.MaxRockCapacity -= sawmillType.WoodProduction * sawmillType.NbBuilding;

            }
            else if(metalMineType.MaxMetalCapacity < metalMineType.MetalProduction * metalMineType.NbBuilding)
            {
                if(warehouseType.MaxRockCapacity >= oreMineType.RockProduction * oreMineType.NbBuilding)
                {
                    _nbResources["rock"] += oreMineType.RockProduction * oreMineType.NbBuilding;
                    warehouseType.MaxRockCapacity -= sawmillType.WoodProduction * sawmillType.NbBuilding;

                }
            }

            if(metalMineType.MaxMetalCapacity >= metalMineType.MetalProduction * metalMineType.NbBuilding)
            {
                _nbResources["metal"] += metalMineType.MetalProduction * metalMineType.NbBuilding;
                metalMineType.MaxMetalCapacity -= metalMineType.MetalProduction * metalMineType.NbBuilding;
            }
            else if (metalMineType.MaxMetalCapacity < metalMineType.MetalProduction * metalMineType.NbBuilding)
            {
                if(warehouseType.MaxMetalCapacity >= metalMineType.MetalProduction * metalMineType.NbBuilding)
                {
                    _nbResources["metal"] += metalMineType.MetalProduction * metalMineType.NbBuilding;
                    warehouseType.MaxMetalCapacity -= metalMineType.MetalProduction * metalMineType.NbBuilding;
                }
            }

            _nbResources["coins"] += _nbResources["cost"];

        }

       
    }
}
