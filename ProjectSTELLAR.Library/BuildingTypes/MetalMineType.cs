using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class MetalMineType : BuildingType
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
        int _metalProduction;
        string _type;
        List<Building> _list;
        int _size;
        int _maxMetalCapacity = 0;
        int _metalCapacity;


        public MetalMineType()
        {
            _rock = 15;
            _wood = 15;
            _coin = 25;
            _metal = 0;
            _electricity = 10;
            _water = 10;
            _pollution = 20;
            _nbPeople = 15;
            _cost = 0;
            _metalProduction = 50;
            _type = "resource";
            _size = 4;
            _metalCapacity = 500;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new MetalMine(this, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
            MaxMetalCapacity += _metalCapacity;
        }

        public override int Cost => _cost;
        public override int Coin => _coin;
        public override int Wood => _wood;
        public override int Rock => _rock;
        public override int Metal => _metal;
        public override int Water => _water;
        public override int Electricity => _electricity;
        public override int Pollution => _pollution;
        public override int NbPeople => _nbPeople;
        public override string Type => _type;

        public int MetalProduction => _metalProduction;
        public override List<Building> List => _list;
        public override int Size => _size;
        public override int NbBuilding => _list.Count;

        public int MaxMetalCapacity
        {
            get { return _maxMetalCapacity; }
            set { _maxMetalCapacity = value; }
        }
    }
}
