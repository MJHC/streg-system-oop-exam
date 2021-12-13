using StregSystem.Core;
using System;

namespace StregSystem.CLI
{
    public class StregSystemCLI : IStregSystemUI
    {
        private IStregSystem _stregSystem;

        public event StregSystemEvent CommandEntered;

        public StregSystemCLI (IStregSystem stregSystem)
        {
            _stregSystem = stregSystem;
        }

        public void Start()
        {
            DisplayProducts();
            GetUserCommand();
        }
        public void Close()
        {
            Console.Clear();
            Console.WriteLine("StregSystem has been closed!");
        }

        public void DisplayProducts()
        {
            foreach (Product product in _stregSystem.ActiveProducts)
            {
                Console.WriteLine(product.ToString());
            }
        }
        public void DisplayUserInfo(User user)
        {
            InfoMessage($"User Info: {user}");

            if(user.Balance < 50)
                InfoMessage("You have less than 50 streg dollars!");

            Console.WriteLine();

            foreach (Transaction transaction in _stregSystem.GetTransactions(user, 10))
            {
                InfoMessage(transaction.ToString());
            }

            Console.WriteLine();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            SuccessMessage($"{transaction.User.Username} has bought 1 product for {transaction.Amount} kr.");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            SuccessMessage($"{transaction.User.Username} has bought {count} products for {transaction.Amount} kr.");
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            ErrorMessage($"{user.Username} has insufficient credit to buy {product.Name}");
        }

        public void DisplayGeneralError(string errorString)
        {
            ErrorMessage(errorString);
        }

        private void SuccessMessage(string infoMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(infoMessage);
            Console.ResetColor();
        }

        private void InfoMessage(string warningMessage)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(warningMessage);
            Console.ResetColor();
        }

        private void ErrorMessage(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public void GetUserCommand()
        {
            Console.Write("Command>");
            CommandEntered.Invoke(Console.ReadLine());
        }
    }
}
