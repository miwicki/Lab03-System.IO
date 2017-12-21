using System;
using System.IO;

namespace word_guessing_game
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {
                string fileName = "words-file.txt";
                string path = Path.Combine(Environment.CurrentDirectory, @"Words\", fileName);
            }
            catch (DirectoryNotFoundException)
            {

                Console.WriteLine("Sike, that's the wrong directory!");
            }
        }
        static void Game(string path)
        {
            Init(path);
            Console.Clear();
            Console.WriteLine("Welcome to Matt Iwicki's Word Guessing Game!");
            Console.WriteLine("Please choose one of the options below! To select an option, type its number and press enter");
            Console.WriteLine("1. START GAME");
            Console.WriteLine("2. VIEW ALL WORDS");
            Console.WriteLine("3. ADD A WORD");
            Console.WriteLine("4. DELETE A WORD");
            Console.WriteLine("5. EXIT");
            string userInput = Console.ReadLine();
            if (userInput == "1")
            {

            }
            if (userInput == "2")
            {

            }
            if (userInput == "3")
            {

            }
            if (userInput == "4")
            {

            }
            if (userInput == "5")
            {

            }
        }
     }
}
