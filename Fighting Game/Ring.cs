using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    static class Ring
    {
        public static int Width { get; }
        public static int Height { get; }
        static Ring()
        {
            Width = 20;
            Height = 20;
        }

        public static bool IsInRing(Coordinate coordinate)
        {
            return coordinate.X >= 0 && coordinate.X < Width &&
                   coordinate.Y >= 0 && coordinate.Y < Height;
        }
    }
}
