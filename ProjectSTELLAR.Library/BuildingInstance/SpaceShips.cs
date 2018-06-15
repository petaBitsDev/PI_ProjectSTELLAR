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
            _speed = 10;
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
            int x = GetNextRandomInt(0, 100);
            int y = GetNextRandomInt(0, 100);
            return new Vector(x, y);
        }

        internal Vector GetRandomDirection()
        {
            double x = GetNextRandomInt(0, 100);
            double y = GetNextRandomInt(0, 100);

            return new Vector((int)x, (int)y);
        }
        public void Update()
        {
            Position = MathHelpers.MoveTo(Position, _direction, _speed);
            Position = MathHelpers.Limit(Position, 0, 100);
            UpdateDirection();
        }

        public void UpdateDirection()
        {
            int x = GetNextRandomInt(0, 100);
            int y = GetNextRandomInt(0, 100);

            _direction = new Vector(x, y);
            Console.WriteLine(_direction.X.ToString(), _direction.Y.ToString(), _position);
        }

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
