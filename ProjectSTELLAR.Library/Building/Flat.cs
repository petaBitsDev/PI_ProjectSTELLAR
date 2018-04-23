using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Flat : Building
    {
        public Flat(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost, bool isFlammable)
          : base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost, isFlammable)
        {

        }

        static public int Pollution => 30;
        static public int PeopleLevel1 => 10;

        static public int PeopleLevel2 => 20;
        static public int PeopleLevel3 => 50;
        static public int PeopleLevel4 => 80;

        static public int PeopleLevel5 => 100;


        static public int Tax => 150;
    }
}
