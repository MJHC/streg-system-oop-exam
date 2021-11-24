using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystemCore
{
    public interface IStregSystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IEnumerable<Transaction> GetTransactions(User user);
        User GetUserByUsername(string username);
        //User GetUsers(Func<User, bool> predicate);
        //event UserBalanceNotification UserBalanceWarning
    }
}
