using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public interface ITransaction
    {
        public void Execute();
    }
}
