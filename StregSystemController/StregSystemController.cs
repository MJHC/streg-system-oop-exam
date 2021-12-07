using StregSystem.CLI;
using StregSystem.Core;
using System;

namespace StregSystem.Controller
{
    public class StregSystemController
    {
        private IStregSystem _stregSystem;
        private IStregSystemUI _ui;

        private StregSystemCommandParser _parser = new StregSystemCommandParser();

        public StregSystemController(IStregSystem stregSystem, IStregSystemUI ui)
        {
            _stregSystem = stregSystem;
            _ui = ui;
            ui.Start();

            ReadLine();
        }

        private void ReadLine()
        {
            while (true)
            {
                _parser.ParseCommand(Console.ReadLine());
                _ui.ClearInputField();
            }
        }

    }
}
