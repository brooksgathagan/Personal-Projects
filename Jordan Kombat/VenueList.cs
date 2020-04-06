using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    static class VenueList
    {
        private static readonly List<string> _venues = new List<string>
        {
            "Rucker Park, NYC",
            "Madison Square Garden, NYC",
            "The Q!, Cleveland",
            "Staples Center, Los Angeles",
            "Venice Beach, Los Angeles",
            "The YMCA!, Your Hometown",
            "TD Garden, Boston",
            "United Center, Chicago",
            "The Oracle, Oakland"
        };

        public static IEnumerable<string> Venues => _venues;

        public static void AddVenue(string venueName)
        {
            _venues.Add(venueName);
        }

        public static void AddVenues(IEnumerable<string> list)
        {
            _venues.AddRange(list);
        }

        public static void AddNewVenue()
        {
            Console.WriteLine("Enter the name of the venue you'd like to add & the city in which it's located, separated by a comma.");
            string venue = Console.ReadLine();
            VenueList.AddVenue(venue);
            Console.WriteLine("Do you want to play at this venue?");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y" || answer.Contains("yes"))
            {
                // Do something, e.g. set the Venue's location/arena name to the entered value.
            }
            else { return; }
        }

        private static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = Random.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static void ShuffleNames()
        {
            foreach (var x in _venues)
            {
                Console.WriteLine(x);
            }
            _venues.Shuffle(); // Shuffle(Name) also works.  I think we can call "_venues.Shuffle()" because we pass in "this" -- if we remove it, _venues.Shuffle() does not work.  
            foreach (var x in _venues)
            {
                Console.WriteLine(x);
            }
        }
    }

    class MyInt  // Pointer/reference type refresher.  Function in MJ, answer in Program.
    {
        public int Value;
    }

    class MyIntTest
    {
        public static string ReturnValue2()  // Pointer/reference type refresher (all classes, strings, objects, etc. are reference type)
        {
            MyInt x = new MyInt() { Value = 3 };
            MyInt y = x;
            y.Value = 4;
            return x.Value + "my Friend!";
        }
    }
}