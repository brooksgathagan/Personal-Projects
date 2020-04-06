using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class RingLocation : Coordinate
    {
        public RingLocation(int x, int y) : base(x, y)
        {
            if (!(Ring.IsInRing(this)))
            {
               throw new NotInRingException("Not In Ring Exception:  You have placed the fighter outside of the ring! Nooooo");
            }
        }
        public bool IsInRangeOf(RingLocation location, int range)
        {
            return DistanceTo(location) <= range;
        }
    }
}
