using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    public class Point
    {
        public int X { get; }
        public int Y { get; }
        private readonly int[] Z = { 1, 2 }; // This variable was created for the methods below.

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return X + ", " + Y;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
            {
                return false;
            }
            Point that = obj as Point;

            return this.X == that.X && this.Y == that.Y;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() * 31 + Y.GetHashCode();
        }

        public int DistanceTo(int x, int y)
        {
            return (int)Math.Sqrt(Math.Pow(X - x, 2) + Math.Pow(Y - y, 2)); // Cartesian distance formula casted to an integer
        }

        public int DistanceTo(Point point)
        {
            return DistanceTo(point.X, point.Y);
        }

        // These last two methods are created to experiment with what was mentioned at 6:00 in the video, as with the code in Game.cs -> Main.  Apparently, we we CAN edit a "readonly" variable -- it just has to be an array, and even then, we can only edit single digits through a member method.  

        public void Change(int x)
        {
            Z[1] = x;
        }

        public int This()
        {
            return Z[1];
        }
    }
}
