using System;

namespace ProjectStellar.Library
{
    [Serializable]
    static class MathHelpers
    {
        internal static Vector MoveTo(Vector position, Vector direction, double speed)
        {
            return position.Add(direction.Mul(speed));
        }

        internal static Vector Limit(Vector v, int min, int max)
        {
            return new Vector(Limit(v.X, min, max), Limit(v.Y, min, max));
        }

        internal static int Limit(int n, int min, int max)
        {
            return Math.Min(Math.Max(n, min), max);
        }

        internal static float Limit(float n, float min, float max)
        {
            return Math.Min(Math.Max(n, min), max);
        }
    }
}
