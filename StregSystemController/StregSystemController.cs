using StregSystem.CLI;
using StregSystem.Controller.Exceptions;
using StregSystem.Core;
using System;

namespace StregSystem.Controller
{
    public class StregSystemController
    {
        private IStregSystem _stregSystem;
        private IStregSystemUI _ui;
        private CommandParser _parser;

        public StregSystemController(IStregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;
            _parser = new CommandParser(_stregSystem, _ui);

            _ui.CommandEntered += _parser.ParseCommand;
        }
    }
}
