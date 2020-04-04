using System;
using System.Collections.Generic;
using System.Text;

namespace Fighting_Game
{
    class FightingGameException : System.Exception
    {
        public FightingGameException()
        { }

        public FightingGameException(string message) : base(message)
        { }
    }

    class NotInRingException : FightingGameException
    {
        public NotInRingException()
        { }

        public NotInRingException(string message) : base(message)
        { }
    }
}
