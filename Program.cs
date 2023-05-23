using System;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the......... ");
            helpConsole();
        }
        static void helpConsole()
        {
            Console.WriteLine("If you want to get an instruction of the game");
            Console.WriteLine("Type help");
            string userInput = Console.ReadLine();

            if (userInput == "help" ||userInput  == "HELP") 
            {
                Console.WriteLine("Instruction");
            }

            
        }
    }
}
