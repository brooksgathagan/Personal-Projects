using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    static class Random
    {
        private static readonly System.Random _random = new System.Random();

        public static double NextDouble()
        {
            return _random.NextDouble();
        }

        public static double NextDoubleMinMax(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static int Next(int x)
        {
            return _random.Next(x);
        }

        public static int Next(int x, int y)
        {
            return _random.Next(x, y);
        }
    }
}
