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
            Console.WriteLine("Use 'north', 'south', 'east' and 'west' to move in those respective directions.");
            Console.WriteLine("Use words like 'examine', 'use', 'look', 'solve' to interact with the items and environment.");
            Console.WriteLine("Explore each room throughly to find items and solve puzzles.");
            Console.WriteLine("Collect useful items to help you progress in the game.");
            Console.WriteLine("Your ultimate goal is to discover the hidden artifact and claim it for yourself.");
            Console.WriteLine("Good Luck!!!!!");
        }
        static void CentralChamber()
        {
            bool hasKey = false;
            bool pedestalActivated = false;
            bool puzzleSolved = false;
            string puzzleAnswer = "feather, eye, scarab, ankh";
            Console.Clear();
            Console.WriteLine("You are now in the Central Chamber.");
            Console.WriteLine("The central chamber is the heart of the excavation site.");
            Console.WriteLine("Ancient hieroglyphics cover the walls, depicting scenes of forgotten legends.");
            Console.WriteLine("The room is dimly lit by flickering torches, casting eerie shadows.");
            Console.WriteLine("An old stone pedestal sits in the center, as if waiting for something to be placed upon it.");
            while (true)
            {
                Console.Write("Please enter a command: ");
                string userInput = Console.ReadLine().ToUpper();
                Console.Clear();
                switch (userInput)
                {
                    case "LOOK":
                        Console.WriteLine("You see an old stone pedestal and a mysterious inscription on the wall, that needs to be solved.");
                        break;
                    case "EXAMINE PEDESTAL":
                        if (!pedestalActivated)
                        {
                            Console.WriteLine("You examine the stone pedestal and notice a small indentation that looks like it could fit a key.");
                        }
                        else
                        {
                            Console.WriteLine("You have already activated the pedestal.");
                        }
                        break;
                    case "USE KEY ON PEDESTAL":
                        if (!hasKey)
                        {
                            Console.WriteLine("You don't have a key to use on the pedestal.");
                        }
                        else if (!pedestalActivated)
                        {
                            Console.WriteLine("You use the key to activate the pedestal. It emits a faint glow.");
                            pedestalActivated = true;
                        }
                        else
                        {
                            Console.WriteLine("You have already activated the pedestal.");
                        }
                        break;
                    case "SOLVE PUZZLE":
                        if (!puzzleSolved)
                        {
                            Console.WriteLine("The wall is covered in ancient symbols and a series of levers nearby. Each symbol corresponds to a specific lever.");
                            Console.WriteLine("The symbols are: Ankh, Feather, Scarab, Eye. To unlock the puzzle,");
                            Console.WriteLine("you must decipher the correct order of symbols and pull the levers accordingly.");
                            Console.WriteLine("What is the correct order? (Enter you answer seperated by a comma ',')");
                            string userAnswer = Console.ReadLine().ToLower();
                            if (userAnswer == puzzleAnswer)
                            {
                                puzzleSolved = true;
                                Console.WriteLine("Congratulations!!! you have solved the puzzle and obtained the key.");
                                hasKey = true;
                            }
                            else
                            {
                                Console.WriteLine("The puzzle remains unsolved.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have already obtained the key.");
                        }
                        break;
                    case "NORTH":
                        if (hasKey)
                        {
                            if (pedestalActivated)
                            {
                                ChamberOfShadow();
                            }
                            else
                            {
                                Console.WriteLine("The door to the north is sealed. You need to find a key and place it on the pedestal.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The door to the north is sealed. You need to activate the pedestal first.");
                        }
                        break;
                    case "EAST":
                        PuzzleRoom();
                        break;
                    case "WEST":
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "HELP":
                        Help();
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }
        static void Library()
        {
            string puzzleAnswer = "treasure";
            Console.Clear();
            Console.WriteLine("Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls. The air is thick with the scent of ancient parchment. Sunlight filters through stained glass windows, illuminating a large desk at the center of the room. On it lies a game for you to win.");
            Console.WriteLine("There is a puzzle for you to solve.");
            Console.Write(">> ");
            string userPuzzleAnswer = Console.ReadLine().ToUpper();

            if (userPuzzleAnswer == "SOLVE")
            {
                string u = JumbleWord();
                if (u == puzzleAnswer)
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
        static string JumbleWord()
        {
            string Word = PickWord();
            string Jum = Jumbled(Word);
            Console.Write($"{Jum} \n What is the word, you think it is: ");
            string user_Choice = Console.ReadLine();
            return user_Choice;
        }
        public static string PickWord()
        {
            Random rand = new Random();
            string[] Words = { "treasure" };
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
            string[] inventory = new string[2];
            inventory[0] = "TORCH";
            Console.WriteLine("You are now in the chamber of shadow.");
            Console.WriteLine("It is too dark to see");
            Console.Write(">> ");
            string userInput = Console.ReadLine().ToUpper();
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
            if (inventory[0] == "TORCH" || inventory[1] == "TORCH" || inventory[2] == "TORCH")
            {
                if (userInput=="USE TORCH")
                {
                    Console.WriteLine("the room is lit");
                }
            }
            else
            {
                Console.WriteLine("no torch");
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