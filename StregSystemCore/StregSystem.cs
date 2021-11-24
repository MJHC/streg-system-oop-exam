using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public class StregSystem : IStregSystem
    {
        public IEnumerable<Product> ActiveProducts => throw new NotImplementedException();

        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }
    }
}
