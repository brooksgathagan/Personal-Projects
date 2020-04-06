using System;
using System.Globalization;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int DistanceTo(int x, int y)
        {
            return (int)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2));
        }

        public int DistanceTo(Coordinate coordinate)
        {
            return DistanceTo(coordinate.X, coordinate.Y);
        }

        public override string ToString()
        {
            return X + ", " + Y;
        }


        public override bool Equals(object obj)
        {
            if (!(obj is Coordinate))
            {
                return false;
            }

            Coordinate that = obj as Coordinate;
            return this.X == that.X && this.Y == that.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 37 + Y.GetHashCode();
        }

    }
}