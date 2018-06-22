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
        public Hospital(BuildingType type, int x, int y): base(type, x, y)
        {
            _nbTruck = 2;
            _nbBed = 10;
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