using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Core
{
    public class StregSystem : IStregSystem
    {
        private List<Product> _products = new();
        private List<User> _users = new();
        private List<Transaction> _transactions = new();
        public IEnumerable<Product> ActiveProducts {
            get 
            {
                return _products.Where(p => p.Active);
            }
        }

        public event UserBalanceNotification UserBalanceWarning;

        public StregSystem()
        {
            ReadUsers();
        }

        private void ReadUsers()
        {
            string[] csv = Properties.Resources.users.Split("\n");
            foreach(string line in csv)
            {
                if (line == csv[0]) continue;
                string[] values = line.Split(",");
                if (values.Length > 1)
                {
                    _users.Add(new User(int.Parse(values[0]), values[1], values[2], values[3], decimal.Parse(values[4]), values[5]));
                }
            }
        }

        private void ReadProducts()
        {

        }

        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            return new InsertCashTransaction(_transactions.Count, user, amount);
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            return new BuyTransaction(_transactions.Count, user, product.Price);
        }

        public void ExecuteTransaction(Transaction transaction)
        {
            try
            {
                ((ITransaction)transaction).Execute();

                if(transaction.User.Balance <= 50)
                {
                    UserBalanceWarning.Invoke(transaction.User);
                }

                _transactions.Add(transaction);
            } 
            catch (InsufficientCreditsException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Product GetProductByID(int id)
        {
            return _products.Find(p => p.ID == id);
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            return _transactions.OrderBy(t => t.Date).Where(t => t.User == user);
        }

        public IEnumerable<Transaction> GetTransactions(User user)
        {
            return _transactions.Where(t => t.User == user);
        }

        public User GetUserByUsername(string username)
        {
            return _users.Find(u => u.Username == username);
        }

        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            return _users.Where(predicate);
        }
    }
}
