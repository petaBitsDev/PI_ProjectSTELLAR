using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class WarehouseType : BuildingType
    {
        int _cost;
        int _coin;
        int _wood;
        int _rock;
        int _metal;
        int _water;
        int _electricity;
        int _pollution;
        int _nbPeople;
        int _woodCapacity;
        int _metalCapacity;
        int _rockCapacity;
        string _type;
        List<Building> _list;
        int _size;
        int _maxMetalCapacity = 0;
        int _maxWoodCapacity = 0;
        int _maxRockCapacity = 0;

        public WarehouseType()
        {
            _rock = 15;
            _wood = 30;
            _coin = 10;
            _metal = 5;
            _electricity = 10;
            _water = 0;
            _pollution = 0;
            _nbPeople = 5;
            _cost = 0;
            _type = "public";
            _size = 4;
            _woodCapacity = 3000;
            _metalCapacity = 1000;
            _rockCapacity = 2000;
            
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new Warehouse(this, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
            _maxMetalCapacity += _metalCapacity;
            _maxWoodCapacity += _woodCapacity;
            _maxRockCapacity += RockCapacity;
        }

        public override int Rock => _rock;
        public override int Wood => _wood;
        public override int Coin => _coin;
        public override int Metal => _metal;
        public override int Electricity => _electricity;
        public override int Water => _water;
        public override int Pollution => _pollution;
        public override int NbPeople => _nbPeople;
        public override int Cost => _cost;
        public override string Type => _type;
        public override List<Building> List => _list;
        public override int Size => _size;

        public int WoodCapacity
        {
            get { return _woodCapacity; }
            set { _woodCapacity = value; }
        }
        public int RockCapacity
        {
            get { return _rockCapacity; }
            set { _rockCapacity = value; }
        }
        public int MetalCapacity
        {
            get { return _metalCapacity; }
            set { _metalCapacity = value; }
        }

        public override int NbBuilding => _list.Count;

        public int MaxMetalCapacity
        {
            get { return _maxMetalCapacity; }
            set { _maxMetalCapacity = value; }
        }

        public int MaxWoodCapacity
        {
            get { return _maxWoodCapacity; }
            set { _maxWoodCapacity = value; }
        }

        public int MaxRockCapacity
        {
            get { return _maxRockCapacity; }
            set { _maxRockCapacity = value; }
        }
    }
}
