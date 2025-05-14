using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class Game
    {
        private UserInterface m_UiManager = new UserInterface();
        private GameLogic m_LogicManager = new GameLogic();

        public void RunGame()
        {
            bool shouldExit = false;

            while (!shouldExit)
            {
                resetGame();
                askUserForDesiredMaximalNumberOfGuesses();
                shouldExit = playGame();
                if (shouldExit)
                {
                    break;
                }

                if (!m_UiManager.CheckIfUserWantToStartAnotherGame())
                {
                    shouldExit = true;
                }
            }

            m_UiManager.PrintGoodByeScreen();
        }

        private void askUserForDesiredMaximalNumberOfGuesses()
        {
            m_LogicManager.MaximalNumberOfGuesses = m_UiManager.GetMaximalNumberOfGuessesFromUser();
        }

        private bool playGame()
        {
            String userGuessInput = "";
            bool isUserWantsToQuit = false;
            bool isVictory = false;

            for (int i = 0; i < m_LogicManager.MaximalNumberOfGuesses; i++)
            {
                m_UiManager.PrintBoard();
                userGuessInput = m_UiManager.GetGuessFromUser();
                if(userGuessInput.ToUpper() == "Q")
                {
                    isUserWantsToQuit = true;
                    break;
                }

                Guess currentGuess = m_LogicManager.ProccesGuessAndGiveFeedback(userGuessInput);

                m_UiManager.AddGuessToBoardView(currentGuess);

                if(currentGuess.IsPerfectGuess)
                {
                    m_UiManager.PrintBoard();
                    m_UiManager.PrintYouWonMessage();
                    isVictory = true;
                    break;
                }
            }

            if (!isUserWantsToQuit && !isVictory)
            {
                m_LogicManager.RevealSecretWord();
                m_UiManager.PrintYouLostMessage();
            }

            return isUserWantsToQuit;
        }

        private void resetGame()
        {
            ConsoleUtils.Screen.Clear();
            m_LogicManager.ResetMembers();
            m_UiManager.ResetMembers();
            m_UiManager.SetSecretWordInUi(m_LogicManager.SecretWord);
        }
    }
}
