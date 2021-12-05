using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public abstract class Transaction
    {
        public int ID { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public Transaction(int id, User user, decimal amount)
        {
            ID = id;
            User = user;
            Amount = amount;
            Date = DateTime.Now;
        }
    }
}
