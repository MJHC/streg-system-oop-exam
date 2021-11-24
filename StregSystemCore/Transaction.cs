using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public abstract class Transaction
    {
        public int ID { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int Amount { get; set; }

        public Transaction()
        {

        }
    }
}
