using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class Map
    {
        public Dictionary<Building, int> _nbBuilding = new Dictionary<Building, int>();
        int _height;
        int _width;
        BuildingType _chosenBuilding;
        public Building[,] _boxes;
        readonly List<BuildingType> _buildingTypes;

        public Map (int width, int height)
        {
            _width = width;
            _height = height;
            _boxes = new Building[height, width];
            _buildingTypes = new List<BuildingType>
            {
                new CityHallType(),
                new FireStationType(),
                new FlatType(),
                new HospitalType(),
                new HouseType(),
                new HutType(),
                new MetalMineType(),
                new OreMineType(),
                new PoliceStationType(),
                new PowerPlantType(),
                new PumpingStationType(),
                new SawmillType(),
                new SpaceStationType(),
                new WarehouseType()
            };
        }

        public List<BuildingType> BuildingTypes => _buildingTypes;

        public int Width => _width;

        public int Height => _height;

        public BuildingType ChosenBuilding
        {
            get { return _chosenBuilding; }
            set { _chosenBuilding = value; }
        }

        public Building[,] Boxes
        {
            get => _boxes;
            set => _boxes = value;
        }

        public void AddBuilding(int x, int y, Building building)
        {
            if(CheckBuilding(x,y) == false)
            {
                if(building.Size == 1) _boxes[x, y] = building;
                else if (building.Size == 4)
                {
                    _boxes[x, y] = building;
                    _boxes[x + 1, y] = building;
                    _boxes[x, y + 1] = building;
                    _boxes[x + 1, y + 1] = building;
                }
                else if (building.Size == 6)
                {
                    _boxes[x, y] = building;
                    _boxes[x + 1, y] = building;
                    _boxes[x, y + 1] = building;
                    _boxes[x + 1, y + 1] = building;
                    _boxes[x, y + 2] = building;
                    _boxes[x + 1, y + 2] = building;
                    
                }
            }
            _chosenBuilding = null;
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
