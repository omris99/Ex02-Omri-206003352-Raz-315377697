using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex02
{
    internal class GameManager
    {
        public int MaximalNumberOfGuesses { get; set; } //public data member --> check if it legit
        private String m_SecretWord;
        private readonly int r_SecretWordLength = 4;

        public void SetMaximalNumberOfGuesses(int i_MaximalNumberOfGuesses)
        {
            MaximalNumberOfGuesses = i_MaximalNumberOfGuesses;
        }

        //public bool IsVictory()
        //{
        //    //
        //}

        public void GenerateSecretWord()
        {
            Random random = new Random();
            char currentLetter;
            List<char> usedLetters = new List<char>();

            for(int i = 0; i < r_SecretWordLength; i++)
            {
                currentLetter = (char)random.Next('A', 'H' + 1);
                foreach(char c in usedLetters)
                {
                    if(c == currentLetter)
                    {
                        i--;
                        break;
                    }
                }
                m_SecretWord.Append(currentLetter);
                usedLetters.Add(currentLetter);
            }
        }


        public Guess ProccesGuessAndGiveFeedback(String i_UserInputGuess)
        {
            Guess guess = new Guess();

            guess.UserGuess = i_UserInputGuess;
            if(guess.UserGuess != null)
            {
                //Give Feedback to GuessFeedBack;

            }

            return guess;
        }

        private void giveFeedbackToGuess(Guess i_Guess)
        {


        }

    }
}
