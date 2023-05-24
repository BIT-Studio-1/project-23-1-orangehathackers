using System;
using System.Threading;

namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                string userLocation = "CentralChamber";
                if (userLocation == "CentralChamber")
                {
                    CentralChamber();
                }
                else if (userLocation == "Library")
                {
                    Library();
                }
                else if (userLocation == "PuzzleRoom")
                {
                    PuzzleRoom();
                }
                else if (userLocation == "chamberOfShadow")
                {
                    chamberOfShadow();
                }
                else if (userLocation == "TreasureVault")
                {
                    TreasureVault();
                }
                else
                {
                    AltarRoom();
                }
            }

            static void CentralChamber()
            {
                Console.WriteLine("Storyline");

                while (true)
                {
                    Console.Write("Please enter a direction: ");
                    string playerDirection = Console.ReadLine().ToUpper();

                    if (playerDirection == "north")
                    {
                        chamberOfShadow();
                        break;
                    }
                    else if (playerDirection == "south")
                    {
                        Console.WriteLine("You can not go to south from here. Please try again");
                    }
                }

            }
            static void Library()
            {

            }
            static void PuzzleRoom()
            {

            }
            static void chamberOfShadow()
            {

            }
            static void TreasureVault()
            {

            }
            static void AltarRoom()
            {

            }
        }

    }
}
