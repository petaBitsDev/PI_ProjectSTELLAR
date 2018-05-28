using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< Updated upstream:ProjectSTELLAR.Library/Building/Types/WarehouseType.cs
namespace ProjectStellar
=======
namespace ProjectStellar.Library
>>>>>>> Stashed changes:ProjectSTELLAR.Library/BuildingTypes/WarehouseType.cs
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
