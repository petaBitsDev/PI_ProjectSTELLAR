using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class SawmillType : BuildingType
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

        public SawmillType()
        {
            _rock = 15;
            _wood = 0;
            _coin = 25;
            _metal = 5;
            _electricity = 10;
            _water = 10;
            _pollution = 20;
            _nbPeople = 15;
            _cost = 0;
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
