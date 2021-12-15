using StregSystem.Core;
using System.Collections.Generic;

namespace StregSystem.Test
{
    internal class DummyDataReader : IDataReader
    {
        public List<Product> ReadProducts()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product(1, "cola", 12m, true, false));
            products.Add(new Product(2, "orange", 10m, true, false));
            return products;
        }

        public List<User> ReadUsers()
        {
           List<User> users = new List<User>();
            users.Add(new User(1, "Hans", "Peter", "hape", 100m, "hans@peter.dk"));
            users.Add(new User(2, "Peter", "Hans", "peha", 200m, "peter@hans.dk"));
            return users;
        }
    }
}
