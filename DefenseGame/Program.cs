using System;

namespace DefenseGame
{
    class Game
    {
        public static void Main()
        {
            try
            {
                Map map = new Map(99, 99);

                MapLocation[] x = new MapLocation[5];

                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = new MapLocation(1, 2, map);
                    Console.WriteLine(x[i]);
                }

                Path path = new Path(
                    new[]
                    {
                        new MapLocation(0, 2, map),
                        new MapLocation(1, 2, map),
                        new MapLocation(2, 2, map),
                        new MapLocation(3, 2, map),
                        new MapLocation(4, 2, map),
                        new MapLocation(5, 2, map),
                        new MapLocation(6, 2, map),
                        new MapLocation(7, 2, map)
                     }
                );


                IInvader[] invaders =
                {
                    new StrongInvader(path),
                    new BasicInvader(path),
                    new FastInvader(path),
                    new ResurrectingInvader(path),
                    new ShieldedInvader(path),
                };

                Console.WriteLine("Welcome to INVADERS!  Prepare to have your base raided, BUB!");
                Console.WriteLine("First, though, you'll need to set the coordinates for your (pathetic and unintimidating) Towers.");

                Tower[] towers =
                {
                    new RangeTower(path, map),
                    new SniperTower(path, map),
                    new PowerTower(path, map),
                    new SuperTower(path, map),
                    new SuperTower(path, map)
                };

                Level level1 = new Level(invaders)
                {
                    Towers = towers
                };

                bool playerWon = level1.Play();

                Console.WriteLine(playerWon ? "You have won the game!" : "Your base has been raided by the Invaders!");

            }
            catch (OutOfBoundsException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (MapSizeInvalidException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (OnThePathException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DefenseException) // no "ex" variable as we'll get a "variable not used" warning -- no biggie, but no need to have one if we're not throwing this exception anywhere (and thus no way for this to catch anything that's not already caught).
            {
                Console.WriteLine("Unhandled Exception DefenseException.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unhandled Exception: " + ex);
            }

        }
    }
}
