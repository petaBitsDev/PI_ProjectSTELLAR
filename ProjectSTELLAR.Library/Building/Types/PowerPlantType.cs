using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.Building.Types
{
    public class PowerPlantType : BuildingType
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

        public PowerPlantType()
        {
            _rock = 25;
            _wood = 38;
            _coin = 25;
            _metal = 30;
            _electricity = 0;
            _water = 30;
            _pollution = 15;
            _nbPeople = 15;
            _cost = 12;
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
    }
}
