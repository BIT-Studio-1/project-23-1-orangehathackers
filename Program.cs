using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "null";
            //gameStart();
            while (userInput != "HELP")
            {
                game(ref userInput);
            }
            helpConsole();
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
            Console.WriteLine("Help method");
        }
        static void game(ref string userInput)
        {
            Console.WriteLine("Game method");
            userInput= Console.ReadLine().ToUpper();
            Console.WriteLine("Still in game method");
        }
    }
}
