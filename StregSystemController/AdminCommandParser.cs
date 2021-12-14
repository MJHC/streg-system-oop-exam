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
    public delegate void AdminCommand(params string[] args);
    public class AdminCommandParser
    {
        private Dictionary<string, AdminCommand> _adminCommands = new();

        private IStregSystem _stregSystem;
        private IStregSystemUI _ui;

        public AdminCommandParser(IStregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;

            _adminCommands.Add(":quit", (args) => _ui.Close());
            _adminCommands.Add(":q", (args) => _ui.Close());

            _adminCommands.Add(":activate", (args) => {
                int id = CommandParser.ConvertToInt(args[0]);
                _stregSystem.GetProductByID(id).Active = true;
                _ui.DisplayGeneralSuccess($"Product: {args[0]} has been activated!");
            });

            _adminCommands.Add(":deactivate", (args) => {
                int id = CommandParser.ConvertToInt(args[0]);
                _stregSystem.GetProductByID(id).Active = false;
                _ui.DisplayGeneralSuccess($"Product: {args[0]} has been deactivated!");
            });

            _adminCommands.Add(":crediton", (args) => {
                int id = CommandParser.ConvertToInt(args[0]);
                _stregSystem.GetProductByID(id).CanBeBoughtOnCredit = true;
                _ui.DisplayGeneralSuccess($"Product: {args[0]} buy on credit has been activated!");
            });

            _adminCommands.Add(":creditoff", (args) => {
                int id = CommandParser.ConvertToInt(args[0]);
                _stregSystem.GetProductByID(id).CanBeBoughtOnCredit = false;
                _ui.DisplayGeneralSuccess($"Product: {args[0]} buy on credit has been deactivated!");
            });

            _adminCommands.Add(":addcredits", (args) => {
                User user = _stregSystem.GetUserByUsername(args[0]);
                int amount = CommandParser.ConvertToInt(args[1]);

                ITransaction transaction = _stregSystem.AddCreditsToAccount(user, amount);
                transaction.Execute();

                _ui.DisplayGeneralSuccess($"Credits: {amount} kr. have been insterted on {user.Username}'s account!");
            });
        }

        public void ParseAdminCommand(string[] args)
        {
            bool commandExists = _adminCommands.TryGetValue(args[0], out AdminCommand method);
            if (!commandExists)
                throw new AdminCommandException($"Command: {args[0]} does not exist!");
            method(args[1..]);
        }
    }
}
