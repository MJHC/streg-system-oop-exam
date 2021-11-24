using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public class BuyTransaction : Transaction, ITransaction
    {
        // Remember Transaction Type
        public override string ToString()
        {
            return $"B {ID} {User.Username} {Amount} {Date}";
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }

        // InsufficientCreditsException
        // Diverse Exceptions
    }
}
