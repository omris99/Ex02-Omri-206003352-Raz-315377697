using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex02;

//TODO:
//1. TO THINK ABOUT ACCESS MODIFIERS OF CLASSES
//2. isVictory in GameManager -- Raz
//3. check if user want to exit -- Raz
//4. UI SHIT (LIKE FORMAT GUESSES TO FIT IN TABLE, OR LOST MESSAGE) -- OMRI
//5. make struct SecretWord with bool m_isHidden, Word {get;set;}, Generate() - nullable
//6. maybe to make class Board? Board.AddGuessToView(), Board.Print()....

namespace Ex02
{
    internal class Program
    {
        UserInterface m_Ui = new UserInterface();
        GameManager m_GameManager = new GameManager();

        public static void Main()
        {
            Program program = new Program();
            program.RunGame();
        }

        private void RunGame()
        {
            while(true)
            {
                resetGame();
                askUserForDesiredMaximalNumberOfGuesses();
                bool quit = startNewGame();
                if(!quit)
                {
                    if(!m_Ui.CheckIfUserWantToStartAnotherGame())
                    {
                        m_Ui.PrintGoodByeScreen();
                        return;
                    }
                }
                m_Ui.PrintGoodByeScreen();
            }            
        }

        private void askUserForDesiredMaximalNumberOfGuesses()
        {
            m_GameManager.MaximalNumberOfGuesses = m_Ui.GetMaximalNumberOfGuessesFromUser();
        }

        private bool startNewGame()
        {
            String userGuessInput = "";
            bool isUserWantsToQuit = false;

            m_Ui.CountOfGuessRowsOnBoard = m_GameManager.MaximalNumberOfGuesses;
            m_Ui.SecretWord = m_GameManager.GenerateSecretWord();
            for (int i = 0; i < m_GameManager.MaximalNumberOfGuesses; i++)
            {
                Guess currentGuess = new Guess();
                m_Ui.PrintBoard();
                while (currentGuess.UserGuess == null)
                {
                    userGuessInput = m_Ui.GetGuessFromUser();
                    //if userGuessInput == Q --> return isUserWantsToQuit;
                    currentGuess = m_GameManager.ProccesGuessAndGiveFeedback(userGuessInput);
                    if (currentGuess.UserGuess == null)
                    {
                        Console.WriteLine("Try Again!");
                    }
                }

                m_Ui.AddGuessToGuessesList(currentGuess);

                //if (m_GameManager.isVictory())
                //{
                //    m_Ui.PrintYouWonMessage();
                //    break;
                //}
            }

            m_Ui.PrintYouLostMessage();

            return isUserWantsToQuit;
        }

        private void resetGame()
        {
            ConsoleUtils.Screen.Clear();
            m_GameManager.ResetMembers();
            m_Ui.ResetMembers();
        }
    }
}

