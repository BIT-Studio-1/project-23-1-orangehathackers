using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";      //userInput could be initiated inside game but its here so that can be ironed out
            GameStart();        //Introduces the game once on start

            while (userInput!="HELP")
            {
                Game(ref userInput);
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
        static void Game(ref string userInput)
        {
            Console.WriteLine("Game method");
            userInput= Console.ReadLine().ToUpper();
        }
    }
}
