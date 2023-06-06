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
            Console.Clear();                                                                                                                                                                                                          
            Console.WriteLine("Instructions");
            Console.WriteLine("Enter commands to navigate between rooms and interact with the environment.");
            Console.WriteLine("Use \"north\", \"south\", \"east\" and \"west\" to move in those respective directions.");
            Console.WriteLine("Explore each room throughly to find items and solve puzzles.");
            Console.WriteLine("Collect useful items to help you progress in the game.");
            Console.WriteLine("Your ultimate goal is to discover the hidden artifact and claim it for yourself.");
            Console.WriteLine("Good Luck!!!!!");
        }
        static void CentralChamber()
        {
            Console.Clear();
            Console.WriteLine("You are now in Central Chamber.");
            Console.WriteLine("There are doors to the north and east.");
            while (true)
            {
                Console.Write(">> ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
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
            Console.Clear();
            Console.WriteLine("Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls. The air is thick with the scent of ancient parchment. Sunlight filters through stained glass windows, illuminating a large desk at the center of the room. On it lies a game for you to win.");
            Console.WriteLine("There is a puzzle for you to solve.");
            Console.Write(">> ");
            string userPuzzleAnswer = Console.ReadLine().ToUpper();

            if (userPuzzleAnswer == "SOLVE")
            {
                JumbleWord();
                if (true)

                {
                    Console.WriteLine("You have solve the puzzle");
                }
                else
                {
                    Console.WriteLine("You did solve the puzzle");
                }
            }
            else
            {
                while (true)
                {
                    Console.Write(">> ");
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
        }
        static void JumbleWord(string RandomWord)
        {
            string Word = PickWord();
            string Jum = Jumbled(Word);
            Console.Write($"{Jum} \n What is the word, you think it is: ");
            string user_Choice = Console.ReadLine();
            return RandomWord;
        }
        public static string PickWord()
        {
            Random rand = new Random();
            string[] Words = { "boy" };
            int temp = rand.Next(0, Words.Length);
            string Pick = Words[temp];
            return Pick;
        }
        public static string Jumbled(string input)
        {
            Random rand = new Random();
            char[] chars = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                int index1 = rand.Next(input.Length);
                int index2 = rand.Next(input.Length);



                char temp = chars[index1];
                chars[index1] = chars[index2];
                chars[index2] = temp;
            }
            return new string(chars);
        }
        static void PuzzleRoom()
        {
            Console.Clear();
            Console.WriteLine("You are now the puzzle room.");
            Console.WriteLine("There are doors to the east and west");
            while (true)
            {
                Console.Write("`>> ");
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
            Console.Clear();
            Console.WriteLine("You are now in the chamber of shadow.");
            Console.WriteLine("It is too dark to see");
            Console.Write(">> ");
            string userInput=Console.ReadLine().ToUpper();
            //if (inventory[1]==torch)

                switch (userInput)
                {
                    case "NORTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        CentralChamber();
                        break;
                    case "WEST":
                        Library();
                        break;
                    case "EAST":
                        AltarRoom();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
        }
        static void TreasureVault()
        {
            Console.Clear();
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
            Console.Clear();
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
        public static void Main(string[] args)
        {
            GameStart();
            string[] inventory = new string[3];
            CentralChamber();
            
        }
    }
}