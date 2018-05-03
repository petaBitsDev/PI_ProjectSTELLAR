using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjectStellar
{
   public  abstract class Building
    {
        bool _isBuild;
        //cost money is true for public buildings and false for the building wich pay taxes
        bool _costMoney;
        readonly int _woodNeeded;
        readonly int _rockNeeded;
        readonly int _stellarCoinNeeded;
        readonly int _metalNeeded;
        readonly int _waterConsume;
        readonly int _electricityConsume;
        readonly int _airPollution;
        readonly int _nbPeople;
        int _moneyWinOrLost;
        Map _ctx ;

        public Building(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost)
        {
            _isBuild = true;
            _rockNeeded = rockNeeded;
            _woodNeeded = woodNeeded;
            _stellarCoinNeeded = stellarCoinNeeded;
            _metalNeeded = metalNeeded;
            _electricityConsume = electricityConsume;
            _waterConsume = waterConsume;
            _airPollution = airPollution;
            _nbPeople = nbPeople;
            _costMoney = costMoney;
            _moneyWinOrLost = moneyWinOrLost;
            _ctx = ctx;
        }

        public int MoneyWinOrLost => _moneyWinOrLost;

        public int RockNeeded => _rockNeeded;


        public int WoodNeeded => _woodNeeded;

        public int MetalNeeded => _metalNeeded;


        public int StellarCoinNeeded => _stellarCoinNeeded;

        public int ElectricityConsume => _electricityConsume;

        public int WaterConsume => _waterConsume;

        public int AirPollution => _airPollution;

        public int NbPeople => _nbPeople;

        public bool IsBuild
        {
            get { return _isBuild; }
            set { _isBuild = value; }
        }

        protected Map Context => _ctx;
        public bool CostMoney => _costMoney;



        //public void Destroy()
        //{
        //    if (!_isBuild) throw new ArgumentException("You can't destroy a building that haven't been built", nameof(_isBuild));
        //    _isBuild = false;
        //}

    }

    
     
}
