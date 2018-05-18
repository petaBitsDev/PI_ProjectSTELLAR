using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    [Serializable]
    public class Map
    {
        public Dictionary<Building, int> _nbBuilding = new Dictionary<Building, int>();
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
                _chosenBuilding = null;
                //throw new ArgumentException("You can't build a building if the box isn't empty");
            }
        }

        public void RemoveBuilding(int x, int y)
        {
            _boxes[x, y] = null;
        }

        public bool CheckBuilding(int x, int y)
        {
            if (_boxes[x, y] != null) return true;
            return false;
        }
        
        public Dictionary<Building, int> NbBuilding
        {
            get { return _nbBuilding; }
            set { _nbBuilding = value; }
        }
    }
}
