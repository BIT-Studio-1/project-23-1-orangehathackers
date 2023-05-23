using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "null";      //userInput could be initiated inside game but its here so that can be ironed out
            GameStart();        //Introduces the game once on start
            while (true)        //This is the new help method code which breaks the while loop
            {
                //game(ref userInput);
                userInput= Console.ReadLine();
                Console.WriteLine("bad");
                if (userInput == "HELP")
                    break;
            }
            Help();
        }
        static void GameStart()
        {
            Console.WriteLine("title");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("world setup placeholder");
        }
        static void Help()
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
