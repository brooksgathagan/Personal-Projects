using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class ShieldedInvader : Invader
    {
        public override int Health { get; protected set; } = 3;

        public ShieldedInvader(Path path) : base(path)
        {
        }

        public override void DecreaseHealth(int factor)
        {
            if (Random.NextDouble() < .5)
            {
                base.DecreaseHealth(factor);
            }
            else
            {
                Console.WriteLine("Attack blocked!");
            }
        }
    }
}
