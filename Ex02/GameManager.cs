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
        private String m_SecretWord = "";
        private readonly int r_SecretWordLength = 4;
        private int m_MaximalNumberOfGuesses = -1;
        private int r_MinimumNumberOfGuessesAllowed = 4;
        private int r_MaximumNumberOfGuessesAllowed = 10;

        public int MaximalNumberOfGuesses
        {
            get
            {
                return m_MaximalNumberOfGuesses;
            }
            set
            {
                if (value >= r_MinimumNumberOfGuessesAllowed && value <= r_MaximumNumberOfGuessesAllowed)
                {
                    m_MaximalNumberOfGuesses = value;
                }
                else
                {
                    Console.WriteLine($"Invalid Input. Please Enter a number in range." +
                        $" ({r_MinimumNumberOfGuessesAllowed}-{r_MaximumNumberOfGuessesAllowed})" +
                        $"{Environment.NewLine}");
                }
            }
        }

        //public bool IsVictory()
        //{
        //    //
        //}

        public void GenerateSecretWord()
        {
            Random random = new Random();
            char currentLetter;
            StringBuilder secretWord = new StringBuilder();

            for(int i = 0; i < r_SecretWordLength; i++)
            {
                currentLetter = (char)random.Next('A', 'H' + 1);
                if(Utillities.CheckIfLetterExistInString(secretWord.ToString(), currentLetter))
                {
                    i--;
                }
                else
                {
                    secretWord.Append(currentLetter);
                }
            }
            m_SecretWord = secretWord.ToString();
        }


        public Guess ProccesGuessAndGiveFeedback(String i_UserInputGuess)
        {
            Guess guess = new Guess();

            if (checkGuessValidation(i_UserInputGuess))
            {
                StringBuilder vString = new StringBuilder();
                StringBuilder xString = new StringBuilder();
                StringBuilder feedBack = new StringBuilder();

                guess.UserGuess = i_UserInputGuess;
                for (int i = 0; i < r_SecretWordLength; i++)
                {
                    if (guess.UserGuess[i] == m_SecretWord[i])
                    {
                        vString.Append('V');
                    }
                    else if (Utillities.CheckIfLetterExistInString(m_SecretWord, guess.UserGuess[i]))
                    {
                        xString.Append('X');
                    }
                }

                feedBack.Append(vString);
                feedBack.Append(xString);
                guess.GuessFeedBack = feedBack.ToString();
            }

            return guess;
        }

        private bool checkGuessValidation(String i_UserGuessInput)
        {
            bool isValid = true;

            if (i_UserGuessInput.Length != r_SecretWordLength)
            {
                isValid = false;
            }
            else
            {
                foreach (char letter in i_UserGuessInput)
                {
                    if (letter < 'A' || letter > 'H')
                    {
                        isValid = false;
                        Console.WriteLine("Invalid!");
                        break;
                    }
                }
            }

            return isValid;
        }

    }
}
