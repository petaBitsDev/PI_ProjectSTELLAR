using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class CityHelper
    {
       MetalMine metalMine;
       OreMine oreMine;
       Sawmill sawMill;
       CityHall cityHall;
       FireStation fireStation ;
       Hospital hospital;
       PoliceStation policeStation ;
       PowerPlant powerPlant;
       PumpingStation pumpingStation ;
       SpaceStation spaceStation;
       Warehouse warehouse ;
       Flat flat ;
       House house ;
       Hut hut;

        Map _map;
       public CityHelper(Map map)
       {
           _map = map;

             metalMine = new MetalMine(_map, 50, 60, 30, 0, 45, 30, 15, 20, false, 0, false);
            oreMine = new OreMine(_map, 0, 80, 50, 10, 45, 30, 15, 20, false, 0, false);
             sawMill = new Sawmill(_map, 50, 0, 50, 10, 45, 30, 15, 20, false, 0, false);
             cityHall = new CityHall(_map, 90, 120, 85, 60, 30, 30, 0, 50, true, 200, false);
            fireStation = new FireStation(_map, 60, 25, 80, 75, 60, 70, 35, 25, true, 55, false);
            hospital = new Hospital(_map, 59, 80, 80, 60, 55, 75, 10, 30, true, 100, false);
            policeStation = new PoliceStation(_map, 70, 45, 60, 70, 35, 45, 25, 25, true, 40, false);
            powerPlant = new PowerPlant(_map, 25, 38, 30, 17, 10, 0, 20, 25, true, 20, true);
             pumpingStation = new PumpingStation(_map, 25, 38, 30, 17, 0, 10, 20, 25, true, 20, true);
             spaceStation = new SpaceStation(_map, 85, 120, 250, 45, 50, 40, 25, 20, true, 75, false);
             warehouse = new Warehouse(_map, 12, 20, 20, 5, 15, 15, 0, 0, false, 0, false);
             flat = new Flat(_map, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
             house = new House(_map, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
             hut = new Hut(_map, 10, 30, 50, 0, 10, 10, 0, 5, false, 20, true);


        }

        static List<Building> _listBuilding = new List<Building>();

        public List<Building> ListBuilding
        {
            get
            {
                _listBuilding.Add(metalMine);
                _listBuilding.Add(oreMine);
                _listBuilding.Add(sawMill);
                _listBuilding.Add(cityHall);
                _listBuilding.Add(fireStation);
                _listBuilding.Add(hospital);
                _listBuilding.Add(policeStation);
                _listBuilding.Add(powerPlant);
                _listBuilding.Add(pumpingStation);
                _listBuilding.Add(spaceStation);
                _listBuilding.Add(warehouse);
                _listBuilding.Add(flat);
                _listBuilding.Add(house);
                _listBuilding.Add(hut);
                return _listBuilding;
            }
        }

        public Building GetMetalMine
        {
            get
            {
                foreach(Building b in _listBuilding)
                {
                    if (b is MetalMine metalMine) return metalMine;
                }
                return null;
            }
        }

        public Building GetOreMine
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is OreMine oreMine) return oreMine ;
                }
                return null;
            }
        }

        public Building GetSawmill
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is Sawmill sawmill) return sawmill;
                }
                return null;
            }
        }

        public Building GetCityHall
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is CityHall cityHall) return cityHall;
                }
                return null;
            }
        }

        public Building GetFireStation
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is FireStation fireStation) return fireStation;
                }
                return null;
            }
        }

        public Building GetHospital
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is Hospital hospital) return hospital;
                }
                return null;
            }
        }

        public Building GetPoliceStation
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is PoliceStation policeStation) return policeStation;
                }
                return null;
            }
        }

        public Building GetPowerPlant
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is PowerPlant powerPlant) return powerPlant;
                }
                return null;
            }
        }

        public Building GetPumpingStation
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is PumpingStation pumpingStation) return pumpingStation;
                }
                return null;
            }
        }

        public Building GetSpaceStation
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is SpaceStation spaceStation) return spaceStation;
                }
                return null;
            }
        }

        public Building GetWareHouse
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is Warehouse warehouse) return warehouse;
                }
                return null;
            }
        }

        public Building GetFlat
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is Flat flat ) return flat;
                }
                return null;
            }
        }

        public Building GetHouse
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is House house) return house;
                }
                return null;
            }
        }

        public Building GetHut
        {
            get
            {
                foreach (Building b in _listBuilding)
                {
                    if (b is Hut hut) return hut;
                }
                return null;
            }
        }
    }
}
