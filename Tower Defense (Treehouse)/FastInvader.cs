using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class FastInvader : Invader
    {
        protected override int StepSize { get; set; } = 2;  // If we comment this out, the Console.WRiteLine's below print 5 and 5.  If left in, it prints 1 and 5 (because base is 1) -- without overriding, "StepSize" represents the StepSize for both this object and base object. 

        public override int Health { get; protected set; } = 3;

        public FastInvader(Path path) : base(path)
        {
            StepSize = 5;
            Console.WriteLine(base.StepSize);
            Console.WriteLine(StepSize);
        }
    }
}
