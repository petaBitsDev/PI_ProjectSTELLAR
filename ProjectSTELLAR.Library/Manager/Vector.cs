using System;

namespace ProjectStellar.Library
{
    [Serializable]
    public struct Vector
    {
        float _x;
        float _y;

        public Vector(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public float X => _x;

        public float Y => _y;

        public double Magnitude => Math.Sqrt(_x * _x + _y * _y);

        public Vector Sub(Vector v) => new Vector(_x - v._x, _y - v._y);

        public Vector Mul(float n) => new Vector(_x * n, _y * n);

        public Vector Add(Vector v) => new Vector(_x + v._x, _y + v._y);
    }
}
