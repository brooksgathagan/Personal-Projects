using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class Tower
    {
        protected virtual int Range { get; } = 1;
        protected virtual int Damage { get; } = 1;
        protected virtual double Accuracy { get; } = 0.75;

        private readonly MapLocation _location;

        public Tower() { }
        public Tower(Path path, Map map)
        {
            Console.Write($"Select the X and Y coordinates (x, y) for the tower, separated by a comma: ");
            var entry = Console.ReadLine();
            var coordinates = entry.Split(',');
            MapLocation location = new MapLocation(int.Parse(coordinates[0]), int.Parse(coordinates[1]), map);

            if (path.IsOnPath(location))
            {
                throw new OnThePathException("On The Path Exception:  Towers cannot be placed along paths.");
            }
            _location = location;
        }

        protected bool IsSuccessfulShot()
        {
            return Accuracy > Random.NextDouble();
        }

        public void FireOnInvaders(IInvader[] invaders)
        {
            foreach (IInvader invader in invaders)
            {
                if (invader.IsAlive && _location.IsInRangeOf(invader.Location, Range))
                {
                    if (IsSuccessfulShot())
                    {
                        invader.DecreaseHealth(Damage);

                        if (invader.IsDead)
                        {
                            Console.WriteLine($"Invader down!  The fell at location " + invader.Location + "!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Missed that invading scumbag!");
                    }
                    break; 
                    // We could also use "continue" to cycle to next loop iteration, tho we'd have to significantly decrease the accuracy as a Tower victory would be almost guaranteed.  As it stands, if we shoot at a single invader, the tower stops firing/ends method. 
                }
            }
        }
    }
}
