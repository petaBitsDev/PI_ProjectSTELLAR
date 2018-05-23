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

        CityHelper c = new CityHelper(_ctx);
       

        public int CityBalance
        {
            get { return CityTaxes - CityCharges; }
        }
        public int CityCharges
        {
            get {
             
                return _totalCharges = (c.GetSpaceStation.MoneyWinOrLost * NbSpaceStation) + (c.GetPumpingStation.MoneyWinOrLost * NbPumpingStation) + (c.GetPowerPlant.MoneyWinOrLost * NbPowerPlant) + (c.GetPoliceStation.MoneyWinOrLost * NbPoliceStation) + (c.GetHospital.MoneyWinOrLost * NbHospital) + (c.GetFireStation.MoneyWinOrLost * NbFireStation) + (c.GetCityHall.MoneyWinOrLost * NbCityHall); }
        }

        public int CityTaxes
        {
            get { return _totalTaxes = (c.GetHut.MoneyWinOrLost * NbHut) + (c.GetHouse.MoneyWinOrLost * NbHouse) + (c.GetFlat.MoneyWinOrLost * NbFlat);  }
        }

        public int CityPollution
        {
            get { return _totalPollution = (c.GetHut.AirPollution * NbHut) + (c.GetHouse.AirPollution * NbHouse) + (c.GetFlat.AirPollution * NbFlat) + (c.GetSpaceStation.AirPollution * NbSpaceStation) + (c.GetPumpingStation.AirPollution * NbPumpingStation) + (c.GetPowerPlant.AirPollution * NbPowerPlant) + (c.GetPoliceStation.AirPollution * NbPoliceStation) + (c.GetHospital.AirPollution * NbHospital) + (c.GetFireStation.AirPollution * NbFireStation) + (c.GetMetalMine.AirPollution * NbMetalMine) + (c.GetOreMine.AirPollution * NbOreMine) + (c.GetSawmill.AirPollution * NbSawMill); }

        }

        internal int NbHut
        {
            get
            {
              
                _ctx.NbBuilding.TryGetValue(c.GetHut, out int nbHut);
                return nbHut;
            }
        }

        internal int NbHouse
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetHouse, out int nbHouse);
                return nbHouse;
            }
        }

        internal int NbFlat
        {
            get {
                _ctx.NbBuilding.TryGetValue(c.GetFlat, out int nbFlat);
             
                return nbFlat;
                }
      
        }

        internal int NbWarehouse
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetWareHouse, out int nbWarehouse);
                return nbWarehouse;
            }
        }

        internal int NbSpaceStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetSpaceStation, out int nbSpaceStation);
                return nbSpaceStation;
            }
        }

        internal int NbPumpingStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetPumpingStation, out int nbPumpingStation);
                return nbPumpingStation;
            }
        }

        internal int NbPowerPlant
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetPowerPlant, out int nbPowerPlant);
                return nbPowerPlant;
            }
        }

        internal int NbPoliceStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetPoliceStation, out int nbPoliceStation);
                return nbPoliceStation;
            }
        }

        internal int NbHospital
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetHospital, out int nbHospital);
                return nbHospital;
            }
        }

        internal int NbFireStation
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetFireStation, out int nbFireStation);
                return nbFireStation;
            }
        }

        internal int NbCityHall
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetCityHall, out int nbCityHall);
                return nbCityHall;
            }
        }
        internal  int NbMetalMine
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetMetalMine, out int nbMetalMine);
                return nbMetalMine;
            }
        }

        internal  int NbOreMine
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetOreMine, out int nbOreMine);
                return nbOreMine;
            }
        }

        internal  int NbSawMill
        {
            get
            {
                _ctx.NbBuilding.TryGetValue(c.GetSawmill, out int nbSawMill);
                return nbSawMill;
            }
        }

          
    }
}
