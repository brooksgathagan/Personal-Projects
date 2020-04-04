using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class BasicInvader : Invader
    {
        public override int Health { get; protected set; } = 3;

        public BasicInvader(Path path) : base(path)
        {
        }
    }
}
