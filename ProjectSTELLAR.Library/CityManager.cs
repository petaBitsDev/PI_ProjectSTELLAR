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

        
        
        public int CityBalance
        {
            get { return CityTaxes - CityCharges; }
        }
        public int CityCharges
        {
            get {
               
                return _totalCharges = (CityHelper.GetSpaceStation.MoneyWinOrLost * NbSpaceStation) + (CityHelper.GetPumpingStation.MoneyWinOrLost * NbPumpingStation) + (CityHelper.GetPowerPlant.MoneyWinOrLost * NbPowerPlant) + (CityHelper.GetPoliceStation.MoneyWinOrLost * NbPoliceStation) + (CityHelper.GetHospital.MoneyWinOrLost * NbHospital) + (CityHelper.GetFireStation.MoneyWinOrLost * NbFireStation) + (CityHelper.GetCityHall.MoneyWinOrLost * NbCityHall); }
        }

        public int CityTaxes
        {
            get { return _totalTaxes = (CityHelper.GetHut.MoneyWinOrLost * NbHut) + (CityHelper.GetHouse.MoneyWinOrLost * NbHouse) + (CityHelper.GetFlat.MoneyWinOrLost * NbFlat);  }
        }

        public int CityPollution
        {
            get { return _totalPollution = (CityHelper.GetHut.AirPollution * NbHut) + (CityHelper.GetHouse.AirPollution * NbHouse) + (CityHelper.GetFlat.AirPollution * NbFlat) + (CityHelper.GetSpaceStation.AirPollution * NbSpaceStation) + (CityHelper.GetPumpingStation.AirPollution * NbPumpingStation) + (CityHelper.GetPowerPlant.AirPollution * NbPowerPlant) + (CityHelper.GetPoliceStation.AirPollution * NbPoliceStation) + (CityHelper.GetHospital.AirPollution * NbHospital) + (CityHelper.GetFireStation.AirPollution * NbFireStation) + (CityHelper.GetMetalMine.AirPollution * NbMetalMine) + (CityHelper.GetOreMine.AirPollution * NbOreMine) + (CityHelper.GetSawmill.AirPollution * NbSawMill); }

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
