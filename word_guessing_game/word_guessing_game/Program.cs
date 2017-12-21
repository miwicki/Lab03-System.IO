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
        }
    }
}
