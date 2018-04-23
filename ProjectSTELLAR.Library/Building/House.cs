using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class House : Building
    {
        public House(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost, bool isFlammable)
            :base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost, isFlammable)
        {

        }

        static public int Pollution => 5;
        static public int PeopleLevel1 => 5;

        static public int PeopleLevel2 => 10;
        static public int PeopleLevel3 => 15;
        static public int PeopleLevel4 => 20;

        static public int Tax => 50;
    }
}



