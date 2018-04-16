using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
   public class Building
    {
        bool _isBuild;
        readonly int _woodNeeded;
        readonly int _rockNeeded;
        readonly int _stellarCoinNeeded;
        readonly int _metalNeeded;
        readonly int _waterConsume;
        readonly int _electricityConsume;
        readonly int _airPollution;
        readonly int _nbPeople;


        public Building(int rockNeeded, int woodNeeded, int stellarCoinNeeded, int metalNeeded, int electricityConsume, int waterConsume, int airPollution, int nbPeople)
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
        }

        public int RockNeeded => _rockNeeded;


        public int WoodNeeded => _woodNeeded;

        public int MetalNeeded => _metalNeeded;


        public int StellarCoinNeeded => _stellarCoinNeeded;

        public int ElectricityConsume => _electricityConsume;

        public int WaterConsume => _waterConsume;

        public int AirPollution => _airPollution;

        public int NbPeople => _nbPeople;
      
    }
}
