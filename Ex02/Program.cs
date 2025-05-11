using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//TODO:
//1. TO THINK ABOUT ACCESS MODIFIERS OF CLASSES
//2. isVictory in GameManager -- Raz
//3. check if user want to exit -- Raz
//4. UI SHIT (LIKE FORMAT GUESSES TO FIT IN TABLE, OR LOST MESSAGE) -- OMRI




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
                while(gameManager.MaximalNumberOfGuesses == -1)
                {
                    int maximalNumberOfGuesses = ui.GetMaximalNumberOfGuessesFromUser();
                    gameManager.MaximalNumberOfGuesses = maximalNumberOfGuesses;
                }

                gameManager.GenerateSecretWord();
                for(int i = 0; i < gameManager.MaximalNumberOfGuesses; i++)
                {
                    ui.PrintScreen(gameManager.MaximalNumberOfGuesses);
                    String userGuessInput = ui.GetGuessFromUser();
                    Guess currentGuess = gameManager.ProccesGuessAndGiveFeedback(userGuessInput);
                    if (currentGuess.UserGuess == null)
                    {
                        Console.WriteLine("Try Again!");
                        //IMPLEMENT SOMETHING THAT GIVES USER TO TRY AGAIN BEFORE CLEAN SCREEN
                    }
                    else
                    {
                        ui.AddGuessToGuessesList(currentGuess);
                    }
                }
            }            

        }

    }
}
