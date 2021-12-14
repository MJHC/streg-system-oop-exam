using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class BuyTransaction : Transaction, ITransaction
    {
        public Product Product { get; private set; }
        public BuyTransaction(int id, User user, Product product, decimal amount) : base(id, user, amount)
        {
            Product = product;
        }

        // Remember Transaction Type
        public override string ToString()
        {
            return $"B {ID} {User.Username} {Amount} {Date}";
        }

        public void Execute()
        {
            if (User.Balance < Amount && !Product.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException($"{User.Username} does not have sufficient credits!");
            }

            User.Balance -=Amount;
        }
    }
}
