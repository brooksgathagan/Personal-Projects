using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    abstract class WaterType : Fighter
    {
        public override string Type => "Water";
        protected override string TypeAttackName => "Hydro Cannon";
        protected override double Accuracy => 0.75;
        protected override double TypeAttackDamage => 14;

        public WaterType(NewLevel level) : base(level)
        {
        }

        protected internal override void TypeAttack(IFighter fighter)
        {
            base.TypeAttack(fighter);
            Commentary.WaterAttack(this);
        }
    }
    class SirSharky : WaterType
    {
        public override string Name => "Sir Sharky";
        protected override string SpecialAttackName => "Hurricane";
        protected override double PunchDamage => 7;
        protected override double KickDamage => 9;
        protected override double SpecialAttackDamage => 20;

        public SirSharky(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.SirSharkySpecial(fighter);
        }

    }
    class Poseidon : WaterType
    {
        public override string Name => "Poseidon";
        protected override string SpecialAttackName => "Tsunami";
        protected override double PunchDamage => 9;
        protected override double KickDamage => 10;
        protected override double SpecialAttackDamage => 23;

        public Poseidon(NewLevel level) : base(level) { }

        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.PoseidonSpecial(fighter);
        }
    }
}
