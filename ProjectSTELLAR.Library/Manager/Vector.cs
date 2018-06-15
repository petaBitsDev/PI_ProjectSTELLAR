using System;

namespace ProjectStellar.Library
{
    [Serializable]
    public struct Vector
    {
        int _x;
        int _y;

        public Vector(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X => _x;

        public int Y => _y;

        public Vector Sub(Vector v) => new Vector(_x - v._x, _y - v._y);

        public Vector Mul(double n) => new Vector(_x * (int)n, _y * (int)n);

        public Vector Add(Vector v) => new Vector(_x + v._x, _y + v._y);
    }
}
