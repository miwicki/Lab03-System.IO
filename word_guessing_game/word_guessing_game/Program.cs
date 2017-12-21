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
                Console.Clear();
                Gameplay(path);
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
        static void Gameplay(string path)
        {
            string randomSelect = GetWord(path);
            string check = "";
            string incorrect = "";
            int guesses = 0;

            char[] guessArray = randomSelect.ToCharArray();
            char[] returnArray = new char[guessArray.Length];
            char[] userGuessesArray = new char[guessArray.Length];

            while (true)
            {
                if (check == randomSelect)
                {
                    Console.WriteLine("YOU WIN!");
                    break;
                }
                Console.WriteLine("GUESS A LETTER OR WORD.");
                userGuessesArray = Console.ReadLine().ToCharArray();
                guesses++;
                Console.Clear();

                for (int i = 0; i < guessArray.Length; i++)
                {
                    if (returnArray[i] != guessArray[i])
                    {
                        returnArray[i] = '_';
                    }
                    for (int k = 0; k < userGuessesArray.Length; k++)
                    {
                        if (userGuessesArray[k] == guessArray[i])
                        {
                            returnArray[i] = guessArray[i];
                            check = new string(returnArray);
                        }
                    }

                }

                foreach (char letter in userGuessesArray)
                {
                    if (Array.IndexOf(returnArray, letter) < 0)
                    {
                        incorrect += letter + " ";
                    }
                }

                Console.WriteLine($"Guesses Attempted: {guesses}");
                Console.WriteLine($"Wrong Guesses: {incorrect} ");
                Console.WriteLine(check);
            }
            Console.ReadLine();
            Gameplay(path);
        }

        static void Exit(string Path)
        {
            File.Delete(Path);
            Console.WriteLine("THANK YOU FOR PLAYING!");
            Console.Read();
            Environment.Exit(0);
        }

    }
}
