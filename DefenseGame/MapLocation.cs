using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    public class MapLocation : Point
    {
        public MapLocation(int x, int y, Map map) : base(x, y)
        {
            if (!(map.IsOnMap(this)))
            {
                throw new OutOfBoundsException("Out of Bounds Exception: " + this + " is outside of the boundary of the map.");
            }
        }

        public bool IsInRangeOf(MapLocation location, int range)
        {
            return DistanceTo(location) <= range;
        }

    }
}
