using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class Fighter : IFighter 
    {
        public abstract string Name { get; } 
        public abstract string Type { get; } 
        public virtual double Health { get; protected set; } = 100;
        public virtual bool IsDead => !(IsAlive);
        public virtual bool IsAlive => Health > 0;
        public double DamageTaken { get; set; }
        public int RageMeter { get; protected set; } = 0;
        public virtual RingLocation Location { get; set; }
        public RingLocation DefaultLocation { get; set; }
        protected abstract string TypeAttackName { get; }
        protected abstract string SpecialAttackName { get; }
        protected abstract double KickDamage { get; }
        protected abstract double PunchDamage { get; }
        protected abstract double SpecialAttackDamage { get; }
        protected abstract double TypeAttackDamage { get; }
        protected internal NewLevel CurrentLevel { get; }
        protected internal virtual int AttackRange { get; } = 2;
        protected internal virtual int RageMeterMax => 100;
        protected internal virtual int RageBoost => 25;
        protected virtual double Accuracy { get { return 0.75; } }

        public Fighter(NewLevel level)
        {
            CurrentLevel = level;
        }

        protected virtual void IncreaseRage() => RageMeter += RageBoost;
        public virtual void DecreaseHealth(double damage) 
        {
            Health -= damage;
            DamageTaken = damage; 
            if (Health < 0) { Health = 0; }
        }
        public virtual void Attack(IFighter fighter)                             
            if (this.Location.IsInRangeOf(fighter.Location, AttackRange))      
            {                                                                   
                if (IsSuccessfulAttack())
                {
                    
                    if (RageMeter >= 100) 
                    { 
                        SpecialAttack(fighter);
                        return; 
                    }

                    int switchCase = Random.Next(0, 3);
                    switch (switchCase)
                    {
                        case 0:
                            Punch(fighter);
                            break;
                        case 1:
                            Kick(fighter);
                            break;
                        case 2:
                            TypeAttack(fighter);
                            break;
                    }

                    if (fighter is MJ) { Console.WriteLine("Damage Sustained."); }
                }
                else
                {
                    Console.WriteLine("Attack missed.");
                    Commentary.Miss(fighter);
                    fighter.DamageTaken = 0;
                }
            }
            else 
            {
                MoveTowards(fighter);
            }

            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            CurrentLevel.DisplayHealth();
            System.Threading.Thread.Sleep(5000);             
            Console.Clear();
        }
        protected virtual bool IsSuccessfulAttack()
        {
            return Accuracy > Random.NextDouble();
        }

        protected virtual void Punch(IFighter fighter)
        {
            fighter.DecreaseHealth(PunchDamage);
            Console.WriteLine($"{Name} used Punch!");
            Commentary.Punch(this);
            IncreaseRage();
        }
        protected virtual void Kick(IFighter fighter)
        {
            fighter.DecreaseHealth(KickDamage);
            Console.WriteLine($"{Name} used Kick!");
            Commentary.Kick(this);
            IncreaseRage();
        }

        protected internal virtual void TypeAttack(IFighter fighter)
        {
            fighter.DecreaseHealth(TypeAttackDamage);
            Console.WriteLine($"{Name} used {TypeAttackName}!");
            IncreaseRage();
        }

        protected virtual void SpecialAttack(IFighter fighter)
        {
            fighter.DecreaseHealth(SpecialAttackDamage);
            Console.WriteLine($"{Name} used {SpecialAttackName}"!);
            RageMeter = 0;
        }

        protected void RageMeterDisplay()
        {
            if (RageMeter >= 100) { Console.WriteLine("Your special attack is ready!\n"); }
            else { Console.WriteLine($"Rage Meter Level:  {RageMeter}\n"); }
        }

        protected virtual void MoveAwayFrom(IFighter fighter)
        {
            int x = Location.X;
            int y = Location.Y;

            try
            {
                if (fighter.Location.Equals(Location)) 
                {
                    Console.WriteLine("Break it up, you two!  ...Reset at the center! ...Fight!"); 
                    this.Location = this.DefaultLocation; 
                    fighter.Location = fighter.DefaultLocation;
                }
                else if (fighter.Location.X > Location.X && fighter.Location.Y > Location.Y) { x--; }
                else if (fighter.Location.X > Location.X && fighter.Location.Y < Location.Y) { x--; }
                else if (fighter.Location.X < Location.X && fighter.Location.Y > Location.Y) { x++; }
                else if (fighter.Location.X < Location.X && fighter.Location.Y < Location.Y) { x++; }
                else if (fighter.Location.X == Location.X)
                    if (fighter.Location.Y > Location.Y) { y--; }
                    else { y++; }
                else if (fighter.Location.Y == Location.Y)
                    if (fighter.Location.X > Location.X) { x--; }
                    else { x++; }

                Location = CurrentLevel.TheRing[x, y];
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"{this.Name}! Get back in the ring, you idiot!  Reset in the center and fight.");
                Location = DefaultLocation;
            }
        }
        protected virtual void MoveTowards(IFighter fighter)
        {
            int x = Location.X;
            int y = Location.Y;
            try
            {
                if (fighter.Location.Equals(Location))
                {
                    Console.WriteLine("Break it up, you two!  Reset at the center. \nFight!");  
                    Location = DefaultLocation;                                                     
                    fighter.Location = fighter.DefaultLocation;                                      
                    return;
                }
                else
                {
                    do
                    {
                        if (fighter.Location.X > Location.X && fighter.Location.Y > Location.Y) { x++; }
                        else if (fighter.Location.X > Location.X && fighter.Location.Y < Location.Y) { x++; }
                        else if (fighter.Location.X < Location.X && fighter.Location.Y > Location.Y) { x--; }
                        else if (fighter.Location.X < Location.X && fighter.Location.Y < Location.Y) { x--; }
                        else if (fighter.Location.X == Location.X)
                            if (fighter.Location.Y > Location.Y) { y++; }
                            else { y--; }
                        else if (fighter.Location.Y == Location.Y)
                            if (fighter.Location.X > Location.X) { x++; }
                            else { x--; }

                        Location = CurrentLevel.TheRing[x, y];
                    }
                    while (!(this.Location.IsInRangeOf(fighter.Location, AttackRange)));
                }

                
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"{this.Name}! Get back in the ring, you idiot!  Reset in the center and fight.");
                Location = DefaultLocation;
            }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
