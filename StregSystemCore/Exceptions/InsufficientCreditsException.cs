using System;

namespace StregSystem.Core
{
    class InsufficientCreditsException : Exception
    {
        public InsufficientCreditsException (string message) : base (message)
        {

        }
    }
}
