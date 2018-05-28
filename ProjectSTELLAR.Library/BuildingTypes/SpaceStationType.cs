using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<< Updated upstream:ProjectSTELLAR.Library/Building/Types/SpaceStationType.cs
namespace ProjectStellar
=======
namespace ProjectStellar.Library
>>>>>>> Stashed changes:ProjectSTELLAR.Library/BuildingTypes/SpaceStationType.cs
{
    public class SpaceStationType : BuildingType
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


        public SpaceStationType()
        {
            _rock = 70;
            _wood = 120;
            _coin = 100;
            _metal = 90;
            _electricity = 70;
            _water = 50;
            _pollution = 25;
            _nbPeople = 30;
            _cost = 70;
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
