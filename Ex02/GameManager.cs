using System;

namespace Ex02
{
    internal class GameManager
    {
        private UserInterface m_UiManager = new UserInterface();
        private GameLogic m_LogicManager = new GameLogic();
        private String m_QuitRequest = "Q";

        public void RunGame()
        {
            bool shouldExit = false;

            while(!shouldExit)
            {
                resetGame();
                askUserForDesiredMaximalNumberOfGuesses();
                shouldExit = playGame();
                if(shouldExit)
                {
                    break;
                }

                if(!m_UiManager.CheckIfUserWantToStartAnotherGame())
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
            String userGuessInput = String.Empty;
            bool isUserWantsToQuit = false;
            bool isVictory = false;

            for(int i = 0; i < m_LogicManager.MaximalNumberOfGuesses; i++)
            {
                m_UiManager.PrintBoard();
                userGuessInput = m_UiManager.GetGuessFromUser();
                if(userGuessInput.ToUpper() == m_QuitRequest)
                {
                    isUserWantsToQuit = true;
                    break;
                }

                Guess currentGuess = m_LogicManager.ProccesGuessAndGiveFeedback(userGuessInput);
                m_UiManager.AddGuessToBoardView(currentGuess);
                if(currentGuess.IsPerfectGuess)
                {
                    m_UiManager.PrintYouWonMessage();
                    isVictory = true;
                    break;
                }
            }

            if(!isUserWantsToQuit && !isVictory)
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
