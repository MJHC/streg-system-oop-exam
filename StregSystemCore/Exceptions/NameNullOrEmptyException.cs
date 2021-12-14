using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core.Exceptions
{
    public class NameNullOrEmptyException : Exception
    {
        public NameNullOrEmptyException(string message) : base(message)
        {

        }
    }
}
