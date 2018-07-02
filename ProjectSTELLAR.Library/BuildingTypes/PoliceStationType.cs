using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class PoliceStationType : BuildingType, IServiceBuildingsType
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
        CrimeType _crime;
        Building _origin;
        Building _target;
        DateTime _timeNow;
        GameTime gameTime = new GameTime();
        double _timeToGo;
        double _distance;
        double _timeMax;
        Truck _truck;


        public PoliceStationType()
        {
            _rock = 45;
            _wood = 100;
            _coin = 60;
            _metal = 55;
            _electricity = 25;
            _water = 20;
            _pollution = 15;
            _nbPeople = 20;
            _cost = -40;
            _type = "public";
            _size = 4;
            _list = new List<Building>();
            _unlockingLevel = 6;
        }

        public override void CreateInstance(int x, int y, ResourcesManager resources, Map map)
        {
            if (!resources.CheckResourcesNeeded(this)) throw new ArgumentException("Ressources manquantes.");

            resources.UpdateWhenCreate(this);
            PoliceStation building = new PoliceStation(this, x, y, map);
            CreateTruck(building, x, y);
            map.AddBuilding(x, y, building);
            _list.Add(building);
        }

        public override int UnlockingLevel => _unlockingLevel;

        public void BuildingDistance(Map map)
        {
            double max = double.MaxValue;

            for(int i = 0; i < this.NbBuilding; i++)
            {
                for(int j = 0; j < _crime.BuildingHasEvent.Count; j++)
                {
                    Distance = Math.Sqrt(Math.Pow((_crime.BuildingHasEvent[j].X - List[i].X), 2.00) + Math.Pow((_crime.BuildingHasEvent[j].Y - List[i].Y), 2.00));
                    if(Distance < max)
                    {
                        max = Distance;
                        _target = _crime.BuildingHasEvent[j];

                        Console.WriteLine("POLICE STATION TARGET ----" +_target);
                        _origin = (PoliceStation)List[i];
                    }
                }
            }
        }

        public void CreateTruck(Building building, int x, int y)
        {
            PoliceStation policeStation = (PoliceStation)building;
            for(int i = 0; i <policeStation.NbVehicule; i++)
            {
                Truck t = new Truck(x, y);
                policeStation.Vehicule.Add(t);
            }
        }

        public void CheckTruckStatement()
        {
            PoliceStation policeStation = (PoliceStation)Origin;
            for(int i = 0; i < policeStation.NbVehicule; i++)
            {
                if(policeStation.Vehicule[i].IsFree == true)
                {
                    TruckSelected = policeStation.Vehicule[i];
                    policeStation.Vehicule[i].IsFree = false;
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