using System;

namespace ProjectStellar.Library
{
    [Serializable]
    static class MathHelpers
    {
        internal static Vector MoveTo(Vector position, Vector direction, double speed)
        {
            Vector distance = direction.Sub(position);
            position = new Vector(distance.X, distance.Y).Mul(speed);
            return position;
        }

        internal static Vector Limit(Vector v, int min, int max)
        {
            return new Vector(Limit(v.X, min, max), Limit(v.Y, min, max));
        }

        internal static int Limit(int n, int min, int max)
        {
            return Math.Min(Math.Max(n, min), max);
        }
    }
}
