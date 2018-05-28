using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class HouseType : BuildingType
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

        public HouseType()
        {
            _rock = 40;
            _wood = 75;
            _coin = 40;
            _metal = 15;
            _electricity = 20;
            _water = 25;
            _pollution = 10;
            _nbPeople = 25;
            _cost = 45;
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
        public override List<Building> List => _list;
    }
}
