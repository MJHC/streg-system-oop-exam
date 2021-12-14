using StregSystem.Core;
using System;

namespace StregSystem.CLI
{
    public class StregSystemCLI : IStregSystemUI
    {
        private IStregSystem _stregSystem;

        public event StregSystemEvent CommandEntered;
        
        private bool _isRunning = false;


        public StregSystemCLI (IStregSystem stregSystem)
        {
            _stregSystem = stregSystem;
            _stregSystem.UserBalanceWarning += BalanceWarning;
        }

        public void Start()
        {
            _isRunning = true;
            DisplayProducts();
            GetUserCommand();
        }
        public void Close()
        {
            _isRunning = false;
            Console.Clear();
            Console.WriteLine("StregSystem has been closed!");
        }

        public void DisplayProducts()
        {
            if (_isRunning)
            {
                foreach (Product product in _stregSystem.ActiveProducts)
                {
                    Console.WriteLine(product.ToString());
                }
            }
        }
        public void DisplayUserInfo(User user)
        {
            InfoMessage($"User Info: {user}");

            if(user.Balance < 50)
                InfoMessage("You have less than 50 kr!");

            Console.WriteLine();

            foreach (Transaction transaction in _stregSystem.GetTransactions(user, 10))
            {
                InfoMessage(transaction.ToString());
            }

            Console.WriteLine();
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            SuccessMessage($"{transaction.User.Username} has bought 1 {transaction.Product.Name} for {transaction.Amount} kr.");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            SuccessMessage($"{transaction.User.Username} has bought {count} {transaction.Product.Name} for {transaction.Amount * count} kr.");
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            ErrorMessage($"{user.Username} has insufficient credit to buy {product.Name}!");
        }

        public void DisplayGeneralError(string errorString)
        {
            ErrorMessage(errorString);
        }

        public void DisplayGeneralSuccess(string successString)
        {
            SuccessMessage(successString);
        }

        private void BalanceWarning(User user)
        {
            InfoMessage($"{user.Username} has less than 50 kr!");
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
            if (_isRunning)
            {
                Console.Write("Command>");
                CommandEntered.Invoke(Console.ReadLine());
            }
        }
    }
}
