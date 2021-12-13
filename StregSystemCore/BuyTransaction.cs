using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class BuyTransaction : Transaction, ITransaction
    {
        public BuyTransaction(int id, User user, decimal amount) : base(id, user, amount)
        {
        }

        // Remember Transaction Type
        public override string ToString()
        {
            return $"B {ID} {User.Username} {Amount} {Date}";
        }

        public void Execute()
        {
            if (!(User.Balance >= Amount))
            {
                throw new InsufficientCreditsException($"{User.Username} does not have sufficient credits!");
            }

            User.Balance -=Amount;
        }
    }
}
