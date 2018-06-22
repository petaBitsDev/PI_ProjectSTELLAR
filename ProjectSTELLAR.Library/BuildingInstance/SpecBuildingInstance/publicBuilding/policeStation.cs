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
        public PoliceStation(BuildingType type, int x, int y) : base(type, x, y)
        {
            _nbTruck = 2;
            _vehicule = new List<Truck>();
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