using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    class PoliceStation : Building, IServiceInstance
    {
        bool _onFire;
        int _nbTruck;
        bool _isSick;
        bool _isCrimeVictim;
        public List<Truck> _vehicule;
        PoliceStationType _policeStationType;
        double _timeMax;
        CrimeType _crimeType;
        Map _ctx;
        GameTime _gameTime = new GameTime();
        public PoliceStation(PoliceStationType type, int x, int y, Map ctx) : base(type, x, y)
        {
            _nbTruck = 2;
            _vehicule = new List<Truck>();
            _ctx = ctx;
            _crimeType = new CrimeType(_ctx);
            _policeStationType = type;
        }

        public void ServiceBuildingWorking()
        {
            Crime newCrime = _crimeType.CreateEvent();
            _policeStationType.StartTime = _gameTime.InGameTime;
            if(_policeStationType.List.Count != 0)
            {
                _policeStationType.BuildingDistance();
                _policeStationType.CheckTruckStatement();
                _policeStationType.TimeToGo = (_policeStationType.Distance / _policeStationType.TruckSelected.Speed);

                _timeMax = 180;
                if (_policeStationType.TimeToGo <= 180)
                    newCrime.EventHandle = true;
                else
                    newCrime.EventHandle = false;

            }
            else
            {
                newCrime.EventHandle = false;
                _policeStationType.TimeToGo = _timeMax;
            }

           

        }

        public List<Truck> Vehicule
        {
            get { return _vehicule; }
            set { _vehicule = value; }
        }
        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }

        public int NbVehicule
        {
            get { return _nbTruck; }
            set { _nbTruck = value; }
        }
        public override bool IsSick
        {
            get { return _isSick; }
            set { _isSick = value; }
        }

        public override bool IsVictimCrime
        {
            get { return _isCrimeVictim; }
            set { _isCrimeVictim = value; }
        }
    }
}