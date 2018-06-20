using System;

namespace ProjectStellar.Library
{
    [Serializable]
    static class MathHelpers
    {
        internal static Vector MoveTo(Vector position, Vector direction, float speed)
        {
            Vector v = ConvertVectorToMap(direction, 99 * 32);
            double diviseur = v.Magnitude;
            if (v.Magnitude == 0) diviseur = 1;
            Vector unit = v.Mul(1.0f / (float)diviseur);
            Vector move = unit.Mul(speed);
            move = ConvertVectorToMap(move, 99*32);
            if (direction.X > position.X && direction.Y > position.Y)
                position = position.Add(move);
            else if (direction.X < position.X && direction.Y < position.Y)
                position = position.Sub(move);
            else if (direction.X < position.X && direction.Y > position.Y)
                position = new Vector(position.X - move.X, position.Y + move.Y);
            else if(direction.X > position.X && direction.Y < position.Y)
                position = new Vector(position.X + move.X, position.Y - move.Y);
            return position;
        }

        internal static Vector Limit(Vector v, float min, float max)
        {
            return new Vector(Limit((int)v.X, min, max), Limit((int)v.Y, min, max));
        }

        internal static float Limit(float n, float min, float max)
        {
            return Math.Min(Math.Max(n, min), max);
        }

        internal static Vector ConvertedVector(Vector v, int max)
        {
            return new Vector(v.X / max, v.Y / max);
        }

        internal static Vector ConvertVectorToMap(Vector v, int max)
        {
            return new Vector(v.X * max, v.Y * max);
        }
    }
}
