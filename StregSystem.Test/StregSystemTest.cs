using StregSystem.Core;
using StregSystem.Core.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace StregSystem.Test
{
    public class StregSystemTest
    {
        [Theory]
        [InlineData("hape", "hans@peter.dk")]
        [InlineData("peha", "peter@hans.dk")]
        public void GetUserByUsername_ExpectedEmailTest(string input, string expected)
        {
            Core.StregSystem stregSystem = new Core.StregSystem(new DummyDataReader());

            User user = stregSystem.GetUserByUsername(input);

            Assert.Equal(expected, user.Email);
        }

        [Fact]
        public void GetUserByUsername_ThrowsUserNotFoundException()
        {
            Core.StregSystem stregSystem = new Core.StregSystem(new DummyDataReader());

            Assert.Throws<UserNotFoundException>(() => stregSystem.GetUserByUsername("user"));
        }

        [Fact]
        public void AddCreditAddCreditsToAccountTest()
        {
            Core.StregSystem stregSystem = new Core.StregSystem(new DummyDataReader());
            User user = stregSystem.GetUserByUsername("hape");

            decimal input = 100m;
            decimal expected = 200m;

            Transaction transaction = stregSystem.AddCreditsToAccount(user, input);
            stregSystem.ExecuteTransaction(transaction);

            Assert.Equal(expected, user.Balance);
        }

        [Theory]
        [InlineData(1, "cola")]
        [InlineData(2, "orange")]
        public void GetProductByIDTest(int input, string expected)
        {
            Core.StregSystem stregSystem = new Core.StregSystem(new DummyDataReader());

            Product product = stregSystem.GetProductByID(input);

            Assert.Equal(expected, product.Name);
        }

        [Fact]
        public void BuyProductTest()
        {
            Core.StregSystem stregSystem = new Core.StregSystem(new DummyDataReader());

            string input1 = "peha";
            int input2 = 2;
            decimal expected = 190m;

            User user = stregSystem.GetUserByUsername(input1);
            Product product = stregSystem.GetProductByID(input2);

            Transaction transaction = stregSystem.BuyProduct(user, product);

            stregSystem.ExecuteTransaction(transaction);

            Assert.Equal(expected, user.Balance);

        }
    }

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
