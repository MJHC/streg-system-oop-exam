using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class InsertCashTransaction : Transaction, ITransaction
    {
        public InsertCashTransaction(int id, User user, decimal amount) : base(id, user, amount)
        {

        }

        // Remember Transaction Type
        public override string ToString()
        {
            return $"C {ID} {User.Username} {Amount} {Date}";
        }

        public void Execute()
        {
            User.Balance += Amount;
        }
    }
}
