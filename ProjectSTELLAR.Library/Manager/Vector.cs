using System;

namespace ProjectStellar.Library
{
    [Serializable]
    public struct Vector
    {
        double _x;
        double _y;

        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public double Magnitude => Math.Sqrt(_x * _x + _y * _y);

        public Vector Div(int n) => new Vector(_x / n, _y / n);

        public Vector Sub(Vector v) => new Vector(_x - v._x, _y - v._y);

        public Vector Mul(double n) => new Vector(_x * n, _y * n);

        public Vector Add(Vector v) => new Vector(_x + v._x, _y + v._y);
    }
}
