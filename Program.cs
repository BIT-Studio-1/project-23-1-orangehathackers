using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace Game
{
    internal class Program

    {
        // An array to store the inventory items
        private static string[] inventory = new string[5];

        // Variable to keep track of the number of items in the inventory
        private static int inventoryCount = 0;

        // Flags to track various game states and puzzle progress
        private static bool pedestalActivated_Central_Chamber = false;
        private static bool puzzleSolved_Central_Chamber = false;
        private static bool puzzleSolved_Puzzle_Room = false;
        private static bool puzzle_1_Solved = false;
        private static bool puzzle_2_Solved = false;
        private static bool puzzle_3_Solved = false;
        private static bool puzzle_4_Solved = false;
        private static bool puzzleSolved_Library = false;
        private static bool torchUsed_Library = false;
        private static bool torchUsed_Chamber_Of_Shadows = false;
        private static bool artifactPlaced = false;
        private static bool puzzleSolved_Chamber_Of_Shadows = false;

        private static bool secretDoorDiscovered = false;
        private static bool secretDoorUnlocked = false;


        // Strust for color to be put in text.
        struct ColorCodes 
        {
            public const string R = "\x1b[31m"; // Red denotes important items 
            public const string G = "\x1b[32m"; // Green cosmetic gimic items
            public const string B = "\x1b[34m"; // Blue used for hidden rooms and secret side quests lines
            public const string Reset = "\x1b[0m"; // At the other side of color so the res of the text remains unafected
        }


        // Display the game title
        static void GameStart()
        {
            int delay = 200;
            bool skip = false;
            string[] splash = { "========================================================================================================================",
            "",
            "  _______ _             _____                    _      ____   __   ______ _   _____                      _       ",
            " |__   __| |           / ____|                  | |    / __ \\ / _| |  ____| | |  __ \\                    | |      ",
            "    | |  | |__   ___  | (___   ___  ___ _ __ ___| |_  | |  | | |_  | |__  | | | |  | | ___  _ __ __ _  __| | ___  ",
            "    | |  | '_ \\ / _ \\  \\___ \\ / _ \\/ __| '__/ _ \\ __| | |  | |  _| |  __| | | | |  | |/ _ \\| '__/ _` |/ _` |/ _ \\ ",
            "    | |  | | | |  __/  ____) |  __/ (__| | |  __/ |_  | |__| | |   | |____| | | |__| | (_) | | | (_| | (_| | (_) |",
            "    |_|  |_| |_|\\___| |_____/ \\___|\\___|_|  \\___|\\__|  \\____/|_|   |______|_| |_____/ \\___/|_|  \\__,_|\\__,_|\\___/ ",
            "",
            "",
            "========================================================================================================================",
            "",
            "Press enter to continue: "};
            foreach (string s in splash)
            {
                if (Console.KeyAvailable)
                {
                    skip = true;
                }
                if (skip == false)
                {
                    Console.WriteLine(s);
                    Thread.Sleep(delay);
                }
                else
                {
                    Console.WriteLine(s);
                }
            }
            Console.ReadKey(intercept: true);       //if a key is pressed this line will absorb it so it doesn't interact with the readline after
            Console.ReadLine();
            Console.Clear();
            {
                string[] text = { "You are an archaeologist exploring an ancient excavation site.",
                "Your mission is to find a long-lost artifact of great power.",
                "Prepare yourself for an adventure filled with puzzles and mysteries!",
                "",
                "Press enter to continue"};
                Animate(text);
            }
            Console.ReadLine();
            Console.Clear();
        }
        // Method for instruction of the game
        static void Help(
        { 

            Console.WriteLine("Instructions");
            Console.WriteLine("Enter commands to navigate between rooms and interact with the environment.");
            Console.WriteLine("Use 'north', 'south', 'east' and 'west' to move in those respective directions.");
            Console.WriteLine("Use words like 'examine', 'use', 'look', 'solve', 'climb', 'take' to interact with the items and environment.");
            Console.WriteLine("Explore each room throughly to find items and solve puzzles.");
            Console.WriteLine("Collect useful items to help you progress in the game.");
            Console.WriteLine("Your ultimate goal is to discover the hidden artifact and claim it for yourself.");
            Console.WriteLine("Good Luck!!!!!");
        }
        // Method to add an item to the player's inventory
        static void AddToInventory(string item)
        {
            if (inventoryCount < inventory.Length)
            {
                inventory[inventoryCount] = item;
                inventoryCount++;
            }
            else
            {
                Console.WriteLine("Inventory is full! Cannot add more items.");
            }
        }
        // This method will check if the player inventory have a specific item
        static bool HasItem(string item)
        {
            for (int i = 0; i < inventoryCount; i++)
            {
                if (inventory[i] == item)
                {
                    return true;
                }
            }
            return false;
        }
        // Central Chamber is a method representing the central area of the excavation site.
        static void CentralChamber()
        {
            string puzzleAnswer = "FEATHER, EYE, SCARAB, ANKH";

            Console.Clear();
            Console.WriteLine("You are now in the Central Chamber.");
            Console.WriteLine("The central chamber is the heart of the excavation site.");
            Console.WriteLine("Ancient hieroglyphics cover the walls, depicting scenes of forgotten legends.");
            Console.WriteLine("The room is dimly lit by flickering torches, casting eerie shadows.");
            Console.WriteLine("An old stone pedestal sits in the center, as if waiting for something to be placed upon it.");

            // Infinite loop for handling player commands in the Central Chamber.
            while (true)
            {
                Console.WriteLine("Please enter a command: ");
                Console.WriteLine("");
                Console.Write("-->: ");

                string userInput = Console.ReadLine().ToUpper();


                // Handle different player commands using a switch statement.
                switch (userInput)
                {
                    case "LOOK":
                        Console.WriteLine("You see an old stone pedestal and a mysterious inscription on the wall, that needs to be solved.");
                        break;
                    case "EXAMINE PEDESTAL":
                        if (!pedestalActivated_Central_Chamber)
                        {
                            Console.WriteLine("You examine the stone pedestal and notice a small indentation that looks like it could fit a key.");
                        }
                        else
                        {
                            Console.WriteLine("You have already activated the pedestal.");
                        }
                        break;
                    case "USE KEY ON PEDESTAL":
                        if (!HasItem("Key"))
                        {
                            Console.WriteLine("You don't have a key to use on the pedestal.");
                        }
                        else if (!pedestalActivated_Central_Chamber)
                        {
                            Console.WriteLine("You use the key to activate the pedestal. It emits a faint glow.");
                            pedestalActivated_Central_Chamber = true;
                        }
                        else
                        {
                            Console.WriteLine("You have already activated the pedestal.");
                        }
                        break;
                    case "SOLVE PUZZLE":
                        while (!puzzleSolved_Central_Chamber)
                        {
                            if (!puzzleSolved_Central_Chamber)
                            {
                                Console.WriteLine("The wall is covered in ancient symbols and a series of levers nearby. Each symbol corresponds to a specific lever.");
                                Console.WriteLine("The symbols are: Ankh, Feather, Scarab, Eye. To unlock the puzzle,");
                                Console.WriteLine("you must decipher the correct order of symbols and pull the levers accordingly.");
                                Console.WriteLine("What is the correct order? (Enter your answer separated by a comma ',')");
                                Console.Write(">> ");
                                string userAnswer = Console.ReadLine().ToUpper();

                                // Allow the player to go back to the Central Chamber if they wish.
                                if (userAnswer == "BACK")
                                {
                                    CentralChamber();
                                }
                                else if (userAnswer == puzzleAnswer)
                                {
                                    puzzleSolved_Central_Chamber = true;
                                    Console.WriteLine("Congratulations!!! you have solved the puzzle and obtained the key.");
                                    AddToInventory("Key");
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
                        }
                        break;
                    case "NORTH":
                        if (HasItem("Key"))
                        {
                            if (pedestalActivated_Central_Chamber)
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
                        Console.WriteLine("You cannot go west from here. Please try again.");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You cannot go south from here. Please try again.");
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("You have the following items in your inventory:");
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid command. Please try again.");
                        break;
                }
            }
        }

        // Puzzle Room is a method representing the puzzle room in the excavation site.
        static void PuzzleRoom()
        {
            Console.Clear();
            Console.WriteLine("You are now in the puzzle room.");
            Console.WriteLine("As you enter this room, you are greeted by a series of intricate puzzles.");
            Console.WriteLine("The walls are adorned with enigmatic symbols, and the floor is marked with a pattern of tiles.");
            Console.WriteLine("A riddle is etched onto a stone tablet, challenging you to unlock the room's secrets.");

            // Define puzzle answers and riddles for the room.
            string puzzle1Answer = "Q";
            string[] riddles = {
        "I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?",
        "I have keys but no locks. I have space but no room. You can enter but can't go outside. What am I?",
        "The more you take, the more you leave behind. What am I?",
        "I can be cracked, made, told, and played. What am I?"
    };
            string[] answers = { "ECHO", "KEYBOARD", "FOOTSTEPS", "JOKE" };
            string[] userAnswers = new string[4];
            string[] symbols = { "STAR", "MOON", "SUN", "PLANET" };
            string[] reflectedSymbols = { "RATS", "NOOM", "NUS", "TENALP" };
            bool allCorrect = true;

            // Infinite loop for handling player commands in the Puzzle Room.
            while (true)
            {
                Console.Write("Please enter a command: ");

                string userInput = Console.ReadLine().ToUpper();

                // Handle different player commands using a switch statement.
                switch (userInput)
                {
                    case "SOLVE PUZZLE":
                        if (!puzzleSolved_Puzzle_Room)
                        {
                            Console.WriteLine("You will have to solve a series of 4 puzzles in order to enter the Treasure vault.");
                            Console.Clear();

                            // Puzzle 1: Missing Letter
                            Console.WriteLine("Puzzle 1: Missing Letter");
                            Console.WriteLine("You come across a series of letters on the wall, but one letter is missing.");
                            Console.WriteLine("The letters form a sequence, and you need to determine the missing letter to complete the sequence.");
                            Console.WriteLine("B, D, G, I, L, N, __, S, V");
                            Console.Write("Please enter the missing letter:");

                            // Loop for handling the user's attempts to solve Puzzle 1.
                            while (!puzzle_1_Solved)
                            {
                                string userAnswer = Console.ReadLine().ToUpper();
                                if (userAnswer == "BACK")
                                {
                                    PuzzleRoom();
                                }
                                if (userAnswer == puzzle1Answer)
                                {
                                    puzzle_1_Solved = true;
                                    Console.WriteLine("Well Done! You solved the puzzle.");
                                    Console.WriteLine("On to the next one.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("That's incorrect. Try again.");
                                }
                            }

                            // Puzzle 2: Cryptic Riddles
                            Console.Clear();
                            Console.WriteLine("Puzzle 2: Cryptic Riddles");
                            Console.WriteLine("Solve the riddles to find the words.");

                            // Check if Puzzle 2 has not been solved yet.
                            if (!puzzle_2_Solved)
                            {
                                while (true)
                                {
                                    // Present riddles to the player and get their answers.
                                    for (int i = 0; i < riddles.Length; i++)
                                    {
                                        Console.WriteLine("\nRiddle " + (i + 1) + ":");
                                        Console.WriteLine(riddles[i]);

                                        Console.Write("Enter your answer: ");
                                        userAnswers[i] = Console.ReadLine().Trim().ToUpper();
                                        if (userAnswers[i] == "BACK")
                                        {
                                            PuzzleRoom();
                                        }
                                    }

                                    // Check if all user answers are correct.
                                    for (int i = 0; i < answers.Length; i++)
                                    {
                                        if (userAnswers[i] != answers[i])
                                        {
                                            allCorrect = false;
                                        }
                                    }

                                    // If all answers are correct, mark Puzzle 2 as solved and continue.
                                    if (allCorrect)
                                    {
                                        puzzle_2_Solved = true;
                                        Console.WriteLine("\nCongratulations! You solved all the riddles!");
                                        Console.WriteLine("Two down. Two to go!");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nSome of your answers are incorrect.");
                                        Console.WriteLine("Please review the riddles and try again.");
                                    }
                                }
                            }

                            // Puzzle 3: Mirror Reflection
                            Console.Clear();
                            Console.WriteLine("Puzzle 3: Mirror Reflection");
                            Console.WriteLine("Rearrange the symbols based on their reflection in the mirror.");
                            Console.WriteLine("Rearrange the following symbols based on their reflection:");

                            // Display symbols for rearrangement.
                            for (int i = 0; i < symbols.Length; i++)
                            {
                                Console.WriteLine(symbols[i]);
                            }

                            // Loop for handling the user's attempts to solve Puzzle 3.
                            while (!puzzle_3_Solved)
                            {
                                string[] rearrangedSymbols = Console.ReadLine().ToUpper().Split(',');
                                if (rearrangedSymbols[0] == "BACK")
                                {
                                    PuzzleRoom();
                                }

                                // Check if the symbols are rearranged correctly.
                                if (rearrangedSymbols.SequenceEqual(reflectedSymbols))
                                {
                                    puzzle_3_Solved = true;
                                    Console.WriteLine("Great job! You rearranged the symbols correctly.");
                                    Console.WriteLine("Just one more puzzle to go!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The symbols are not rearranged correctly. Keep trying.");
                                }
                            }

                            // Puzzle 4: Cryptic Code
                            Console.Clear();
                            Console.WriteLine("Puzzle 4: Cryptic Code");
                            Console.WriteLine("Decipher the cryptic clues to find the code.");

                            // Clue 1
                            int clue1 = 1;
                            Console.WriteLine("\nClue 1: \"I am the beginning and the end, the first and the last. Look for my value in the Fibonacci sequence.\"");

                            // Clue 2
                            int clue2 = 16;
                            Console.WriteLine("\nClue 2: \"Add the number of sides in a hexagon to the sum of the first three prime numbers.\"");

                            // Clue 3
                            int clue3 = 38;
                            Console.WriteLine("\nClue 3: \"I am the answer to life, the universe, and everything. Subtract the square root of 16.\"");

                            // Loop for handling the user's attempts to solve Puzzle 4.
                            while (!puzzle_4_Solved)
                            {
                                Console.WriteLine("\nEnter the code:");

                                int code = Convert.ToInt32(Console.ReadLine());

                                // Check if the entered code is correct.
                                if (code == clue1 * 1000 + clue2 * 10 + clue3)
                                {
                                    Console.WriteLine("Congratulations! You've solved the cryptic code puzzle!");
                                    Console.WriteLine("All the puzzles are now solved.");
                                    puzzleSolved_Puzzle_Room = true;
                                    puzzle_4_Solved = true;
                                }
                                else
                                {
                                    Console.WriteLine("That's not the correct code. Keep deciphering or try again.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("All the puzzles are solved. You can now enter the Treasure Vault.");
                        }
                        break;
                    case "NORTH":
                        Console.WriteLine("You cannot go north from here. Please try again.");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You cannot go south from here. Please try again.");
                        break;
                    case "EAST":
                        if (puzzleSolved_Puzzle_Room)
                        {
                            TreasureVault();
                        }
                        else
                        {
                            Console.WriteLine("The door to the Treasure Vault is sealed. First solve all the puzzles to gain access.");
                        }
                        break;
                    case "WEST":
                        CentralChamber();
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("You have the following items in your inventory:");
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;
                    case "BOW":
                        BowAndArrow();
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }

        static void BowAndArrow()
        {
            Console.WriteLine("Welcome to the Bow and Arrow Game!");
            Console.WriteLine("Press Enter to shoot the arrow.");
            Console.ReadLine();

            Random random = new Random();
            int targetPosition = random.Next(1, 11); // The target position will be between 1 and 10.

            Console.WriteLine("Target is placed at position " + targetPosition);
            Console.WriteLine("Enter the position you want to shoot the arrow (1-10):");

            string input = Console.ReadLine();
            int arrowPosition;

            if (int.TryParse(input, out arrowPosition))     //this cool line is like convert to int32 but outputs a boolian so the variable does not break if something is inputted by the user wrong
            {
                if (arrowPosition == targetPosition)
                {
                    Console.WriteLine("Congratulations! You hit the target!");
                }
                else
                {
                    Console.WriteLine("Sorry, you missed the target.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number between 1 and 10.");
            }
        }


        // Library is a method representing the library area in the excavation site.
        static void Library()
        {
            string puzzleAnswerTreasure = "TREASURE HUNT";
            Console.Clear();

            string[] messages = {
                "Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls.",
                "The air is thick with the scent of ancient parchment.",
                "Sunlight filters through stained glass windows, illuminating a large desk at the center of the room.",
                "On it lies a puzzle for you to solve.",
                "On the right, you see a ladder leading into the tunnel.",
                "You have look straight into the middle, and discover a book laying on a floor."
            };
            foreach (string message in messages)
            {
                Console.WriteLine("       " + message);
                Thread.Sleep(500);
            }

            // Infinite loop for handling player commands in the Library.
            while (true)
            {
                Console.Write(">> ");
                string userInput = Console.ReadLine().ToUpper();

                // Handle different player commands using a switch statement.
                switch (userInput)
                {
                    case "NORTH":
                        Console.WriteLine("You cannot go north from here. Please try again.");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You cannot go south from here. Please try again.");
                        break;
                    case "EAST":
                        ChamberOfShadow();
                        break;
                    case "WEST":
                        Console.WriteLine("You cannot go west from here. Please try again.");
                        break;
                    case "HELP":
                        helpLibrary();
                        Console.WriteLine("Press enter to continue");
                        Thread.Sleep(100);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "SOLVE PUZZLE":
                        if (!puzzleSolved_Library)
                        {
                            Console.WriteLine("The words are 'raseture nhtu'.");
                            while (!puzzleSolved_Library)
                            {
                                Console.Write(">> ");
                                string solvePuzzle = Console.ReadLine().ToUpper();

                                // Check if the player's answer is correct.
                                if (solvePuzzle == puzzleAnswerTreasure)
                                {
                                    puzzleSolved_Library = true;
                                    Console.WriteLine("You have solved the puzzle. In the middle, it appears an old wooden chest covered with dust.");
                                    Console.WriteLine("Inside the wooden chest, you find an old book laying on the bottom.");

                                    // Check if the player already has a book.
                                    if (HasItem("Book Of Totem"))
                                    {
                                        Console.WriteLine("You have already taken a book.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The Book Of Totem has been succesfully added into your inventory.");
                                        AddToInventory("Book");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid answer. Please try again.");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have already solved the puzzle.");
                        }
                        break;
                    case "CLIMB":
                        Console.WriteLine("You have climbed the ladder. It's leading into a dark room.");
                        break;
                    case "USE TORCH":
                        if (HasItem("Torch"))
                        {
                            torchUsed_Library = true;
                            Console.WriteLine("As the beam of your torch pierced the enveloping darkness, the once concealed room came alive, revealing a mesmerizing pendant resting serenely on the table, its facets sparkling with newfound light.");
                        }
                        else
                        {
                            Console.WriteLine("The room is too dark. You can't see anything.");
                        }
                        break;
                    case "TAKE PENDANT":
                        if (torchUsed_Library)
                        {
                            if (HasItem("Pendant"))
                            {
                                Console.WriteLine("The pendant has been successfully added to the inventory");
                            }
                            else
                            {
                                Console.WriteLine("You have picked up a pendant and go back to the library.");
                                AddToInventory("Pendant");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The room is too dark. Maybe you have something to light up the room.");
                        }
                        break;
                    case "USE ORB";
                        if (HasItem("Oracle's Guidance Orb"))
                        {
                            string[] orbMessage = {
                                "In a forgotten land, an excavation team delved into ancient ruins, unearthing cryptic texts.",
                                "As players, they deciphered enigmatic riddles and dodged traps, revealing the secrets of a long-lost civilization.",
                                "The game sparked an archeological renaissance, igniting passion for history and unraveling mysteries buried in the sands of time."
                            }

                            foreach (string orbMessages in orbMessage)
                            {
                                Console.WriteLine("       " + orbMessages);
                                Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You doesn't have an orb in your inventory.");
                        }
                    case "TAKE BOOK":
                        if (torchUsed_Library)
                        {
                            Console.WriteLine("The book has been successfully added to the inventory.");
                            AddToInventory("Book");
                        }
                        else if (HasItem("Book"))
                        {
                            Console.WriteLine("You have already taken a book");
                        }
                        else
                        {
                            Console.WriteLine("You need to use a torch to investigate the book shelf");
                        }
                        break;
                    case "USE BOOK":
                        if (HasItem("Book"))
                        {
                            string[] useBook = {
                                    "In the heart of a scorching desert, an excavation site emerged.",
                                    "Digging through layers of time, the team unearthed remnants of an ancient civilization.",
                                    "Fragments of pottery whispered tales of forgotten traditions, while weathered hieroglyphs held untold secrets.",
                                    "Among the dust and sand, they discovered a long-buried temple, revealing the lost splendor of a civilization lost to the ages.",
                                    "The archaeologists marveled at their discovery, knowing that they had become custodians of a timeless legacy, ready to share its wonders with the world."
                            };
                            foreach (string useBooks in useBook)
                            {
                                Console.WriteLine("       " + useBooks);
                                System.Threading.Thread.Sleep(500);
                            }
                        }
                        else
                        {
                            Console.WriteLine("You havn't pick up the book yet");
                        }
                        break;
                    case "TAKE BOTTLE":
                        if (torchUsed_Library)
                        {
                            if (HasItem("Bottle"))
                            {
                                Console.WriteLine("You have already taken the bottle");
                            }
                            else
                            {
                                Console.WriteLine("You have picked up a bottle with a spray head fill of water.");
                                AddToInventory("Bottle");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The room is too dark. You can't see anything.");
                        }
                        break;
                    case "USE BOTTLE":
                        if (HasItem("bottle"))
                        {
                            Console.WriteLine("You spray the bottle and the water turns into confetti");
                        } else
                        {
                            Console.WriteLine("you do not yet have the bottle");
                        }
                        break;
                    case "INVENTORY":
                        Console.WriteLine("You have the following items in your inventory:");
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;

                    case "STORYLINE":
                        foreach (string message in messages)
                        {
                            Console.WriteLine("       " + message);
                            System.Threading.Thread.Sleep(500);
                        }
                        break;
                    case "GAME":
                        libraryGame();
                        break;

                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static bool libraryGame() //RPS game in library part
        {
            int playerScore = 0;
            int libraryKeeperScore = 0;
            Random rand = new Random();
            char[] select = { 'R', 'P', 'S' };
            for (int i = 0; i < 3; i++)
            {
                int index = rand.Next(0, 3);
                char libraryKeeperChoice = select[index];
                Console.Write("\nPlease enter Rock, Paper, Scissor by pressing 'R', 'P', 'S':");
                char playerChoice = Convert.ToChar(Console.ReadLine().ToUpper());
                while (playerChoice != 'R' && playerChoice != 'P' && playerChoice != 'S')
                {
                    Console.Write("Invalid Selection. Please enter your answer again: ");
                    playerChoice = Convert.ToChar(Console.ReadLine().ToUpper());
                }
                Console.WriteLine($"Library Keeper chose: {libraryKeeperChoice}");
                Console.WriteLine($"Player Chose: {playerChoice}");
                if (libraryKeeperChoice == playerChoice)
                {
                    Console.WriteLine("The game is a draw.");
                }
                else if (playerChoice == 'R' && libraryKeeperChoice == 'S' || playerChoice == 'P' && libraryKeeperChoice == 'R' || playerChoice == 'S' && libraryKeeperChoice == 'P')
                {
                    Console.WriteLine("Player Wins");
                    playerScore++;
                }
                else
                {
                    Console.WriteLine("Library Keeper Wins.");
                    libraryKeeperScore++;
                }
            }
            Console.WriteLine($"\nPlayer Score: {playerScore}");
            Console.WriteLine($"Library Keeper Score: {libraryKeeperScore}");
            Console.ReadLine();
            if (!HasItem("Oracle's Guidance Orb"))
            {
                if (playerScore > libraryKeeperScore)
                {
                    Console.WriteLine("An Oracle's Guidance Orb has been add into your inventory.");
                    AddToInventory("Oracle's Guidance Orb");
                }
                else if (libraryKeeperScore > playerScore)
                {
                    Console.WriteLine("You have lose to the library keep");
                }
                else
                {
                    Console.WriteLine("What a luck. You and the library keeper didn't score any point.");
                }
            }
            else
            {
                Console.WriteLine("You have already obtain an orb in your inventory.");
            }
        }
        // This is all the helpful command in library room only.
        static void helpLibrary()
        {
            Console.WriteLine("This is all the helpful command in library room");
            Console.WriteLine("You can type 'GAME' to win more treasure.");
            Console.WriteLine($"{ColorCodes.R}- North{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- South{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- East{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- West{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Solve Puzzle{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Climb{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Use Torch{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Take Pendant{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Take Book{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Use Book{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Take Bottle{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Use Bottle{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Inventory{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- Help{ColorCodes.Reset}");
            Console.WriteLine($"{ColorCodes.R}- StoryLine{ColorCodes.Reset}");
        }
        // ChamberOfShadow is a method representing the chamber of shadow area in the excavation site.
        static void ChamberOfShadow()
        {
            Console.Clear();

            string[] roomDesc = { "You are now in the chamber of shadow.",
                                  "As you cautiously step into the Chamber of Shadows, the air grows heavy and oppressive.",
                                  $"Dim, flickering lights barely illuminate the {ColorCodes.B}obscure corners{ColorCodes.Reset} of the room, casting eerie shadows that seem to dance and writhe along the walls.",
                                  "The darkness shrouds the chamber, leaving much to the imagination and evoking an unsettling sense of the unknown.",
                                  " ",
                                  $"Please enter {ColorCodes.B}Help{ColorCodes.Reset} for list of commands to be used in the Chamber Of Shadows."
                                };
            string[] dimLightMessage = { "It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room." };
            string[] secretDoorMessage = { $"There appears to be a {ColorCodes.B}hidden door{ColorCodes.Reset}, but it remains concealed from your sight. Perhaps you need to find a way to reveal it." };
            string[] invalidAnswer = { "Invalid Answer.Please try again." };

            // Call to Animate method to display the room description
            Animate(roomDesc);

            string userAnswer;

            string puzzleAnswer = "OWL";

            // Infinite loop for handling player commands
            while (true)
            {

                Console.Write("\nPlease enter a command: ");

                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "LOOK":
                        if (!torchUsed_Chamber_Of_Shadows)
                        {
                            Animate(dimLightMessage);
                        }
                        else
                        {
                            string[] text = { $"In the far corner, stands a {ColorCodes.B}locked cabinet{ColorCodes.Reset}, its contents hidden from prying eyes.",
                                              "Whispers of untold treasures or crucial clues linger in the air, enticing your curiosity.",
                                              $"In the center of the room, an ancient and {ColorCodes.R}mysterious painting{ColorCodes.Reset} hangs on the wall, its colors faded but its details hauntingly vivid."
                                            };
                            Animate(text);
                        }
                        break;
                    case "USE TORCH":
                        if (HasItem("Torch"))
                        {
                            string[] text = { "As the player ignites the torch,",
                                              $"the flickering flames cast dancing shadows that begin to reveal the {ColorCodes.B}hidden details{ColorCodes.Reset} of the room, shrouded in darkness no more."
                                            };
                            Animate(text);
                            torchUsed_Chamber_Of_Shadows = true;
                        }
                        else
                        {
                            string[] text = { "You do not have the torch to light the room." };
                            Animate(text);
                        }
                        break;
                    case "USE KEY ON CABINET":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (HasItem("Key"))
                            {

                                string[] text = { $"In the heart of the cabinet, an {ColorCodes.R}enigmatic mechanism{ColorCodes.Reset} catches your attention, its intricate design hinting at a greater purpose.",
                                                  $"A small slot within the mechanism awaits the {ColorCodes.R}placement of a mysterious artifact{ColorCodes.Reset}, teasing its significance.",
                                                  $"Beyond this intricate contraption lies a {ColorCodes.B}concealed door{ColorCodes.Reset}, promising a path to the unknown."
                                                };
                                Animate(text);

                            }
                            else
                            {
                                string[] text = { $"You don't have the {ColorCodes.R}key{ColorCodes.Reset} to unlock the chest." };
                                Animate(text);
                            }
                        }
                        else
                        {

                            Animate(dimLightMessage);

                        }
                        break;
                    case "EXAMINE CABINET":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            string[] text = { "The cabinet stands tall and imposing against the chamber's wall,",
                                              $"its surface adorned with intricate carvings, hinting at the {ColorCodes.B}mysteries concealed within{ColorCodes.Reset}."
                                            };
                            Animate(text);
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "PLACE ARTIFACT ON MECHANISM":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (HasItem("Artifact"))
                            {
                                artifactPlaced = true;
                                string[] text = { "As the artifact is carefully placed on the mechanism,",
                                                  $"{ColorCodes.B}the door to the far EAST of the chamber{ColorCodes.Reset} begins to shimmer with an ethereal glow, {ColorCodes.B}revealing a doorway{ColorCodes.Reset} to the final room.",
                                                  "The door itself is made of ancient, weathered wood, adorned with mysterious symbols and engravings that seem to shift and rearrange as if alive.",
                                                  $"To {ColorCodes.B}unlock the door{ColorCodes.Reset} and gain access to the final room, a {ColorCodes.B}complex puzzle{ColorCodes.Reset} awaits the player."
                                                };
                                Animate(text);
                            }
                            else
                            {
                                string[] text = { $"You do not have the {ColorCodes.B}artifact{ColorCodes.Reset} to place on the mechanism." };
                                Animate(text);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "SOLVE PUZZLE":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (artifactPlaced)
                            {
                                if (!puzzleSolved_Chamber_Of_Shadows)
                                {
                                    {
                                        string[] text = { $"{ColorCodes.R}The Tome of Forgotten Knowledge\" holds the key to unlocking the door to the final room{ColorCodes.Reset}.",
                                                      "PUZZLE:",
                                                      "Of wisdom's embrace, seek the guardian's gaze,",
                                                      "A scholar's delight, a learned mind's blaze.",
                                                      "Within the pages marked by timeless lore,",
                                                      "Find the symbol that opens the door."
                                                    };
                                        Animate(text);
                                    }

                                    while (!puzzleSolved_Chamber_Of_Shadows)
                                    {
                                        userAnswer = Console.ReadLine().ToUpper();
                                        if (userAnswer == puzzleAnswer)
                                        {
                                            puzzleSolved_Chamber_Of_Shadows = true;
                                            string[] text = { "Behold! The once impenetrable barrier has yielded to your unwavering determination,",
                                                              "as the majestic door now stands ajar, beckoning you to enter the realm of finality."
                                                            };
                                            Animate(text);
                                        }
                                        else if (userAnswer == "USE BOOK")
                                        {
                                            if (HasItem("Book"))
                                            {
                                                string[] text = { "In the realm of twilight's embrace, a creature of feathered grace dwells,",
                                                                   "casting its mystic aura upon the land.",
                                                                   $"Embrace the essence of this {ColorCodes.B}nocturnal sentinel{ColorCodes.Reset} to illuminate the path towards the answer you seek."
                                                                 };
                                                Animate(text);
                                            }
                                            else
                                            {
                                                string[] text = { "Within the depths of my vast knowledge,",
                                                                   $"the {ColorCodes.R}book{ColorCodes.Reset} that contains the sought-after {ColorCodes.B}hint{ColorCodes.Reset} eludes my grasp,",
                                                                   "leaving me unable to provide you with its wisdom."
                                                                 };
                                                Animate(text);
                                            }
                                        }
                                        else
                                        {
                                            Animate(invalidAnswer);
                                        }
                                    }
                                }
                                else
                                {
                                    string[] text = { "The puzzle is already solved." };
                                    Animate(text);
                                }

                            }
                            else
                            {
                                string[] text = { $"Activate the {ColorCodes.B}mechanism{ColorCodes.Reset} to access the puzzle." };
                                Animate(text);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "NORTH":
                        {
                            string[] text = { "You can not go to north from here. Please try again" };
                            Animate(text);
                        }
                        break;
                    case "SOUTH":
                        CentralChamber();
                        break;
                    case "EAST":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (puzzleSolved_Chamber_Of_Shadows)
                            {
                                AltarRoom();
                            }
                            else
                            {
                                string[] text = { "The access to the door is locked. You cannot go further." };
                                Animate(text);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "WEST":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            Library();
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "STORYLINE":
                        Animate(roomDesc);
                        break; 
                    case "EXAMINE PAINTING":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (!secretDoorDiscovered)
                            {
                                string[] text = { "As you closely examine the ancient painting on the wall, you notice a faint outline around it.",
                                                    $"With a gentle push, the painting slides aside, revealing a {ColorCodes.B}hidden door{ColorCodes.Reset} behind it!"

                                                  };
                                Animate(text);
                                secretDoorDiscovered = true;
                            }
                            else
                            {
                                string[] text = { "You have already discovered the secret door." };
                                Animate(text);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;

                    case "EXAMINE SECRET DOOR":
                        if (torchUsed_Chamber_Of_Shadows)

                        {
                            if (secretDoorDiscovered)
                            {
                                if (!secretDoorUnlocked)
                                {
                                    {
                                        string[] text = { "You approach the secret door and run your fingers along its intricate engravings.",
                                                        $"The engravings seem to depict a pattern of glowing symbols, a {ColorCodes.B}memory game{ColorCodes.Reset} to unlock the door.",
                                                        "Do you dare to challenge the ancient memory puzzle? (Y/N)"
                                                      };
                                        Animate(text);
                                    }
                                    char input = Convert.ToChar(Console.ReadLine().ToUpper());
                                    while (input != 'Y' && input != 'N')
                                    {
                                        Console.Write("Invalid Input. You can only type (Y/N). Please enter again: ");
                                        input = Convert.ToChar(Console.ReadLine().ToUpper());
                                    }
                                    if (input == 'Y')
                                    {
                                        secretDoorUnlocked = MemoryGamePuzzle();
                                    }
                                    else
                                    {
                                       string[] text = { "You decide to step back from the mysterious memory puzzle for now." };
                                       Animate(text);
                                    }
                                }
                                else
                                {
                                    string[] text = { "The secret door has already been unlocked." };
                                    Animate(text);
                                }
                            }
                            else
                            {
                                Animate(secretDoorMessage);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "ENTER SECRET ROOM":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (secretDoorDiscovered)
                            {
                                if (secretDoorUnlocked)
                                {
                                    AlternateEnding();
                                }
                                else
                                {
                                    string[] text = { $"As you approach the hidden door, you find it {ColorCodes.B}securely locked{ColorCodes.Reset},",
                                                        $" its ancient mechanism awaiting the touch of a worthy hand to {ColorCodes.B}unlock its mysteries{ColorCodes.Reset}." };
                                    Animate(text);
                                }
                            }
                            else
                            {
                                Animate(secretDoorMessage);
                            }
                        }
                        else
                        {
                            Animate(dimLightMessage);
                        }
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "INVENTORY":
                        {
                            string[] text = { "You have the following items in your inventory:" };
                            Animate(text);
                        }
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;
                    default:
                        Animate(invalidAnswer);
                        break;
                }
            }
        }
        // TreasureVault is a method representing the treasure vault area in the excavation site.
        static void TreasureVault()
        {
            Console.Clear();
            string[] messages = {
                "You have entered the Treasure Vault.",
                "The Treasure Vault is a vast chamber filled with glittering treasures and ancient artifacts.",
                "The room is bathed in a soft golden light, illuminating the riches that surround you.",
                "You notice a gentle flickering in the corner of your eye, hinting at something hidden within the shadows.",
                "As you explore further, you spot an enchanting crystal radiating a soft blue light, captivating your attention.",
                "Nearby, there is a pedestal with a lever and a locked chest, intriguing you with their mysterious aura.",
                "You also have a vague sense that there might be something else of interest waiting to be discovered in this room.",
            };

            foreach (string message in messages)
            {
                Console.WriteLine("       " + message); 
                System.Threading.Thread.Sleep(500); 
            }

            while (true)
            {
                Console.Write("       Please enter a command: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "LOOK":
                        
                        Console.WriteLine("       The vault shimmers with various treasures - precious gems, golden artifacts, and ancient relics.");
                        Console.WriteLine("       A pedestal with a lever and a secured chest piques your curiosity.");
                        Console.WriteLine("       Amidst these riches, a mysterious orb, an enigmatic amulet, a peculiar hourglass, and a radiant crystal catch your attention.");
                        break;
                    case "EXAMINE CHEST":
                        Console.WriteLine("       The chest is forged from resilient iron, its secrets guarded by a heavy lock. It eagerly awaits a key.");
                        break;
                    case "USE KEY ON CHEST":
                        if (HasItem("Key"))
                        {
                            Console.WriteLine("       With the key, you release the chest's long-held secrets. Within, you find a pulsating artifact, ancient and powerful.");
                            Console.WriteLine("       You're now the guardian of this artifact.");
                            AddToInventory("Artifact");
                        }
                        else
                        {
                            Console.WriteLine("       Alas, without a key, the chest's secrets remain beyond your reach.");
                        }
                        break;
                    case "EXAMINE PEDESTAL":
                        Console.WriteLine("       The pedestal, solid and silent, holds a lever begging to be pulled.");
                        break;
                    case "PULL LEVER":
                        Console.WriteLine("       With a swift movement, you pull the lever. A subtle tremor sweeps the room as the crystal's glow intensifies.");
                        break;
                    case "EXAMINE CRYSTAL":
                        Console.WriteLine("       This enchanting crystal is more than mere decoration - it's a beacon of power, an ancient artifact pulsating with magical energy.");
                        break;
                    case "EXAMINE FLICKERING":
                        if (HasItem("Torch"))
                        {
                            Console.WriteLine("       You have already taken the torch.");
                        }
                        else
                        {
                            Console.WriteLine("       You observe a hint of warmth in the shadows, as if a flickering light awaits to be revealed.");
                            Console.WriteLine("       The allure of the hidden torch grows stronger, urging you to uncover its secrets.");
                        }
                        break;
                    case "TAKE TORCH":
                        if (HasItem("Torch"))
                        {
                            Console.WriteLine("       You have already taken the torch.");
                        }
                        else
                        {
                            Console.WriteLine("       Driven by an unexplained impulse, you reach into the shadows and grasp the enigmatic torch.");
                            Console.WriteLine("       You add the torch to your inventory, eager to discover its purpose.");
                            AddToInventory("Torch");
                        }
                        break;
                    case "NORTH":
                        Console.WriteLine("       You can not go to north from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("       You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        Console.WriteLine("       You can not go to east from here. Please try again");
                        break;
                    case "WEST":
                        PuzzleRoom();
                        break;
                    case "TAKE MYSTIC ORB":
                        if (HasItem("Mystic Orb"))
                        {
                            Console.WriteLine("       You have already taken the Mystic Orb.");
                        }
                        else
                        {
                            Console.WriteLine("       You take the Mystic Orb and add it to your inventory.");
                            AddToInventory("Mystic Orb");
                        }
                        break;

                    case "USE MYSTIC ORB":
                        if (HasItem("Mystic Orb"))
                        {
                            Console.WriteLine("       You hold the Mystic Orb in your hands. The orb emits a strange humming sound, and mystical runes appear on the walls of the vault.");
                        }
                        else
                        {
                            Console.WriteLine("       You don't have the Mystic Orb in your inventory.");
                        }
                        break;

                    case "EXAMINE MYSTIC ORB":
                        Console.WriteLine("       The orb appears to be from another world, filled with swirling energies. Its presence feels calming yet energetic, like the ebb and flow of an ethereal tide.");
                        break;

                    case "TAKE ENCHANTED AMULET":
                        if (HasItem("Enchanted Amulet"))
                        {
                            Console.WriteLine("       You have already taken the Enchanted Amulet.");
                        }
                        else
                        {
                            Console.WriteLine("       You take the Enchanted Amulet and add it to your inventory.");
                            AddToInventory("Enchanted Amulet");
                        }
                        break;

                    case "USE ENCHANTED AMULET":
                        if (HasItem("Enchanted Amulet"))
                        {
                            Console.WriteLine("       You hold the Enchanted Amulet. It glows with a gentle light, and you feel a wave of tranquility wash over you.");
                        }
                        else
                        {
                            Console.WriteLine("       You don't have the Enchanted Amulet in your inventory.");
                        }
                        break;

                    case "EXAMINE ENCHANTED AMULET":
                        Console.WriteLine("       An ancient aura surrounds the amulet. It bears the mark of forgotten craftsmen, its enchantment radiating a soothing light that beckons the heart.");
                        break;

                    case "TAKE CHRONO HOURGLASS":
                        if (HasItem("Chrono Hourglass"))
                        {
                            Console.WriteLine("       You have already taken the Chrono Hourglass.");
                        }
                        else
                        {
                            Console.WriteLine("       You take the Chrono Hourglass and add it to your inventory.");
                            AddToInventory("Chrono Hourglass");
                        }
                        break;

                    case "USE CHRONO HOURGLASS":
                        if (HasItem("Chrono Hourglass"))
                        {
                            Console.WriteLine("       You flip the Chrono Hourglass. The sands within it move strangely, seeming to flow in slow motion. You feel as though time itself is bending around you.");
                        }
                        else
                        {
                            Console.WriteLine("       You don't have the Chrono Hourglass in your inventory.");
                        }
                        break;

                    case "EXAMINE CHRONO HOURGLASS":
                        Console.WriteLine("       The hourglass holds your gaze with its languid rhythm. Each grain of sand feels like a stolen moment, the glass vessel a gateway to a realm beyond time.");
                        break;

                    case "TAKE LUMINOUS CRYSTAL":
                        if (HasItem("Luminous Crystal"))
                        {
                            Console.WriteLine("       You have already taken the Luminous Crystal.");
                        }
                        else
                        {
                            Console.WriteLine("       You take the Luminous Crystal and add it to your inventory.");
                            AddToInventory("Luminous Crystal");
                        }
                        break;

                    case "EXAMINE LUMINOUS CRYSTAL":
                        Console.WriteLine("       The crystal's radiant glow engulfs your senses. Its luminescence illuminates hidden corners of the vault, as if yearning to reveal untold treasures.");
                        break;

                    case "USE LUMINOUS CRYSTAL":
                        if (HasItem("Luminous Crystal"))
                        {
                            Console.WriteLine("       You hold the Luminous Crystal aloft. A brilliant light fills the room, revealing glittering treasures in every corner.");
                        }
                        else
                        {
                            Console.WriteLine("       You don't have the Luminous Crystal in your inventory.");
                        }
                        break;
                    case "STORYLINE":
                        Console.Clear();
                        foreach (string message in messages)
                        {
                            Console.WriteLine("       " + message);
                            System.Threading.Thread.Sleep(500);
                        }
                        break;
                    case "HELP":
                        Help();
                        break;
                    case "INVENTORY":
                        Console.WriteLine("       You have the following items in your inventory:");
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("       Invalid answer. Please try again.");
                        break;
                }
            }
        }
        //Equation Method
        static bool EquationGame()
        {
            // Generate a random math problem
            bool playAgain = true;
            // Create a Random object to generate random numbers.
            Random random = new Random();
            while (playAgain)
            {
                // Generate random numbers for the math problem.
                int num1 = random.Next(50, 250);
                int num2 = random.Next(-250, -50);
                char[] operatorIndex = {'+', '-', '/', '*'};
                // Randomly choose a math operator from the array.
                char op = operatorIndex[random.Next(operatorIndex.Length)];
                int correctAnswer;
                if (op == '+')
                {
                    correctAnswer = num1 + num2;
                }
                else if (op == '-')
                {
                    correctAnswer = num1 - num2;
                }
                else if (op == '/')
                {
                    correctAnswer = num1 / num2;
                }
                else
                {
                    correctAnswer = num1 * num2;
                }
                

                Console.WriteLine("Please answer the following math question: \n");
                Console.Write($"{num1} {op} {num2} = ");

                // Get the user's answer and check if it's a valid number.
                int Answer;
                if (int.TryParse(Console.ReadLine(), out Answer))
                {
                    if (Answer == correctAnswer)
                    {
                        Console.WriteLine("\nYour answer is correct !");
                        Console.WriteLine("Congualution! You've already sovled the equation ! ! !\n");
                        // End the current round and return true to play again.
                        return true;
                    }
                    else
                    {
                        // User's answer is wrong.
                        Console.WriteLine($"\nWrong! The correct answer is : [{correctAnswer}].");
                        Console.Write("Press any key to continue: ");
                        string userInput = Console.ReadLine();
                        playAgain = (userInput.ToLower() == "");
                        Console.Clear();
                        
                    }
                }

                else
                {
                    Console.WriteLine("Invalid answer. Please enter a valid number.");
                }

                
            }
            Console.WriteLine("Congualution! You've already sovled the equation ! ! !");
            
            return playAgain;
        }
                // Check if the answer is correct
                if (guess == answer)
                {
                    Console.WriteLine("Congratulations! You've solved the puzzle!");
                    return true;
                }

                else
                {
                    Console.WriteLine($"Sorry, your answer: {guess} is incorrect. \nThe correct answer is {answer}");
                    Console.WriteLine(" ");
                    Console.WriteLine("Would you like to try again? Press y for yes and n for no\n");
                    string tryAgain = Console.ReadLine().ToLower();
                    if(tryAgain == "y")
                    {
                        Console.Clear();
                        continue;
                    }
                    
                    else
                    {
                        return false;
                    }
                }
            }
        }
        //Altar Room Method
        static void AltarRoom()
        {
            Console.Clear();
            string[] messages = {"You come across a door and on it is an equations", "seems as if you must answer it to open the door", "There are doors to the east and west\n"};
            foreach(string message in messages)
            {
                Console.WriteLine("" + message);
                Thread.Sleep(1000);
            }
            bool gotCorrect = EquationGame();
            int count = 0;
                string[] storyLine = { "You are now in the Altar room.", "You look around the decaying room and see old run down table in the middle of the room", "The table has small indents the shape of different items almost as if you are mean to place them in there\n" };
                if (gotCorrect && count == 0)
                {
                count++;
                    foreach (string storylinetext in storyLine)
                    {
                        Console.WriteLine("" + storylinetext);
                        Thread.Sleep(1000);
                    }
                }
            while (true)
            {
                Console.WriteLine("Please enter an action: ");
                Console.Write("---> ");
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "BACK")
                {
                    return;
                }
                switch (userInput)
                {
                    case "STORYLINE":
                        {
                            Console.Clear();
                            foreach (string storylinetext in storyLine)
                            {
                                Console.WriteLine("" + storylinetext);
                                Thread.Sleep(1000);
                            }
                        }
                        break;
                    case "PLACE":
                        if (gotCorrect)
                        {
                            Console.WriteLine("You put your items in the indents on the table");
                            if (Array.Exists(inventory, element => element == "Artifact") && Array.Exists(inventory, element => element == "Key"))
                            {
                                Console.WriteLine("it seems as if you don't have all the items to go on the table.");
                            }
                            else
                            {
                                Console.WriteLine("The table starts to shake");
                                Thread.Sleep(1000);
                                Console.WriteLine("All of a sudden the wall behind you starts to open up");
                                Console.WriteLine("Among the gleaming heap of treasure lies a magnificent artifact,");
                                Console.WriteLine("adorned with intricate carvings and shimmering gemstones,");
                                Console.WriteLine("exuding an aura of mystery and ancient power.");
                                Console.WriteLine("You will never have to work another day in your life");
                                Console.WriteLine("Congratulation on completing the game!!!!");
                            }
                        }
                        break;
                    case "NORTH":
                        Console.WriteLine("You can not go to north from here. Please try again");
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
                    case "INVENTORY":
                        Console.WriteLine("You have the following items in your inventory:");
                        for (int i = 0; i < inventoryCount; i++)
                        {
                            Console.WriteLine(inventory[i]);
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }

        // Method to handle the memory game puzzle
        static bool MemoryGamePuzzle()
        {
            {
                string[] text = { "The memory game begins......\n" };
                Animate(text);
            }
            Random rand = new Random();
            int[] number = new int[7];
            int[] userGuess = new int[7];

            // Generate random numbers for the memory game
            for (int i = 0;i<number.Length;i++)
            {
                number[i] = rand.Next(10,100);
            }
            Console.WriteLine("\n");
            // Display the numbers to the player
            for (int i = 0; i < number.Length; i++)
            {
                Console.WriteLine($"{number[i]} ");
            }
            Thread.Sleep(3000);
            Console.Clear();
            {
                string[] text = { $"Enter the sequence of numbers in {ColorCodes.B}the order{ColorCodes.Reset} that it was displayed." };
                Animate(text);
            }
            // Get user input for the memory game
            for (int i = 0; i < userGuess.Length; i++)
            {
               // Logic to check that user enters a valid number
                while (!int.TryParse(Console.ReadLine(), out userGuess[i]))
                {
                    string[] text = { "Invalid input. Please enter a number." };
                    Animate(text);
                }
            }

            // Check if the user's guess matches the generated numbers
            for (int i = 0; i < userGuess.Length; i++)
            {
                if (userGuess[i] != number[i])
                {
                    {
                        string[] text = { "Unfortunately, your memory fails you as the numbers blur together.",
                                       "The hidden door remains locked, concealing its secrets for now."
                                     };
                        Animate(text);
                    }
                    return false;
                }
            }
            {
                string[] text = { "Congratulations! You successfully unlocked the hidden door." };
                Animate(text);
            }
            return true;
        }

        //Method to handle the alternate ending of the game
        static void AlternateEnding()
        {
            string[] text = { "You step through the secret door and find yourself in the Chamber of Enlightenment.",
                              "Before you lies a radiant crystal orb, glowing with ancient wisdom.",
                              " ",
                              "You reach out and touch the crystal orb, and a flood of knowledge fills your mind.",
                              "The secrets of the universe unfold before you, and you become a beacon of enlightenment.",
                              "You return to the world outside, forever changed by the wisdom you've gained."
                            };
            Animate(text);

            // ASCII art to mark the end of the game in the secret room
            Console.WriteLine(          @"
               ____  _            _             _____            __ _ _
              / __ \| |          | |           |  __ \          / _(_) |
             | |  | | |_   _  ___| |_ ___ _ __ | |  | | _____  _| |_ _| | ___
             | |  | | | | | |/ _ \ __/ _ \ '_ \| |  | |/ _ \ \/ /  _| | |/ _ \
             | |__| | | |_| |  __/ ||  __/ | | | |__| |  __/>  <| | | | |  __/
              \____/|_|\__,_|\___|\__\___|_| |_|_____/ \___/_/\_\_| |_|_|\___|
            ");

            // End the game here
            Environment.Exit(0);
        }



        // Method housing common input commands that are used throughout the code's switches
        static void CondencedHelp(string input, string room)
        {
            // Switch-case for processing user's input
            switch (input)
            {
                // Case for "NORTH" with if-else statements to distinguish which room the user is currently in
                case "NORTH":
                    if (room == "CentralChamber") // Checking if user is in CentralChamber
                    {
                        if (HasItem("Key")) // If user has the Key item
                        {
                            if (pedestalActivated_Central_Chamber) // If the pedestal in CentralChamber is activated
                            {
                                ChamberOfShadow(); // Move user to ChamberOfShadow
                            }
                            else
                            {
                                // Notify user about the need to place the key on the pedestal
                                Console.WriteLine("       The door to the north is sealed. You need to find a key and place it on the pedestal.");
                            }
                        }
                        else
                        {
                            // Notify user about the need to activate the pedestal
                            Console.WriteLine("       The door to the north is sealed. You need to activate the pedestal first.");
                        }
                    }
                    else
                    {
                        // If user is not in CentralChamber, going north is not possible
                        Console.WriteLine("       You can not go to north from here. Please try again");
                    }
                    break;

                // Case for "EAST" with if-else statements to distinguish what room the user is currently in
                case "EAST":
                    if (room == "CentralChamber") // If user is in CentralChamber, they move east to PuzzleRoom
                    {
                        PuzzleRoom();
                    }
                    else if (room == "PuzzleRoom") // If user is in PuzzleRoom
                    {
                        if (puzzleSolved_Puzzle_Room) // If puzzle in PuzzleRoom is solved
                        {
                            TreasureVault(); // Move user to TreasureVault
                        }
                        else
                        {
                            // Notify user about the need to solve the puzzle to gain access to the Treasure Vault
                            Console.WriteLine("       The door to the Treasure Vault is sealed. First solve all the puzzles to gain access.");
                        }
                    }
                    else if (room == "library") // If user is in Library, they move east to ChamberOfShadow
                    {
                        ChamberOfShadow();
                    }
                    else if (room == "ChamberOfShadow") // If user is in ChamberOfShadow
                    {
                        if (torchUsed_Chamber_Of_Shadows) // If torch is used in Chamber of Shadows
                        {
                            if (puzzleSolved_Chamber_Of_Shadows) // If puzzle in Chamber of Shadows is solved
                            {
                                AltarRoom(); // Move user to AltarRoom
                            }
                            else
                            {
                                // Notify user about the locked door
                                Console.WriteLine("       The access to the door is locked. You cannot go further.");
                            }
                        }
                        else
                        {
                            // Notify user about the need for light in the room
                            Console.WriteLine("       It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                    }
                    else
                    {
                        // If user is not in any of these rooms, going east is not possible
                        Console.WriteLine("       You can not go to east from here. Please try again");
                    }
                    break;

                // Case for "WEST" with if-else statements to distinguish what room the user is currently in
                case "WEST":
                    if (room == "PuzzleRoom") // If user is in PuzzleRoom, they move west to CentralChamber
                    {
                        CentralChamber();
                    }
                    else if (room == "ChamberOfShadow") // If user is in ChamberOfShadow
                    {
                        if (torchUsed_Chamber_Of_Shadows) // If torch is used in Chamber of Shadows
                        {
                            Library(); // Move user to Library
                        }
                        else
                        {
                            // Notify user about the need for light in the room
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                    }
                    else if (room == "TreasureVault") // If user is in TreasureVault, they move west to PuzzleRoom
                    {
                        PuzzleRoom();
                    }
                    else if (room == "AltarRoom") // If user is in AltarRoom, they move west to ChamberOfShadow
                    {
                        ChamberOfShadow();
                    }
                    else
                    {
                        // If user is not in any of these rooms, going west is not possible
                        Console.WriteLine("       You can not go to west from here. Please try again");
                    }
                    break;

                // Case for "SOUTH" with if-else statements to distinguish what room the user is currently in
                case "SOUTH":
                    if (room == "ChamberOfShadow") // If user is in ChamberOfShadow, they move south to CentralChamber
                    {
                        CentralChamber();
                    }
                    else
                    {
                        // If user is not in ChamberOfShadow, going south is not possible
                        Console.WriteLine("       You can not go to south from here. Please try again");
                    }
                    break;

                // Case for "HELP", this calls the Help() function which probably displays game instructions
                case "HELP":
                    Help();
                    break;

                // Case for "INVENTORY", this shows all the items in the user's inventory
                case "INVENTORY":
                    Console.WriteLine("You have the following items in your inventory:");
                    for (int i = 0; i < inventoryCount; i++) // Loop through the items in the inventory
                    {
                        Console.WriteLine(inventory[i]); // Print each item
                    }
                    break;

                // Default case, this is used when the input doesn't match any of the previous cases
                default:
                    Console.WriteLine("Invalid command. Please try again.");
                    break;
            }

        }

        static void Animate(string[] text)        //method that takes text and prints it 
        {
            bool skip = false;
            {
                int delay = 30;     //change the number stored in delay to speed up or slow down the texts animation
                Console.SetCursorPosition(0, 2);        //adds the padding to the top of the page
                foreach (string s in text)
                {
                    Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);     //adds padding to the left and right sides of the sentence
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (Console.KeyAvailable)       //if a key is pressed
                        {
                            skip = true;
                        }
                        if (skip == false)
                        {
                            Console.Write(s[i]);
                            Thread.Sleep(delay);
                        }
                        else
                        {
                            Console.Write(s[i]);
                        }
                    }
                    Console.WriteLine();
                }
                Console.ReadLine();
                Console.SetCursorPosition((40), Console.CursorTop);
            }
        }


        public static void Main(string[] args)
        {
            GameStart();
            CentralChamber();
        }

    }
}

