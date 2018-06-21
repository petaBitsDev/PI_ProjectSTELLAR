using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SpaceStationType : BuildingType
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
        string _type;
        List<Building> _list;
        int _size;
        int _unlockingLevel;

        public SpaceStationType()
        {
            _rock = 70;
            _wood = 120;
            _coin = 100;
            _metal = 90;
            _electricity = 70;
            _water = 50;
            _pollution = 25;
            _nbPeople = 30;
            _cost = 70;
            _type = "public";
            _size = 6;
            _list = new List<Building>();
            _unlockingLevel = 10;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new SpaceStation(this, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
        }

        public override int UnlockingLevel => _unlockingLevel;
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
        public override int NbBuilding => _list.Count;
    }
}