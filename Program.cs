using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "";      //userInput could be initiated inside game but its here so that can be ironed out
            GameStart();
            Help();
            while (userInput != "HELP")
            {
                Game(ref userInput);
            }
            Help();
            static void GameStart()
            {
                Console.WriteLine("title");
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine("world setup placeholder");
            }
            static void Help()
            {
                Console.WriteLine("If you want to get an instruction of the game");
                Console.WriteLine("Type help");
                string userInput = Console.ReadLine().ToUpper();

            }

            static void Game(ref string userInput)
            {
                userInput = Console.ReadLine().ToUpper();
                Console.WriteLine("game done");
            }

            static void CentralChamber()
            {
                Console.WriteLine("Storyline");

                while (true)
                {
                    Console.Write("Please enter a direction: ");
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "north")
                    {
                        chamberOfShadow();
                        break;
                    }
                    else if (playerDirection == "south")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                }

            }
            static void Library()
            {

            }
            static void puzzleRoom()
            {

            }
            static void chamberOfShadow()
            {

            }
            static void treasureVault()
            {

            }
            static void altarRoom()
            {

            }
        }

    }
}
