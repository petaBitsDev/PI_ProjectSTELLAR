using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    class SpaceStation : Building
    {
        bool _onFire;
        bool _isSick;
        bool _isCrimeVictim;
        int _nbExplorationShips;
        List<ExplorationShips> _shipList;

        public SpaceStation(BuildingType type, int x, int y) : base(type, x, y)
        {
            _nbExplorationShips = 4;
            _shipList = new List<ExplorationShips>();
            GenerateShips();
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
            get { return _isCrimeVictim; }
            set { _isCrimeVictim = value; }
        }

        public List<ExplorationShips> ShipList => _shipList;

        public int NbExplorationShips
        {
            get { return _nbExplorationShips; }
            set { _nbExplorationShips = value; }
        }

        public void GenerateShips()
        {
            for(int i = 0; i < NbExplorationShips; i++)
            {
                ExplorationShips ship = new ExplorationShips();
                _shipList.Add(ship);
            }
        }

        public void SendShip (ExplorationShips ship)
        {
            Random nb = new Random();
            DateTime start = DateTime.Now;
            TimeSpan et = DateTime.Now - start;

            while(et.Minutes < 3)
            {
                et = DateTime.Now - start;
                Console.WriteLine(et.ToString());
                ship.IsAvailable = false;
                ship.NbResources += nb.Next(0, 3);
            }

            Console.WriteLine(ship.NbResources.ToString());
            ship.IsAvailable = true;
        }
    }
}