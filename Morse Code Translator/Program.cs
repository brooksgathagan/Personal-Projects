using System;
using System.Collections.Generic;
using System.Linq;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main(string[] args)
        {

            //  Test Morse:  .... . .-.. .-.. --- --..-- / .-- --- .-. .-.. -.. -.-.--
            //  Expected Result:  HELLO, WORLD!

            //  Test Morse:  .. / .-.. --- ...- . / -.. --- --. / ---... -.--.-   
            //  Expected Result:  I LOVE DOG :)

            //  Test Morse:    ...     /  kaw --- dwadawd !$!@#  ///// /   12
            //  Expected Result:  S ?O??? ?

            // To access morse-to-text, enter nothing & hit enter, or type "stop"
            while (true)
            {
                Console.Write("Enter text to translate into Morse Code:  ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "stop")
                {
                    break;
                }
                Console.WriteLine(MorseCodeTranslator.ToMorse(input));
            }

            while (true)
            {
                Console.Write("Enter morse code to translate into text:  ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input) || input.ToLower() == "stop")
                {
                    break;
                }

                Console.WriteLine(MorseCodeTranslator.MorseToTextBadVersion(input));
            }
        }
    }
}
