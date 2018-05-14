using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class ResourcesManager
    {
       static Map _ctx;
        Dictionary<string, int> _nbResources = new Dictionary<string, int>();
        CityHelper c = new CityHelper(_ctx);


        public ResourcesManager(Map ctx)
        {
            _ctx = ctx;
            _nbResources.Add("wood", 500);
            _nbResources.Add("rock", 500);
            _nbResources.Add("metal", 150);
            _nbResources.Add("coins", 5000);
            _nbResources.Add("pollution", 0);
        }

        public Dictionary<string, int> NbResources => _nbResources;
        
        public void UpdateResources()
        {
            CityManager cityManager = new CityManager(_ctx);

            if (!_nbResources.ContainsKey("wood"))
            {
                _nbResources.Add("wood", 500);
            }
            else
            {

                _nbResources["wood"] += (c.GetSawmill.WoodProduction * cityManager.NbSawMill) ;
            }

            if (!_nbResources.ContainsKey("rock"))
            {
                _nbResources.Add("rock", 500);
            }
            else
            {
                _nbResources["rock"] += (c.GetOreMine.RockProduction * cityManager.NbOreMine);
            }

            if (!_nbResources.ContainsKey("metal"))
            {
                _nbResources.Add("metal", 150);
            }
            else
            {
                _nbResources["metal"] += (c.GetMetalMine.MetalProduction * cityManager.NbMetalMine);
            }

            if (!_nbResources.ContainsKey("coins"))
            {
                _nbResources.Add("coins", 5000);
            }
            else
            {
                _nbResources["coins"] += cityManager.CityBalance;
            }
        }

        public void UpdateWhenCreate(Building building)
        {
            _nbResources["wood"] -= building.WoodNeeded;
            _nbResources["rock"] -= building.RockNeeded;
            _nbResources["metal"] -= building.MetalNeeded;
            _nbResources["coins"] -= building.StellarCoinNeeded;
        }

        public bool CheckResourcesNeeded(Building building)
        {
            if (_nbResources["wood"] - building.WoodNeeded < 0) return false;
            else if (_nbResources["rock"] - building.RockNeeded < 0) return false;
            else if (_nbResources["metal"] - building.MetalNeeded < 0) return false;
            else if (_nbResources["coins"] - building.StellarCoinNeeded < 0) return false;

            return true;
        }
        public int Electricity
        {
            get
            {
                CityManager cityManager = new CityManager(_ctx);

                return (c.GetPowerPlant.ElectricityProduction * cityManager.NbPowerPlant);
            }
        }

        public int Water
        {
            get
            {
                CityManager cityManager = new CityManager(_ctx);
                return (c.GetPumpingStation.WaterProduction * cityManager.NbPumpingStation);

            }
        }

        public int ElectricityConsume
        {
            get
            {
                CityManager cityManager = new CityManager(_ctx);
                return ((c.GetCityHall.ElectricityConsume * cityManager.NbCityHall) + (c.GetFireStation.ElectricityConsume * cityManager.NbFireStation) + (c.GetFlat.ElectricityConsume * cityManager.NbFlat) + (c.GetHospital.ElectricityConsume * cityManager.NbHospital) + (c.GetHouse.ElectricityConsume * cityManager.NbHouse) + (c.GetHut.ElectricityConsume * cityManager.NbHut) + (c.GetMetalMine.ElectricityConsume * cityManager.NbMetalMine) + (c.GetOreMine.ElectricityConsume * cityManager.NbOreMine) + (c.GetPoliceStation.ElectricityConsume * cityManager.NbPoliceStation) + (c.GetPowerPlant.ElectricityConsume * cityManager.NbPowerPlant) + (c.GetPumpingStation.ElectricityConsume * cityManager.NbPumpingStation) + (c.GetSawmill.ElectricityConsume * cityManager.NbSawMill) + (c.GetSpaceStation.ElectricityConsume * cityManager.NbSpaceStation) + (c.GetWareHouse.ElectricityConsume * cityManager.NbWarehouse));
            }
        }

        public int WaterConsume
        {
            get
            {
                CityManager cityManager = new CityManager(_ctx);
                return ((c.GetCityHall.WaterConsume * cityManager.NbCityHall) + (c.GetFireStation.WaterConsume * cityManager.NbFireStation) + (c.GetFlat.WaterConsume * cityManager.NbFlat) + (c.GetHospital.WaterConsume * cityManager.NbHospital) + (c.GetHouse.WaterConsume * cityManager.NbHouse) + (c.GetHut.WaterConsume * cityManager.NbHut) + (c.GetMetalMine.WaterConsume * cityManager.NbMetalMine) + (c.GetOreMine.WaterConsume * cityManager.NbOreMine) + (c.GetPoliceStation.WaterConsume * cityManager.NbPoliceStation) + (c.GetPowerPlant.WaterConsume * cityManager.NbPowerPlant) + (c.GetPumpingStation.WaterConsume * cityManager.NbPumpingStation) + (c.GetSawmill.WaterConsume * cityManager.NbSawMill) + (c.GetSpaceStation.WaterConsume * cityManager.NbSpaceStation) + (c.GetWareHouse.WaterConsume * cityManager.NbWarehouse));
            }
        }

        public int ElectricityBalance
        {
            get
            {
                return Electricity - ElectricityConsume;
            }
        }

        public int WaterBalance
        {
            get
            {
                return Water - WaterConsume;
            }
        }
    }
}
