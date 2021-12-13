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

            _ui.GetUserCommand();
        }

        private void ParseCommand(string command)
        {
            Console.WriteLine(command);
        }
    }
}
