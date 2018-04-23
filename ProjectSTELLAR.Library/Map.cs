using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Map
    {
        int _width;
        int _height;

        public Map (int width, int height)
        {
            _width = width;
            _height = height;
        }
        public int Width => _width;
        public int Height => _height;

        public Building[,] _boxes = new Building[20, 20];

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


    }
}
