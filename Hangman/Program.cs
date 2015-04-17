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
        static string guessCurrent = String.Empty;

        //holds word to guess
        static string wordToGuess = string.Empty;

        //wordToGuess with spaces (ie: W O R D T O G U E S S)
        static string wordToGuessSpaces = string.Empty;

        //used for combined correct guesses and underscores (ie: if word is "baseball" B A _ E B A _ _ )
        static string underscoreGuessTempString = string.Empty;

        //number of wrong guesses
        static int wrongGuessCount = 0;

        //used to determine how many "_ " strings to display
        static int numUnderscore = wordToGuess.Length;

        //return string with correct number of underscorse
        static string underscores = new String('_', numUnderscore);

        //String.Concat(Enumerable.Repeat("_ ", numUnderscore));

        //used to compare with wordToGuess and determine if word is complete
        static string correctGuessString = string.Empty;

        //used to display incorrectly guessed letters to user
        static string incorrectGuessString = string.Empty;

        //used to store play again "yes"/"no" input from user
        static string yesNoInput = string.Empty;

        //if false program will end
        static bool gameOn = true;

        //if true user will be asked to play again
        static bool gameOver = false;

        static void Main(string[] args)
        {
            while (gameOn == true)
            {
                if (gameOver == false)
                {
                    if (nameUserInput == String.Empty || IsValidInput(nameUserInput) == false)
                    {
                        Console.Write("Please enter your name: ");
                        nameUserInput = Console.ReadLine();
                        IsValidInput(nameUserInput);
                    }

                    if (nameUserInput != String.Empty)
                    {
                        Greeting(nameUserInput);
                        HowToPlay();
                        RandomWordSeletor();
                        //diplay word blanks
                    }

                    while (!(correctGuessString.Contains(wordToGuess)) && wrongGuessCount < 8)
                    {
                        BuildTheGallows(wrongGuessCount);
                        //WordBuilder(guessCurrent);
                        guessCurrent = String.Empty;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                                Incorrect Letters: " + incorrectGuessString);
                        Console.ResetColor();
                        AskForGuessInput(guessCurrent);
                        guessCurrent = Console.ReadLine();

                        if (IsValidInput(guessCurrent) && wrongGuessCount <= 8)
                        {
                            IsGuessCorrect(guessCurrent);
                            Console.Clear();
                        }

                        if (wrongGuessCount >= 8)
                        {
                            BuildTheGallows(wrongGuessCount);
                            Console.WriteLine("Sorry buddy, you lose. Press any key.");
                            Console.ReadKey();
                            gameOver = true;
                            Console.Clear();
                        }
                        if (correctGuessString.Contains(wordToGuess) || guessCurrent == wordToGuess)
                        {
                            //WordBuilder(guessCurrent);
                            Console.WriteLine("You won the game! ...not very exciting, is it?");
                            Console.ResetColor();
                            Console.ReadKey();
                            Console.Clear();
                            gameOver = true;
                        }
                    }
                }
                if (gameOver == true)
                {
                    Console.Write("Would you like to play again? YES or NO? ");
                    yesNoInput = Console.ReadLine();
                    PlayAgainTrue(yesNoInput);
                }
            }
        }

        public static bool IsValidInput(string input)
        {
            if (input.All(Char.IsLetter) && input != null && input != string.Empty)
            {
                return true;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine();
                Console.WriteLine("Enter letters only. Please try again.");
                nameUserInput = string.Empty;
                guessCurrent = string.Empty;
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                return false;
            }
        }

        public static string Greeting(string name)
        {
            Console.Clear();
            Console.WriteLine("Hello " + name + "!");
            return name;
        }

        public static bool HowToPlay()
        {
            Console.WriteLine();
            Console.WriteLine("                           Welcome to HANGMAN!");
            Console.WriteLine();
            Console.WriteLine("Here are the rules:");
            Console.WriteLine();
            Console.WriteLine("You have 8 guesses to the fill in the blanks by guessing a letter or the whole   word. Every time you guess wrong, the little man under the gallows is one step closer to death. Good Luck!");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("A man's very life is in your hands. Press any key to continue.");
            Console.ReadKey();
            Console.Clear();
            return true;
        }

        public static string RandomWordSeletor()
        {
            //create list of 10 words to guess
            List<string> WordList = new List<string>();
            WordList.Add("indulge");
            WordList.Add("throwing");
            WordList.Add("negative");
            WordList.Add("zebra");
            WordList.Add("cowabunga");
            WordList.Add("reactor");
            WordList.Add("furnace");
            WordList.Add("duckling");
            WordList.Add("anteater");
            WordList.Add("fervently");

            //sets random number for the game
            Random rng = new Random();

            //set random number for index
            int index = rng.Next(WordList.Count);

            //set word for user to guess
            wordToGuess = WordList[index].ToUpper();

            return wordToGuess;

        }

        public static bool BuildTheGallows(int wrongGuessCount)
        {
            if (wrongGuessCount == 0)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 1)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      ( )  " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 2)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 3)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 4)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |      /|\  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 5)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |      /|\  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |      /    " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 6)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |      /|\  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |      / \  " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
                return true;
            }
            if (wrongGuessCount == 7)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |      /|\  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |     _/ \  " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
            }
            if (wrongGuessCount == 8)
            {
                Console.WriteLine(
                @"   _________   " + Environment.NewLine +
                @"   |/      |   " + Environment.NewLine +
                @"   |      (+)  " + Environment.NewLine +
                @"   |      /|\  " + Environment.NewLine +
                @"   |       |   " + Environment.NewLine +
                @"   |     _/ \_ " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"   |           " + Environment.NewLine +
                @"___|___        " + Environment.NewLine);
                Console.WriteLine();
                Console.WriteLine((8 - wrongGuessCount) + " guesses left!");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(wordToGuessSpaces.ToUpper() + " was the word.");
                Console.ResetColor();
                Console.WriteLine();
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool AskForGuessInput(string guessCurrent)
        {
            if (guessCurrent == String.Empty)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Type a letter or guess the word and hit ENTER: ");
                return true;
            }
            return false;
        }


        public static bool IsGuessCorrect(string guessCurrent)
        {
            guessCurrent = guessCurrent.ToUpper();

            if (wordToGuess.Contains(guessCurrent) && !correctGuessString.Contains(guessCurrent))
            {
                correctGuessString += guessCurrent;
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You guessed correctly!");
                guessCurrent = String.Empty;
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            else if (correctGuessString.Contains(guessCurrent) || incorrectGuessString.Contains(guessCurrent))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Really?! You already guessed " + guessCurrent + ".");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                return true;
            }
            else if (!(wordToGuess.Contains(guessCurrent)))
            {
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your killing me!");
                Console.WriteLine();
                wrongGuessCount++;
                incorrectGuessString += guessCurrent;
                Console.WriteLine(guessCurrent + " is not correct.");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                return false;
            }
            else
            {
                return false;
            }
        }

        /* public static string WordBuilder(string guessCurrent)
         {
         * 
         * string str = "Characters in a string.";
 System.Text.StringBuilder sb = new System.Text.StringBuilder();
 foreach (var ch in str)
    sb.Append(" '").Append(ch).Append("' ");

 Console.WriteLine("Characters in the string:");
 Console.WriteLine("  {0}", sb);


             //need to find a way to change underscores to letters
             //Console.WriteLine(underscoreGuessTempString);

           //  Console.Write("The word has " + wordToGuess.Length + " letters: ");
            // Console.WriteLine(wordToGuess);
            // {
             //    for (int i = 0; i < wordToGuess.Length; i++)
              //   {
               //      wordToGuess = wordToGuess.Replace(wordToGuess[i], '_');
                     //wordToGuess = wordToGuess.add(wordToGuess[(!i%2)], ' ');
             //    }
              //   Console.WriteLine(wordToGuess);
            // }
            // return string.Empty;
             /*
         if (guessCurrent.Contains(wordToGuess[i].ToString().ToUpper()))
         {
         underscoreGuessTempString = underscoreGuessTempString.Replace('_', guessCurrent);

         }	
         if (correctGuessString != String.Empty)
         {
             underscoreGuessTempString += wordToGuess[i];
             Console.WriteLine(underscoreGuessTempString);
         }*/

        public static bool PlayAgainTrue(string yesNoInput)
        {
            if (IsValidInput(yesNoInput) && @"Yy".Any(yesNoInput.Contains))
            {
                Console.WriteLine();
                Console.WriteLine("Sweet. Let's play again!");
                wrongGuessCount = 0;
                correctGuessString = string.Empty;
                incorrectGuessString = string.Empty;

                Console.ReadKey();
                return gameOver = false;
            }
            if (IsValidInput(yesNoInput) && @"Nn".Any(yesNoInput.Contains))
            {
                Console.WriteLine();
                Console.WriteLine("Quitter...");
                Console.ReadKey();
                return gameOn = false;
            }
            return false;
        }
    }
}
