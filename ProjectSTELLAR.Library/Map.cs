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
        SpaceShipsTypes _spaceShipType;
        int _nbSpaceShip;

        public Map (int width, int height)
        {
            _width = width;
            _height = height;
            _boxes = new Building[height, width];
            _spaceShipType = new SpaceShipsTypes();
            _buildingTypes = new List<BuildingType>
            {
              /* 0 */ new CityHallType(),
              /* 1 */ new FireStationType(),
              /* 2 */ new FlatType(),
              /* 3 */ new HospitalType(),
              /* 4 */ new HouseType(),
              /* 5 */ new HutType(),
              /* 6 */ new MetalMineType(),
              /* 7 */ new OreMineType(),
              /* 8 */ new PoliceStationType(),
              /* 9 */ new PowerPlantType(),
              /* 10*/ new PumpingStationType(),
              /* 11*/ new SawmillType(),
              /* 12*/ new SpaceStationType(),
              /* 13*/ new WarehouseType(),
              /* 14*/ new FactoryType(),
              /* 15*/ new ShopType(),
              /* 16*/ new ParkType()
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
                building.SpritePosition = new Vector(x, y);
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
            //_chosenBuilding = null;
        }

        public void RemoveBuilding(int x, int y)
        {
            int size = _boxes[x, y].Size;
            int realX = _boxes[x, y].X;
            int realY = _boxes[x, y].Y;

            _boxes[realX, realY] = null;
            if (size == 1) _boxes[realX, realY] = null;
            else if (size == 4)
            {
                _boxes[realX, realY] = null;
                _boxes[realX + 1, realY] = null;
                _boxes[realX, realY + 1] = null;
                _boxes[realX + 1, realY + 1] = null;
            }
            else if (size == 6)
            {
                _boxes[realX, realY] = null;
                _boxes[realX + 1, realY] = null;
                _boxes[realX, realY + 1] = null;
                _boxes[realX + 1, realY + 1] = null;
                _boxes[realX, realY + 2] = null;
                _boxes[realX + 1, realY + 2] = null;
            }
        }

        public void GenerateSpaceShips (ResourcesManager resourcesManager)
        {
            _nbSpaceShip = resourcesManager.NbResources["nbPeople"] / 300;

            if (_nbSpaceShip > _spaceShipType.List.Count)
            { 
                _spaceShipType.CreateInstance(this);
            }
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

        public int NbSpaceShips => _nbSpaceShip;

        public List<SpaceShips> SpaceShipsList => _spaceShipType.List;

        public void SetSpaceShipTypes()
        {
            _spaceShipType = new SpaceShipsTypes();
        }
    }
}
