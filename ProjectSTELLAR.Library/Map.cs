using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Map
    {
        public Dictionary<string, int> _nbBuilding = new Dictionary<string, int>();
        int _height;
        int _width;
        Building _chosenBuilding;

        public Map (int width, int height)
        {
            _width = width;
            _height = height;
        }

        public int Width => _width;

        public int Height => _height;

        public Building ChosenBuilding
        {
            get { return _chosenBuilding; }
            set { _chosenBuilding = value; }
        }
        
        public Building[,] _boxes = new Building[20, 20];

        public Building[,] Boxes
        {
            get => _boxes;
            set => _boxes = value;
        }

        public void AddBuilding(int x, int y)
        {
            if(CheckBuilding(x,y) == false)
            {
                _boxes[x, y] = _chosenBuilding;
                _chosenBuilding = null;
            }
            else
            {
                throw new ArgumentException("You can't build a building if the box isn't empty");
            }
        }

        public void RemoveBuilding(int x, int y, Building building)
        {
            _boxes[x, y] = null;
        }

        public bool CheckBuilding(int x, int y)
        {
            if (_boxes[x, y] != null) return true;
            return false;
        }

 

        public Dictionary<string, int> NbBuilding
        {
            get { return _nbBuilding; }
            set { _nbBuilding = value; }
        }


        //public void CreateHut(int x, int y)
        //{
        //    Hut hut = new Hut(this, 10, 30, 50, 0, 10, 10, 0, 5, false, 20, true);
        //    this.AddBuilding(x, y, hut);



        //    if (_nbBuilding.ContainsKey("hut"))
        //    {
        //        _nbBuilding["hut"] ++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("hut", 1);
        //    }

        //}


        //public void CreateHouse(int x, int y)
        //{
        //    House house = new House(this, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
        //    this.AddBuilding(x, y, house);

        //    if (_nbBuilding.ContainsKey("house"))
        //    {
        //        _nbBuilding["house"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("house", 1);
        //    }
        //}

        //public void CreateFlat(int x, int y)
        //{
        //    Flat flat = new Flat(this, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
        //    this.AddBuilding(x, y, flat);

        //    if (_nbBuilding.ContainsKey("flat"))
        //    {
        //        _nbBuilding["flat"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("flat", 1);
        //    }
        //}

        //public void CreateWarehouse(int x, int y)
        //{
        //    Warehouse warehouse = new Warehouse(this, 12, 20, 20, 5, 15, 15, 0, 0, false, 0, false);
        //    this.AddBuilding(x, y, warehouse);



        //    if (_nbBuilding.ContainsKey("wareHouse"))
        //    {
        //        _nbBuilding["wareHouse"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("wareHouse", 1);
        //    }

        //}

        //public void CreateSpaceStation(int x, int y)
        //{
        //    SpaceStation spaceStation = new SpaceStation(this, 85, 120, 250, 45, 50, 40, 25, 20, true, 75, false);
        //    this.AddBuilding(x, y, spaceStation);



        //    if (_nbBuilding.ContainsKey("spaceStation"))
        //    {
        //        _nbBuilding["spaceStation"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("spaceStation", 1);
        //    }

        //}

        //public void CreatePumpingStation(int x, int y)
        //{
        //    PumpingStation pumpingStation = new PumpingStation(this, 25, 38, 30, 17, 0, 10, 20, 25, true, 20, true);
        //    this.AddBuilding(x, y, pumpingStation);



        //    if (_nbBuilding.ContainsKey("pumpingStation"))
        //    {
        //        _nbBuilding["pumpingStation"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("pumpingStation", 1);
        //    }

        //}

        //public void CreatePowerPlant(int x, int y)
        //{
        //    PowerPlant powerPlant = new PowerPlant(this, 25, 38, 30, 17, 10, 0, 20, 25, true, 20, true);
        //    this.AddBuilding(x, y, powerPlant);



        //    if (_nbBuilding.ContainsKey("powerPlant"))
        //    {
        //        _nbBuilding["powerPlant"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("powerPlant", 1);
        //    }

        //}

        //public void CreatePoliceStation(int x, int y)
        //{
        //    PoliceStation policeStation = new PoliceStation(this, 70, 45, 60, 70, 35, 45, 25, 25, true, 40, false);
        //    this.AddBuilding(x, y, policeStation);



        //    if (_nbBuilding.ContainsKey("policeStation"))
        //    {
        //        _nbBuilding["policeStation"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("policeStation", 1);
        //    }

        //}

        //public void CreateHospital(int x, int y)
        //{
        //    Hospital hospital = new Hospital(this, 59, 80, 80, 60, 55, 75, 10, 30, true, 100, false);
        //    this.AddBuilding(x, y, hospital);



        //    if (_nbBuilding.ContainsKey("hospital"))
        //    {
        //        _nbBuilding["hospital"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("hospital", 1);
        //    }

        //}

        //public void CreateFireStation(int x, int y)
        //{
        //    FireStation fireStation = new FireStation(this, 60, 25, 80, 75, 60, 70, 35, 25, true, 55, false);
        //    this.AddBuilding(x, y, fireStation);



        //    if (_nbBuilding.ContainsKey("fireStation"))
        //    {
        //        _nbBuilding["fireStation"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("fireStation", 1);
        //    }

        //}

        //public void CreateCityHall(int x, int y)
        //{
        //    CityHall cityHall = new CityHall(this, 90, 120, 85, 60, 30, 30, 0, 50, true, 200, false);
        //    this.AddBuilding(x, y, cityHall);



        //    if (_nbBuilding.ContainsKey("cityHall"))
        //    {
        //        throw new ArgumentException("Your city can't have more than 1 city Hall");
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("cityHall", 1);
        //    }

        //}


        //public void CreateMetalMine(int x, int y)
        //{
        //    MetalMine metalMine = new MetalMine(this, 50, 60, 30, 0, 45, 30, 15, 20, false, 0, false);
        //    this.AddBuilding(x, y, metalMine);



        //    if (_nbBuilding.ContainsKey("metalMine"))
        //    {
        //        _nbBuilding["metalMine"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("metalMine", 1);
        //    }

        //}

        //public void CreateOreMine(int x, int y)
        //{
        //    OreMine oreMine = new OreMine(this, 0, 80, 50, 10, 45, 30, 15, 20, false, 0, false);
        //    this.AddBuilding(x, y, oreMine);



        //    if (_nbBuilding.ContainsKey("oreMine"))
        //    {
        //        _nbBuilding["oreMine"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("oreMine", 1);
        //    }

        //}

        //public void CreateSawMill(int x, int y)
        //{
        //    Sawmill sawMill = new Sawmill(this, 50, 0, 50, 10, 45, 30, 15, 20, false, 0, false);
        //    this.AddBuilding(x, y, sawMill);



        //    if (_nbBuilding.ContainsKey("sawMill"))
        //    {
        //        _nbBuilding["sawMill"]++;
        //    }
        //    else
        //    {
        //        _nbBuilding.Add("sawMill", 1);
        //    }

        //}

        //public void DestroyHut(int x, int y,  Hut hut)
        //{
        //    this.RemoveBuilding(x, y, hut);

        //    if (_nbBuilding.ContainsKey("hut"))
        //    {
        //        _nbBuilding["hut"]--;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }
        //}

        //public void DestroyHouse(int x, int y, House house)
        //{
        //    this.RemoveBuilding(x, y, house);


        //    if (_nbBuilding.ContainsKey("house"))
        //    {
        //        _nbBuilding["house"]--;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }
        //}

        //public void DestroyFlat(int x, int y, Flat flat)
        //{
        //    this.RemoveBuilding(x, y, flat);


        //    if (_nbBuilding.ContainsKey("flat"))
        //    {
        //        _nbBuilding["flat"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyWarehouse(int x, int y, Warehouse warehouse)
        //{
        //    this.RemoveBuilding(x, y, warehouse);


        //    if (_nbBuilding.ContainsKey("wareHouse"))
        //    {
        //        _nbBuilding["wareHouse"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroySpaceStation(int x, int y, SpaceStation spaceStation)
        //{
        //    this.RemoveBuilding(x, y, spaceStation);


        //    if (_nbBuilding.ContainsKey("spaceStation"))
        //    {
        //        _nbBuilding["spaceStation"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyPumpingStation(int x, int y, PumpingStation pumpingStation)
        //{
        //    this.RemoveBuilding(x, y, pumpingStation);


        //    if (_nbBuilding.ContainsKey("pumpingStation"))
        //    {
        //        _nbBuilding["pumpingStation"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyPowerPlant(int x, int y, PowerPlant powerPlant)
        //{
        //    this.RemoveBuilding(x, y, powerPlant);


        //    if (_nbBuilding.ContainsKey("powerPlant"))
        //    {
        //        _nbBuilding["powerPlant"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyPoliceStation(int x, int y, PoliceStation policeStation)
        //{
        //    this.RemoveBuilding(x, y, policeStation);


        //    if (_nbBuilding.ContainsKey("policeStation"))
        //    {
        //        _nbBuilding["policeStation"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyHospital(int x, int y, Hospital hospital)
        //{
        //    this.RemoveBuilding(x, y, hospital);


        //    if (_nbBuilding.ContainsKey("hospital"))
        //    {
        //        _nbBuilding["hospital"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyFireStation(int x, int y, FireStation fireStation)
        //{
        //    this.RemoveBuilding(x, y, fireStation);


        //    if (_nbBuilding.ContainsKey("fireStation"))
        //    {
        //        _nbBuilding["fireStation"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyCityHall(int x, int y, CityHall cityHall)
        //{
        //    this.RemoveBuilding(x, y, cityHall);


        //    if (_nbBuilding.ContainsKey("cityHall"))
        //    {
        //        _nbBuilding["cityHall"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyMetalMine(int x, int y, MetalMine metalMine)
        //{
        //    this.RemoveBuilding(x, y, metalMine);


        //    if (_nbBuilding.ContainsKey("metalMine"))
        //    {
        //        _nbBuilding["metalMine"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroyOreMine(int x, int y, OreMine oreMine)
        //{
        //    this.RemoveBuilding(x, y, oreMine);


        //    if (_nbBuilding.ContainsKey("oreMine"))
        //    {
        //        _nbBuilding["oreMine"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

        //public void DestroySawMill(int x, int y, Sawmill sawmill)
        //{
        //    this.RemoveBuilding(x, y, sawmill);


        //    if (_nbBuilding.ContainsKey("sawMill"))
        //    {
        //        _nbBuilding["sawMill"]--;

        //    }
        //    else
        //    {
        //        throw new ArgumentException("You're trying to destroy a building wich isn't register");
        //    }

        //}

    }
}
