using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class Level
    {
        private readonly IInvader[] _invaders;

        public Tower[] Towers { get; set; }

        public Level(IInvader[] invaders)
        {
            _invaders = invaders;
        }

        // returns True if player wins, false if not.

        public bool Play()
        {

            int remainingInvaders = _invaders.Length;

            while (remainingInvaders > 0)
            {
                foreach (Tower tower in Towers)
                {
                    tower.FireOnInvaders(_invaders);
                }

                remainingInvaders = 0;
                foreach (IInvader invader in _invaders)
                {
                    if (invader.IsAlive)
                    {
                        invader.Move();

                        if (invader.HasScored)
                        {
                            return false;
                        }

                        remainingInvaders++;
                    }
                }
            }

            return true;
        }
    }
}

