using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
<<<<<<< HEAD
            gameStart();
                helpConsole();
 

=======
            string userInput = "null";      //userInput could be initiated inside game but its here so that can be ironed out
            GameStart();        //Introduces the game once on start
            while (true)        //This is the new help method code which breaks the while loop
            {
                //game(ref userInput);
                userInput= Console.ReadLine();
                Console.WriteLine("bad");
                if (userInput == "HELP")
                    break;
            }
            Help();
>>>>>>> c69df1a7a45846cf1fed0cea9286f0bf04164861
        }
        static void GameStart()
        {
            Console.WriteLine("title");
            Thread.Sleep(2000);
            Console.Clear();
            Console.WriteLine("world setup placeholder");
        }
        static void Help()
        {
<<<<<<< HEAD
            Console.WriteLine("If you want to get an instruction of the game");
            Console.WriteLine("Type help");
            string userInput = Console.ReadLine().ToUpper();

            if (userInput == "HELP")
            {
                Console.WriteLine("Instruction");
            }
=======
            Console.WriteLine("Help method");
>>>>>>> c69df1a7a45846cf1fed0cea9286f0bf04164861
        }
        //static void game(ref string userInput)
        //{
        //userInput= Console.ReadLine().ToUpper();
        //Console.WriteLine("game done");
        //}
        static void centralChamber()
        {
<<<<<<< HEAD
            Console.WriteLine("Storyline");

            while (true) { 
                Console.Write("Please enter a direction: ");
                string playerDirection = Console.ReadLine().ToUpper();

                if (playerDirection == "north")
                {
                    chamberOfShadow();
                    break;
                }
                else if (playerDirection == "south") {
                    Console.WriteLine("You can not go to south from here. Please try again");
                }
            } 
=======
            Console.WriteLine("Game method");
            userInput= Console.ReadLine().ToUpper();
            Console.WriteLine("Still in game method");
>>>>>>> c69df1a7a45846cf1fed0cea9286f0bf04164861
        }
        static void Library()
        {
            
        }
        static void puzzleRoom()
        { 
        
        }
        static void chamberOfShadow()
        { 
        
        }
        static void treasureVault()
        { 
        
        }
        static void altarRoom()
        { 
            
        }


    }
}
