using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public delegate void UserBalanceNotification(User user);
    public interface IStregSystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, decimal amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IEnumerable<Transaction> GetTransactions(User user);
        User GetUserByUsername(string username);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);
        IEnumerable<Product> GetProducts(Func<Product, bool> predicate);
        void ExecuteTransaction(Transaction transaction);
        event UserBalanceNotification UserBalanceWarning;
    }
}
