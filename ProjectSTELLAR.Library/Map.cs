using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Map
    {
        public Building[,] _boxes = new Building[10, 10];

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
