using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Controller.Exceptions
{
    public class AdminCommandException : Exception
    {
        public AdminCommandException(string message) : base (message)
        {

        }
    }
}
