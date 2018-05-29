using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace ProjectStellar.Library
    {
        public class PumpingStationType : BuildingType
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

        public PumpingStationType()
        {
            _rock = 25;
            _wood = 38;
            _coin = 25;
            _metal = 30;
            _electricity = 30;
            _water = 0;
            _pollution = 15;
            _nbPeople = 15;
            _cost = -12;
            _type = "resource";
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new PumpingStation(x, y);
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

        internal int NbPumpingStation => this.List.Count;

    }
}
