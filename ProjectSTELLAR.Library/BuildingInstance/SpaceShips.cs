using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectStellar.Library
{
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
            _speed = 0.02;
            _position = GetNextRandomPosition();
            _x = _position.X;
            _y = _position.Y;
        }

        internal double GetNextRandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }

        internal Vector GetNextRandomPosition()
        {
            double x = GetNextRandomDouble(-1.0, 1.0);
            double y = GetNextRandomDouble(-1.0, 1.0);
            return new Vector((int)x, (int)y);
        }

        internal Vector GetRandomDirection()
        {
            double x = GetNextRandomDouble(-1.0, 1.0);
            double y = Math.Sqrt(1 - x * x);
            if (GetNextRandomDouble(0, 1) < 0.5) y = -y;

            return new Vector((int)x, (int)y);
        }
        public void Update()
        {
            Position = MathHelpers.MoveTo(Position, _direction, _speed);
            Position = MathHelpers.Limit(Position, -1, 1);
            UpdateDirection();
        }

        void UpdateDirection()
        {
            double beta = GetNextRandomDouble(Math.PI / -8.0, Math.PI / 8.0);
            double alpha = Math.Acos(_direction.X);
            double x = Math.Cos(alpha + beta);

            alpha = Math.Asin(_direction.Y);
            double y = Math.Sin(alpha + beta);

            _direction = new Vector((int)x, (int)y);
        }

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }
    }
}
