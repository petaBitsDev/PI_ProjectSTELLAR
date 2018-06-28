using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    public class FireStation : Building, IServiceInstance
    {
        bool _onFire;
        int _nbTruck;
        bool _isSick;
        bool _isVictimCrime;
        Vector _spritePosition;

        Map _ctx;
        FireType fire;
        public List<Truck> _Vehicule;
        FireStationType fireStationType;
        double _timeMax;
        GameTime gameTime = new GameTime();
        public FireStation(FireStationType type, int x, int y, Map map) : base(type, x, y)
        {
            _nbTruck = 1;
            _ctx = map;
            _Vehicule = new List<Truck>();
            fireStationType = type;
            fire = new FireType(_ctx);
            
        }

        public void ServiceBuildingWorking()
        {
            Fire newFire = fire.CreateEvent();
            fireStationType.StartTime = gameTime.InGameTime;

            if (fireStationType.List.Count != 0)
            {
               fireStationType.BuildingDistance();
               fireStationType.CheckTruckStatement();
                fireStationType.TimeToGo = (fireStationType.Distance / fireStationType.TruckSelected.Speed);

                _timeMax = 180;
                if (fireStationType.TimeToGo <= _timeMax)
                    newFire.EventHandle = true;
                else
                    newFire.EventHandle = false;
            }

            else
            {
                newFire.EventHandle = false;
                fireStationType.TimeToGo = _timeMax;
            }

        }



        public List<Truck> Vehicule
        {
            get { return _Vehicule; }
            set { _Vehicule = value; }
        }


        public int NbVehicule
        {
            get { return _nbTruck; }
            set { _nbTruck = value; }
        }

        public override bool OnFire
        {
            get { return _onFire; }
            set { _onFire = value; }
        }

                public override bool IsSick
        {
            get { return _isSick; }
            set { _isSick = value; }
        }

        public override bool IsVictimCrime
        {
            get { return _isVictimCrime; }
            set { _isVictimCrime = value; }
        }

        public override Vector SpritePosition
        {
            get { return _spritePosition; }
            set { _spritePosition = value; }
        }
    }
}
