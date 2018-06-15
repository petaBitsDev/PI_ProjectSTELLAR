using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SpaceShipsTypes
    {
        List<SpaceShips> _list;
        SpaceShips _lastAdded;

        public SpaceShipsTypes()
        {
            _list = new List<SpaceShips>();
        }

        public void CreateInstance(Map map)
        {
            SpaceShips spaceShip = new SpaceShips();
            _list.Add(spaceShip);
            _lastAdded = spaceShip;
        }

        public SpaceShips LastAdded
        {
            get { return _lastAdded; }
            set { _lastAdded = value; }
        }

        public List<SpaceShips> List =>  _list;
    }
}
