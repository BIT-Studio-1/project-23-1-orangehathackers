using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Numerics;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static string[] inventory = new string[4];
        static int inventoryCount = 0;
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
            Console.WriteLine("Use words like 'examine', 'use', 'look', 'solve', 'climb', 'take' to interact with the items and environment.");
            Console.WriteLine("Explore each room throughly to find items and solve puzzles.");
            Console.WriteLine("Collect useful items to help you progress in the game.");
            Console.WriteLine("Your ultimate goal is to discover the hidden artifact and claim it for yourself.");
            Console.WriteLine("Good Luck!!!!!");
        }
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
        static void CentralChamber()
        {
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
                        if (!HasItem("Key"))
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
                        while (true) {
                            if (!puzzleSolved)
                            {
                                Console.WriteLine("The wall is covered in ancient symbols and a series of levers nearby. Each symbol corresponds to a specific lever.");
                                Console.WriteLine("The symbols are: Ankh, Feather, Scarab, Eye. To unlock the puzzle,");
                                Console.WriteLine("you must decipher the correct order of symbols and pull the levers accordingly.");
                                Console.WriteLine("What is the correct order? (Enter you answer seperated by a comma ',')");
                                string userAnswer = Console.ReadLine().ToUpper();
                                if (userAnswer == "BACK")
                                {
                                    CentralChamber();
                                }
                                if (userAnswer == puzzleAnswer)
                                {
                                    puzzleSolved = true;
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
        static void PuzzleRoom()
        {
            Console.Clear();
            Console.WriteLine("You are now in the puzzle room.");
            Console.WriteLine("As you enter this room, you are greeted by a series of intricate puzzles.");
            Console.WriteLine("The walls are adorned with enigmatic symbols, and the floor is marked with a pattern of tiles.");
            Console.WriteLine("A riddle is etched onto a stone tablet, challenging you to unlock the room's secrets.");
            bool puzzleSolved = false, allCorrect = true;
            string puzzle1Answer = "Q";
            string[] riddles = {
                                    "I speak without a mouth and hear without ears. I have no body, but I come alive with the wind. What am I?",
                                    "I have keys but no locks. I have space but no room. You can enter but can't go outside. What am I?",
                                    "The more you take, the more you leave behind. What am I?",
                                    "I can be cracked, made, told, and played. What am I?"
                                   };
            string[] answers = { "Echo", "Keyboard", "Footsteps", "Joke" };
            string[] userAnswers = new string[4];
            string[] symbols = { "STAR", "MOON", "SUN", "PLANET" };
            string[] reflectedSymbols = { "RATS", "NOOM", "NUS", "TENALP" };
            while (true)
            {
                Console.Write("Please enter a command: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "SOLVE PUZZLE":
                        if (!puzzleSolved)
                        {
                            Console.WriteLine("You will have to solve a series of 4 puzzles in order to enter the Treasure vault.");
                            Console.Clear();
                            Console.WriteLine("Puzzle 1:Missing Letter");
                            Console.WriteLine("You come across a series of letters on the wall, but one letter is missing.");
                            Console.WriteLine("The letters form a sequence, and you need to determine the missing letter to complete the sequence.");
                            Console.WriteLine("B, D, G, I, L, N, __, S, V");
                            Console.Write("Please enter the missing letter:");
                            while (true)
                            {
                                string userAnswer = Console.ReadLine().ToUpper();
                                if (userAnswer == "QUIT")
                                {
                                    PuzzleRoom();
                                }
                                if (userAnswer == puzzle1Answer)
                                {
                                    Console.WriteLine("Well Done! You solved the puzzle.");
                                    Console.WriteLine("On to the next one.");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("That's incorrect. Try again.");
                                }
                            }
                            Console.Clear();                           
                            Console.WriteLine("\nPuzzle 2: Cryptic Riddles");
                            Console.WriteLine("Solve the riddles to find the words.");
                            while (true)
                            {
                                for (int i = 0; i < riddles.Length; i++)
                                {
                                    Console.WriteLine("\nRiddle " + (i + 1) + ":");
                                    Console.WriteLine(riddles[i]);

                                    Console.Write("Enter your answer: ");
                                    userAnswers[i] = Console.ReadLine().Trim().ToLower();
                                    if (userAnswers[i] == "quit")
                                    {
                                        PuzzleRoom();
                                    }
                                }
                                for (int i = 0; i < answers.Length; i++)
                                {
                                    if (userAnswers[i] != answers[i].ToLower())
                                    {
                                        allCorrect = false;
                                    }
                                }
                                if (allCorrect)
                                {
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
                            Console.Clear();
                            Console.WriteLine("\nPuzzle 3: Mirror Reflection");
                            Console.WriteLine("Rearrange the symbols based on their reflection in the mirror.");
                            Console.WriteLine("Rearrange the following symbols based on their reflection:");
                            while (true)
                            {
                                for (int i = 0; i < symbols.Length; i++)
                                {
                                    Console.WriteLine(symbols[i]);
                                }

                                string[] rearrangedSymbols = Console.ReadLine().ToUpper().Split(',');
                                Console.WriteLine(rearrangedSymbols[0]);
                                if (rearrangedSymbols[0] == "QUIT")
                                {
                                    PuzzleRoom();
                                }

                                if (rearrangedSymbols.SequenceEqual(reflectedSymbols))
                                {
                                    Console.WriteLine("Great job! You rearranged the symbols correctly.");
                                    Console.WriteLine("Just one more puzzle to go!");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("The symbols are not rearranged correctly. Keep trying.");
                                }
                            }
                            Console.Clear();
                            Console.WriteLine("\nPuzzle 4: Cryptic Code");
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
                            while (true)
                            {
                                Console.WriteLine("\nEnter the code:");

                                int code = Convert.ToInt32(Console.ReadLine());

                                if (code == clue1 * 1000 + clue2 * 10 + clue3)
                                {
                                    Console.WriteLine("Congratulations! You've solved the cryptic code puzzle!");
                                    Console.WriteLine("All the puzzles are now solved.");
                                    puzzleSolved = true;

                                }
                                else
                                {
                                    Console.WriteLine("That's not the correct code. Keep deciphering or try again.");
                                    return;
                                }
                            }
                        }
                        else
                            Console.WriteLine("All the puzzles are solved. You can now enter the Treasure Vault.");
                        break;
                    case "NORTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "EAST":
                        if (puzzleSolved)
                            TreasureVault();
                        else
                            Console.WriteLine("The door to the Treasure Vault is sealed. First solve all the puzzles to gain access.");
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
                    default:
                        Console.WriteLine("Invalid answer. Please try again.");
                        break;
                }
            }
        }
        static void Library()
        {
            string puzzleAnswerTreasure = "TREASURE HUNT";
            string puzzleAnswerBook = "TAKE BOOK";
            string puzzleAnswerPendant = "TAKE PENDANT";
            Console.Clear();
            Console.WriteLine("Stepping into the library, you are surrounded by shelves filled with dusty tomes and scrolls. The air is thick with the scent of ancient parchment. Sunlight filters through stained glass windows, illuminating a large desk at the center of the room. On it lies a game for you to win.");
            Console.WriteLine("On the right you see a ladder leading into the tunnel.");
            Console.WriteLine("There is a puzzle for you to solve.");
            while (true)
            {
                Console.Write(">> ");
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
                        Console.WriteLine("Chamber of shadow");
                        break;
                    case "WEST":
                        Console.WriteLine("You can not go to west from here. Please try again");
                        break;
                    case "HELP":
                        Console.WriteLine("help");
                        break;
                    case "SOLVE":
                        Console.WriteLine("The word are raseture nhtu ");
                        string solvePuzzle = Console.ReadLine().ToUpper();
                        if (solvePuzzle == puzzleAnswerTreasure)
                        {
                            Console.WriteLine("You have solve the puzzle. In the middle it appear a old wooden chest cover with dust.");
                            Console.WriteLine("Inside the wooden chest show an old book laying on the bottom.");
                            Console.Write(">> ");
                            solvePuzzle = Console.ReadLine().ToUpper();
                            if (HasItem("Book"))
                            {
                                Console.WriteLine("You have taken a book");
                            }
                            if (solvePuzzle == puzzleAnswerBook)
                            {
                                Console.WriteLine("You have pick up a book"); ;
                                AddToInventory("Book");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid answer. Please try again.");
                        }
                        break;
                    case "CLIMB":
                        Console.WriteLine("You have climb the ladder. It leading into a dark old room. In the room you found a pendant");
                        Console.WriteLine(">> ");
                        string takingPendant = Console.ReadLine().ToUpper();
                        if (HasItem("Pendant"))
                        {
                            Console.WriteLine("You have taken a pendant");
                        }
                        if (takingPendant == puzzleAnswerPendant)
                        {
                            Console.WriteLine("You have pick up a pendant");
                            AddToInventory("Pendant");
                        }
                        else
                        {
                            Console.WriteLine("Invalid answer. Please try again.");
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
        static void ChamberOfShadow()
        {
            Console.Clear();
            Console.WriteLine("You are now in the chamber of shadow.");
            Console.WriteLine("As you cautiously step into the Chamber of Shadows, the air grows heavy and oppressive.");
            Console.WriteLine("Dim, flickering lights barely illuminate the obscure corners of the room, casting eerie shadows that seem to dance and writhe along the walls.");
            Console.WriteLine("The darkness shrouds the chamber, leaving much to the imagination and evoking an unsettling sense of the unknown.");
            bool torchUsed = false;
            bool artifactPlaced = false;
            bool puzzleSolved = false;
            while (true)
            {
                Console.Write("Please enter a command: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "LOOK":
                        if (!torchUsed)
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
                            torchUsed = true;
                        }
                        else
                        {
                            Console.WriteLine("You do not have the torch to light the room.");
                        }
                        break;
                    case "USE KEY ON CABINET":
                        if (torchUsed)
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
                        if (torchUsed)
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
                        if (torchUsed)
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
                        if (torchUsed)
                        {
                            if (artifactPlaced)
                            {
                                Console.WriteLine("Puzzle needs to be put. I will do it tomorrow.");
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
                        Console.WriteLine("You can not go to south from here. Please try again");
                        break;
                    case "SOUTH":
                        CentralChamber();
                        break;
                    case "EAST":
                        if (puzzleSolved)
                        {
                            AltarRoom();
                        }
                        else
                        {
                            Console.WriteLine("The access to the door is locked. You cannot go further.");
                        }
                        break;
                    case "WEST":
                        if (torchUsed)
                        {
                            Library();
                        }
                        else
                        {
                            Console.WriteLine("It's difficult to see the details in the dim light. Perhaps there's something that can help you illuminate the room.");
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
        static void TreasureVault()
        {
            Console.Clear();
            Console.WriteLine("You have entered the Treasure Vault.");
            Console.WriteLine("The Treasure Vault is a vast chamber filled with glittering treasures and ancient artifacts.");
            Console.WriteLine("The room is bathed in a soft golden light, illuminating the riches that surround you.");
            Console.WriteLine("You notice a gentle flickering in the corner of your eye, hinting at something hidden within the shadows.");
            Console.WriteLine("As you explore further, you spot an enchanting crystal radiating a soft blue light, captivating your attention.");
            Console.WriteLine("Nearby, there is a pedestal with a lever and a locked chest, intriguing you with their mysterious aura.");
            Console.WriteLine("You also have a vague sense that there might be something else of interest waiting to be discovered in this room.");
            while (true)
            {
                Console.Write("Please enter a command: ");
                string userInput = Console.ReadLine().ToUpper();
                switch (userInput)
                {
                    case "LOOK":
                        Console.WriteLine("You see a multitude of precious gems, golden artifacts, and mysterious relics.");
                        Console.WriteLine("You see a pedestal with a lever and a locked chest.");
                        Console.WriteLine("Among the treasures, there is a mysterious object concealed within the dimly lit corners.");
                        break;
                    case "EXAMINE CHEST":
                        Console.WriteLine("The chest is made of solid iron and secured with a heavy lock. It seems to be waiting for a key.");
                        break;
                    case "USE KEY ON CHEST":
                        if (HasItem("Key"))
                        {
                            Console.WriteLine("You unlock the chest with the key. Inside, you find a glowing artifact.");
                            Console.WriteLine("The artifact radiates a powerful energy, and you can sense its ancient origins.");
                            Console.WriteLine("You carefully pick up the artifact and add it to your inventory.");
                            AddToInventory("Artifact");
                        }
                        else
                        {
                            Console.WriteLine("You don't have the key to unlock the chest.");
                        }
                        break;
                    case "EXAMINE PEDESTAL":
                        Console.WriteLine("The pedestal has a lever that can be pulled.");
                        break;
                    case "PULL LEVER":
                        Console.WriteLine("You pull the lever, and the room trembles slightly. The crystal in the center of the room glows brighter.");
                        break;
                    case "EXAMINE CRYSTAL":
                        Console.WriteLine("The crystal is a powerful artifact that seems to be the source of the room's enchantment.");
                        break;
                    case "EXAMINE FLICKERING":
                        if (HasItem("Torch"))
                        {
                            Console.WriteLine("You have already taken the torch.");
                        }
                        else
                        {
                            Console.WriteLine("You observe a hint of warmth in the shadows, as if a flickering light awaits to be revealed.");
                            Console.WriteLine("The allure of the hidden torch grows stronger, urging you to uncover its secrets.");
                        }
                        break;
                    case "TAKE TORCH":
                        if (HasItem("Torch"))
                        {
                            Console.WriteLine("You have already taken the torch.");
                        }
                        else
                        {
                            Console.WriteLine("Driven by an unexplained impulse, you reach into the shadows and grasp the enigmatic torch.");
                            Console.WriteLine("You add the torch to your inventory, eager to discover its purpose.");
                            AddToInventory("Torch");
                        }
                        break;
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
        static void AltarRoom()
        {
            Console.Clear();
            Console.WriteLine("You are now the puzzle room.");
            Console.WriteLine("In the ");
            Console.WriteLine("There are doors to the east and west");
            while (true)
            {
                Console.Write("Please enter a direction: ");
                string userInput = Console.ReadLine().ToUpper();
                if (userInput == "QUIT")
                {
                    return;
                }

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
            CentralChamber();
            
        }
    }
}