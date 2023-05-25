using System;
using System.Numerics;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userInput = "", userLocation = "";
            GameStart();
            Console.WriteLine("Enter help for a list of actions");
            while (userInput !="HELP")
            {
                Game();
            }
            Help();

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

            static void Game()
            {
                CentralChamber();
            }

            static void CentralChamber()
            {
                Console.WriteLine("You are now in Central Chamber.");

                while (true)
                {
                    Console.Write("Please enter a direction: ");
                    string userInput = Console.ReadLine().ToUpper();
                    //would be better to use a switch statement here instead of if/else
                    // also, you can use [] after to check just the first letter so you dont have to check for both N and NORTH
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
                        default:
                            Console.WriteLine("Invalid answer. Please try again.");
                            break;

                    }

                }

            }
            static void Library()
            {
                Console.WriteLine("You are now in Library.");

                while (true)
                {
                    Console.Write("Door East.");
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
                        ChamberOfShadow();
                    }
                    else if (userInput == "WEST" || userInput == "W")
                    {
                        Console.WriteLine("You can not go to west from here. Please try again");
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
            static void PuzzleRoom()
            {
                Console.WriteLine("You are now in Puzzle Room.");

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
                        TreasureVault();
                        break; 
                    }
                    else if (userInput == "WEST" || userInput == "W")
                    {
                        CentralChamber();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer. Please try again.");
                    }
                }
            }
            static void ChamberOfShadow()
            {
                Console.WriteLine("You are now in Chamber Of Shadow.");

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
                        CentralChamber();
                        break;
                    }
                    else if (userInput == "EAST" || userInput == "E")
                    {
                        AltarRoom();
                        break;
                    }
                    else if (userInput == "WEST" || userInput == "W")
                    {
                        Library();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid answer. Please try again.");
                    }
                }
            }
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
                    else
                    {
                        Console.WriteLine("Invalid answer. Please try again.");
                    }
                }
            }
        }

    }
}
