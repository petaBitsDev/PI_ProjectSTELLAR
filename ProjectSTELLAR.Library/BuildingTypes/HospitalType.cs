using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class HospitalType : BuildingType, IServiceBuildingsType
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
        public List<Building> _list = new List<Building>();
        int _size;
        int _unlockingLevel;
        Disease _disease;
        Building _target;
        Building _origin;
        DateTime _timeNow;
        GameTime gameTime = new GameTime();
        double _timeToGo;
        double _distance;
        double _timeMax;
        Truck _truck;

        public HospitalType()
        {
            _rock = 70;
            _wood = 40;
            _coin = 67;
            _metal = 75;
            _electricity = 45;
            _water = 60;
            _pollution = 15;
            _nbPeople = 25;
            _cost = -30;
            _type = "public";
            _size = 6;
            _list = new List<Building>();
            _unlockingLevel = 6;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            Building building = new Hospital(this, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
        }
        public override int UnlockingLevel => _unlockingLevel;

        public void ServiceBuildingWorking()
        {
            _timeNow = gameTime.InGameTime;
            BuildingDistance();
            CheckTruckStatement();
            _timeToGo = (Distance / TruckSelected.Speed);

            _timeMax = 180;
            if (_timeToGo <= _timeMax)
                _disease.EventHandle = true;
            else
                _disease.EventHandle = false;
        }

        public void BuildingDistance()
        {
            double max = double.MaxValue;

            for(int i = 0; i< NbBuilding; i++)
            {
                for(int j = 0; j< _disease.BuildingHasEvent.Count; j++)
                {
                    Distance = Math.Sqrt(Math.Pow((_disease.BuildingHasEvent[j].X - List[i].X), 2.00) + Math.Pow((_disease.BuildingHasEvent[j].Y - List[i].Y), 2.00));
                    if(Distance < max)
                    {
                        max = Distance;
                        _target = _disease.BuildingHasEvent[j];
                        _origin = (Hospital)List[i];
                    }
                }
            }
        }

        public void CreateTruck()
        {
            foreach(Hospital hospital in List)
            {
                Truck t = new Truck();
                hospital.Vehicule.Add(t);
            }
        }

        public void CheckTruckStatement()
        {
            Hospital hospital = (Hospital)Origin;
            for (int i = 0; i < hospital.NbVehicule; i++)
            {
                if(hospital.Vehicule[i].IsFree == true)
                {
                    TruckSelected = hospital.Vehicule[i];
                    hospital.Vehicule[i].IsFree = false;
                    break;
                }
                else
                {
                    TruckSelected = null;
                }
            }
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
        public Truck TruckSelected
        {
            get { return _truck; }
            set { _truck = value; }
        }
       
    }
}