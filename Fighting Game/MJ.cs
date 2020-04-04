using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class MJ : Fighter
    {
        private const int _handCheckDamage = 13;
        private readonly int _waterAttackDamage;
        private readonly int _fireAttackDamage;
        private readonly int _hauntedAttackDamage;
        public override string Name => "Michael Jordan";
        public override string Type { get; } = "Human";
        public override RingLocation Location { get; set; }
        protected override string TypeAttackName => "Hand Check";
        protected override string SpecialAttackName => "The MJ Slam Jam!";
        protected override double KickDamage { get; }
        protected override double PunchDamage { get; }
        protected override double TypeAttackDamage => 16;
        protected override double SpecialAttackDamage => 25;
        public MJ(NewLevel level) : base(level)
        {
            switch (level.Stage) // Different attacks affect different opponents differently...Yep. 
            {
                case 3:
                case 4:
                    PunchDamage = 9;
                    KickDamage = 13;
                    _waterAttackDamage = 20;
                    _fireAttackDamage = 10;
                    _hauntedAttackDamage = 15;
                    break;
                case 5:
                case 6:
                    PunchDamage = 12;
                    KickDamage = 10;
                    _waterAttackDamage = 17;
                    _fireAttackDamage = 18;
                    _hauntedAttackDamage = 10;
                    break;
                default:
                    PunchDamage = 10;
                    KickDamage = 12;
                    _waterAttackDamage = 17;
                    _fireAttackDamage = 18;
                    _hauntedAttackDamage = 19;
                    break;
            }
        }

// Attacks

        protected override void Kick(IFighter fighter)
        {
            fighter.DecreaseHealth(KickDamage);
            Console.WriteLine($"{Name} used Kick!");
            Commentary.MJKick();
            IncreaseRage();
        }

        protected override void Punch(IFighter fighter)
        {
            fighter.DecreaseHealth(PunchDamage);
            Console.WriteLine($"{Name} used Punch!");
            Commentary.MJPunch();
            IncreaseRage();

        }
        private void HandCheck(IFighter fighter)
        {
            fighter.DecreaseHealth(_handCheckDamage);
            Console.WriteLine($"{Name} used Hand Check!");
            Commentary.MJHandCheck();
            IncreaseRage();
        }

        private void HydroCannon(IFighter fighter)
        {
            fighter.DecreaseHealth(_waterAttackDamage);
            Console.WriteLine($"{Name} used Hydro Cannon!");
            Commentary.WaterAttack(this);
            IncreaseRage();
        }

        protected void Fireball(IFighter fighter)
        {
            fighter.DecreaseHealth(_fireAttackDamage);
            Console.WriteLine($"{Name} used Fireball!");
            Commentary.FireAttack(this);
            IncreaseRage();
        }

        public void EatSoul(IFighter fighter)
        {   
            Console.WriteLine($"{Name} took a bite out of {fighter}'s soul!");
            fighter.DecreaseHealth(_hauntedAttackDamage);
            Commentary.HauntedAttack(this);
            IncreaseRage();
        }


        protected override void SpecialAttack(IFighter fighter)
        {
            base.SpecialAttack(fighter);
            Commentary.MJSpecial();
        }

// OpponentMJAttack (below) was written to address the issue that arose when I decided to make the final "boss" a composited fighter -- a Sir Sharky that morphs into an MJ.  Because the MJ class (this class) involves user-operated attacks, fighting against an "MJ" would also involve the user choosing his attacks -- not ideal! 
// This way, the "opponent" MJ can call this method and randomly select an attack, whereas the user's MJ is controlled by the user.
        internal void OpponentMJAttack(IFighter fighter)
        {
            if (!(this.Location.IsInRangeOf(fighter.Location, AttackRange)))
            {
                MoveTowards(fighter);
            }

            if(RageMeter >= 100)
            {
                SpecialAttack(fighter);
            }
            else
            {
                int switchCase = Random.Next(0, 6);
                switch (switchCase)
                {
                    case 0:
                        Punch(fighter);
                        break;
                    case 1:
                        Kick(fighter);
                        break;
                    case 2:
                        HandCheck(fighter);
                        break;
                    case 3:
                        HydroCannon(fighter);
                        break;
                    case 4:
                        Fireball(fighter);
                        break;
                    case 5:
                        EatSoul(fighter);
                        break;
                }
            }
        }

        public override void Attack(IFighter fighter)
        {
            if (DamageTaken >= 20)
            {
                string decision = Commentary.MoveAway(fighter); // prompts user to decide if he/she wants to retreat or not

                if (decision.Equals("yes"))
                {
                    RetreatBoost();
                    System.Threading.Thread.Sleep(3000);
                    MoveAwayFrom(fighter);
                    System.Threading.Thread.Sleep(2000);

                }

                if (decision.Equals("no"))
                {
                    Console.WriteLine("Hey, just trying to help.  Have at it, partner!");
                }

            }

            if (!(this.Location.IsInRangeOf(fighter.Location, AttackRange)))
            {
                MoveTowards(fighter);
                System.Threading.Thread.Sleep(5000);
                Console.Clear();
            }   

            CurrentLevel.DisplayHealth();
            DetermineAttack(fighter);
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
        }

// I separated "Attack" (above) and "DetermineAttack" (below) into two separate methods (where Attack calls DetermineAttack).  It seemed easiest to incorporate the "movement" into the Attack given it's a console game and movement is going to be limited, if not completely automated.  
// I also combined the "Display Health" with the Attack to give the player an idea of what his/her health is in case it affects their decision for an attack any.
// To me, it seemed as though it'd be more confusing to include the entirety of what's written in DetermineAttack along with what I just commented on above.  DetermineAttack is doing just that -- seeking user input to determine the attack.  It takes care of the actual "attacking" as well, which is why I call it in the primary (public) Attack method.   
        private void DetermineAttack(IFighter fighter)
        {
            string attackType;
            int invalidAnswerCheck = 0;
            RageMeterDisplay();

 // Attack(s) for Water Stage

            if (CurrentLevel.Stage == 1 || CurrentLevel.Stage == 2)
            {
                if (RageMeter >= 100)
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Special Attack!");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  Please select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Special Attack!");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && attackType != "special");
                }
                else
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  Please select your attack:  1. Punch, 2. Kick, 3. Hand Check");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")));
                }

                if (IsSuccessfulAttack())
                {
                    Console.WriteLine("Successful attack!\n");

                    if (attackType == "1" || attackType == "punch")
                        Punch(fighter);
                    else if (attackType == "2" || attackType == "kick")
                        Kick(fighter);
                    else if (attackType == "3" || attackType.Contains("hand"))
                        HandCheck(fighter);
                    else
                        SpecialAttack(fighter);
                }
                else
                {
                    Console.WriteLine("Attack missed.\n");
                    Commentary.Miss(fighter);
                }
            }

