using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SpaceShips : SpaceShipsTypes
    {
        int _x;
        int _y;
        double _speed;
        Vector _direction;
        Vector _position;
        readonly Random _random;

        public SpaceShips ()
        {
            _random = new Random();
            _speed = 1.0;
            _position = GetNextRandomPosition();
            _x = _position.X;
            _y = _position.Y;
        }

        internal int GetNextRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        internal Vector GetNextRandomPosition()
        {
            int x = GetNextRandomInt(0, 99 * 32);
            int y = GetNextRandomInt(0, 99 * 32);
            return new Vector(x, y);
        }

        public void Update()
        {
            _direction = GetDirection();
            Position = MathHelpers.MoveTo(Position, _direction, _speed);
            Position = MathHelpers.Limit(Position, 0, 99 * 32);
        }

        public Vector GetDirection()
        {
            int x = GetNextRandomInt(0, 99 * 32);
            int y = GetNextRandomInt(0, 99 * 32);

            return new Vector(x, y);
        }

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
