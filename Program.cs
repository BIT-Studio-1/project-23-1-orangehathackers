using System;
using System.Numerics;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void GameStart()
        {
            Console.WriteLine("Name placeholder");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("Welcome!!!! to the Excavation Game.");
            Console.WriteLine("You are an archaeologist exploring an ancient excavation site.");
            Console.WriteLine("Your mission is to find a long lost artifact of great power.");
            Console.WriteLine("Prepare yourself for an adventure filled with puzzles and mysteries!\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }

        static void Help()
        {
            Console.WriteLine("Instructions");
            Console.WriteLine("Enter commands to navigate between rooms and interact with the environment.");
            Console.WriteLine("Use 'north', 'south', 'east' and 'west' to move in those respective directions.");
            Console.WriteLine("Explore each room throughly to find items and solve puzzles.");
            Console.WriteLine("Collect useful items to help you progress in the game.");
            Console.WriteLine("Your ultimate goal is to discover the hidden artifact and claim it for yourself.");
            Console.WriteLine("Good Luck!!!!!");
        }
        static void CentralChamber()
        {
            Console.WriteLine("You are now in Central Chamber.");

            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput[0])
                {
                    case 'N':
                        ChamberOfShadow();
                        break;
                    case 'S':
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case 'E':
                        PuzzleRoom();
                        break;
                    case 'W':
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case 'H':
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }

            }

        }
        static void Library()
        {
            Console.WriteLine("You are now the library.");
            Console.WriteLine("There is a door to the east.");
            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput[0])
                {
                    case 'N':
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case 'S':
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case 'E':
                        ChamberOfShadow();
                        break;
                    case 'W':
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case 'H':
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static void PuzzleRoom()
        {
            Console.WriteLine("You are now the puzzle room.");

            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput[0])
                {
                    case 'N':
                        ChamberOfShadow();
                        break;
                    case 'S':
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case 'E':
                        ChamberOfShadow();
                        break;
                    case 'W':
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case 'H':
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static void ChamberOfShadow()
        {

        }
        static void TreasureVault()
        {

        }
        static void AltarRoom()
        {

        }
        static void Main(string[] args)
        {
            GameStart();