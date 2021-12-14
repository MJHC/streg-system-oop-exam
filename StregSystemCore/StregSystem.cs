using StregSystem.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class StregSystem : IStregSystem
    {
        private List<Product> _products;
        private List<User> _users;
        private List<Transaction> _transactions = new();
        public IEnumerable<Product> ActiveProducts {
            get 
            {
                DateTime now = DateTime.Now;
                return _products.Where(p => 
                 p.Active && p is not SeasonalProduct || 
                (p is SeasonalProduct sp && sp.Active &&
                  now >= sp.SeasonStartDate  && now <= sp.SeasonEndDate));
            }
        }

        public event UserBalanceNotification UserBalanceWarning;

        public StregSystem(IDataReader reader)
        {
            _users = reader.ReadUsers();
            _products = reader.ReadProducts();
        }

        public InsertCashTransaction AddCreditsToAccount(User user, decimal amount)
        {
            return new InsertCashTransaction(_transactions.Count, user, amount);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            return new BuyTransaction(_transactions.Count, user, product, product.Price);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            ((ITransaction)transaction).Execute();
            LogTransaction(transaction);

            if(transaction.User.Balance < 50)
            {
                UserBalanceWarning.Invoke(transaction.User);
            }

            _transactions.Add(transaction);
        }

        private void LogTransaction(Transaction transaction)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            File.AppendAllText(Path.Combine(path, "log.txt"), transaction.ToString() + Environment.NewLine);
        }

        public Product GetProductByID(int id)
        {
            Product p = _products.Find(p => p.ID == id);
            if (p == null)
                throw new ProductNotFoundException($"Product ID: {id} not found!");
            return p;
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.OrderBy(t => t.Date).Where(t => t.User == user).Take(count);
        }

        public IEnumerable<Transaction> GetTransactions(User user)
        {
            return _transactions.OrderBy(t => t.Date).Where(t => t.User == user);
        }

        public User GetUserByUsername(string username)
        {
            User u = _users.Find(u => u.Username == username);
            if (u == null)
                throw new UserNotFoundException($"User: {username} not found!");
            return u;
        }

        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }

        public IEnumerable<Product> GetProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }
    }
}
