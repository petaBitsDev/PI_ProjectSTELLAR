using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public abstract class Building
    {
        BuildingType _buildingType;
        int _x;
        int _y;
        List<Building> _instanceBuilding = new List<Building>();

        public int X => _x;
        public int Y => _y;
        public BuildingType Type => _buildingType;
    }
}
