using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "null";
            gameStart();
            while (userInput == "help")
            {
                helpConsole();
            }
            else

        }
        static void gameStart()
        {
            Console.WriteLine("title");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("world setup");
        }
        static void helpConsole()
        {
            Console.WriteLine("If you want to get an instruction of the game");
            Console.WriteLine("Type help");
            string userInput = Console.ReadLine();

            if (userInput == "HELP")
            {
                Console.WriteLine("Instruction");
            }
        }
        static void game(ref string userInput)
        {
            userInput= Console.ReadLine().ToUpper();
            Console.WriteLine("game done");
        }
    }
}
