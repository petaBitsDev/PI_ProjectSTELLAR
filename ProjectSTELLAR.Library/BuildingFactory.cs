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
        public BuildingFactory(Map ctx)
        {
            _ctx = ctx;
        }
        ResourcesManager _resourcesManager;


        public void CreateHut(int x, int y)
        {
           _resourcesManager = new ResourcesManager(_ctx);
           _ctx.AddBuilding(x, y, CityHelper.GetHut);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetHut);

           if (_ctx._nbBuilding.ContainsKey("hut"))
           {
              _ctx._nbBuilding["hut"]++;
           }
           else
           {
              _ctx._nbBuilding.Add("hut", 1);
           }
        }

        public void CreateHouse(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetHouse);

            _ctx.AddBuilding(x, y, CityHelper.GetHouse);


            if (_ctx._nbBuilding.ContainsKey("house"))
            {
                _ctx._nbBuilding["house"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("house", 1);
            }
        }

        public void CreateFlat(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetFlat);
            _ctx.AddBuilding(x, y, CityHelper.GetFlat);

            if (_ctx._nbBuilding.ContainsKey("flat"))
            {
                _ctx._nbBuilding["flat"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("flat", 1);
            }
        }

        public void CreateWareHouse(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetWareHouse);
            _ctx.AddBuilding(x, y, CityHelper.GetWareHouse);

            if (_ctx._nbBuilding.ContainsKey("wareHouse"))
            {
                _ctx._nbBuilding["wareHouse"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("wareHouse", 1);
            }
        }

        public void CreateSpaceStation(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetSpaceStation);
            _ctx.AddBuilding(x, y, CityHelper.GetSpaceStation);

            if (_ctx._nbBuilding.ContainsKey("spaceStation"))
            {
                _ctx._nbBuilding["spaceStation"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("spaceStation", 1);
            }
        }

        public void CreatePumpingStation(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetPumpingStation);
            _ctx.AddBuilding(x, y, CityHelper.GetPumpingStation);

            if (_ctx._nbBuilding.ContainsKey("pumpingStation"))
            {
                _ctx._nbBuilding["pumpingStation"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("pumpingStation", 1);
            }
        }

        public void CreatePowerPlant(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetPowerPlant);
            _ctx.AddBuilding(x, y, CityHelper.GetPowerPlant);

            if (_ctx._nbBuilding.ContainsKey("powerPlant"))
            {
                _ctx._nbBuilding["powerPlant"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("powerPlant", 1);
            }
        }


        public void CreatePoliceStation(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetPoliceStation);
            _ctx.AddBuilding(x, y, CityHelper.GetPoliceStation);

            if (_ctx._nbBuilding.ContainsKey("policeStation"))
            {
                _ctx._nbBuilding["policeStation"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("policeStation", 1);
            }
        }

        public void CreateHospital(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetHospital);
            _ctx.AddBuilding(x, y, CityHelper.GetHospital);

            if (_ctx._nbBuilding.ContainsKey("hospital"))
            {
                _ctx._nbBuilding["hospital"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("hospital", 1);
            }
        }

        public void CreateFireStation(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetFireStation);
            _ctx.AddBuilding(x, y, CityHelper.GetFireStation);

            if (_ctx._nbBuilding.ContainsKey("fireStation"))
            {
                _ctx._nbBuilding["fireStation"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("fireStation", 1);
            }
        }

        public void CreateCityHall(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetCityHall);
            _ctx.AddBuilding(x, y, CityHelper.GetCityHall);

            if (_ctx._nbBuilding.ContainsKey("cityHall"))
            {
                _ctx._nbBuilding["cityHall"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("cityHall", 1);
            }
        }

         public void CreateSawMill(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetSawmill);
            _ctx.AddBuilding(x, y, CityHelper.GetSawmill);

            if (_ctx._nbBuilding.ContainsKey("sawMill"))
            {
                _ctx._nbBuilding["sawMill"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("sawMill", 1);
            }
        }

        public void CreateOreMine(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetOreMine);
            _ctx.AddBuilding(x, y, CityHelper.GetOreMine);

            if (_ctx._nbBuilding.ContainsKey("oreMine"))
            {
                _ctx._nbBuilding["oreMine"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("oreMine", 1);
            }
        }


        public void CreateMetalMine(int x, int y)
        {
            _resourcesManager = new ResourcesManager(_ctx);
            _resourcesManager.UpdateWhenCreate(CityHelper.GetMetalMine);
            _ctx.AddBuilding(x, y, CityHelper.GetMetalMine);

            if (_ctx._nbBuilding.ContainsKey("metalMine"))
            {
                _ctx._nbBuilding["metalMine"]++;
            }
            else
            {
                _ctx._nbBuilding.Add("metalMine", 1);
            }
        }

        public void DestroyHut(int x, int y, Hut hut)
        {
           
            _ctx.RemoveBuilding(x, y, hut);

            if (_ctx._nbBuilding.ContainsKey("hut"))
            {
                _ctx._nbBuilding["hut"]--;
            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }
        }

        public void DestroyHouse(int x, int y, House house)
        {
            _ctx.RemoveBuilding(x, y, house);


            if (_ctx._nbBuilding.ContainsKey("house"))
            {
                _ctx._nbBuilding["house"]--;
            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }
        }

        public void DestroyFlat(int x, int y, Flat flat)
        {
            _ctx.RemoveBuilding(x, y, flat);


            if (_ctx._nbBuilding.ContainsKey("flat"))
            {
                _ctx._nbBuilding["flat"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyWarehouse(int x, int y, Warehouse warehouse)
        {
            _ctx.RemoveBuilding(x, y, warehouse);


            if (_ctx._nbBuilding.ContainsKey("wareHouse"))
            {
                _ctx._nbBuilding["wareHouse"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroySpaceStation(int x, int y, SpaceStation spaceStation)
        {
            _ctx.RemoveBuilding(x, y, spaceStation);


            if (_ctx._nbBuilding.ContainsKey("spaceStation"))
            {
                _ctx._nbBuilding["spaceStation"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyPumpingStation(int x, int y, PumpingStation pumpingStation)
        {
            _ctx.RemoveBuilding(x, y, pumpingStation);


            if (_ctx._nbBuilding.ContainsKey("pumpingStation"))
            {
                _ctx._nbBuilding["pumpingStation"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyPowerPlant(int x, int y, PowerPlant powerPlant)
        {
            _ctx.RemoveBuilding(x, y, powerPlant);


            if (_ctx._nbBuilding.ContainsKey("powerPlant"))
            {
                _ctx._nbBuilding["powerPlant"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyPoliceStation(int x, int y, PoliceStation policeStation)
        {
            _ctx.RemoveBuilding(x, y, policeStation);


            if (_ctx._nbBuilding.ContainsKey("policeStation"))
            {
                _ctx._nbBuilding["policeStation"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyHospital(int x, int y, Hospital hospital)
        {
            _ctx.RemoveBuilding(x, y, hospital);


            if (_ctx._nbBuilding.ContainsKey("hospital"))
            {
                _ctx._nbBuilding["hospital"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyFireStation(int x, int y, FireStation fireStation)
        {
            _ctx.RemoveBuilding(x, y, fireStation);


            if (_ctx._nbBuilding.ContainsKey("fireStation"))
            {
                _ctx._nbBuilding["fireStation"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyCityHall(int x, int y, CityHall cityHall)
        {
            _ctx.RemoveBuilding(x, y, cityHall);


            if (_ctx._nbBuilding.ContainsKey("cityHall"))
            {
                _ctx._nbBuilding["cityHall"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyMetalMine(int x, int y, MetalMine metalMine)
        {
            _ctx.RemoveBuilding(x, y, metalMine);


            if (_ctx._nbBuilding.ContainsKey("metalMine"))
            {
                _ctx._nbBuilding["metalMine"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroyOreMine(int x, int y, OreMine oreMine)
        {
            _ctx.RemoveBuilding(x, y, oreMine);


            if (_ctx._nbBuilding.ContainsKey("oreMine"))
            {
                _ctx._nbBuilding["oreMine"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }

        public void DestroySawMill(int x, int y, Sawmill sawmill)
        {
            _ctx.RemoveBuilding(x, y, sawmill);


            if (_ctx._nbBuilding.ContainsKey("sawMill"))
            {
                _ctx._nbBuilding["sawMill"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }


    }
}
