using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class PoliceStationType : BuildingType
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
        List<Building> _list;

        public PoliceStationType()
        {
            _rock = 45;
            _wood = 100;
            _coin = 60;
            _metal = 55;
            _electricity = 25;
            _water = 20;
            _pollution = 15;
            _nbPeople = 20;
            _cost = 40;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new PoliceStation(x, y);
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
        public override List<Building> List => _list;

        internal int NbPoliceStation => this.List.Count;

    }
}
