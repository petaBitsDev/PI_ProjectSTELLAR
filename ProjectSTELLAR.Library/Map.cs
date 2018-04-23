using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Map
    {
       public  Dictionary<string, int> _nbBuilding = new Dictionary<string, int>();
        public Building[,] _boxes = new Building[10, 10];
        internal int _countHut = 0;
        internal int _countHouse = 0;
        internal int _countFlat = 0;

        public Building[,] Boxes
        {
            get => _boxes;
            set => _boxes = value;
        }

        public void AddBuilding(int x, int y, Building building)
        {
            if(CheckBuilding(x,y) == false)
            {
                _boxes[x, y] = building;
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


        public void CreateHut(int x, int y)
        {
            Hut hut = new Hut(this, 10, 30, 50, 0, 10, 10, 0, 5, false, 20, true);
            this.AddBuilding(x, y, hut);
          


            if (_nbBuilding.ContainsKey("hut"))
            {
                _nbBuilding["hut"] ++;
            }
            else
            {
                _nbBuilding.Add("hut", 1);
            }
            
        }


        public void CreateHouse(int x, int y)
        {
            House house = new House(this, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
            this.AddBuilding(x, y, house);

            if (_nbBuilding.ContainsKey("house"))
            {
                _nbBuilding["house"]++;
            }
            else
            {
                _nbBuilding.Add("house", 1);
            }
        }

        public void CreateFlat(int x, int y)
        {
            Flat flat = new Flat(this, 65, 120, 110, 15, 25, 30, 5, 20, false, 50, true);
            this.AddBuilding(x, y, flat);

            if (_nbBuilding.ContainsKey("flat"))
            {
                _nbBuilding["flat"]++;
            }
            else
            {
                _nbBuilding.Add("flat", 1);
            }
        }

        public void DestroyHut(int x, int y,  Hut hut)
        {
            this.RemoveBuilding(x, y, hut);

            if (_nbBuilding.ContainsKey("hut"))
            {
                _nbBuilding["hut"]--;
            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }
        }

        public void DestroyHouse(int x, int y, House house)
        {
            this.RemoveBuilding(x, y, house);


            if (_nbBuilding.ContainsKey("house"))
            {
                _nbBuilding["house"]--;
            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }
        }

        public void DestroyFlat(int x, int y, Flat flat)
        {
            this.RemoveBuilding(x, y, flat);


            if (_nbBuilding.ContainsKey("flat"))
            {
                _nbBuilding["flat"]--;

            }
            else
            {
                throw new ArgumentException("You're trying to destroy a building wich isn't register");
            }

        }


    }
}
