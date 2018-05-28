using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    class Building 
    {
        BuildingType _buildingType;
        int _x;
        int _y;
        List<Building> _instanceBuilding = new List<Building>();
    

        public int X => _x;
        public int Y => _y;
        public BuildingType Type => _buildingType;
        public List<Building> InstanceBuilding => _instanceBuilding;

        //public BuildingType Hospital
        //{
        //    get {  _instanceBuilding.Contains<Hospital> }
        //}
    }
}
