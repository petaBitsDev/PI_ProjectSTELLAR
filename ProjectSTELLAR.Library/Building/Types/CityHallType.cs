using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.Building.Types
{
    public class CityHallType : BuildingType
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

        public CityHallType()
        {
            _rock = 100;
            _wood = 150;
            _coin = 80;
            _metal = 50;
            _electricity = 20;
            _water = 20;
            _pollution = 5;
            _nbPeople = 50;
            _cost = 200;
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
    }
}
