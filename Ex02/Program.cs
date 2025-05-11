using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO:
//1. TO THINK ABOUT ACCESS MODIFIERS OF CLASSES
//2. Create Guess Class with feedback and guess fields



namespace Ex02
{
    public class Program //maybe to change public to internal
    {
        public static void Main()
        {
            RunGame();
        }

        private static void RunGame()
        {
            UserInterface ui = new UserInterface();
            GameManager gameManager = new GameManager();

            while (true)
            {
                int maximalNumberOfGuesses = ui.GetMaximalNumberOfGuessesFromUser();
                gameManager.MaximalNumberOfGuesses = maximalNumberOfGuesses;
                ui.PrintScreen(maximalNumberOfGuesses);
                String userGuessInput = ui.GetGuessFromUser();
                Guess currentGuess = gameManager.ProccesGuessAndGiveFeedback(userGuessInput);
                if(currentGuess.UserGuess == null)
                {
                    Console.WriteLine("Try Again");
                }
                else
                {
                    //ui.AddToGuessList(currentGuess);
                }
            }            

        }

    }
}
