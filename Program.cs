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
            Console.WriteLine("Use "north", "south", "east" and "west" to move in those respective directions.");
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
                    case "NORTH":
                        ChamberOfShadow();
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        PuzzleRoom();
                        break;
                    case "WEST":
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case "HELP":
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
            int totalPlayer = 0, totalKeeper;
            Console.WriteLine("Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls. The air is thick with the scent of ancient parchment. Sunlight filters through stained glass windows, illuminating a large desk at the center of the room. On it lies a game for you to win.");
            Console.WriteLine("There is a puzzle for you to solve in centre of the room");
            Console.WriteLine("It a drawing card game that you need to win the library keeper");
            Console.WriteLine("The rule are:");
            Console.WriteLine("The card will be draw 3 time");
            Console.WriteLine("After 3 round it will calculate the total number of your card");
            Console.Write("Would you like to start the game: ");
            string userPuzzleAnswer = Console.WriteLine().ToUpper();

            if (userPuzzleAnswer == "YES" || userPuzzleAnswer == "Y")
            {
                for (int i; i <= 3; i++)
                {
                    Random rand = new Random();
                    int player = rand.Next(1, 14);
                    int libraryKeeper = rand.Next(1, 14);
                    Console.WriteLine($"You got {player} point.");
                    Console.WriteLine($"The library keeper got {libraryKeeper} point.");


                }
            }
            else
            {
                while (true)
                {
                    Console.Write("Please enter a direction: ");
                    string userInput = Console.ReadLine().ToUpper();
                    switch (userInput)
                    {
                        case "NORTH":
                            Console.WriteLine("You can not go to south from here. Please try again");
                            break;
                        case "SOUTH":
                            Console.WriteLine("You can not go to south from here. Please try again");
                            break;
                        case "EAST":
                            ChamberOfShadow();
                            break;
                        case "WEST":
                            Console.WriteLine("You can not go to west from here. Please try again");
                            break;
                        case "HELP":
                            Help();
                            break;
                        default:
                            Console.WriteLine("Invalid answer. Please try again.");
                            break;
                    }
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
                switch (userInput)
                {
                    case "NORTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        ChamberOfShadow();
                        break;
                    case "WEST":
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case "HELP":
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
            Console.WriteLine("You are now the puzzle room.");
            Console.WriteLine("There is a door to the west");
            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "NORTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "WEST":
                        PuzzleRoom();
                        break;
                    case "HELP":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static void AltarRoom()
        {
            Console.WriteLine("You are now the puzzle room.");
            Console.WriteLine("There are doors to the east and west");
            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "NORTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        Console.WriteLine("You can not go to east from here. Please try again");
                        break;
                    case "WEST":
                        ChamberOfShadow();
                        break;
                    case "HELP":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static void Main(string[] args)
        {
            GameStart();
        }
    }
}