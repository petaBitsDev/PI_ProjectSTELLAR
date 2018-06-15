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
        Vector _position;
        readonly Random _random;
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

        public int X => _position.X;

        public int Y => _position.Y;

        public List<SpaceShips> List =>  _list;
    }
}
