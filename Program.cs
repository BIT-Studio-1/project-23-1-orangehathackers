using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            gameStart();
            helpConsole();

        }
        static void gameStart()
        {
            Console.WriteLine("title");
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine("world setup");
            Console.WriteLine("");
        }
        static void helpConsole()
        {
            Console.WriteLine("If you want to get an instruction of the game");
            Console.WriteLine("Type help");
            string userInput = Console.ReadLine();

            if (userInput == "help" || userInput == "HELP")
            {
                Console.WriteLine("Instruction");
            }
            static void inventory()
            {

            }
        }
    }
}
