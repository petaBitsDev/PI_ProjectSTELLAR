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
        public List<Truck> _trucks;
        FireStationType fireStationType;
        TimeSpan _timeMax;
        GameTime gameTime = new GameTime();

        public FireStation(FireStationType type, int x, int y, Map map) : base(type, x, y)
        {
            _nbTruck = 4;
            _ctx = map;
            _trucks = new List<Truck>();
            fireStationType = type;
            fire = new FireType(_ctx);
            GenerateTrucks();
        }

        public void GenerateTrucks()
        {
            for (int i = 0; i < NbTrucks; i++)
            {
                Truck truck = new Truck(this, this.X, this.Y);
                _trucks.Add(truck);
                _ctx.AllTrucks.Add(truck);
                this.TruckList = _trucks;
            }
        }

        public void ServiceBuildingWorking()
        {
            fireStationType.StartTime = _ctx.GetGameTime.InGameTime;
            fireStationType.End = fireStationType.StartTime.AddHours(10.0);

            if (fireStationType.List.Count == 0)
            {
                fireStationType.NewFire.EventHandle = false;
                fireStationType.TimeToGo = _timeMax;
            }
            else
            {
                fireStationType.CheckTruckStatement();
                if(fireStationType.TruckSelected != null)
                {   
                    
                    fireStationType.TimeToGo = fireStationType.End.Subtract(fireStationType.StartTime);

                    _timeMax = new TimeSpan(0, 150, 0);
                    if (fireStationType.TimeToGo <= _timeMax)
                        fireStationType.NewFire.EventHandle = true;
                    else
                        fireStationType.NewFire.EventHandle = false;
                }
                else
                {
                    fireStationType.NewFire.EventHandle = false;
                    fireStationType.TimeToGo = new TimeSpan(0, 60, 0);
                }
            }
        }

        public override List<Truck> TruckList
        {
            get => _trucks;
            set => _trucks = value;
        }

        public int NbTrucks
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
