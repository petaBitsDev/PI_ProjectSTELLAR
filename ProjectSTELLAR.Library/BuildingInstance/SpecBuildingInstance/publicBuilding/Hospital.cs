using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    class Hospital : Building, IServiceInstance
    {
        bool _onFire;
        int _nbTruck;
        int _nbBed;
        bool _isSick;
        bool _isCrimeVictim;
        public List<Truck> _vehicule;
        HospitalType _hospitalType;
        double _timeMax;
        DiseaseType _diseaseType;
        Map _ctx;
        GameTime gameTime = new GameTime();

        public Hospital(HospitalType type, int x, int y, Map ctx): base(type, x, y)
        {
            _nbTruck = 2;
            _nbBed = 10;
            _vehicule = new List<Truck>();
            _ctx = ctx;
            _diseaseType = new DiseaseType(_ctx);
            _hospitalType = type;
        }

        public void ServiceBuildingWorking()
        {
            Disease newDisease = _diseaseType.CreateEvent();
            _hospitalType.StartTime = gameTime.InGameTime;

            if(_hospitalType.List.Count != 0)
            {
               _hospitalType.BuildingDistance();
               _hospitalType.CheckTruckStatement();
               _hospitalType.TimeToGo  = (_hospitalType.Distance /_hospitalType.TruckSelected.Speed);

                _timeMax = 180;
                if (_hospitalType.TimeToGo <= _timeMax)
                    newDisease.EventHandle = true;
                else
                    newDisease.EventHandle = false;
            }
            else
            {
                newDisease.EventHandle = false;
                _hospitalType.TimeToGo = _timeMax;
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

        public int NbBed
        {
            get { return _nbBed; }
            set { _nbBed = value; }
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