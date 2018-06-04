using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class FireStationType : BuildingType
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

        public FireStationType()
        {
            _rock = 45;
            _wood = 10;
            _coin = 35;
            _metal = 80;
            _electricity = 25;
            _water = 70;
            _pollution = 25;
            _nbPeople = 22;
            _cost = -35;
            _type = "public";
            _size = 4;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new FireStation(this, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
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
        public override int NbBuilding => _list.Count;
    }
}
