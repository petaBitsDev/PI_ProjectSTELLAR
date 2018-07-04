using System;

namespace ProjectStellar.Library
{
    [Serializable]
    public class SpaceShips : SpaceShipsTypes
    {
        int _compteur = 0;
        double _x;
        double _y;
        float _speed;
        Vector _direction;
        Vector _position;
        readonly Random _random;

        public SpaceShips ()
        {
            _random = new Random();
            _speed = 0.0009f;
            _position = GetNextRandomPosition();
            this._direction = new Vector();
            _x = _position.X;
            _y = _position.Y;
        }

        public Vector Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public Vector Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        internal double GetNextRandomDouble(double min, double max)
        {
            return _random.NextDouble() * (max - min) + min;
        }

        internal Vector GetNextRandomPosition()
        {
            double x = GetNextRandomDouble(0, 99 * 32);
            double y = GetNextRandomDouble(0, 99 * 32);
            return new Vector(x, y);
        }

        public void Update()
        {
            _compteur++;
            if (_compteur == 90)
            {
                _compteur = 0;
                _direction = GetNextRandomPosition();
            }

            Position = MathHelpers.MoveTo(Position, _direction, _speed);
       
        }
    }
}