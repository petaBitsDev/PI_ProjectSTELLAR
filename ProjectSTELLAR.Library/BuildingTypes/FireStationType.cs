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
        Truck _truck;
        Fire _fire;
        double _distance;
        Building _origin;
        Building _target;
        Double _timeToGo;
        double _timeMax;
        DateTime _timeNow;
        GameTime gameTime = new GameTime();
        Timer _timer;

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
        }

        public void ServiceBuildingWorking()
        {
            
            _timeNow = gameTime.InGameTime;
            BuildingDistance();
            CheckTruckStatement();
            _timeToGo = (Distance / _truck.Speed );

            _timeMax = 180;
            if (_timeToGo <= _timeMax)
                _fire.EventHandle = true;
            else
                _fire.EventHandle = false;
        }

        public void BuildingDistance()
        {
            double max = double.MaxValue;

            for(int i = 0; i <this.NbBuilding; i++)
            {
                for(int j = 0;j<_fire.BuildingHasEvent.Count; j++)
                {
                    Distance = Math.Sqrt(Math.Pow((_fire.BuildingHasEvent[j].X - this.List[i].X), 2.00) + Math.Pow((_fire.BuildingHasEvent[j].Y - this.List[i].Y), 2.00));
                    if(Distance < max)
                    {
                        max = Distance;
                        _target = _fire.BuildingHasEvent[j];
                        _origin = (FireStation)this.List[i];
                    }

                }
            }
        }

        public void CreateTruck()
        {
            foreach(FireStation firestation in this.List)
            {
                for(int i = 0; i < firestation.NbVehicule; i++)
                {
                    Truck t = new Truck();
                    firestation.Vehicule.Add(t);
                }
            }
        
        }

        public void CheckTruckStatement()
        {
            FireStation fireStation = (FireStation)Origin;
            for(int i = 0; i < fireStation.NbVehicule; i++)
            {
                if (fireStation.Vehicule[i].IsFree == true)
                {
                    TruckSelected = fireStation.Vehicule[i];
                    fireStation.Vehicule[i].IsFree = false;
                    break;
                }
                else _truck = null;
            }
        }
        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            FireStation building = new FireStation(this, x, y, map);
            this.CreateTruck();
            map.AddBuilding(x, y, building);
            _list.Add(building);
        }

    

        public Truck TruckSelected
        {
            get { return _truck; }
            set { _truck = value; }
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

        public double Distance
        {
            get { return _distance; }
            set { _distance = value; }
        }

        public double TimeToGo
        {
            get { return _timeToGo; }
            set { _timeToGo = value; }
        }

        public double TimeMax => _timeMax;

        public DateTime StartTime
        {
            get { return _timeNow; }
            set { _timeNow = value; }
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
    }
}