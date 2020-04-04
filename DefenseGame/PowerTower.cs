using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class PowerTower : Tower
    {
        protected override int Damage { get; } = 2;

        public PowerTower(Path path, Map map) : base(path, map) { }
        {
        }
    }
}
