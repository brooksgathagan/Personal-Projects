using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class Fighter : IFighter // Make this and the "//" properties below abstract.  Delete all of the shit at the bottom -- ONCE YOU GO THRU IT AGAIN TO UNDERSTAND WTF YOU"RE DOING YOU IDIOT!
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
        public virtual void DecreaseHealth(double damage) // Decreasing health is handled by the object itself.  Other objects can call DecreaseHealth on a fighter passed in as an argument to their attack methods, effectively affecting their health.  
        {
            Health -= damage;
            DamageTaken = damage; // this is the easiest place to include DamageTaken -- the damage is tied to the attack damage that we use when Decreasing Health, and writing it here meanas we only need to write it once (as opposed to making a new method, or writing it in the method for each attack, etc.)
            if (Health < 0) { Health = 0; }
        }
        public virtual void Attack(IFighter fighter)                             // Need to completely switch order of this so that it flows.  As of now, we're choosing our attack after it says "Successful Strike!", and ReadLine is used for all attacks -- not just ours.  Also need to account for an alternative to "if Fighter is MJ" if we do the "Mirror Image" boss transformation.  
        {                                                                       // Sort of did this.  We need to override the Attack in MJ to take ReadLine.  
            if (this.Location.IsInRangeOf(fighter.Location, AttackRange))       // Seems silly to have a "if Fighter is MJ" if we're only using this on MJ -- every time we attack, we'll also receive self-damage messages, etc.  Not good. 
            {                                                                   // To overcome the "mirror MJ" problem, maybe instead (or in addition to) Level property, have a "Defeated Opponents" property and base functionality on that to discern between the main MJ and mirror MJ. 
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
                    Console.WriteLine("Break it up, you two!  Reset at the center. \nFight!");   // Because we're in Fighter, we can pass in any type of Fighter to a method and change its protected members (from a different fighter object -- e.g. MJ can change Drac's DefaultLocation (protected).
                    Location = DefaultLocation;                                                     // We can't simply do this in one of the sub-classes.  In fact, we can't even change a "Fighter"'s protected parameters.
                    fighter.Location = fighter.DefaultLocation;                                      // If in Drac (or any other sub-class/class), we CAN change the protected members of another Drac.      
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
