using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class FireType : Fighter
    {
        public override string Type => "Fire";
        protected override string TypeAttackName => "Fireball";
        protected override double Accuracy => 0.78;
        protected override double TypeAttackDamage => 14;

        public FireType(NewLevel level) : base(level)
        {
        }

        protected internal override void TypeAttack(IFighter fighter)
        {
            base.TypeAttack(fighter);
            Commentary.FireAttack(this);
        }
    }

    class Dylan : FireType
    {
        public override string Name => "Dylan";
        protected override string SpecialAttackName => "Spit Hot Fire";
        protected override double PunchDamage => 8;
        protected override double KickDamage => 9;
        protected override double SpecialAttackDamage => 21;

        public Dylan(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.DylanSpecial(fighter);
        }
    }

    class Devil : FireType
    {
        public override string Name => "The Devil";
        protected override string SpecialAttackName => "Inferno";
        protected override double PunchDamage => 9;
        protected override double KickDamage => 11;
        protected override double SpecialAttackDamage => 23;

        public Devil(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.DevilSpecial(fighter);
        }
    }
}