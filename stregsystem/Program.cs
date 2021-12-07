using System;
using StregSystem.CLI;
using StregSystem.Controller;
using StregSystem.Core;

namespace StregSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStregSystem stregSystem = new Core.StregSystem();
            IStregSystemUI ui = new StregSystemCLI(stregSystem);
            StregSystemController controller = new StregSystemController(stregSystem, ui);
        }
    }
}
