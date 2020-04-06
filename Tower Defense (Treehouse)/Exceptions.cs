using System;
using System.Collections.Generic;
using System.Text;

namespace DefenseGame
{
    class DefenseException : System.Exception
    {
        public DefenseException()
        {
        }

        public DefenseException(string message) : base(message)
        {
        }
    }

    class OutOfBoundsException : DefenseException
    {
        public OutOfBoundsException()
        {
        }

        public OutOfBoundsException(string message) : base(message)
        {
        }
    }

    class MapSizeInvalidException : DefenseException
    {
        public MapSizeInvalidException()
        {
        }

        public MapSizeInvalidException(string message) : base(message)
        {
        }
    }

    class OnThePathException : DefenseException
    {
        public OnThePathException()
        {
        }

        public OnThePathException(string message) : base(message)
        {
        }
    }
}

