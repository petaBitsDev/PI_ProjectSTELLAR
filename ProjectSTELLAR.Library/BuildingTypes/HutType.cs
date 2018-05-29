using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class HutType : BuildingType
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

        public HutType()
        {
            _rock = 25;
            _wood = 50;
            _coin = 15;
            _metal = 0;
            _electricity = 5;
            _water = 5;
            _pollution = 0;
            _nbPeople = 5;
            _cost = 20;
            _type = "habitation";
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new Hut(x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
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
        public override List<Building> List => _list;

        internal int NbHut => this.List.Count;
    }
}
