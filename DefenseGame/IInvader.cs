using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    interface IMap
    {
        MapLocation Location { get; }
    }

    interface IMove
    {
        void Move();
    }

    interface IInvader : IMap, IMove
    {
        int Health { get; }

        bool HasScored { get; }

        bool IsDead { get; }

        bool IsAlive { get; }

        void DecreaseHealth(int factor);
    }
}
