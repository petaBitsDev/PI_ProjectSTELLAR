using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class CityHelper
    {
       MetalMine metalMine;
       OreMine oreMine;
       SawMill sawMill;
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

           metalMine = new MetalMine(_map, 70);
           oreMine = new OreMine(_map, 70);
           sawMill = new Sawmill(_map, 70);
           cityHall = new CityHall(_map);
           fireStation = new FireStation(_map);
           hospital = new Hospital(_map);
           policeStation = new PoliceStation(_map);
           powerPlant = new PowerPlant(_map, 220);
           pumpingStation = new PumpingStation(_map, 250);
           spaceStation = new SpaceStation(_map);
           warehouse = new Warehouse(_map);
           flat = new Flat(_map);
           house = new House(_map);
           hut = new Hut(_map);


        }

        static List<BuildingType> _listBuilding = new List<BuildingType>();

        public List<BuildingType> ListBuilding
        {
            get
            {
                return _listBuilding;
            }
        }

        public void CreateListBuilding()
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
        }

         public MetalMine GetMetalMine
        {
            get
            {
                foreach(BuildingType b in _listBuilding)
                {
                    if (b is MetalMine metalMine) return metalMine;
                }
                return null;
            }
        }

         public OreMine GetOreMine
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is OreMine oreMine) return oreMine ;
                }
                return null;
            }
        }

         public Sawmill GetSawmill
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is Sawmill sawmill) return sawmill;
                }
                return null;
            }
        }

         public CityHall GetCityHall
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is CityHall cityHall) return cityHall;
                }
                return null;
            }
        }

         public FireStation GetFireStation
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is FireStation fireStation) return fireStation;
                }
                return null;
            }
        }

         public Hospital GetHospital
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is Hospital hospital) return hospital;
                }
                return null;
            }
        }

         public PoliceStation GetPoliceStation
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is PoliceStation policeStation) return policeStation;
                }
                return null;
            }
        }

         public PowerPlant GetPowerPlant
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is PowerPlant powerPlant) return powerPlant;
                }
                return null;
            }
        }

         public PumpingStation GetPumpingStation
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is PumpingStation pumpingStation) return pumpingStation;
                }
                return null;
            }
        }

         public SpaceStation GetSpaceStation
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is SpaceStation spaceStation) return spaceStation;
                }
                return null;
            }
        }

         public Warehouse GetWareHouse
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is Warehouse warehouse) return warehouse;
                }
                return null;
            }
        }

         public Flat GetFlat
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is Flat flat ) return flat;
                }
                return null;
            }
        }

         public House GetHouse
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is House house) return house;
                }
                return null;
            }
        }

         public Hut GetHut
        {
            get
            {
                foreach (BuildingType b in _listBuilding)
                {
                    if (b is Hut hut) return hut;
                }
                return null;
            }
        }
    }
}
