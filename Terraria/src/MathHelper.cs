using SFML.System;
using System;

namespace Terraria
{
    class MathHelper
    {
        // return distance between two points
        public static float GetDistance(Vector2f v1, Vector2f v2)
        {
            float x = v2.X - v1.X;
            float y = v2.Y - v1.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static float GetDistance(float x1, float x2, float y1, float y2)
        {
            float x = x1 - x2;
            float y = y1 - y2;
            return (float)Math.Sqrt(x * x + y * y);
        }

        // return length of vector
        public static float GetDistance(Vector2f vec)
        {
            return (float)Math.Sqrt(vec.X * vec.X + vec.Y * vec.Y);
        }
    }
}
