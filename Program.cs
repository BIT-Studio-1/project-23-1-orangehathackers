using System;
using System.Linq;
using System.Numerics;
using System.Threading;

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
        // Display the game title
        static void GameStart()
        {
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("");
            Console.WriteLine("  _______ _             _____                    _      ____   __   ______ _   _____                      _       ");
            Thread.Sleep(500);
            Console.WriteLine(" |__   __| |           / ____|                  | |    / __ \\ / _| |  ____| | |  __ \\                    | |      ");
            Thread.Sleep(500);
            Console.WriteLine("    | |  | |__   ___  | (___   ___  ___ _ __ ___| |_  | |  | | |_  | |__  | | | |  | | ___  _ __ __ _  __| | ___  ");
            Thread.Sleep(500);
            Console.WriteLine("    | |  | '_ \\ / _ \\  \\___ \\ / _ \\/ __| '__/ _ \\ __| | |  | |  _| |  __| | | | |  | |/ _ \\| '__/ _` |/ _` |/ _ \\ ");
            Thread.Sleep(500);
            Console.WriteLine("    | |  | | | |  __/  ____) |  __/ (__| | |  __/ |_  | |__| | |   | |____| | | |__| | (_) | | | (_| | (_| | (_) |");
            Thread.Sleep(500);
            Console.WriteLine("    |_|  |_| |_|\\___| |_____/ \\___|\\___|_|  \\___|\\__|  \\____/|_|   |______|_| |_____/ \\___/|_|  \\__,_|\\__,_|\\___/ ");
            Thread.Sleep(500);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("");
            Console.WriteLine("Press enter to continue: ");
            Console.ReadLine();
            Console.Clear();

            Console.WriteLine("You are an archaeologist exploring an ancient excavation site.");
            Console.WriteLine("Your mission is to find a long-lost artifact of great power.");
            Console.WriteLine("Prepare yourself for an adventure filled with puzzles and mysteries!\n");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            Console.Clear();
        }
        // Method for instruction of the game
        static void Help()
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
                Console.Write("Solve Puzzle");
                Console.Write("- North");
                Console.Write("- South");
                Console.Write("- West");
                Console.Write("- East");
                Console.Write("- Help");

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
            Console.WriteLine("Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls. The air is thick with the scent of ancient parchment. Sunlight filters through stained glass windows, illuminating a large desk at the center of the room. On it lies a game for you to win.");
            Console.WriteLine("On the right, you see a ladder leading into the tunnel. There a book laying on the side of the shelves");
            Console.WriteLine("There is a puzzle for you to solve.");

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
                        Help();
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
                                    if (HasItem("Book"))
                                    {
                                        Console.WriteLine("You have already taken a book.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("The book is added to the inventory.");
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
                                Console.WriteLine("You have already taken a pendant.");
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
                    case "TAKE BOOK":
                        Console.WriteLine("You have taken a book.");
                        AddToInventory("Book");
                        break;
                    case "USE BOOK":
                        if (HasItem("Book"))
                        {
                            Console.WriteLine("In the heart of a scorching desert, an excavation site emerged. Digging through layers of time, the team unearthed remnants of an ancient civilization.");
                            Console.WriteLine("Fragments of pottery whispered tales of forgotten traditions, while weathered hieroglyphs held untold secrets. Among the dust and sand, they discovered a long-buried temple, revealing the lost splendor of a civilization lost to the ages.");
                            Console.WriteLine("The archaeologists marveled at their discovery, knowing that they had become custodians of a timeless legacy, ready to share its wonders with the world.");
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
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        // ChamberOfShadow is a method representing the chamber of shadow area in the excavation site.
        static void ChamberOfShadow()
        {
            Console.Clear();
            Console.WriteLine("You are now in the chamber of shadow.");
            Console.WriteLine("As you cautiously step into the Chamber of Shadows, the air grows heavy and oppressive.");
            Console.WriteLine("Dim, flickering lights barely illuminate the obscure corners of the room, casting eerie shadows that seem to dance and writhe along the walls.");
            Console.WriteLine("The darkness shrouds the chamber, leaving much to the imagination and evoking an unsettling sense of the unknown.");
            
            string userAnswer = "";
            string puzzleAnswer = "OWL";
            // Infinite loop for handling player commands
            while (true)
            {
                
                Console.WriteLine("- Look");
                Console.WriteLine("- Use Torch");
                Console.WriteLine("- Use Key On Cabinet");
                Console.WriteLine("- Examine Cabinet");
                Console.Write("Please enter a command: ");


                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "LOOK":
                        if (!torchUsed_Chamber_Of_Shadows)
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        else
                        {
                            Console.WriteLine("In the far corner, stands a locked cabinet, its contents hidden from prying eyes.");
                            Console.WriteLine("Whispers of untold treasures or crucial clues linger in the air, enticing your curiosity.");
                        }
                        break;
                    case "USE TORCH":
                        if (HasItem("Torch"))
                        {
                            Console.WriteLine("As the player ignites the torch,");
                            Console.WriteLine("the flickering flames cast dancing shadows that begin to reveal the hidden details of the room, shrouded in darkness no more.");
                            torchUsed_Chamber_Of_Shadows = true;
                        }
                        else
                        {
                            Console.WriteLine("You do not have the torch to light the room.");
                        }
                        break;
                    case "USE KEY ON CABINET":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (HasItem("Key"))
                            {
                                Console.WriteLine("In the heart of the cabinet, an enigmatic mechanism catches your attention, its intricate design hinting at a greater purpose.");
                                Console.WriteLine("A small slot within the mechanism awaits the placement of a mysterious artifact, teasing its significance.");
                                Console.WriteLine("Beyond this intricate contraption lies a concealed door, promising a path to the unknown.");
                                
                            }
                            else
                            {
                                Console.WriteLine("You don't have the key to unlock the chest.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        } 
                        break;
                    case "EXAMINE CABINET":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            Console.WriteLine("The cabinet stands tall and imposing against the chamber's wall,");
                            Console.WriteLine("its surface adorned with intricate carvings, hinting at the mysteries concealed within.");
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        break;
                    case "PLACE ARTIFACT ON MECHANISM":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (HasItem("Artifact"))
                            {
                                artifactPlaced = true;
                                Console.WriteLine("As the artifact is carefully placed on the mechanism,");
                                Console.WriteLine("the door to the far EAST of the chamber begins to shimmer with an ethereal glow, revealing a doorway to the final room.");
                                Console.WriteLine("The door itself is made of ancient, weathered wood, adorned with mysterious symbols and engravings that seem to shift and rearrange as if alive.");
                                Console.WriteLine("To unlock the door and gain access to the final room, a complex puzzle awaits the player.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        break;
                    case "SOLVE PUZZLE":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (artifactPlaced)
                            {
                                if (!puzzleSolved_Chamber_Of_Shadows)
                                {
                                    Console.WriteLine("The Tome of Forgotten Knowledge\" holds the key to unlocking the door to the final room.");
                                    Console.WriteLine("PUZZLE:");
                                    Console.WriteLine("Of wisdom's embrace, seek the guardian's gaze,");
                                    Console.WriteLine("A scholar's delight, a learned mind's blaze.");
                                    Console.WriteLine("Within the pages marked by timeless lore,");
                                    Console.WriteLine("Find the symbol that opens the door.");
                                    while (!puzzleSolved_Chamber_Of_Shadows)
                                    {
                                        userAnswer = Console.ReadLine().ToUpper();
                                        if (userAnswer ==  puzzleAnswer)
                                        {
                                            puzzleSolved_Chamber_Of_Shadows = true;
                                            Console.WriteLine("Behold! The once impenetrable barrier has yielded to your unwavering determination,");
                                            Console.WriteLine("as the majestic door now stands ajar, beckoning you to enter the realm of finality.");
                                        }
                                        else if (userAnswer == "USE BOOK")
                                        {
                                            if (HasItem("Book"))
                                            {
                                                Console.WriteLine("In the realm of twilight's embrace, a creature of feathered grace dwells,");
                                                Console.WriteLine("casting its mystic aura upon the land.");
                                                Console.WriteLine("Embrace the essence of this nocturnal sentinel to illuminate the path towards the answer you seek.");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Within the depths of my vast knowledge,");
                                                Console.WriteLine("the book that contains the sought-after hint eludes my grasp,");
                                                Console.WriteLine("leaving me unable to provide you with its wisdom.");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Invalid Answer. Please try again.");
                                        }
                                    }        
                                }
                                else
                                {
                                    Console.WriteLine("The puzzle is already solved.");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine("Activate the mechanism to access the puzzle.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        break;
                    case "NORTH":
                        Console.WriteLine("You can not go to north from here. Please try again");
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
                                Console.WriteLine("The access to the door is locked. You cannot go further.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        break;
                    case "WEST":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            Library();
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
                        }
                        break;
                    case "DAGGER":
                        if (torchUsed_Chamber_Of_Shadows)
                        {
                            if (HasItem("dagger"))
                            {
                                Console.WriteLine("You have already taken the dagger");
                            }
                            else
                            {
                                Console.WriteLine("You have picked up a dagger with embellished engravings all over the blade");
                                AddToInventory("dagger");
                            }
                        }
                        else
                        {
                            Console.WriteLine("The room is too dark. You can't see anything.");
                        }
                        break;
                        case "USE DAGGER":
                        if (HasItem("dagger"))
                        {
                            Console.WriteLine("You twirl the dagger thinking your self so cool");
                        }
                        else
                        {
                            Console.WriteLine("you do not yet have the dagger");
                        }
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
            Random random = new Random();
            while (playAgain)
            {
                int num1 = random.Next(50, 250);
                int num2 = random.Next(-250, -50);
                char[] operatorIndex = {'+', '-', '/', '*'};
                char op = operatorIndex[random.Next(operatorIndex.Length)];

                int correctAnswer;
                if(op == '+') 
                {
                    correctAnswer = num1 + num2;
                }

                else if(op ==  '-')
                {
                    correctAnswer = num1 - num2;
                }

                else if(op == '/')
                {
                    correctAnswer = num1 / num2;
                }

                else
                {
                    correctAnswer = num1 * num2;
                }
                

                Console.WriteLine("\nPlease answer the following math question: \n");
                Console.Write($"{num1} {op} {num2} = ");

                int Answer;
                if (int.TryParse(Console.ReadLine(), out Answer))
                {
                    if (Answer == correctAnswer)
                    {
                        Console.WriteLine("\nYour answer is correct !");
                        return true;
                    }
                    else
                    {
                        Console.WriteLine($"\nWrong! The correct answer is : [{correctAnswer}].");
                        Console.Write("Do you want to try again? (y/n): ");
                        string userInput = Console.ReadLine();
                        playAgain = (userInput.ToLower() == "y");
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


        static void AltarRoom()
        {
            Console.Clear();
            Console.WriteLine("You come across a door and on it is an equations \n seems as if you must answer it to open the door");
            Console.WriteLine("There are doors to the east and west");
            bool gotCorrect = EquationGame();
            while (true)
            {
                if (gotCorrect)
                {
                    Console.WriteLine("You are now in the Altar room.");
                    Console.WriteLine("You look around the decaying room and see old run down table in the middle of the room");
                    Console.WriteLine("The table has small indents the shape of different items almost as if you are mean to place them in there");
                }
                Console.WriteLine("Please enter an action: ");
                Console.Write("---> ");

                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "BACK")
                {
                    return;
                }

                 switch (userInput)
                {

                    case "PLACE":
                        if (gotCorrect)
                        {
                            Console.WriteLine("You put your items in the indents on the table");
                            if (Array.Exists(inventory, element => element == "Artifact") && Array.Exists(inventory, element => element == "Key"))
                            {
                                Console.WriteLine("it seems as if you dont have all the items to go on the table.");
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
                                Console.WriteLine("Congradulations on completing the game!!!!");
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
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        public static void Main(string[] args)
        {
            //GameStart();
            //CentralChamber();
            //Library();
            //CentralChamber();
            AltarRoom();
            EquationGame();

            
        }
    }
}

