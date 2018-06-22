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
        Map _ctx;
        Fire fire;
        public List<Truck> _Vehicule;
        Truck _freeTruck;

        public FireStation(BuildingType type, int x, int y, Map map) : base(type, x, y)
        {
            _nbTruck = 1;
            _ctx = map;
            _Vehicule = new List<Truck>();
            
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

 

        
    }
}
