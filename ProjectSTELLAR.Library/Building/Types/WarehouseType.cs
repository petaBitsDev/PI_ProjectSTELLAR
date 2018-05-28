using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library.Building.Types
{
    public class WarehouseType : BuildingType
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

        public WarehouseType()
        {
            _rock = 15;
            _wood = 30;
            _coin = 10;
            _metal = 5;
            _electricity = 10;
            _water = 0;
            _pollution = 0;
            _nbPeople = 5;
            _cost = 0;
        }

        public override int Rock { get; }
        public override int Wood { get; }
        public override int Coin { get; }
        public override int Metal { get; }
        public override int Electricity { get; }
        public override int Water { get; }
        public override int Pollution { get; }
        public override int NbPeople { get; }
        public override int Cost { get; }
        

        public override int Count()
        {
            return _list.Count;
        }
    }
}
