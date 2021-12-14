using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core.Exceptions
{
    public class InvalidUsernameException : Exception
    {
        public InvalidUsernameException(string message) : base(message)
        {

        }
    }
}
