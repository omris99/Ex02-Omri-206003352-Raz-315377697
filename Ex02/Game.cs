using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Game
    {
        UserInterface m_Ui = new UserInterface();
        GameManager m_GameManager = new GameManager();

        public void RunGame()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                resetGame();
                askUserForDesiredMaximalNumberOfGuesses();
                shouldExit = startNewGame();
                if (shouldExit)
                {
                    break;
                }

                if (!m_Ui.CheckIfUserWantToStartAnotherGame())
                {
                    shouldExit = true;
                }
            }

            m_Ui.PrintGoodByeScreen();
        }

        private void askUserForDesiredMaximalNumberOfGuesses()
        {
            m_GameManager.MaximalNumberOfGuesses = m_Ui.GetMaximalNumberOfGuessesFromUser();
        }

        private bool startNewGame()
        {
            String userGuessInput = "";
            bool isUserWantsToQuit = false;
            bool isVictory = false;

            //m_Ui.CountOfGuessRowsOnBoard = m_GameManager.MaximalNumberOfGuesses;
            //m_Ui.SecretWord = m_GameManager.SecretCode;
            for (int i = 0; i < m_GameManager.MaximalNumberOfGuesses; i++)
            {
                Guess currentGuess = new Guess();
                m_Ui.PrintBoard();
                while (currentGuess.UserGuess == null)
                {
                    userGuessInput = m_Ui.GetGuessFromUser();
                    //if userGuessInput == Q --> return isUserWantsToQuit; // NEW (RAZ)
                    if (userGuessInput.ToUpper() == "Q")
                    {
                        isUserWantsToQuit = true;
                        break;
                    }

                    currentGuess = m_GameManager.ProccesGuessAndGiveFeedback(userGuessInput);
                    if (currentGuess.UserGuess == null)
                    {
                        Console.WriteLine("Try Again!");
                    }
                }
                // NEW (RAZ)
                if (isUserWantsToQuit)
                {
                    break;
                }

                m_Ui.AddGuessToBoardView(currentGuess);

                if (m_GameManager.IsVictory(currentGuess.UserGuess))
                {
                    m_Ui.PrintYouWonMessage();
                    isVictory = true;
                    break;
                }
            }

            //m_Ui.PrintYouLostMessage(); // NEW (RAZ)
            if (!isUserWantsToQuit && !isVictory)
            {
                m_GameManager.RevealSecretWord();
                m_Ui.PrintYouLostMessage();
            }

            return isUserWantsToQuit;
        }

        private void resetGame()
        {
            ConsoleUtils.Screen.Clear();
            m_GameManager.ResetMembers();
            m_Ui.ResetMembers();
            m_Ui.SetSecretWordInUi(m_GameManager.SecretWord);
        }
    }
}
