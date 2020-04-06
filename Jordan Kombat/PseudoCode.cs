



// The Monstars weren't enough for you, huh? 
// OK, MJ.
// Guess what?  Because you're the so-called "GOAT," we're not going to allow you to battle us in basketball.  
// Nooo! Michael!
// Instead, you're going to fight to the death -- Mortal Kombat style, but in Pokemon-style text format because I can only write console apps.  A pity, isn't it, MJ? 
// Lol so funny he can't code! 
// SHUT UP, MICHAEL!
// Time to meet your maker. Ready?
// string answer = Console.ReadLine();
// if answer == "y" || answer.Contains("yes"), proceed to game
// if answer == "n" || answer.Contains("no")
// Are you sure?  Trust me, you'll have a blast!  
// if answer = y, quit
// if answer = n, "OK, well make up your mind.  Are you ready or not?"
// if answer = y, continue
// if answer = n, quit
// In program, new MJ
// New level1
// Upon level 2, ask for ability boost.
// only do ability boosts after type stages from then on out. 

// 3 characters of each "type" -- water, fire, haunted + a boss (which morphs into "you")

// Exchange attacks
// If takes a certain amount of damage, retreat
// Move backwards and move towards opponent
// Display opponent's health after each attack


// Maybe use Composition to create the Final Boss class -- starts as Squirtle or another class, evolves into "mirror" or w/e.


// Give the option for health regeneration (for player and bosses) -- maybe if health gets below a certain point, or, for player, if completed a certain amount of levels.  
// Maybe give the bosses a certain likelihood of regenerating health





// General Questions:
// For class members -- in this case, the "Damage" members -- for MJ, we have a private "_throwDamage" and protected inherited members "KickDamage" and "PunchDamage."  Is it bad practice to have members that are otherwise alike differentiated this way 
// Both in terms of one being private (unique to class) and the others being protected inherited, and in the sense of style/placement -- I keep privates at the top, and it has an underscore; protected lower, and capitalized.  Looks odd.  
// I do know that it's best practice (at least as I've learned) to format things this way (underscore private members, capitalize non-private properties)

// New Game
// New Level(game)
// New Venue(

//_________________________________________________________________________________________________________________________
//_________________________________________________________________________________________________________________________
//_________________________________________________________________________________________________________________________
//_________________________________________________________________________________________________________________________
//_________________________________________________________________________________________________________________________



// Struct and Enumerations are only non-standard (int, char, bool, floating points e.g. double) value types.  

// How are Dictionary Key's set -- manually, by HashCode, both/

// Can you index into a HashSet and set another object to its value?
// e.g. For a HashSet of ints, HashSet<int> mySet
// int x = mySet[object.GetHashCode()]

// Can you update values in HashSets, or are they only used for lookup/add/remove and set operations?

// To the HashSet questions, I think the answer is "No."

// Sets are fast for lookup (O(1)), adding/removing (O(1)).  Can't update, I don't think?  Verify.
// Don't allow for duplicates -- assuming Equals and HashCode are set to be equal!
// Lists/arrays are fast at updating and retrieving (assuming we have the index of the item we're looking for, that is), but suck at everything else.
// Always allow for duplicates.
// Dictionary keys behave like sets, and their values like arrays -- the keys are hashed, whereas the values are not.  If we have key, very fast.  If only value, not so much.
// I don't think they allow for duplicates -- at least not more than 1 of the same key given our notes in the MorseTranslator.cs constructor.  Values can be duplicates.  
// LinkedLists are super fast for adding (assuming no order), and fast for removing  once the item is found, but potentially also relatively slow.  Also not good for updating/indexing for same reason -- we have to start @ beginning and work our way down the list, as we do w/ array/list.
// Don't require that items be shifted, so still faster than array/list even if the time to "find" the item to remove is the same.  
// Node w/ value & pointer to another node, making a chain of nodes (the linked list)
// Queues are like lists, but items can only be added to end & removed from beginning (hence the name).  First-in, first out
// Stacks are Last-In, First Out (I'd imagine designed based on the "stack frame LIFO" concept -- functions/local variables, or in C#, )
// SortedSet / SortedDictionary / SortedList require less memory than their non-sorted counterparts, and should be used when we want to keep thing sorted or loop through a sorted collection (obviously).  
//  SortedList is more like a Dictionary -- requires a <Key, Value>

// Aaaand even MORE collections in the System.Collections namespace!

// System.Collections.ObjectModel
// Used when we want to create our own collection type.  Classes within are generic & work with any object.
// System.Collections.Concurrent
// Used to share data between threads (multiple threads = code running simultaneously w/ other code in program).
// When working with threads, must ensure that one thread isn't interfering w/ data that another is working with.
// System.Collections itself
// Most of these are no longer used -- better versions in System.Collections.Generic.  In general, go for Generic collections.

// if NONE of these work, we can likely find 3rd-party libraries w/ implementations of other Collections (others do exist), or again, we could create or own (via extending them, combining, making something new altogether, etc.)

