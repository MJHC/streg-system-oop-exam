using StregSystem.CLI;
using StregSystem.Core;
using System;

namespace StregSystem.Controller
{
    public class StregSystemController
    {
        private IStregSystem _stregSystem;
        private IStregSystemUI _ui;

        public StregSystemController(IStregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;

            _ui.CommandEntered += ParseCommand;
        }

        private void ParseCommand(string command)
        {
            string[] args = command.Split(' ');

            if (args.Length == 0) return;

            if (args[0].StartsWith(":"))
            {

            } 
            else
            {
                try
                {
                    User user = _stregSystem.GetUserByUsername(args[0]);

                    switch (args.Length)
                    {
                        case 1:  _ui.DisplayUserInfo(user);                      break;
                        case 2:  Buy(user, args[1]);                             break;
                        case 3:  Buy(user, args[2], args[1]);                    break;
                        default: _ui.DisplayGeneralError("Too Many Arguments!"); break;
                    }
                }
                catch (Exception ex)
                {
                    _ui.DisplayGeneralError(ex.Message);
                }
            }
            _ui.DisplayProducts();
            _ui.GetUserCommand();
        }

        private void Buy(User user, string id)
        {
            bool isNumber = int.TryParse(id, out int result);
            if (isNumber)
            {
                Product product = _stregSystem.GetProductByID(result);
                BuyTransaction transaction = _stregSystem.BuyProduct(user, product);

                _stregSystem.ExecuteTransaction(transaction);

                _ui.DisplayUserBuysProduct(transaction);
            }
            else 
            {
                _ui.DisplayGeneralError($"Product ID: {id} is not an integer!");
            }
        }
        private void Buy(User user, string id, string count)
        {
            bool isIdNumber = int.TryParse(id, out int idResult);
            bool isCountNumber = int.TryParse(count, out int countResult);

            if (isIdNumber && isCountNumber)
            {
                Product product = _stregSystem.GetProductByID(idResult);

                for(int i = 0; i < countResult; i++)
                {
                    BuyTransaction transaction = _stregSystem.BuyProduct(user, product);

                    _stregSystem.ExecuteTransaction(transaction);
                }
                //_ui.DisplayUserBuysProduct(countResult, transaction);
            }
            else
            {
                _ui.DisplayGeneralError("Some arguments are not integers!");
            }
        }
    }
}
