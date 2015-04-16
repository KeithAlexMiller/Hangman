using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        string nameUserInput = string.Empty;
        string wordToGuess = string.Empty;
        static bool gameOn = true;
        
        static void Main(string[] args)
        {
            Greeting(nameUserInput);
            GameIntro();
            RandomWordSeletor();

            //chooses random number

            //Console.Clear();
        }

        public static string Greeting(string nameUserInput)
        {
            if (nameUserInput == string.Empty)
            {
                string name = Console.ReadLine();
                Console.WriteLine("Hello user! Please enter your name: ");
            }
            else
            {
                Console.WriteLine("Please try again.");
            }
        }

        public static string GameIntro(string rules)
        {
            Console.WriteLine("Welcome to Hangman. Here are the rules...");

        }
        public static string RandomWordSeletor()
        {
            //create list of 10 words to guess
            List<string>WordList = new List<string>();
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
            int index = rng.Next(WordList.Count - 1);

            //set word for user to guess
            wordToGuess = WordList[index];

        }


       // public static string SetDifficulty()
       // {
            
       // }
    }
}
