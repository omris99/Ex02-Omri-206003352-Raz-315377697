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

        public int MaximalNumberOfGuesses { get; set; }

        public bool IsVictory(string i_UserGuess) // NEW (RAZ)
        {
            return i_UserGuess == m_SecretWord;
        }


        public String GenerateSecretWord()
        {
            Random random = new Random();
            char currentLetter;
            StringBuilder secretWord = new StringBuilder();
            Dictionary<char, bool> usedLetters = new Dictionary<char, bool>();

            for(int i = 0; i < r_SecretWordLength; i++)
            {
                currentLetter = (char)random.Next('A', 'H' + 1);
                if(usedLetters.ContainsKey(currentLetter))
                {
                    i--;
                }
                else
                {
                    secretWord.Append(currentLetter);
                    usedLetters.Add(currentLetter, true);
                }
            }
            m_SecretWord = secretWord.ToString();

            return m_SecretWord;
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
            Dictionary<char, bool> lettersExistInUserGuess = new Dictionary<char, bool>();
            bool isValid = true;

            if (i_UserGuessInput.Length != r_SecretWordLength)
            {
                isValid = false;
            }
            else
            {
                foreach (char letter in i_UserGuessInput)
                {
                    if ((letter < 'A' || letter > 'H') || (lettersExistInUserGuess.ContainsKey(letter)))
                    {
                        isValid = false;
                        break;
                    }

                    lettersExistInUserGuess.Add(letter, true);
                }
            }

            return isValid;
        }

        public void ResetMembers()
        {
            MaximalNumberOfGuesses = -1;
        }
    }
}
