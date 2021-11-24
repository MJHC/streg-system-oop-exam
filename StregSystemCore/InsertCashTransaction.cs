using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public class InsertCashTransaction : Transaction, ITransaction
    {
        // Remember Transaction Type
        public override string ToString()
        {
            return $"C {ID} {User.Username} {Amount} {Date}";
        }

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
