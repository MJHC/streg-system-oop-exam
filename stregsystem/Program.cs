using System;
using StregSystem.Core;

namespace StregSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IStregSystem stregSystem = new Core.StregSystem();
            foreach(User user in stregSystem.GetUsers(user => user != null))
                Console.WriteLine(user.ToString());
        }
    }
}
