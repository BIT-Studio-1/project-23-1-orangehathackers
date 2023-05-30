using System;
using System.Numerics;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GameStart();
            CentralChamber();
        }
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
            Console.WriteLine("There are doors to the north and east.");
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
            Console.WriteLine("There are doors to the east and west");
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
                        TreasureVault();
                        break;
                    case 'W':
                        CentralChamber();
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
        //{
            //    Console.WriteLine("You are now in Chamber Of Shadow.");
            //
            //    while (true)
            //    {
            //        Console.Write("Please enter a direction: ");
            //        string userInput = Console.ReadLine().ToUpper();
            //
            //        if (userInput == "NORTH" || userInput == "N")
            //        {
            //            Console.WriteLine("You can not go to north from here. Please try again");
            //        }
            //        else if (userInput == "SOUTH" || userInput == "S")
            //        {
            //            CentralChamber();
            //            break;
            //        }
            //        else if (userInput == "EAST" || userInput == "E")
            //        {
            //            AltarRoom();
            //            break;
            //        }
            //        else if (userInput == "WEST" || userInput == "W")
            //        {
            //            Library();
            //            break;
            //        }
            //        else if (userInput == "HELP")
            //        {
            //            Help();
            //        }
            //        else
            //        {
            //            Console.WriteLine("Invalid answer. Please try again.");
            //        }
            //    }
            //}
        static void TreasureVault()
        {
            Console.WriteLine("You are now in Treasure Vault.");

            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "NORTH" || userInput == "N")
                {
                    Console.WriteLine("You can not go to north from here. Please try again");
                }
                else if (userInput == "SOUTH" || userInput == "S")
                {
                    Console.WriteLine("You can not go to south from here. Please try again");
                }
                else if (userInput == "EAST" || userInput == "E")
                {
                    Console.WriteLine("You can not go to east from here. Please try again");
                }
                else if (userInput == "WEST" || userInput == "W")
                {
                    PuzzleRoom();
                    break;
                }
                else if (userInput == "HELP")
                {
                    Help();
                }
                else
                {
                    Console.WriteLine("Invalid answer. Please try again.");
                }
            }
        }
        static void AltarRoom()
        {
            Console.WriteLine("You are now in Altar Room.");

            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();

                if (userInput == "NORTH" || userInput == "N")
                {
                    Console.WriteLine("You can not go to north from here. Please try again");
                }
                else if (userInput == "SOUTH" || userInput == "S")
                {
                    Console.WriteLine("You can not go to south from here. Please try again");
                }
                else if (userInput == "EAST" || userInput == "E")
                {
                    Console.WriteLine("You can not go to east from here. Please try again");
                }
                else if (userInput == "WEST" || userInput == "W")
                {
                    ChamberOfShadow();
                    break;
                }
                else if (userInput == "HELP")
                {
                    Help();
                }
                else
                {
                    Console.WriteLine("Invalid answer. Please try again.");
                }
            }
        }
    }
}

