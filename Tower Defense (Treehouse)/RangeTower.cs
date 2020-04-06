using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class RangeTower : Tower
    {
        protected override int Range { get; } = 2;

        public RangeTower(Path path, Map map) : base(path, map)
        {
        }
    }
}
