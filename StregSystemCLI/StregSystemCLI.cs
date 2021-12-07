using StregSystem.Core;
using System;

namespace StregSystem.CLI
{
    public class StregSystemCLI : IStregSystemUI
    {
        private IStregSystem _stregSystem;
        private int ActiveProducts;

        public StregSystemCLI (IStregSystem stregSystem)
        {
            _stregSystem = stregSystem;
        }

        public void Start()
        {
            Console.WriteLine("TREONs STREGSYSTEM : Jægerstuen");

            Console.SetCursorPosition(0, 4);

            foreach (Product product in _stregSystem.GetProducts(p => p.Active))
            {
                Console.WriteLine(product.ToString());
                ActiveProducts++;
            }

            ClearInputField();
        }
        public void Close()
        {
            Console.Clear();
            Console.WriteLine("StregSystem has been closed!");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            WriteInfoMessage($"Admin command: \"{adminCommand}\" not found!");
        }

        public void DisplayGeneralError(string errorString)
        {
            WriteInfoMessage(errorString);
        }

        public void DisplayInsufficientCash(User user, Product product)
        {
            WriteInfoMessage($"{user.Username} has insufficient credit to buy {product.Name}");
        }

        public void DisplayProductNotFound(string product)
        {
            WriteInfoMessage($"{product} not found!");
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            WriteInfoMessage($"{command} had too many arguments!");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            WriteInfoMessage($"{transaction.User.Username} has bought 1 product for {transaction.Amount} kr.");
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            WriteInfoMessage($"{transaction.User.Username} has bought {count} products for {transaction.Amount} kr.");
        }

        public void DisplayUserInfo(User user)
        {
            WriteInfoMessage($"User Info: {user}");
        }

        public void DisplayUserNotFound(string username)
        {
            WriteInfoMessage($"User {username} not found!");
        }

        private void WriteInfoMessage(string infoMessage)
        {
            Console.SetCursorPosition(0, 2);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.WriteLine(infoMessage);
            Console.SetCursorPosition(0, ActiveProducts + 5);
        }

        public void ClearInputField()
        {
            Console.SetCursorPosition(0, ActiveProducts + 5);
            Console.Write("\r" + new string(' ', Console.WindowWidth) + "\r");
            Console.Write("Command>");
        }
    }
}
