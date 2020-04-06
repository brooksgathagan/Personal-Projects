using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class ResurrectingInvader : IInvader
    {
        private readonly BasicInvader _incarnation1;
        private readonly StrongInvader _incarnation2;

        private int _morphMessageFactor = 0; // Message to display when invader changes form

        public MapLocation Location => _incarnation1.IsDead ? _incarnation2.Location : _incarnation1.Location;

        public int Health => _incarnation1.IsDead ? _incarnation2.Health : _incarnation1.Health;

        public bool HasScored => _incarnation1.HasScored || _incarnation2.HasScored;

        public bool IsDead => _incarnation1.IsDead && _incarnation2.IsDead;

        public bool IsAlive => !(IsDead || HasScored);


        public ResurrectingInvader(Path path)
        {
            _incarnation1 = new BasicInvader(path);
            _incarnation2 = new StrongInvader(path);
        }

        public void DecreaseHealth(int factor)
        {
            if (!_incarnation1.IsDead)
            {
                _incarnation1.DecreaseHealth(factor);
            }
            else
            {
                while (_morphMessageFactor < 1)
                {
                    Console.WriteLine("Watch out! The invader that you vanquished has morphed into a Strong Invader!");
                    _morphMessageFactor++;
                }

               _incarnation2.DecreaseHealth(factor);
            }
        }

        public void Move()
        {
            _incarnation1.Move();
            _incarnation2.Move();
        }
    }
}
