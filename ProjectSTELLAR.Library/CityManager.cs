using ProjectStellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar
{
        public class CityManager
        {
        int _totalCharges;
        int _totalPollution;
        int _totalTaxes ;
        static  Map _ctx;
        
        public CityManager(Map ctx)
        {
            _ctx = ctx;
        }

        CityHelper city = new CityHelper(_ctx);
        
        
        public int CityBalance
        {
            get { return CityTaxes - CityCharges; }
        }
        public int CityCharges
        {
            get {
               
                return _totalCharges = (city.GetSpaceStation.MoneyWinOrLost * NbSpaceStation) + (city.GetPumpingStation.MoneyWinOrLost * NbPumpingStation) + (city.GetPowerPlant.MoneyWinOrLost * NbPowerPlant) + (city.GetPoliceStation.MoneyWinOrLost * NbPoliceStation) + (city.GetHospital.MoneyWinOrLost * NbHospital) + (city.GetFireStation.MoneyWinOrLost * NbFireStation) + (city.GetCityHall.MoneyWinOrLost * NbCityHall); }
        }

        public int CityTaxes
        {
            get { return _totalTaxes = (city.GetHut.MoneyWinOrLost * NbHut) + (city.GetHouse.MoneyWinOrLost * NbHouse) + (city.GetFlat.MoneyWinOrLost * NbFlat);  }
        }

        public int CityPollution
        {
            get { return _totalPollution = (city.GetHut.AirPollution * NbHut) + (city.GetHouse.AirPollution * NbHouse) + (city.GetFlat.AirPollution * NbFlat) + (city.GetSpaceStation.AirPollution * NbSpaceStation) + (city.GetPumpingStation.AirPollution * NbPumpingStation) + (city.GetPowerPlant.AirPollution * NbPowerPlant) + (city.GetPoliceStation.AirPollution * NbPoliceStation) + (city.GetHospital.AirPollution * NbHospital) + (city.GetFireStation.AirPollution * NbFireStation) + (city.GetMetalMine.AirPollution * NbMetalMine) + (city.GetOreMine.AirPollution * NbOreMine) + (city.GetSawmill.AirPollution * NbSawMill); }

        }

        private int NbHut
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("hut", out int nbHut);
                return nbHut;
            }
        }

        private int NbHouse
        {
            get
            {
               
                _ctx.NbBuilding.TryGetValue("house", out int nbHouse);
                return nbHouse;
            }
        }

        private int NbFlat
        {
            get {
               _ctx.NbBuilding.TryGetValue("flat", out int nbFlat);
               
                return nbFlat;
                }
      
        }

        private int NbWarehouse
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("wareHouse", out int nbWarehouse);
                return nbWarehouse;
            }
        }

        private int NbSpaceStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("spaceStation", out int nbSpaceStation);
                return nbSpaceStation;
            }
        }

        private int NbPumpingStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("pumpingStation", out int nbPumpingStation);
                return nbPumpingStation;
            }
        }

        private int NbPowerPlant
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("powerPlant", out int nbPowerPlant);
                return nbPowerPlant;
            }
        }

        private int NbPoliceStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("policeStation", out int nbPoliceStation);
                return nbPoliceStation;
            }
        }

        private int NbHospital
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("hospital", out int nbHospital);
                return nbHospital;
            }
        }

        private int NbFireStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("fireStation", out int nbFireStation);
                return nbFireStation;
            }
        }

        private int NbCityHall
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("cityHall", out int nbCityHall);
                return nbCityHall;
            }
        }
        internal  int NbMetalMine
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("metalMine", out int nbMetalMine);
                return nbMetalMine;
            }
        }

        internal  int NbOreMine
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("oreMine", out int nbOreMine);
                return nbOreMine;
            }
        }

        internal  int NbSawMill
        {
            get
            {
                _ctx.NbBuilding.TryGetValue("sawMill", out int nbSawMill);
                return nbSawMill;
            }
        }

    
    }
}
