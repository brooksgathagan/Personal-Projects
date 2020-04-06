using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class HauntedType : Fighter
    {
        public override string Type => "Haunted";
        protected override string TypeAttackName => "Spook";
        protected override double Accuracy => 0.75;
        protected override double TypeAttackDamage => 15;

        public HauntedType(NewLevel level) : base(level)
        { }

        protected internal override void TypeAttack(IFighter fighter)
        {
            Console.WriteLine($"{Name} used {TypeAttackName}! You are now susceptible to a more dangerous attack.");

            var attackSwitch = Random.Next(0, 4);

            if (RageMeter >= 100)
            {
                fighter.DecreaseHealth(SpecialAttackDamage);
                RageMeter = 0;
            }
            else
            {
                switch(attackSwitch)
                {
                    case 0:
                        Punch(fighter);
                        break;
                    case 1:
                        Kick(fighter);
                        break;
                    case 3:
                    case 4:
                        EatSoul(fighter);
                        break;
                }
            }
        }

        private void EatSoul(IFighter fighter)
        {
            Console.WriteLine($"{Name} took a bite out of {fighter}'s soul!");
            fighter.DecreaseHealth(SpecialAttackDamage);
            IncreaseRage();
            Commentary.HauntedAttack(this);
        }

    }
    class FreddyKrueger : HauntedType
    {
        public override string Name => "Freddy Krueger";
        protected override string SpecialAttackName => "Dream Eater";
        protected override double PunchDamage => 19;
        protected override double KickDamage => 10;
        protected override double Accuracy => 0.8;
        protected override double SpecialAttackDamage => 21;

        public FreddyKrueger(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.FreddySpecial(fighter);
        }
    }
    class Dracula : HauntedType
    {
        public override string Name => "Dracula";
        protected override string SpecialAttackName => "Neck Bite";
        protected override double PunchDamage => 11;
        protected override double KickDamage => 11;
        protected override double SpecialAttackDamage => 23;

        public Dracula(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.DraculaSpecial(fighter);
        }
    }
}