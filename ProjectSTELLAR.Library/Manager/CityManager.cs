using ProjectStellar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
        public class CityManager
        {
        int _totalCharges;
        int _totalPollution;
        int _totalTaxes ;
        static  Map _ctx;


        SpaceStationType _spaceStation = new SpaceStationType();
        PumpingStationType _pumpingStation = new PumpingStationType();
        PowerPlantType _powerPlant = new PowerPlantType();
        PoliceStationType _policeStation = new PoliceStationType();
        HospitalType _hospital = new HospitalType();
        FireStationType _fireStation = new FireStationType();
        CityHallType _cityhall = new CityHallType();
        HutType _hut = new HutType();
        HouseType _house = new HouseType();
        FlatType _flat = new FlatType();
        OreMineType _oreMine = new OreMineType();
        SawmillType _sawMill = new SawmillType();
        MetalMineType _metaMine = new MetalMineType();
        WarehouseType _warehouse = new WarehouseType();

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
             
                return _totalCharges = (_spaceStation.Cost * _spaceStation.NbSpaceStation) + (_pumpingStation.Cost * _pumpingStation.NbPumpingStation) + (_powerPlant.Cost * _powerPlant.NbPowerPlant) + (_policeStation.Cost * _policeStation.NbPoliceStation) + (_hospital.Cost * _hospital.NbHospital) + (_fireStation.Cost * _fireStation.NbFireStation) + (_cityhall.Cost * _cityhall.NbCityHall); }
        }

        public int CityTaxes
        {
            get { return _totalTaxes = (_hut.Cost * _hut.NbHut) + (_house.Cost* _house.NbHouse) + (_flat.Cost * _flat.NbFlat);  }
        }

        public int CityPollution
        {
            get { return _totalPollution = (_hut.Pollution * _hut.NbHut) + (_house.Pollution * _house.NbHouse) + (_flat.Pollution* _flat.NbFlat) + (_spaceStation.Pollution * _spaceStation.NbSpaceStation) + (_pumpingStation.Pollution * _pumpingStation.NbPumpingStation) + (_powerPlant.Pollution * _powerPlant.NbPowerPlant) + (_policeStation.Pollution * _policeStation.NbPoliceStation) + (_hospital.Pollution * _hospital.NbHospital) + (_fireStation.Pollution * _fireStation.NbFireStation) + (_metaMine.Pollution * _metaMine.NbMetalMine) + (_oreMine.Pollution * _oreMine.NbOreMine) + (_sawMill.Pollution * _sawMill.NbSawMill); }

        }

  

          
    }
}
