using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    public class Map
    {
        public int Width { get; }
        public int Height { get; }

        public Map(int width, int height)
        {
            if (height % 2 != 1)
            {
                throw new MapSizeInvalidException("Map Size Invalid Exception:  The height of the map must be an Odd Positive Integer.");
            }

            Width = width;
            Height = height;
        }

        public bool IsOnMap(Point point)
        {
            return point.X >= 0 && point.X < Width &&
                   point.Y >= 0 && point.Y < Height;

        }
    }
}
