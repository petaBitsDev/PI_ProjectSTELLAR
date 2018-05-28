using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.BuildingInstance
{
    class Building 
    {
        BuildingType _buildingType;
        float _x;
        float _y;
        public Building(BuildingType buildingType, float x, float y)
        {
            _buildingType = buildingType;
            _x = x;
            _y = y;
        }
    }
}
