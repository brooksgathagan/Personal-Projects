using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class NewLevel 
    {
        public string Phase { get; private set; }
        public int Stage { get; private set; }
        public IFighter Opponent { get; private set; }
        public MJ Hero { get; private set; }
        public string Arena { get; private set; }
        public RingLocation[,] TheRing { get; protected internal set; }
        public NewLevel(Game game)
        {
            Stage = game.Stage;

            RingLocation[,] newRing = new RingLocation[Ring.Height, Ring.Width];
            for (int i = 0; i < newRing.GetLength(0); i++)
            {
                for (int j = 0; j < newRing.GetLength(1); j++)
                {
                    newRing[i, j] = new RingLocation(i, j);
                }
            }

            TheRing = newRing;
            Hero = new MJ(this);

            switch (Stage)
            {
                case 1:
                    Phase = "Water Phase";
                    Arena = "Your Neighbor's Pool";
                    Opponent = new SirSharky(this);
                    break;
                case 2:
                    Phase = "Water Phase";
                    Arena = "Atlantis";
                    Opponent = new Poseidon(this);
                    break;
                case 3:
                    Phase = "Fire Phase";
                    Arena = "Volcano";
                    Opponent = new Dylan(this);
                    break;
                case 4:
                    Phase = "Fire Phase";
                    Arena = "Hell";
                    Opponent = new Devil(this);
                    break;
                case 5:
                    Phase = "Haunted Phase";
                    Arena = "Elm Street";
                    Opponent = new MJ(this); //new FreddyKrueger(this);
                    break;
                case 6:
                    Phase = "Haunted Phase";
                    Arena = "The Underworld";
                    Opponent = new Dracula(this);
                    break;
                case 7:
                    Phase = "Final Phase";
                    Arena = "Hmmm...?";
                    Opponent = new MJHybrid(this);
                    break;
                case 8:
                    Phase = "Bonus Round:  Celebrity Boss";
                    Arena = "Piers' Pier";
                    Opponent = new PiersMorgan(this);
                    break;
                case 9:
                    Phase = "Bonus Round:  Celebrity Boss #2";
                    Arena = "Kardashian Ranch";
                    Opponent = new KanyeWest(this);
                    break;
            }

            Hero.DefaultLocation = TheRing[8, 10];
            Hero.Location = Hero.DefaultLocation;
            Opponent.DefaultLocation = TheRing[11, 7];
            Opponent.Location = Opponent.DefaultLocation;

            LevelIntro();
        }

        private void LevelIntro()
        {
            // I only have these separated (i.e. not simply printed below thru WriteLine) in order to easily change the cursor position based on the length value of the strings (as to display text in the center of the console window)
            string levelIntro = $"{Phase} - Level {Stage}";
            string arenaIntro = $"Arena:  {Arena}";
            string opponentIntro = $"Your opponent is:  {Opponent.Name}";
            string tip = "Tip:  Certain types of fighters may be susceptible to certain attacks, although you may not be quite as accurate when using them...";
            string tipReminder = "Remember:  Certain types of fighters may be susceptible to certain attacks, although you may not be quite as accurate when using them...";
            string finalTip = "Tip:  Sorry, bud.  I've got nothing for this one.  Good luck!";

            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - (arenaIntro.Length)) / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(levelIntro);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - (arenaIntro.Length)) / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(arenaIntro);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
            Console.SetCursorPosition((Console.WindowWidth - (opponentIntro.Length)) / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(opponentIntro);
            System.Threading.Thread.Sleep(1000);
            Console.Clear();

            if (Stage == 1)
            {
               // Console.SetCursorPosition((Console.WindowWidth - (tip.Length)) / 2, Console.WindowHeight / 2 - 1);
                Console.WriteLine(tip);
                System.Threading.Thread.Sleep(3000);
            }
            else if (Stage == 3 || Stage == 5)
            {
                //Console.SetCursorPosition((Console.WindowWidth - (tipReminder.Length)) / 2, Console.WindowHeight / 2 - 1);
                Console.WriteLine(tipReminder);
                System.Threading.Thread.Sleep(3000);
            }
            else if (Stage == 7)
            {

               // Console.SetCursorPosition((Console.WindowWidth - (finalTip.Length)) / 2, Console.WindowHeight / 2 - 1); 
                Console.WriteLine(finalTip);
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Sir Sharky? I thought that I defea- ...whatever.");
            }
        }

        public bool Play()
        {
            while (Hero.IsAlive && Opponent.IsAlive)
            {
                Hero.Attack(Opponent);
                if (Opponent.IsDead)
                {
                    Console.WriteLine($"{Hero} wins!");
                    System.Threading.Thread.Sleep(3000);
                    return true;
                }
                Opponent.Attack(Hero);
                if (Hero.IsDead)
                {
                    Console.WriteLine($"{Opponent} wins!");
                    return false;
                }
            }
            return false;

        }
        public void DisplayHealth()
        {
            Console.WriteLine($"Your Health:  {Hero.Health}");
            Console.WriteLine($"Opponent's Health:  {Opponent.Health}");
        }

        /* No longer used, but could see a use for it eventually.
         
        public void DisplayLocations()
        {
            Console.WriteLine($"Your Location:  {Hero.Location}");
            Console.WriteLine($"Opponent's Location:  {Opponent.Location}");
        }
        */

    }
}
