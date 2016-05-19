using System;

namespace LibOutfitEnforcer
{
    class InvalidCommandArgument: Exception
    {
        public InvalidCommandArgument(string message): base(message)
        {
        }

        public InvalidCommandArgument(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
