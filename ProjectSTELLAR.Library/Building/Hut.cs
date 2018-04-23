using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
<<<<<<< Updated upstream:ProjectSTELLAR.Library/Building/Hut.cs
        public class Hut : Building
         {
              public  Hut(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost, bool isFlammable)
                    :base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost, isFlammable)
                {
=======
    public class Hut : Building
    {
        public  Hut(Map ctx, int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople, bool costMoney, int moneyWinOrLost)
            :base(ctx, rockNeeded, woodNeeded, stellarCoinNeeded, metalNeeded, electricityConsume, waterConsume, airPollution, nbPeople, costMoney, moneyWinOrLost)
        {
>>>>>>> Stashed changes:ProjectSTELLAR.Library/Hut.cs
            
                }



       static public int Pollution => 0;
        static public int People => 5;
        static public int Tax => 20;
    }   
}
