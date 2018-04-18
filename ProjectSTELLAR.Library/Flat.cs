using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    class Flat : Building
    {
        public Flat(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost)
          : base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost)
        {

        }

        static int Pollution => 30;
        static int PeopleLevel1 => 10;

        static int PeopleLevel2 => 20;
        static int PeopleLevel3 => 50;
        static int PeopleLevel4 => 80;

        static int PeopleLevel5 => 100;


        static int Tax => 50;
    }
}
