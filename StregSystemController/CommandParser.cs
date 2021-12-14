using StregSystem.CLI;
using StregSystem.Controller.Exceptions;
using StregSystem.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StregSystem.Controller
{
    public class CommandParser
    {
        private IStregSystem _stregSystem;
        private IStregSystemUI _ui;
        private AdminCommandParser _adminCommandParser;
        
        public CommandParser(IStregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;
            _adminCommandParser = new AdminCommandParser(_stregSystem, _ui);
        }
        
        public void ParseCommand(string command)
        {
            string[] args = command.Split(' ');

            if (args.Length == 0) return;

            try
            {
                if (args[0].StartsWith(":"))
                {
                    _adminCommandParser.ParseAdminCommand(args);
                }
                else
                {
                    User user = _stregSystem.GetUserByUsername(args[0]);

                    switch (args.Length)
                    {
                        case 1: _ui.DisplayUserInfo(user); break;
                        case 2: Buy(user, args[1]); break;
                        case 3: Buy(user, args[2], args[1]); break;

                        default: throw new ArgumentException("Too Many Arguments!");
                    }
                }
            }
            catch (Exception ex)
            {
                _ui.DisplayGeneralError(ex.Message);
            }
            _ui.DisplayProducts();
            _ui.GetUserCommand();

        }


        private void Buy(User user, string id)
        {
            int productId = ConvertToInt(id);

            Product product = _stregSystem.GetProductByID(productId);
            BuyTransaction transaction = _stregSystem.BuyProduct(user, product);

            _stregSystem.ExecuteTransaction(transaction);

            _ui.DisplayUserBuysProduct(transaction);

        }
        private void Buy(User user, string id, string count)
        {
            int productId = ConvertToInt(id);
            int productCount = ConvertToInt(count);

            Product product = _stregSystem.GetProductByID(productId);

            for (int i = 0; i < productCount; i++)
            {
                BuyTransaction transaction = _stregSystem.BuyProduct(user, product);

                _stregSystem.ExecuteTransaction(transaction);

                if (i == productCount - 1)
                    _ui.DisplayUserBuysProduct(productCount, transaction);
            }
        }
        public static int ConvertToInt(string str)
        {
            bool isNumber = int.TryParse(str, out int result);

            if (!isNumber)
                throw new ArgumentException($"Argument: {str} is not an integer!");
            return result;
        }
    }
}
