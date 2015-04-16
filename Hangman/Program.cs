using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        //holds user name
        static string nameUserInput = string.Empty;

        //holds current user guess
        static string guessCurrent = string.Empty;

        //holds word to guess
        static string wordToGuess = string.Empty;

        //used for combined correct guesses and underscores (ie: if word is "baseball" B A _ E B A _ _ )
        static string underscoreGuessTempString = string.Empty;

        //number of wrong guesses
        static int wrongGuessCount = 0;

        //used to determine how many "_ " strings to display
        static int numUnderscore = wordToGuess.Length;

        //return dashes and letters
        public static string underscores = string.Concat(Enumerable.Repeat("_ ", numUnderscore));

        //used to create a string of wrong letters/words that have been guessed 
        string wrongGuessString = string.Empty;

        //used to combine correct guess letters with blanks (underscores)
        string correctGuessString = string.Empty;

        //if false game will end
        static bool gameOn = true;

        static void Main(string[] args)
        {
            Console.Write("Please enter your name: ");
            string nameUserInput = Console.ReadLine();
            Greeting(nameUserInput);
            HowToPlay();
            RandomWordSeletor();
            //diplay word blanks
            BuildTheGallows(wrongGuessCount);
            WordBuilder(underscores);
            string guessCurrent = Console.ReadLine();
            IsGuessCorrect(guessCurrent);


            Console.ReadKey();

            //chooses random number

            //Console.Clear();
        }

        public static string Greeting(string name)
        {
            Console.WriteLine();
            Console.WriteLine("Hello " + name + "!");
            return name;
        }

        public static bool HowToPlay()
        {
            Console.WriteLine();
            Console.WriteLine("Welcome to Hangman. Here are the rules...");
            Console.WriteLine();
            Console.WriteLine("A man's very life is in your hands. Press any key to continue.");
            Console.ReadKey();
            return true;
        }

        public static string RandomWordSeletor()
        {
            //create list of 10 words to guess
            List<string> WordList = new List<string>();
            WordList.Add("running");
            WordList.Add("throwing");
            WordList.Add("jumping");
            WordList.Add("falling");
            WordList.Add("tripping");
            WordList.Add("laughing");
            WordList.Add("talking");
            WordList.Add("turning");
            WordList.Add("burrning");
            WordList.Add("exploding");

            //sets random number for the game
            Random rng = new Random();

            //set random number for index
            int index = rng.Next(WordList.Count);

            //set word for user to guess
            wordToGuess = WordList[index];

            return wordToGuess;

        }

        public static bool WordBuilder(string guessString)
        {

            //need to find a way to change underscores to lettes
            //Console.WriteLine(underscoreGuessTempString);

            if (wordToGuess.Contains(guessString))
            {
                Console.WriteLine(guessString);
                return true;
            }
            else if (!(wordToGuess.Contains(guessString)))
            {
                Console.WriteLine(underscores);
                return true;
            }

            return false; 
        }

        public static bool BuildTheGallows(int wrongGuessCount)
        {
            string gallows0 = "gallows0";
            string gallows1 = "gallows1";
            string gallows2 = "gallows2";
            string gallows3 = "gallows3";
            string gallows4 = "gallows4";
            string gallows5 = "gallows5";
            string gallows6 = "gallows6";
            string gallows7 = "gallows7";
            string gallows8 = "gallows8";

            if (wrongGuessCount == 0)
            {
                Console.WriteLine(gallows0);
                return true;
            }
            if (wrongGuessCount == 1)
            {
                Console.WriteLine(gallows1);
                return true;
            }
            if (wrongGuessCount == 2)
            {
                Console.WriteLine(gallows2);
                return true;
            }
            if (wrongGuessCount == 3)
            {
                Console.WriteLine(gallows3);
                return true;
            }
            if (wrongGuessCount == 4)
            {
                Console.WriteLine(gallows4);
                return true;
            }
            if (wrongGuessCount == 5)
            {
                Console.WriteLine(gallows5);
                return true;
            }
            if (wrongGuessCount == 6)
            {
                Console.WriteLine(gallows6);
                return true;
            }
            if (wrongGuessCount == 7)
            {
                Console.WriteLine(gallows7);
                return true;
            }
            if (wrongGuessCount == 8)
            {
                Console.WriteLine(gallows8);
                return true;
            }
            else
            {
                return false;
            }

        }


        /* public static bool ValidateUserInput(string userInput)
            
         if ()
         {
             return true;
         }

         else if ()
     {
         Console.WriteLine("User input is not valid. Please only enter a letter or a word.");
     return false;
     }
         */

        public static bool IsGuessCorrect(string currentGuess)
        {
            if (wordToGuess.Contains(currentGuess))
            {
                Console.WriteLine("You guessed correctly!");
                return true;
            }
            //else (!(wordToGuess.Contains(currentGuess)))
            {
                Console.WriteLine("Your killing me!");
                return false;
            }
        }

        // public static string SetDifficulty()
        // {

        // }
    }
}
