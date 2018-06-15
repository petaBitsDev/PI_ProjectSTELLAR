using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    public class SpaceShipsTypes
    {
        List<SpaceShips> _list;

        public SpaceShipsTypes()
        {
            _list = new List<SpaceShips>();
        }

        public void CreateInstance(Map map)
        {
            SpaceShips spaceShip = new SpaceShips();
            _list.Add(spaceShip);
        }

        public List<SpaceShips> List =>  _list;
    }
}
