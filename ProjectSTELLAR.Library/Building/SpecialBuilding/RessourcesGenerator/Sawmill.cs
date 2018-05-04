using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
    public class Sawmill : Building
    {

        int _woodProduction;
        public Sawmill(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost, int woodProduction, int xp)
            : base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost, xp)
        {
            _woodProduction = woodProduction;
        }

 
        public int WoodProduction => _woodProduction;


    }
}