// Attack(s) for Fire Stage

            else if (CurrentLevel.Stage == 3 || CurrentLevel.Stage == 4)
            {
                if (RageMeter >= 100)
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Special Attack!");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Special Attack!");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && attackType != "special" && attackType != "5" && !(attackType.Contains("hydro")));

                }
                else
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && !(attackType.Contains("hydro")));
                }

                if (IsSuccessfulAttack())
                {
                    Console.WriteLine("Successful attack!\n");

                    if (attackType == "1" || attackType == "punch")
                        Punch(fighter);
                    else if (attackType == "2" || attackType == "kick")
                        Kick(fighter);
                    else if (attackType == "3" || attackType.Contains("hand"))
                        HandCheck(fighter);
                    else if (attackType == "4" || attackType.Contains("hydro") || attackType.Contains("cannon"))
                        HydroCannon(fighter);
                    else
                        SpecialAttack(fighter);
                }
                else
                {
                    Console.WriteLine("Attack missed.\n");
                    Commentary.Miss(fighter);
                }

            }

// Attack(s) for Spooky Stage
            else if (CurrentLevel.Stage == 5 || CurrentLevel.Stage == 6)
            {
                if (RageMeter >= 100)
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Special Attack!");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Special Attack!");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && attackType != "special" && attackType != "5" && !(attackType.Contains("hydro")) && attackType != "6" && !(attackType.Contains("fire")));
                }
                else
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball");

                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && !(attackType.Contains("hydro")) && attackType != "5" && !(attackType.Contains("fire")));
                }

                if (IsSuccessfulAttack())
                {
                    Console.WriteLine("Successful attack!\n");

                    if (attackType == "1" || attackType == "punch")
                        Punch(fighter);
                    else if (attackType == "2" || attackType == "kick")
                        Kick(fighter);
                    else if (attackType == "3" || attackType.Contains("hand"))
                        HandCheck(fighter);
                    else if (attackType == "4" || attackType.Contains("hydro") || attackType.Contains("cannon"))
                        HydroCannon(fighter);
                    else if (attackType == "5" || attackType.Contains("fire"))
                        Fireball(fighter);
                    else
                        SpecialAttack(fighter);
                }
                else
                {
                    Console.WriteLine("Attack missed.\n");
                    Commentary.Miss(fighter);
                }
            }

// Attack(s) for final boss
            else
            { 
                if (RageMeter >= 100)
                { 
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Eat Soul, 7. Special Attack!");
                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Eat Soul, 7. Special Attack!");
  
                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && attackType != "special" && attackType != "5" && !(attackType.Contains("hydro")) && attackType != "6" && !(attackType.Contains("fire")) && attackType != "7" && !(attackType.Contains("eat")));
                }
                else
                {
                    Console.WriteLine("Select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Eat Soul");
                    do
                    {
                        if (invalidAnswerCheck >= 1)
                            Console.WriteLine("Invalid attack input.  \nPlease select your attack:  1. Punch, 2. Kick, 3. Hand Check, 4. Hydro Cannon, 5. Fireball, 6. Eat Soul!");

                        attackType = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        invalidAnswerCheck++;
                    }
                    while (attackType != "1" && attackType != "punch" && attackType != "2" && attackType != "kick" && attackType != "3" && !(attackType.Contains("hand")) && attackType != "4" && !(attackType.Contains("hydro")) && attackType != "5" && !(attackType.Contains("fire")) && attackType != "6" && !(attackType.Contains("eat")));
                }

                if (IsSuccessfulAttack())
                {
                    Console.WriteLine("Successful attack!\n");

                    if (attackType == "1" || attackType == "punch")
                        Punch(fighter);
                    else if (attackType == "2" || attackType == "kick")
                        Kick(fighter);
                    else if (attackType == "3" || attackType.Contains("hand"))
                        HandCheck(fighter);
                    else if (attackType == "4" || attackType.Contains("hydro") || attackType.Contains("cannon"))
                        HydroCannon(fighter);
                    else if (attackType == "5" || attackType.Contains("fire"))
                        Fireball(fighter);
                    else if (attackType == "6" || attackType.Contains("eat"))
                        EatSoul(fighter);
                    else
                        SpecialAttack(fighter);
                }
                else
                {
                    Console.WriteLine("Attack missed.\n");
                    Commentary.Miss(fighter);
                }
            }
        }

        private void RetreatBoost()
        {
            Console.WriteLine("A smart one, you are!  +5 Health regenerated.");
            Health += 5;
        }

    }
}
