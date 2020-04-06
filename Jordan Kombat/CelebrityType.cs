using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class CelebrityType : Fighter
    {
        public override string Type => "Celebrity";
        protected override string TypeAttackName => "Speak";
        protected override double Accuracy => 0.8;
        protected override double TypeAttackDamage => 16;

        public CelebrityType(NewLevel level) : base(level)
        {
        }

        protected internal override void TypeAttack(IFighter fighter)
        {
            base.TypeAttack(fighter);
            Commentary.CelebAttack(this);
        }
    }
    class PiersMorgan : CelebrityType
    {
        public override string Name => "Piers Morgan";
        protected  override string SpecialAttackName => "Rant";
        protected override double PunchDamage => 10;
        protected override double KickDamage => 12;
        protected override double SpecialAttackDamage => 23;

        public PiersMorgan(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.PiersMorganSpecial(fighter);
        }
    }
    class KanyeWest : CelebrityType
    {
        public override string Name => "Kanye West";
        protected override string SpecialAttackName => "Rant";
        protected override double PunchDamage => 11;
        protected override double KickDamage => 13;
        protected override double SpecialAttackDamage => 25;

        public KanyeWest(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.KanyeSpecial(fighter);
        }
    }
}
