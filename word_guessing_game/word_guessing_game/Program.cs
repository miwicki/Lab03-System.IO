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
                Console.Clear();
                GetAllWords(path);
                Console.ReadLine();
                Gameplay(path);
            }
            if (userInput == "3")
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine("Enter a word you would like to add.");

                string addWord = Console.ReadLine().ToLower();
                AddWord(addWord, path);

                GetAllWords(path);
                Gameplay(path);
            }
            if (userInput == "4")
            {
                Console.Clear();
                GetAllWords(path);

                Console.WriteLine("Enter a word you would like to remove.");
                string rmWord = Console.ReadLine().ToLower();
                RemoveWord(rmWord, path);
                Console.Clear();

                GetAllWords(path);
                Console.ReadLine();
                Gameplay(path);
            }
            if (userInput == "5")
            {
                Console.Clear();
                Exit(path);
            }
            Console.Read;
        }

                static void Init(string path)
        {
            string[] defaultWords = new String[10];
            defaultWords[0] = "sailboat";
            defaultWords[1] = "transluscent";
            defaultWords[2] = "cooperate";
            defaultWords[3] = "rendezvous";
            defaultWords[4] = "jazz";
            defaultWords[5] = "lynx";
            defaultWords[6] = "buzzing";
            defaultWords[7] = "vessels";
            defaultWords[8] = "soap";
            defaultWords[9] = "neighborhood";

        }

        static string GetWord(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string[] words = File.ReadAllLines(path);
                Random rand = new Random();
                int roll = rand.Next(0, words.Length -1);
                return words[roll];
            }
        }

        static string[] GetAllWords(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string[] words = File.ReadAllLines(path);

                int length = words.Length;

                foreach (string word in words)
                {
                    Console.WriteLine(word);
                }
                return words;
            }
        }
    
        static void AddWord(string newWord, string path)
        {
            string[] all = GetAllWords(path);

            string[] newAll = new string[all.Length + 1];

            newAll[0] = newWord;

            for (int i = 0; i < all.Length; i++)
            {
                if (all[i] == newWord)
                {
                    Console.WriteLine("The word you added is already on the list.");
                    return;
                }
                newAll[i + 1] = all[i];
            }
           
           

        }

        
        static void RemoveWord(string remove, string path)
        { 
       
            string[] all = GetAllWords(path);
                       
            string[] newAll = new string[all.Length - 1];
                        
            bool removed = false;
                     
            int removeAt = Array.IndexOf(all, remove);
                        
            for (int i = 0; i < all.Length; i++)
            {

                if (removed == true)
                {
                    newAll[i - 1] = all[i];
                }
                if (i != removeAt && removed == false)
                {
                    newAll[i] = all[i];
                }
                else
                {
                    removed = true;
                }

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
