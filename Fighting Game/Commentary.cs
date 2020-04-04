using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    static class Commentary
    {

        public static void Commentators()
        {
            int switchCase = Random.Next(0, 2);
            switch (switchCase)
            {
                case 0:
                    Console.Write("Joe Rogan: ");
                    break;
                case 1:
                    Console.Write("Bob Ross: ");
                    break;
            }
        }

        public static string MoveAway(IFighter fighter)
        {
            string answer;
            Console.WriteLine($"{fighter} got you good on that hit! \nDo you want to take a step back to recover momentarily?  It could help... \nType \"Yes\" or \"No\". \n");
            do
            {
                Console.Write("Answer: ");
                answer = Console.ReadLine().ToLower();
            }
            while (!(answer.Contains("yes")) && !(answer.Contains("no")));

            return answer;
        }

        public static void Miss(IFighter fighter) // include special commoentary for MJ, tho probably going to have to do it in the Fighter file.  
        {
            Commentators(); 
            int switchCase = Random.Next(0, 5);
            switch (switchCase)
            {
                case 0:
                    Console.Write($"Incredible dodge by {fighter.Name}!");
                    break;
                case 1:
                    Console.Write("Missed him!");
                    break;
                case 2:
                    Console.Write($"Sometimes, it seems like {fighter.Name} is simply too fast to be touched.");
                    break;
                case 3:
                    Console.Write($"Can't connect with air! That was one hell of a juke.");
                    break;
                case 4:
                    Console.Write($"Outstanding job avoiding that attack by {fighter.Name}");
                    break;
            }
            Console.WriteLine("\n");
        }
        public static void Punch(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 10);
            switch (switchCase)
            {
                case 0:
                    Console.Write($"Nice punch, {fighter.Name}!");
                    break;
                case 1:
                    Console.Write("Oh, he's feeling that one!");
                    break;
                case 2:
                    Console.Write("The Haymaker!");
                    break;
                case 3:
                    Console.Write($"Ouch! {fighter.Name} definitely killed a few of his opponent's braincells with that punch.");
                    break;
                case 4:
                    Console.Write("In the face!");
                    break;
                case 5:
                    Console.Write("That's one of the smoothest punches that I've ever seen.");
                    break;
                case 6:
                    Console.Write($"A laser shot from {fighter.Name}!");
                    break;
                case 7:
                    Console.Write($"What a shot!  {fighter.Name} is an impressive fighter.");
                    break;
                case 8:
                    Console.Write("I haven't seen a punch like that since Tyson Fury back in 2020.");
                    break;
                case 9:
                    Console.Write("Now that's a stong blow to the body.");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void Kick(IFighter fighter)
        {
            Commentators();

            List<string> kick = new List<string>
            {
                $"Nice kick by {fighter.Name}!",
                "Ouch! What a kick!",
                $"{fighter.Name} is looking like Lionel Messi with some of these kicks.",
                "Right in the thigh!",
                "That kick almost took his knee out!",
                $"{fighter.Name} is going places.  Amazing kick.",
                "That's one of the cleanest head kicks that I've seen."
            };

            int index = Random.Next(kick.Count);
            Console.WriteLine(kick[index] + "\n");
        }

        public static void MJPunch()
        {
            Commentators();
            int switchCase = Random.Next(0, 6);
            switch (switchCase)
            {
                case 0:
                    Console.Write("Mike Jordan, or Mike Tyson?  Nice punch!");
                    break;
                case 1:
                    Console.Write("Left HOOK! What a shot from Jordan.");
                    break;
                case 2:
                    Console.Write("He'll jab you to sleep if you let him.");
                    break;
                case 3:
                    Console.Write("MJ for two!  Great punch.");
                    break;
                case 4:
                    Console.Write("What a punch!  Jordan has really come out swinging tonight.");
                    break;
                case 5:
                    Console.Write("Off the heezy!");
                    break;
                

            }
            Console.WriteLine("\n");
        }

        public static void MJKick()  // The non-switch way -- likely a bit less cumbersome. 
        {
            Commentators();
            List<string> mjKick= new List<string>
            {
                "Stupendous legwork from Michael.",
                "What a kick by MJ!  This guy is unreal.",
                "Ankle Breaker!",
                "You shook the man out of his shoes!",
                "A swift kick to the basketballs.  He's really something, isn't he?"
            };

            int index = Random.Next(mjKick.Count);
            Console.WriteLine(mjKick[index] + "\n");
        }

        public static void MJHandCheck()  // The non-switch way -- likely a bit less cumbersome. 
        {
            Commentators();

            List<string> mjThrow = new List<string>
            {
                "Oh, MJ is ready to throw hands, alright!",
                "You can't slap a man's hands like that, Michael!",
                "Is this Michael Jordan or Isiah Thomas?",
                "Oof! Such disrespect from MJ.",
                "Playground moves!  I see you, MJ!"
            };

            int index = Random.Next(mjThrow.Count);
            Console.WriteLine(mjThrow[index] + "\n");
        }

        public static void MJSpecial()
        {
            int switchCase = Random.Next(0, 2);
            switch (switchCase)
            {
                case 0:
                    Console.Write("Joe Rogan: Uh oh! MJ grabbed his Secret Stuff. \n**Gulp, gulp, gulp**"); // delay these .WriteLines by 0.5 - 1 second.
                    Console.Write("Joe Rogan: He's going for it!");
                    Console.Write("Joe Rogan: THE MJ SLAM-JAM!!!  OH. ME. OH. MY!");
                    break;
                case 1:
                    Console.Write("Bob Ross: Like Mike!  If I could be Like Mike...");
                    Console.Write("Bob Ross: ...I would give up painting in a heartbeat!");
                    Console.Write("Bob Ross: An ungodly Special Attack by MJ.");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void WaterAttack(IFighter fighter)
        {
            Commentators();
            List<string> list = new List<string>
            {
                $"These Hydro Cannons are lethal. I wouldn't want to be on the other end of that thing, let alone from {fighter.Name}.",
                "Hydro Cannon! That's gotta hurt.",
                $"Fun fact: {fighter.Name}'s Hydro Cannon is capable of toppling a building!",
                "That may as well be a fire hose!"
            };

            int index = Random.Next(list.Count);
            Console.WriteLine(list[index] + "\n");
        }

        public static void FireAttack(Fighter fighter)
        {
            Commentators();
            List<string> list = new List<string>
            {
                $"A magnificent Fireball attack from {fighter.Name}.  I can feel that burn from over here!  Wowzers.",
                "Ouch!  That Fireball is BLAZING!",
                $"That's one large mass of fire, courtesy of {fighter.Name}.",
                "Feel the burn!  Feel the Bern!  Bernie Sanders?  Wait..."
            };
            int index = Random.Next(list.Count);
            Console.WriteLine(list[index] + "\n");
        }

        public static void HauntedAttack(IFighter fighter)
        {
            Commentators();
            List<string> list = new List<string>
            {
                $"Woahh, {fighter.Name} is SpOoKY!  hE CAn EaT SoULs!",
                $"{fighter.Name} said, \"Boo!\" And then he devoured another soul.  What a pro!",
                $"Fun fact: {fighter.Name} has caused a cumulative 937871245 hours of sleep loss for humans around the globe -- and counting!",
                "What a Spooky maneuver! I'd sure hate to have my soul eaten..."
            };
            int index = Random.Next(list.Count);
            Console.WriteLine(list[index] + "\n");
        }

        public static void CelebAttack(Fighter fighter)
        {
            Commentators();
            List<string> list = new List<string>
            {
                $"{fighter.Name} might very well be the worst human being we've ever laid eyes upon.",
                "I can see why the public is not particularly fond of this man.  Wow.",
                $"Does anyone actually like {fighter.Name}?  Honestly.",
                $"Breaking news:  {fighter.Name} is a hero!"
            };
            int index = Random.Next(list.Count);
            Console.WriteLine(list[index] + "\n");
        }

        public static void SirSharkySpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write("SIR SHARKY! You can't do him like that, pal!  It's not hurricane season quite yet.");
                    break;
                case 1:
                    Console.Write("'Hurricane' attack is one of the most unique we've ever seen.  Wow!");
                    break;
                case 2:
                    Console.Write("Sir Sharky's Hurricane!  A devastating blow.");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void PoseidonSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write("The Lord of the Sea! Poseidon's Tsunami has been the cause of the past ten Tsunami-related disasters around the globe -- simply because someone pissed him off.");
                    break;
                case 1:
                    Console.Write($"{fighter.Name} is going to have some trouble keeping his head above water after that Tsunami from Poseidon.");
                    break;
                case 2:
                    Console.Write("Abort! Abort!  Tsunami Alert!");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void DylanSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write("HOT FIRE?!  Dylan, you can't spit that out on your opponents, pal!  It's only meant for making music!");
                    break;
                case 1:
                    Console.Write("Dylan spits the hottest fire that I've ever seen.");
                    break;
                case 2:
                    Console.Write($"Yes, Dylan.  We know that you spit Hot Fire!  Relax! {fighter.Name} didn't deserve that.");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void DevilSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write($"Which Circle of Hell is 'Inferno'?  Do I have that right?  Probably not.  Either way, that's where {fighter.Name} is right now!");
                    break;
                case 1:
                    Console.Write("A brilliant Inferno attack from Devil!");
                    break;
                case 2:
                    Console.Write($"I can feel that Inferno blazing from all the way over here!  {fighter.Name}'s gotta be feeling that one!");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void FreddySpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write($"Get out of {fighter.Name}'s dreams, Freddy!  It's not fair.");
                    break;
                case 1:
                    Console.Write("Freddy literally just ate his opponent's dream.  Uhhhh...");
                    break;
                case 2:
                    Console.Write("Dream Eater!  A nightmarish attack that can only occur when Spooked.");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void DraculaSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write($"WTF!  Dracula just bit {fighter.Name}'s neck!  EWWWWWWW! ");
                    break;
                case 1:
                    Console.Write("That blood-sucking bastard doesn't know right from wrong. That is disgusting, unsanitary, and presumably paintful!");
                    break;
                case 2:
                    Console.Write("A lethal bite from Dracula!");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void KanyeSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.Write("What on Earth is this guy talking about?  I legitimately have no idea.");
                    break;
                case 1:
                    Console.Write("Is Kanye just stringing random words together in hope that it will make sense?  That's all I can come up with.  I feel terrible for his opponent.");
                    break;
                case 2:
                    Console.Write($"Seriously, who thought that bringing Kanye here was a good idea? {fighter.Name}'s head is going to explode.");
                    break;
            }
            Console.WriteLine("\n");
        }


        public static void PiersMorganSpecial(IFighter fighter)
        {
            Commentators();
            int switchCase = Random.Next(0, 3);
            switch (switchCase)
            {
                case 0:
                    Console.WriteLine("Stop it, Piers!  Just stop it!");
                    Console.Write($"No, seriously.  Stop it, Piers.  Nobody wants to listen to you, much less {fighter}");
                    break;
                case 1:
                    Console.Write("Piers Morgan!!!");
                    Console.Write("...I hate you.");
                    break;
                case 2:
                    Console.Write("Honestly, does this guy ever stop talking?");
                    break;
            }
            Console.WriteLine("\n");
        }

        public static void MJMorph()
        {
            Console.WriteLine("You:  OK, that was interes--");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("You:  ...What the...what is happening?");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();

            Console.WriteLine("New Message!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Enter (1) to open, or enter (2) to exit.");
            var answer = Console.ReadLine();

            if (answer != "1")
            {
                Console.WriteLine("Ya, ya. Enough funny business.  This is a SERIOUS game!  Just type \"1\" so that we can move on.  Kthx.");
                do
                {
                    Console.WriteLine("Please type the number one (1) to read your message.");
                    answer = Console.ReadLine();
                }
                while (answer != "1");
            }

            System.Threading.Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Message from:  The Temple of Jordan");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("URGENT:  Michael, that was NOT Sir Sharky.  You are in D-A-N-G-E-R!  I repeat:  That was NOT Sir Sharky.  Please respond ASAP with your location");
            System.Threading.Thread.Sleep(4000);
            Console.Clear();
            Console.WriteLine("Enter arena name or location:  ");
            Console.ReadLine();
            System.Threading.Thread.Sleep(3000);
            Console.WriteLine("--- No Signal ---");

            Console.WriteLine("Joe Rogan:  What happened to the lights?  Hello?!");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Unknown voice:  Well, well, well.  This was a long time coming, Michael.  I'm glad you could make it.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("You:  I...I don't understand.  Who are you?");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Unknown voice:  You've been fighting me all along, Michael.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("You:  What? How does that make any sen--");
            Console.WriteLine("You:  Oh, no...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Familiar voice:  Oh, yes.  It's your very own Tyler Durden, baby!  Your own personal Jesus.  Get it?  Becuase of your insanely inflated ego...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("You:  ...");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("** The lights flicker and regain power **");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Joe Rogan:  WHAT?!  Sir Sharky has morphed into Michael Jordan!");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Bob Ross:  That can't be in the rules.  Is it?");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Joe Rogan:  No, Bob.  It isn't.  \nJoe Rogan:  Sir Sharky, or MJ, or whoever the hell you are.  Ya, you're going to need to get out of here.  I also commentate the UFC, so don't mess with me, bro -- just leave.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("MJ #2:  Oh, Joseph...");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("** MJ #2 smacks Joseph **");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Joe Rogan:  What the hell, man?  Not cool.  You know what, I think I'm gonna go hit some DMT and bounce.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Bob Ross:  Well, now that is thoroughly terrifying.  Michael and Michael, please allow me to craft a magnificently average portrait of this occasion.  Just let me grab some Titanium H-Wite.");
            Console.Clear();

            Console.WriteLine("MJ #2:  You ready?  Let's see if you can finally overcome yourself.");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("MJ #2:  Reach out and touch faith, bitch.");
            System.Threading.Thread.Sleep(3000);
            Console.Clear();

            Console.WriteLine("New Opponent:  Yourself");
        }
    }
}
