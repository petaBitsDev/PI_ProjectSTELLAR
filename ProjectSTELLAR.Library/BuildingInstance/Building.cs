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
        readonly int _x;
        readonly int _y;
        List<Building> _instanceBuilding = new List<Building>();

        public Building(BuildingType buildingType, int x, int y)
        {
            _x = x;
            _y = y;
            _buildingType = buildingType;
        }

        public int X => _x;
        public int Y => _y;
        public BuildingType Type => _buildingType;
        public int Size => _buildingType.Size;
    }
}
