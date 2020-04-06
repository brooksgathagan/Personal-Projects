using System;
using System.Collections.Generic;
using System.Text;

namespace MorseCodeTranslator
{
    static class MorseCodeTranslator
    {
        private static readonly Dictionary<char, string> _textToMorse = new Dictionary<char, string>
        {
            {' ', "/"},
            {'A', ".-"},
            {'B', "-..."},
            {'C', "-.-."},
            {'D', "-.."},
            {'E', "."},
            {'F', "..-."},
            {'G', "--."},
            {'H', "...."},
            {'I', ".."},
            {'J', ".---"},
            {'K', "-.-"},
            {'L', ".-.."},
            {'M', "--"},
            {'N', "-."},
            {'O', "---"},
            {'P', ".--."},
            {'Q', "--.-"},
            {'R', ".-."},
            {'S', "..."},
            {'T', "-"},
            {'U', "..-"},
            {'V', "...-"},
            {'W', ".--"},
            {'X', "-..-"},
            {'Y', "-.--"},
            {'Z', "--.."},
            {'1', ".----"},
            {'2', "..---"},
            {'3', "...--"},
            {'4', "....-"},
            {'5', "....."},
            {'6', "-...."},
            {'7', "--..."},
            {'8', "---.."},
            {'9', "----."},
            {'0', "-----"},
            {',', "--..--"},
            {'.', ".-.-.-"},
            {'?', "..--.."},
            {';', "-.-.-."},
            {':', "---..."},
            {'/', "-..-."},
            {'-', "-....-"},
            {'\'', ".----."},
            {'"', ".-..-."},
            {'(', "-.--."},
            {')', "-.--.-"},
            {'=', "-...-"},
            {'+', ".-.-."},
            {'@', ".--.-."},
            {'!', "-.-.--"},
            {'Á', ".--.-"},
            {'É', "..-.."},
            {'Ö', "---."},
            {'Ä', ".-.-"},
            {'Ñ', "--.--"},
            {'Ü', "..--"}
        };

        private static readonly Dictionary<string, char> _morseToText = new Dictionary<string, char>();


        static MorseCodeTranslator() // Static methods can be used in non-static classes to immutably initialize static members (they can only alter static members).  Static constructors are only run once.
        {
            foreach (KeyValuePair<char, string> pair in _textToMorse)
            {
                _morseToText.Add(pair.Value, pair.Key);
            }
        }

        // For each capitalized character in "input" (the keys), set the associated Value pair to string morseCode & add morseCode to the List, output.  
        // If the key somehow doesn't exist, throw in an "!" 
        public static string ToMorse(string input)
        {
            List<string> output = new List<string>(input.Length);

            foreach (char character in input.ToUpper())
            {
                try
                {
                    string morseCode = _textToMorse[character];
                    output.Add(morseCode);
                }
                catch (KeyNotFoundException)
                {
                    output.Add("!");
                }
            }
            return string.Join(" ", output);
        }

        public static string ToText(string input)  
        {

            List<char> output = new List<char>();
            var x = input.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); // used to account for more than a single space between morse characters, as well as spaces before/after the message.

            foreach (var y in x)
            {
                try
                {
                    output.Add(_morseToText[y]);
                }
                catch (KeyNotFoundException)
                {
                    output.Add('?');
                }
            }

            return string.Join("", output);
        }

        // A far less eloquent version of converting morse to text below (i.e. without using string.Split())...

        // To start, morseCharacter will be null if we haven't added anything to the output (output is the exact same as in the methods above).  
        // If we have spaces at the beginning, nothing happens -- we pass thru the conditional.  
        // If we have a character at the beginning, we add it to the morseCharacter string, and keep doing this until we hit a space again.  At that point, morseCharacter will not be null, so we add the Value pair of the string (morseCharacter, the key) to the List, output.
        // Once we add an item to the List, we set morseCharacter back to null.  This also has the effect of accounting for multiple spaces.
        // As with above, if a key doesn't match, we add a special character (?)

        // The second set of try blocks following the foreach loop are to account for a missing final output character.
            // If there are no spaces at the end of the morse code message that we're entering, we never get thru the first "if", which means we never .Add the associated Value to the output. 
            // So, we go thru again w/ another set of try blocks.  If morseCharacter isn't null, then we add the final character of output.  
             
        public static string MorseToTextBadVersion(string input)
        {

            List<char> output = new List<char>();

            string morseCharacter = null;

            foreach (char morseDotDash in input)
            {
                try
                {
                    if (morseDotDash == ' ')
                    {
                        if (morseCharacter != null)
                        {
                            output.Add(_morseToText[morseCharacter]);
                            morseCharacter = null;
                        }
                    }
                    else
                    {
                        morseCharacter += morseDotDash.ToString();
                    }
                }
                catch (KeyNotFoundException)
                {
                    output.Add('?');
                    morseCharacter = null;
                }
            }
            try
            {
                if (morseCharacter != null)
                {
                    output.Add(_morseToText[morseCharacter]);
                }
            }
            catch (KeyNotFoundException)
            {
                output.Add('?');
            }

            return string.Join("", output);
        }

        public static void WriteDictionary()
        {
            foreach (KeyValuePair<char, string> abc in _textToMorse)    // or in _morseToText, but same thing apart from swapping the keys/values. 
            {                                                                  
                Console.WriteLine(abc);
            }
        }

        public static void WriteKeys()
        {
            foreach (KeyValuePair<char, string> pair in _textToMorse)
            {
                Console.WriteLine(pair.Key);
            }

        }
    }
}
