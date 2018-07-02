using System;

namespace ProjectStellar.Library
{
    [Serializable]
    static class MathHelpers
    {
        internal static Vector MoveTo(Vector position, Vector direction, float speed)
        {
            double div = direction.Magnitude;

            if (direction.Magnitude == 0) div = 1;
            else div = 1 / div;

            Vector unit_vector = direction.Mul(div);
            Vector move = unit_vector.Mul(speed);
            move = ConvertVectorToMap(move, 99 * 32);
            Console.WriteLine(move.X.ToString());
            Console.WriteLine(move.Y.ToString());

            if (direction.X > position.X && direction.Y > position.Y)
                position = new Vector(position.X + move.X, position.Y + move.Y);
            else if (direction.X < position.X && direction.Y < position.Y)
                position = new Vector(position.X - move.X, position.Y - move.Y);
            else if (direction.X < position.X && direction.Y > position.Y)
                position = new Vector(position.X - move.X, position.Y + move.Y);
            else if (direction.X > position.X && direction.Y < position.Y)
                position = new Vector(position.X + move.X, position.Y - move.Y);

            position = Limit(position, 0, 99 * 32);
            return position;
        }

        internal static Vector Limit(Vector v, double min, double max)
        {
            return new Vector(Limit(v.X, min, max), Limit(v.Y, min, max));
        }

        internal static double Limit(double n, double min, double max)
        {
            return Math.Min(Math.Max(n, min), max);
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
