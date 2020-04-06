using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    abstract class Invader : IInvader
    {
        private readonly Path _path;
        private int _pathStep = 0;

        protected virtual int StepSize { get; set; } = 1;

        public MapLocation Location => _path.GetLocationAt(_pathStep);

        public abstract int Health { get; protected set; }

        public bool HasScored { get { return _pathStep >= _path.Length; } } 

        public bool IsDead => Health <= 0;

        public bool IsAlive => !(IsDead || HasScored);

        // Common to use Is/Has when naming boolean properties.  

        public Invader(Path path)
        {
            _path = path;
        }

        public void Move() { _pathStep += StepSize; Console.WriteLine(StepSize); }

        public virtual void DecreaseHealth(int factor)
        {
            Health -= factor;
            Console.WriteLine("Blasted that invading scumbag!");
        }
    }
}
