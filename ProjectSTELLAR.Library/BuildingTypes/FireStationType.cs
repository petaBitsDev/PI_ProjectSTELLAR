using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ProjectStellar.Library
{
    [Serializable]
    public class FireStationType : BuildingType, IServiceBuildingsType
    {
        int _cost;
        int _coin;
        int _wood;
        int _rock;
        int _metal;
        int _water;
        int _electricity;
        int _pollution;
        int _nbPeople;
        string _type;
        List<Building> _list;
        int _size;
        int _unlockingLevel;
        FireType _fire;
        double _distance;
        Building _origin;
        Building _target;
        Truck _freeTruck;
        Truck _truck;
        TimeSpan _timeToGo;
        DateTime _start;
        DateTime _end;
        Fire newFire;
        Vector _truckPosition;
        Vector _truckDestination;

        public FireStationType()
        {
            _rock = 45;
            _wood = 10;
            _coin = 35;
            _metal = 80;
            _electricity = 25;
            _water = 70;
            _pollution = 25;
            _nbPeople = 22;
            _cost = -35;
            _type = "public";
            _size = 4;
            _list = new List<Building>();
            _unlockingLevel = 0;
        }

        public void BuildingDistance(Map map)
        {
            _fire = map.NewFireType;
            newFire = _fire.CreateEvent();
            double max = double.MaxValue;

            for (int i = 0; i < this.NbBuilding; i++)
            {
                for (int j = 0; j < _fire.BuildingHasEvent.Count; j++)
                {
                    Distance = Math.Sqrt(Math.Pow((_fire.BuildingHasEvent[j].X - this.List[i].X), 2.00) + Math.Pow((_fire.BuildingHasEvent[j].Y - this.List[i].Y), 2.00));
                    Console.WriteLine(Distance);
                    if (Distance < max)
                    {
                        max = Distance;
                        _target = _fire.BuildingHasEvent[j];
                        _origin = this.List[i];
                    }
                }
            }
        }

        public void TruckMoveTo(Truck truck)
        {
            //truck.Position = new Vector(Origin.X, Origin.Y);
            //truck.Destination = new Vector(Target.X, Target.Y);

            //if(TruckSelected != null)
            //{
            //    truck.Position = truck.Position.Add(truck.Destination.Mul(_truck.Speed));
            //}
            //_truckPosition = truck.Position;
            //_truckDestination = truck.Destination;
        }

        public void CheckTruckStatement()
        {
            FireStation fireStation = (FireStation)this.Origin;
            for (int i = 0; i < Origin.TruckList.Count; i++)
            {
                if (Origin.TruckList[i].IsFree == true)
                {
                    TruckSelected = Origin.TruckList[i];
                    TruckSelected.IsFree = false;
                }
                else TruckSelected = null;
            }
        }
        
        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            FireStation building = new FireStation(this, x, y, map);
            map.AddBuilding(x, y, building);
            _list.Add(building);
        }

        public void CreateTruck(Building building, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override int UnlockingLevel => _unlockingLevel;

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public Building Target
        {
            get { return _target; }
            set { _target = value; }
        }

        public Building Origin
        {
            get { return _origin; }
            set { _origin = value; }
        }

        public Truck TruckSelected
        {
            get { return _truck; }
            set { _truck = value; }
        }

        public DateTime StartTime
        {
            get { return _start; }
            set { _start = value; }
        }
        public DateTime End
        {
            get { return _end; }
            set { _end = value; }
        }
        public TimeSpan TimeToGo
        {
            get { return _timeToGo; }
            set { _timeToGo = value; }
        }

        public override int Rock => _rock;
        public override int Wood => _wood;
        public override int Coin => _coin;
        public override int Metal => _metal;
        public override int Electricity => _electricity;
        public override int Water => _water;
        public override int Pollution => _pollution;
        public override int NbPeople => _nbPeople;
        public override int Cost => _cost;
        public override string Type => _type;
        public override List<Building> List => _list;
        public override int Size => _size;
        public override int NbBuilding => _list.Count;
        internal Fire NewFire => newFire;

        public Vector TruckPosition
        {
            get { return _truckPosition; }
            set { _truckPosition = value; }
        }

        public Vector TruckDestination
        {
            get { return _truckDestination; }
            set { _truckDestination = value; }
        }
    }
}