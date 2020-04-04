using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    public class Path
    {
        // if no underscore to incidate a private field, we'd have to name "path" and "path" (one as a field, the other a constructor argument) differnenly (as otherwise we'd be setting path = path in constructor, which is senseless), or type "this.path = path;" in the constructor ("this" refers to the current object)

        private readonly MapLocation[] _path;

        internal int x = 5; // used for practice with assembly references -- unrelated to this project

        public int Length => _path.Length;

        public Path(MapLocation[] path)
        {
            _path = path;
        }

        public MapLocation GetLocationAt(int pathLocation)
        {
            return pathLocation < _path.Length ? _path[pathLocation] : null; // requires that we make a path of contiguous MapLocations.  We could add dozens of MapLocations to the path in Program.cs, but could make game run improperly if not contiguous or there's any repeats.
        }

        public bool IsOnPath(MapLocation location)
        {
            foreach (var pathLocation in _path)
            {
                if (location.Equals(pathLocation))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
