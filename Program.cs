using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CentralChamber();
            
            //string userInput = "";      //userInput could be initiated inside game but its here so that can be ironed out
            //GameStart();
            //Help();
            //while (userInput != "HELP")
            //{
            //    Game(ref userInput);
            //}
            //Help();
            GameStart();
            Help();

            Game();

            static void GameStart()
            {
                Console.WriteLine("Description placeholder");
                Thread.Sleep(2000);
                Console.Clear();
            }

            static void Help()
            {
                Console.WriteLine("If you want to get an instruction of the game");
                Console.WriteLine("Type help");
            }

            static void Game()
            {
                Display_Introduction();
                CentralChamber();
            }

            static void Display_Introduction()
            {
                Console.WriteLine("Welcome!!!! to the Excavation Game.");
                Console.WriteLine("You are an archaeologist exploring an ancient excavation site.");
                Console.WriteLine("Your mission is to find a long lost artifact of great power.");
                Console.WriteLine("Prepare yourself for an adventure filled with puzzles and mysteries!\n");
            }



            static void CentralChamber()
            {
                Console.WriteLine("You are now in Central Chamber.");

                while (true)
                {
                    Console.Write("Please enter a direction: ");
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        ChamberOfShadow();
                        break;
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        PuzzleRoom();
                        break;
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
                    {
                        Console.WriteLine("You can not go to west from here. Please try again");
                    }
                    else 
                    {
                        Console.WriteLine("Invalid answer. Please try again.");
                    }
                }

            }
            static void Library()
            {
                Console.WriteLine("You are now in Library.");

                while (true)
                {
                    Console.Write("Door East.");
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        Console.WriteLine("You can not go to north from here. Please try again");
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        ChamberOfShadow();
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
                    {
                        Console.WriteLine("You can not go to west from here. Please try again");
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
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        Console.WriteLine("You can not go to north from here. Please try again");
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        TreasureVault();
                        break; 
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
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
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        Console.WriteLine("You can not go to north from here. Please try again");
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        CentralChamber();
                        break;
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        AltarRoom();
                        break;
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
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
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        Console.WriteLine("You can not go to north from here. Please try again");
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        Console.WriteLine("You can not go to east from here. Please try again");
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
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
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "NORTH" || playerDirection == "N")
                    {
                        Console.WriteLine("You can not go to north from here. Please try again");
                    }
                    else if (playerDirection == "SOUTH" || playerDirection == "S")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                    else if (playerDirection == "EAST" || playerDirection == "E")
                    {
                        Console.WriteLine("You can not go to east from here. Please try again");
                    }
                    else if (playerDirection == "WEST" || playerDirection == "W")
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
