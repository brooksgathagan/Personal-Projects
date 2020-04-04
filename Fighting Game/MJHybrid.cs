using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class MJHybrid : IFighter
    {
        private bool morphCount = false;
        private MJ _mj { get; }
        private SirSharky _sirShark { get; }
        public string Name => _sirShark.IsDead ? "Michael Jordan" : "Sir Sharky";
        public string Type => _sirShark.IsDead ? "Human Clone" : "Water";
        public double Health => _sirShark.IsDead ? _mj.Health : _sirShark.Health;
        public bool IsDead => _sirShark.IsDead && _mj.IsDead;
        public bool IsAlive => !(IsDead);
        public double DamageTaken { get; set; }
        public RingLocation Location { get; set; }
        public RingLocation DefaultLocation { get; set; }


        // Need to figure out Location for all characters.  Currently, location is set to (9, 10) for everyone (tho that was mostly to ensure Attacks could work in Program given DistanceTo = 0).  


        public MJHybrid(NewLevel level) 
        {

            _sirShark = new SirSharky(level); 
            _mj = new MJ(level);               
        }

        public void Attack(IFighter fighter)
        {

            if (!(_sirShark.IsDead))
                _sirShark.Attack(fighter);

            else
            {
                while (!(morphCount))
                {
                    Commentary.MJMorph();
                    morphCount = true;
                }

                _mj.OpponentMJAttack(fighter);
            }
                
        }

        public void DecreaseHealth(double damage)
        {
            if (!(_sirShark.IsDead))
                _sirShark.DecreaseHealth(damage);
            else
                _mj.DecreaseHealth(damage);
        }

    }
}
