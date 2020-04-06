using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class SuperTower : Tower
    {
        protected override int Range { get; } = 2;
        protected override int Damage { get; } = 2;

        public SuperTower(Path path, Map map) : base(path, map)
        {
        }
    }
}
