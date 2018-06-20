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
        float _x;
        float _y;
        float _speed;
        Vector _direction;
        Vector _position;
        readonly Random _random;

        public SpaceShips ()
        {
            _random = new Random();
            _speed = 0.0003f;
            _position = GetNextRandomPosition();
            this._direction = new Vector();
            _x = _position.X;
            _y = _position.Y;
        }

        internal int GetNextRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }

        internal Vector GetNextRandomPosition()
        {
            float x = GetNextRandomInt(0, 99 * 32);
            float y = GetNextRandomInt(0, 99 * 32);
            return new Vector(x, y);
        }

        public void Update()
        {
            this._direction = GetNextRandomPosition();
            Position = MathHelpers.MoveTo(Position, this._direction, _speed);
            Position = MathHelpers.Limit(Position, 0, 99 * 32);
            //this._direction = GetNextRandomPosition();
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
    }
}
