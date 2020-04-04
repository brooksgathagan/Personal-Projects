using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class SniperTower : Tower
    {
        protected override double Accuracy { get; } = 0.9;

        public SniperTower(Path path, Map map) : base(path, map)
        {
        }
    }
}
