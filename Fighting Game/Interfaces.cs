using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{

    interface IMove
    {
        void Move(Fighter fighter);
    }

    interface IAttack
    {
 //       void DecreaseHealth(double damage);
        void Attack(IFighter fighter);
        void DecreaseHealth(double damage);
        double DamageTaken { get; set; }
    }

    interface IBoxer : IPerson
    {
        RingLocation Location { get; set; }
        RingLocation DefaultLocation { get; set; }
    }
    interface IFighter : IAttack,  IType, IBoxer
    {
        double Health { get; }
        bool IsDead { get; }
        bool IsAlive { get; }
    }
    interface IType
    {
        string Type { get; }
    }

    interface IFighterGame : ILevel, IPlay
    {
    }
    interface ILevel
    {
        int Stage { get; }
    }
    interface IPlay
    {
        void PlayGame();
    }
    interface IPhase
    {
        string Phase { get; }
    }

    interface IPerson
    {
        string Name { get; }
    }
}
