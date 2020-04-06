using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class Game : IFighterGame
    {
        public virtual int Stage { get; private set; } = 1; // after each level (level will likely be in a while or do-while loop, with the option to repeat level upon a loss part of the level class's functionality), Level++;
        public virtual void PlayGame() 
        {
            for (int i = 0; i < 9; i++) // magic number; edit this
            {
                NewLevel Level = new NewLevel(this);
                bool result = Level.Play();
                if (result == false)
                {
                    Console.WriteLine("Boooo!");
                    return;
                }
                Stage++;
                continue;
            }
        }
        public bool BeatGame { get; private set; }

        public void TryAgain()
        {
            Console.WriteLine("Would you like to try again? \n\nAnswer: ");
            string answer = Console.ReadLine().ToLower();

  //          do ()
        }

    }
}
