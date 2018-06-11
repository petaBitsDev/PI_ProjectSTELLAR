using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{ 
    [Serializable]
    class FireStation : Building, IServiceBuildings
    {
        bool _onFire;
        int _nbTruck;
        bool _isSick;
        bool _isVictimCrime;
        Map _ctx;
        Fire fire;
        Building _target;
        FireStation _origin;
        List<Truck> _Vehicule = new List<Truck>();
        Truck _freeTruck;

        public FireStation(BuildingType type, int x, int y, Map map) : base(type, x, y)
        {
            _nbTruck = 1;
            _ctx = map;
            fire = new Fire(_ctx);
            
        }


        private void BuildingDistance()
        {
            double max = double.MaxValue;
            FireStationType fireStationType = (FireStationType)_ctx.BuildingTypes[1];
            for(int i = 0; i <fireStationType.NbBuilding; i++)
            {
                for(int j =0; j<fire.BuildingHasEvent.Count; j++)
                {
                    Double distance = Math.Sqrt(Math.Pow((fire.BuildingHasEvent[j].X - fireStationType.List[i].X), 2.00) + Math.Pow((fire.BuildingHasEvent[j].Y - fireStationType.List[i].Y), 2.00));

                    if(distance < max)
                    {
                        max = distance;
                        Target = fire.BuildingHasEvent[j];
                        Origin = (FireStation)fireStationType.List[i];
                    }
                    
                }
            }
        }

        private void CheckTruckStatement()
        {
            for(int i = 0; i < Origin.NbVehicule; i++)
            {
                if(Origin.Vehicule[i].IsFree == true)
                {
                    FreeTruck = Origin.Vehicule[i];
                    Origin.Vehicule[i].IsFree = false;
                    break;
                }
                else
                {
                    FreeTruck = null;
                }

            }
        } 

        public void CreateTruck()
        {
            for (int i = 0; i < Origin.NbVehicule; i++)
            {
                Truck t = new Truck();
                Vehicule.Add(t);
            }
        }

        public Truck FreeTruck
        {
            get { return _freeTruck; }
            set { _freeTruck = value; }
        }

        public List<Truck> Vehicule
        {
            get { return _Vehicule; }
            set { _Vehicule = value; }
        }

        public Building Target
        {
            get { return _target; }
            set { _target = value; }

        }

        public FireStation Origin
        {
            get { return _origin; }
            set { _origin = value; }
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

 

        
    }
}
